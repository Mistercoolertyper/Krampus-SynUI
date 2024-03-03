using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using Synapse_UI_WPF.Interfaces;
using Synapse_UI_WPF.Static;

namespace Synapse_UI_WPF
{
	public partial class OptionsWindow
	{
		private readonly MainWindow Main;

		public OptionsWindow(MainWindow _Main)
		{
			WindowStartupLocation = WindowStartupLocation.CenterScreen;

			InitializeComponent();

			Main = _Main;
			Main.OptionsOpen = true;
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
			AutoAttachBox.IsChecked = Globals.Options.AutoAttach;
			AutoLaunchBox.IsChecked = Globals.Options.AutoLaunch;
			TopmostBox.IsChecked = Globals.Options.Topmost;
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Globals.Options = new Data.Options
			{
				AutoAttach = AutoAttachBox.IsChecked.Value,
				AutoLaunch = AutoLaunchBox.IsChecked.Value,
				Topmost = TopmostBox.IsChecked.Value
			};
			DataInterface.Save("options", new Data.OptionsHolder
			{
				Version = Data.OptionsVersion,
				Data = JsonConvert.SerializeObject(Globals.Options)
			});

			if (Main.Ready())
			{
				MessageBox.Show("Some options may not apply until you reinject Synapse.", "Synapse X",
					MessageBoxButton.OK, MessageBoxImage.Warning);
			}

			Main.OptionsOpen = false;
			Close();
		}

		private void AutoAttachBox_Click(object sender, RoutedEventArgs e)
		{
			if (AutoAttachBox.IsChecked.Value)
			{
				new Thread(() => Constants.mainWindow.StartAutoAttachLoop()).Start();
			}
		}

		private static bool CheckRegistryKey()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Classes\roblox-player\shell\open\command");
			return key.GetValue("") as string == $"\"{Constants.exeName}\" %1";
		}

		private static bool runningAutoLaunchLoop = false;

		public static void StartAutoLaunchLoop()
		{
			if (runningAutoLaunchLoop) return;
			runningAutoLaunchLoop = true;
			while (Globals.Options.AutoLaunch)
			{
				if (!CheckRegistryKey())
				{
					Constants.Register("roblox-player", "Roblox", Constants.exeName);
				}
				Thread.Sleep(5000);
			}
			runningAutoLaunchLoop = false;
		}

		private void AutoLaunchBox_Click(object sender, RoutedEventArgs e)
		{
			if (AutoLaunchBox.IsChecked.Value)
			{
				Constants.Register("roblox-player", "Roblox", Constants.exeName);
				new Thread(() => StartAutoLaunchLoop()).Start();
			} else
			{
				Constants.Register("roblox-player", "Roblox", File.ReadAllText($"{Constants.currentDir}\\oldRegistryKey.txt").Split('"')[1]);
			}
		}

		private void TopmostBox_Click(object sender, RoutedEventArgs e)
		{
			Main.Topmost = TopmostBox.IsChecked.Value;
		}
	}
}
