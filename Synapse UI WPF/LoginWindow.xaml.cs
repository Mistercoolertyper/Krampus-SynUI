using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Synapse_UI_WPF.Interfaces;

namespace Synapse_UI_WPF
{
	public partial class LoginWindow
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Title = WebInterface.RandomString(WebInterface.Rnd.Next(10, 32));
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
			Environment.Exit(0);
		}

		private void Window_Closing(object sender, CancelEventArgs e)
		{
			Environment.Exit(0);
		}

		private void MiniButton_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
			{
				DragMove();
			}
		}

		private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Login to https://loader.live go to dashboard and copy LOGIN TOKEN", "Synapse X", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			File.WriteAllText($"{Constants.currentDir}\\launch.cfg", PasswordBox.Password);
			var main = new MainWindow();
			Visibility = Visibility.Hidden;
			Constants.mainWindow = main;
			main.Show();
		}
	}
}
