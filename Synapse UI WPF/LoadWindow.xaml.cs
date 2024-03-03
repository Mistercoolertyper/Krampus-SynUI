#define USE_UPDATE_CHECKS
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;
using Synapse_UI_WPF.Interfaces;
using Synapse_UI_WPF.Static;

namespace Synapse_UI_WPF
{
	public partial class LoadWindow
	{
		public const string UiVersion = "14";
		public const uint TVersion = 2;

		public static ThemeInterface.TInitStrings InitStrings;
		public static BackgroundWorker LoadWorker = new BackgroundWorker();

		public LoadWindow()
		{
			string[] programArgs = Environment.GetCommandLineArgs();
			Process currentProcess = Process.GetCurrentProcess();
			var runningProcess = (from process in Process.GetProcesses() where process.Id != currentProcess.Id && process.ProcessName.Equals(currentProcess.ProcessName, StringComparison.Ordinal) select process).FirstOrDefault();
			if (runningProcess != null)
			{
				if (programArgs.Length > 1 && programArgs[1] == "--killLast")
				{
					runningProcess.Kill();
				} else
				{
					if (programArgs.Length > 1)
					{
						string res = File.ReadAllText($"{Constants.currentDir}\\oldRegistryKey.txt").Split('"')[1];
						var robloxProcess = new Process()
						{
							StartInfo = new ProcessStartInfo(res)
							{
								UseShellExecute = true,
								WorkingDirectory = "C:\\Windows\\system32",
								Arguments = programArgs[1]
							}
						};
						robloxProcess.Start();
					}
					Environment.Exit(0);
				}
			}

			AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
			{
				var Result = MessageBox.Show(
					$"Synapse has encountered an exception. Please report the following text below to decerzz on Discord (make sure to give the text, not an image):\n\n{((Exception)args.ExceptionObject)}\n\nIf you would like this text copied to your clipboard, press \'Yes\'.",
					"Synapse X",
					MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No);

				if (Result != MessageBoxResult.Yes) return;

				var STAThread = new Thread(
					delegate ()
					{
						Clipboard.SetText(((Exception)args.ExceptionObject).ToString());
					});

				STAThread.SetApartmentState(ApartmentState.STA);
				STAThread.Start();
				STAThread.Join();

				Thread.Sleep(1000);
			};

			if (!File.Exists($"{Constants.currentDir}\\oldRegistryKey.txt"))
			{
				var key = Registry.CurrentUser.OpenSubKey(@"Software\Classes\roblox-player\shell\open\command");
				File.WriteAllText($"{Constants.currentDir}\\oldRegistryKey.txt", key.GetValue("") as string);
			}

			if (programArgs.Length > 1 && programArgs[1] != "--killLast")
			{
				string res = File.ReadAllText($"{Constants.currentDir}\\oldRegistryKey.txt").Split('"')[1];
				var robloxProcess = new Process()
				{
					StartInfo = new ProcessStartInfo(res)
					{
						UseShellExecute = true,
						WorkingDirectory = "C:\\Windows\\system32",
						Arguments = programArgs[1]
					}
				};
				robloxProcess.Start();
				var process = new Process()
				{
					StartInfo = new ProcessStartInfo(Constants.exeName)
					{
						UseShellExecute = true,
						WorkingDirectory = Constants.currentDir,
						Arguments = "--killLast"
					}
				};
				process.Start();
			}

			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			LoadWorker.DoWork += LoadWorker_DoWork;

			InitializeComponent();
		}

		private void Register(string key, string name, string handler)
		{
			string handlerArgs = $"\"{handler}\" %1";

			RegistryKey uriKey = Registry.CurrentUser.CreateSubKey($@"Software\Classes\{key}");
			RegistryKey uriIconKey = uriKey.CreateSubKey("DefaultIcon");
			RegistryKey uriCommandKey = uriKey.CreateSubKey(@"shell\open\command");

			if (uriKey.GetValue("") is null)
			{
				uriKey.SetValue("", $"URL: {name} Protocol");
				uriKey.SetValue("URL Protocol", "");
			}

			if (uriCommandKey.GetValue("") as string != handlerArgs)
			{
				uriIconKey.SetValue("", handler);
				uriCommandKey.SetValue("", handlerArgs);
			}
		}

		public void SetStatusText(string Status, int Percentage)
		{
			Dispatcher.Invoke(() =>
			{
				StatusBox.Content = Status;
				ProgressBox.Value = Percentage;
			});
		}

		private ThemeInterface.TBase MigrateT1ToT2(ThemeInterface.TBase Old)
		{
			Old.Version = 2;

			Old.Main.ExecuteFileButton = new ThemeInterface.TButton
			{
				BackColor = new ThemeInterface.TColor(255, 60, 60, 60),
				TextColor = new ThemeInterface.TColor(255, 255, 255, 255),
				Font = new ThemeInterface.TFont("Segoe UI", 14f),
				Image = new ThemeInterface.TImage(),
				Text = "Execute File"
			};

			return Old;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

			if (!File.Exists($"{Constants.currentDir}\\bin\\theme-wpf.json"))
			{
				File.WriteAllText($"{Constants.currentDir}\\bin\\theme-wpf.json",
					JsonConvert.SerializeObject(ThemeInterface.Default(), Formatting.Indented));
			}

			try
			{
				Globals.Theme =
					JsonConvert.DeserializeObject<ThemeInterface.TBase>(File.ReadAllText($"{Constants.currentDir}\\bin\\theme-wpf.json"));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Failed to parse theme.json file.\n\nException details:\n" + ex.Message,
					"Synapse X Theme Parser", MessageBoxButton.OK, MessageBoxImage.Error);
				Globals.Theme = ThemeInterface.Default();
			}

			if (Globals.Theme.Version != TVersion)
			{
				if (Globals.Theme.Version == 1)
				{
					Globals.Theme = MigrateT1ToT2(Globals.Theme);
				}

				File.WriteAllText($"{Constants.currentDir}\\bin\\theme-wpf.json", JsonConvert.SerializeObject(Globals.Theme, Formatting.Indented));
			}

			if (!DataInterface.Exists("options"))
			{
				Globals.Options = new Data.Options
				{
					AutoAttach = false,
					AutoLaunch = false,
					Topmost = false
				};
				DataInterface.Save("options", new Data.OptionsHolder
				{
					Version = Data.OptionsVersion,
					Data = JsonConvert.SerializeObject(Globals.Options)
				});
			}
			else
			{
				try
				{
					var Read = DataInterface.Read<Data.OptionsHolder>("options");
					if (Read.Version != Data.OptionsVersion)
					{
						Globals.Options = new Data.Options
						{
							AutoAttach = false,
							AutoLaunch = false,
							Topmost = false
						};
						DataInterface.Save("options", new Data.OptionsHolder
						{
							Version = Data.OptionsVersion,
							Data = JsonConvert.SerializeObject(Globals.Options)
						});
					}
					else
					{
						Globals.Options = JsonConvert.DeserializeObject<Data.Options>(Read.Data);
					}
				}
				catch (Exception)
				{
					Globals.Options = new Data.Options
					{
						AutoAttach = false,
						AutoLaunch = false,
						Topmost = false
					};
					DataInterface.Save("options", new Data.OptionsHolder
					{
						Version = Data.OptionsVersion,
						Data = JsonConvert.SerializeObject(Globals.Options)
					});
				}
			}

			var TLoad = Globals.Theme.Load;
			ThemeInterface.ApplyWindow(this, TLoad.Base);
			ThemeInterface.ApplyLogo(IconBox, TLoad.Logo);
			ThemeInterface.ApplyLabel(TitleBox, TLoad.TitleBox);
			ThemeInterface.ApplyLabel(StatusBox, TLoad.StatusBox);
			ThemeInterface.ApplySeperator(TopBox, TLoad.TopBox);
			InitStrings = TLoad.BaseStrings;

			Title = WebInterface.RandomString(WebInterface.Rnd.Next(10, 32));
			Globals.Context = SynchronizationContext.Current;

			LoadWorker.RunWorkerAsync();
		}
		
		private void LoadWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			Dispatcher.Invoke(() =>
			{
				SetStatusText("Success", 100);
				if (!File.Exists($"{Constants.currentDir}\\launch.cfg"))
				{
					var login = new LoginWindow();
					login.Show();
				} else
				{
					var main = new MainWindow();
					Constants.mainWindow = main;
					main.Show();
				}
				Close();
			});
		}
	}
}
