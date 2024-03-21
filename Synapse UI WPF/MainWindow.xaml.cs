#define USE_UPDATE_CHECKS

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CefSharp;
using CefSharp.Wpf;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Synapse_UI_WPF.Controls;
using Synapse_UI_WPF.Interfaces;
using Synapse_UI_WPF.Static;
using WebSocketSharp;
using static Synapse_UI_WPF.Interfaces.ThemeInterface;
using Process = System.Diagnostics.Process;

namespace Synapse_UI_WPF
{
	public partial class MainWindow
	{

		public delegate void InteractMessageEventHandler(object sender, string Input);
		public event InteractMessageEventHandler InteractMessageRecieved;

		public bool ConnectedToKrampus = false;

		public bool OptionsOpen;

		public bool ScriptHubOpen;
		private bool ScriptHubInit;
		public bool IsInlineUpdating;

		private readonly string BaseDirectory;
		private readonly string ScriptsDirectory;

		public static BackgroundWorker Worker = new BackgroundWorker();
		public static BackgroundWorker HubWorker = new BackgroundWorker();

		private WebSocket ws;

		public MainWindow()
		{
			Cef.EnableHighDPISupport();
			var settings = new CefSettings();
			settings.SetOffScreenRenderingBestPerformanceArgs();
			Cef.Initialize(settings);

			InitializeComponent();

			HubWorker.DoWork += HubWorker_DoWork;

			var TMain = Globals.Theme.Main;
			ThemeInterface.ApplyWindow(this, TMain.Base);
			ThemeInterface.ApplyLogo(IconBox, TMain.Logo);
			ThemeInterface.ApplySeperator(TopBox, TMain.TopBox);
			ThemeInterface.ApplyFormatLabel(TitleBox, TMain.TitleBox, Globals.Version);
			ThemeInterface.ApplyListBox(ScriptBox, TMain.ScriptBox);
			ThemeInterface.ApplyButton(MiniButton, TMain.MinimizeButton);
			ThemeInterface.ApplyButton(CloseButton, TMain.ExitButton);
			ThemeInterface.ApplyButton(ExecuteButton, TMain.ExecuteButton);
			ThemeInterface.ApplyButton(ClearButton, TMain.ClearButton);
			ThemeInterface.ApplyButton(OpenFileButton, TMain.OpenFileButton);
			ThemeInterface.ApplyButton(ExecuteFileButton, TMain.ExecuteFileButton);
			ThemeInterface.ApplyButton(SaveFileButton, TMain.SaveFileButton);
			ThemeInterface.ApplyButton(OptionsButton, TMain.OptionsButton);
			ThemeInterface.ApplyButton(AttachButton, TMain.AttachButton);
			ThemeInterface.ApplyButton(ScriptHubButton, TMain.ScriptHubButton);

			ScaleTransform.ScaleX = 1D;
			ScaleTransform.ScaleY = 1D;

			BaseDirectory = Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName;

			var text = File.ReadAllText($"{Constants.currentDir}\\launch.cfg");
			ws = new WebSocket("wss://loader.live/?login_token=\"" + text + "\"");

			ws.OnClose += (obj, args) =>
			{
				Thread.Sleep(1000);
				ws.Connect();
			};

			ws.Connect();

			ScriptsDirectory = Path.Combine(BaseDirectory, "scripts");
			if (!Directory.Exists((ScriptsDirectory))) Directory.CreateDirectory(ScriptsDirectory);

			foreach (var FilePath in Directory.GetFiles(ScriptsDirectory))
			{
				ScriptBox.Items.Add(Path.GetFileName(FilePath));
			}

			foreach (var FilePath in Directory.GetFiles("bin/tabs/"))
			{
				Console.WriteLine(Path.GetFileName(FilePath));
				CreateTab(Path.GetFileName(FilePath).Split(".".ToCharArray())[0]);
			}

			if (Globals.Options.AutoAttach)
			{
				new Thread(() => StartAutoAttachLoop()).Start();
			}
			if (Globals.Options.AutoLaunch)
			{
				new Thread(() => OptionsWindow.StartAutoLaunchLoop()).Start();
			}
			Topmost = Globals.Options.Topmost;
		}

		private bool loopRunning = false;

		private void WaitForRobloxWindow(Process robloxProcess)
		{
			while (robloxProcess.MainWindowTitle == "")
			{
				robloxProcess.Refresh();
				Thread.Sleep(1000);
			}
		}

		public void StartAutoAttachLoop()
		{
			if (loopRunning) return;
			loopRunning = true;
			while (Globals.Options.AutoAttach)
			{
				Process robloxProcess;
				if ((robloxProcess = CheckForRoblox()) != null && !(GetProcId() == lastProcId) && !injecting)
				{
					WaitForRobloxWindow(robloxProcess);
					Thread.Sleep(5000); //Krampus injection is so fast now that starting when the roblox window is shown is too early and will crash ur game.
					Dispatcher.Invoke(Inject);
				}
				Thread.Sleep(2000);
			}
			loopRunning = false;
		}

		public void SetTitle(string Str, int Delay = 0)
		{
			Dispatcher.Invoke(() =>
			{
				TitleBox.Content = ConvertFormatString(Globals.Theme.Main.TitleBox, Str);
			});

			if (Delay != 0)
			{
				new Thread(() =>
				{
					Thread.Sleep(Delay);
					Dispatcher.Invoke(() =>
					{
						TitleBox.Content = ConvertFormatString(Globals.Theme.Main.TitleBox, Globals.Version);
					});
				}).Start();
			}
		}

		public bool Ready()
		{
			return true;
		}

		public void Execute(string data)
		{
			if (data.Length == 0) return;
			Dispatcher.Invoke(() =>
			{
				try
				{
					ws.Send("<SCRIPT>" + data);
				} catch {
					MessageBox.Show("Unable to execute!", "Synapse X", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			});
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Title = WebInterface.RandomString(WebInterface.Rnd.Next(10, 32));
		}

		private void Browser_MonacoReady()
		{
			Browser.SetTheme(Globals.Theme.Main.Editor.Light ? MonacoTheme.Light : MonacoTheme.Dark);
			if (!File.Exists($"{Constants.currentDir}/bin/tabs/{Globals.CurrentTab}.txt")) File.WriteAllText($"{Constants.currentDir}/bin/tabs/{Globals.CurrentTab}.txt", "");
			Browser.SetText(File.ReadAllText($"{Constants.currentDir}/bin/tabs/{Globals.CurrentTab}.txt"));
		}

		public void Attach()
		{
			if (Worker.IsBusy || IsInlineUpdating) return;

			//Worker.RunWorkerAsync();
		}

		public void SetEditor(string Text)
		{
			if (!File.Exists($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt")) File.WriteAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt", "");
			File.WriteAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt", Text);
			Browser.SetText(Text);
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			if (!File.Exists($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt")) File.WriteAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt", "");
			File.WriteAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt", Browser.GetText());
			Environment.Exit(0);
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			Environment.Exit(0);
		}

		private void OptionsButton_Click(object sender, RoutedEventArgs e)
		{
			if (OptionsOpen) return;

			var Options = new OptionsWindow(this);
			Options.Show();
		}

		private void MiniButton_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			SetEditor("");
		}

		private void IconBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show(
				"Synapse X was developed by 3dsboy08, brack4712, Louka, DefCon42, and Eternal.\r\n\r\nAdditional credits:\r\n    - Rain: Emotional support and testing",
				"Synapse X Credits", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		public void OpenFileButton_Click(object sender, RoutedEventArgs e)
		{
			var OpenDialog = new OpenFileDialog
			{
				Filter = "Script Files (*.lua, *.txt)|*.lua;*.txt", Title = "Synapse X - Open File", FileName = ""
			};

			if (OpenDialog.ShowDialog() != true) return;

			try
			{
				Console.WriteLine(OpenDialog.FileName);
				SetEditor(File.ReadAllText(OpenDialog.FileName));
			}
			catch (Exception ex) { Console.WriteLine(ex); }
		}

		private void ExecuteFileButton_Click(object sender, RoutedEventArgs e)
		{
			var OpenDialog = new OpenFileDialog
			{
				Filter = "Script Files (*.lua, *.txt)|*.lua;*.txt", Title = "Synapse X - Execute File", FileName = ""
			};

			if (OpenDialog.ShowDialog() != true) return;

			try
			{
				Execute(File.ReadAllText(OpenDialog.FileName));
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to read file. Check if it is accessible.", "Synapse X", MessageBoxButton.OK,
					MessageBoxImage.Warning);
			}
		}

		private void SaveFileButton_Click(object sender, RoutedEventArgs e)
		{
			var SaveDialog = new SaveFileDialog { Filter = "Script Files (*.lua, *.txt)|*.lua;*.txt", FileName = "" };

			SaveDialog.FileOk += (o, args) =>
			{
				File.WriteAllText(SaveDialog.FileName, Browser.GetText());
			};

			SaveDialog.ShowDialog();
		}

		private bool injecting = false;

		private int lastProcId = 0;

		private Process CheckForRoblox()
		{
			Process[] processes = Process.GetProcesses();
			foreach(var process in processes)
			{
				if (process.ProcessName == "RobloxPlayerBeta")
				{
					return process;
				}
			}
			return null;
		}

		private int GetProcId()
		{
			Process[] processes = Process.GetProcesses();
			foreach (var process in processes)
			{
				if (process.ProcessName == "RobloxPlayerBeta")
				{
					return process.Id;
				}
			}
			return 0;
		}

		public void Inject()
		{
			if (injecting) return;
			if (CheckForRoblox() == null)
			{
				SetTitle("v1.0.0 (failed to find roblox!)", 5000);
				return;
			}
			var procId = GetProcId();
			if (procId == 0 || procId == lastProcId)
			{
				SetTitle("v1.0.0 (already injected!)", 5000);
				return;
			}
			lastProcId = procId;
			injecting = true;
			if (!File.Exists($"{Constants.currentDir}\\krampusPath.cfg"))
			{
				File.WriteAllText($"{Constants.currentDir}\\krampusPath.cfg", "");
			}
			string krampus = File.ReadAllText($"{Constants.currentDir}\\krampusPath.cfg");
			if (!File.Exists(krampus))
			{
				var dialog = new OpenFileDialog
				{
					Filter = "Executable Files (.exe)|*.exe",
					Title = "Select Krampus EXE"
				};
				bool result = dialog.ShowDialog().Value;
				if (result)
				{
					krampus = dialog.FileName;
				} else
				{
					return;
				}
				File.WriteAllText($"{Constants.currentDir}\\krampusPath.cfg", dialog.FileName);
			}
			var process = new Process()
			{
				StartInfo = new ProcessStartInfo()
				{
					FileName = krampus,
					RedirectStandardError = true,
					RedirectStandardInput = true,
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					WorkingDirectory = new FileInfo(krampus).DirectoryName
				}
			};

			process.OutputDataReceived += (obj, data) =>
			{
				if (data.Data != null && data.Data.StartsWith("Success!"))
				{
					SetTitle("v1.0.0 (ready!)", 5000);
				}
			};
			process.EnableRaisingEvents = true;

			process.Start();
			process.BeginOutputReadLine();
			SetTitle("v1.0.0 (injecting...)");
			new Thread(() =>
			{
				process.WaitForExit();
				process.Close();
				injecting = false;
			}).Start();
		}

		private void AttachButton_Click(object sender, RoutedEventArgs e)
		{
			Inject();
		}

		private void ScriptHubButton_Click(object sender, RoutedEventArgs e)
		{
			if (ScriptHubOpen)
			{
				if (oldWindow != null && oldWindow.WindowState == WindowState.Minimized)
				{
					oldWindow.WindowState = WindowState.Normal;
				}
				return;
			}
			if (ScriptHubInit) return;

			ScriptHubOpen = true;
			ScriptHubInit = true;

			ScriptHubButton.Content = Globals.Theme.Main.ScriptHubButton.TextYield;
			HubWorker.RunWorkerAsync();
		}

		private ScriptHubWindow oldWindow;

		private void HubWorker_DoWork(object sender, DoWorkEventArgs e)
		{

			Dispatcher.Invoke(() =>
			{
				ScriptHubInit = false;
				ScriptHubButton.Content = Globals.Theme.Main.ScriptHubButton.TextNormal;

				var ScriptHub = new ScriptHubWindow(this);
				oldWindow = ScriptHub;
				ScriptHub.Show();
			});
		}

		private void ExecuteButton_Click(object sender, RoutedEventArgs e)
		{
			if (!File.Exists($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt")) File.WriteAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt", "");
			File.WriteAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt", Browser.GetText());
			Task.Run(() => Execute(Browser.GetText()));
		}

		private void ExecuteItem_Click(object sender, RoutedEventArgs e)
		{
			if (ScriptBox.SelectedIndex == -1) return;

			try
			{
				var Element = ScriptBox.Items[ScriptBox.SelectedIndex].ToString();

				Execute(File.ReadAllText(Path.Combine(ScriptsDirectory, Element)));
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to read file. Check if it is accessible.", "Synapse X", MessageBoxButton.OK,
					MessageBoxImage.Warning);
			}
		}

		private void LoadItem_Click(object sender, RoutedEventArgs e)
		{
			if (ScriptBox.SelectedIndex == -1) return;

			try
			{
				var Element = ScriptBox.Items[ScriptBox.SelectedIndex].ToString();

				SetEditor(File.ReadAllText(Path.Combine(ScriptsDirectory, Element)));
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to read file. Check if it is accessible.", "Synapse X", MessageBoxButton.OK,
					MessageBoxImage.Warning);
			}
		}

		private void RefreshItem_Click(object sender, RoutedEventArgs e)
		{
			ScriptBox.Items.Clear();

			foreach (var FilePath in Directory.GetFiles(ScriptsDirectory))
			{
				ScriptBox.Items.Add(Path.GetFileName(FilePath));
			}
		}

		private void ClearTab_Click(object sender, RoutedEventArgs e)
		{
			if (TabSystem.SelectedIndex == -1) return;

			try
			{
				Console.WriteLine(CurrentTab());
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to clear tab.", "Synapse X", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}


		private object CurrentTab()
		{
			var Tab = TabSystem.SelectedItem as ClosableTab;
			if (Tab == null)
			{
				var Tab1 = TabSystem.SelectedItem as TabItem;
				return Tab1.Header;
			}
			return Tab.Title;
		}

		private void CreateTab(string Name)
		{
			var NewTab = new ClosableTab
			{
				Title = Name
			};
			var Converter = new BrushConverter();
			NewTab.Background = (Brush)Converter.ConvertFromString("#696969");
			NewTab.Foreground = (Brush)Converter.ConvertFromString("#909090");
			NewTab.BorderBrush = (Brush)Converter.ConvertFromString("#545454");
			TabSystem.Items.Insert(TabSystem.Items.Count - 1, NewTab);
			Dispatcher.BeginInvoke(new Action(() => TabSystem.SelectedItem = NewTab));
		}

		private object lastTab = null;

		private string TabName(int last = 1)
		{
			string name = "Tab " + last;
			foreach(var tab in TabSystem.Items)
			{
				if (tab is ClosableTab)
				{
					var tab1 = tab as ClosableTab;
					if (tab1.Title == name)
					{
						return TabName(last + 1);
					}
				}
			}
			return name;
		}

		private void TabSystem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Globals.CurrentTab = CurrentTab();
			if (e.AddedItems.Contains(AddTabButton))
			{
				CreateTab(TabName());
			}
			else
			{
				if (lastTab != null)
				{
					File.WriteAllText($"{Constants.currentDir}/bin/tabs/{lastTab}.txt", Browser.GetText());
				}
				if (!File.Exists($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt")) File.WriteAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt", "");
				SetEditor(File.ReadAllText($"{Constants.currentDir}/bin/tabs/{CurrentTab()}.txt"));
				lastTab = CurrentTab();
			}
			e.Handled = true;
		}
	}
}
