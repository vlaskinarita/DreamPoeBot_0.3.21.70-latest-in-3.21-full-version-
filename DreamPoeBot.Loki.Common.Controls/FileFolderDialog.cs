using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DreamPoeBot.Loki.Common.Controls;

public class FileFolderDialog : CommonDialog
{
	private OpenFileDialog openFileDialog_0 = new OpenFileDialog();

	public OpenFileDialog Dialog
	{
		get
		{
			return openFileDialog_0;
		}
		set
		{
			openFileDialog_0 = value;
		}
	}

	public string SelectedPath
	{
		get
		{
			try
			{
				if (openFileDialog_0.FileName != null && (openFileDialog_0.FileName.EndsWith("Folder Selection.") || !File.Exists(openFileDialog_0.FileName)) && !Directory.Exists(openFileDialog_0.FileName))
				{
					return Path.GetDirectoryName(openFileDialog_0.FileName);
				}
				return openFileDialog_0.FileName;
			}
			catch (Exception)
			{
				return openFileDialog_0.FileName;
			}
		}
		set
		{
			if (value != null && value != "")
			{
				openFileDialog_0.FileName = value;
			}
		}
	}

	public string SelectedPaths
	{
		get
		{
			if (openFileDialog_0.FileNames != null && openFileDialog_0.FileNames.Length > 1)
			{
				StringBuilder stringBuilder = new StringBuilder();
				string[] fileNames = openFileDialog_0.FileNames;
				foreach (string text in fileNames)
				{
					try
					{
						if (File.Exists(text))
						{
							stringBuilder.Append(text + ";");
						}
					}
					catch (Exception)
					{
					}
				}
				return stringBuilder.ToString();
			}
			return null;
		}
	}

	public new DialogResult ShowDialog()
	{
		return ShowDialog(null);
	}

	public new DialogResult ShowDialog(IWin32Window owner)
	{
		openFileDialog_0.ValidateNames = false;
		openFileDialog_0.CheckFileExists = false;
		openFileDialog_0.CheckPathExists = true;
		try
		{
			if (!string.IsNullOrEmpty(openFileDialog_0.FileName))
			{
				if (Directory.Exists(openFileDialog_0.FileName))
				{
					openFileDialog_0.InitialDirectory = openFileDialog_0.FileName;
				}
				else
				{
					openFileDialog_0.InitialDirectory = Path.GetDirectoryName(openFileDialog_0.FileName);
				}
			}
		}
		catch (Exception)
		{
		}
		openFileDialog_0.FileName = "Folder Selection.";
		if (owner == null)
		{
			return openFileDialog_0.ShowDialog();
		}
		return openFileDialog_0.ShowDialog(owner);
	}

	public override void Reset()
	{
		openFileDialog_0.Reset();
	}

	protected override bool RunDialog(IntPtr hwndOwner)
	{
		return true;
	}
}
