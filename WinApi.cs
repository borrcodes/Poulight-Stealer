using System;
using System.Runtime.InteropServices;

internal class WinApi
{
	public const int WS_CHILD = 1073741824;

	public const int WS_POPUP = int.MinValue;

	[DllImport("avicap32.dll")]
	public static extern IntPtr capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int X, int Y, int nWidth, int nHeight, int hwndParent, int nID);

	[DllImport("user32")]
	public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

	[DllImport("Kernel32.dll")]
	public static extern IntPtr GetModuleHandle(string running);
}
