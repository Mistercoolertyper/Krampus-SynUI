using Microsoft.Win32;
using Synapse_UI_WPF;
using System.IO;

class Constants
{
	public static MainWindow mainWindow;
	public static string exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
	public static string currentDir = new FileInfo(exeName).Directory.FullName;

	public static void Register(string key, string name, string handler)
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
}
