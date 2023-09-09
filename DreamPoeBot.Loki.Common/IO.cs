using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki.Common;

public static class IO
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private const int BYTES_TO_READ = 8;

	public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool deleteFile = false)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (!directoryInfo.Exists)
		{
			ilog_0.ErrorFormat("[DirectoryCopy] Source directory does not exist or could not be found: " + sourceDirName, Array.Empty<object>());
			MessageBox.Show("[DirectoryCopy] Source directory does not exist or could not be found: " + sourceDirName, "Source directory does not exist or could not be found", MessageBoxButton.OK, MessageBoxImage.Hand);
			return;
		}
		if (!Directory.Exists(destDirName))
		{
			Directory.CreateDirectory(destDirName);
		}
		DirectoryInfo directoryInfo2 = new DirectoryInfo(destDirName);
		FileInfo[] files = directoryInfo2.GetFiles();
		FileInfo[] files2 = directoryInfo.GetFiles();
		FileInfo[] array = files2;
		foreach (FileInfo file in array)
		{
			string text = Path.Combine(destDirName, file.Name);
			if (files.Any((FileInfo x) => x.Name == file.Name))
			{
				FileInfo fileInfo = files.FirstOrDefault((FileInfo x) => x.Name == file.Name);
				if (fileInfo != null && !FilesAreEqual(file, fileInfo))
				{
					try
					{
						file.CopyTo(text, overwrite: true);
					}
					catch (Exception ex)
					{
						ilog_0.ErrorFormat(ex.ToString(), Array.Empty<object>());
						ilog_0.ErrorFormat("Source: " + file.FullName, Array.Empty<object>());
						ilog_0.ErrorFormat("Destination: " + text, Array.Empty<object>());
						ilog_0.ErrorFormat("Rebooting the vm b/c files are inacessible.", Array.Empty<object>());
						Terminate();
					}
				}
			}
			else
			{
				try
				{
					file.CopyTo(text, overwrite: true);
				}
				catch (Exception ex2)
				{
					ilog_0.ErrorFormat(ex2.ToString(), Array.Empty<object>());
					ilog_0.ErrorFormat("Source: " + file.FullName, Array.Empty<object>());
					ilog_0.ErrorFormat("Destination: " + text, Array.Empty<object>());
					ilog_0.ErrorFormat("Rebooting the vm b/c files are inacessible.", Array.Empty<object>());
					Terminate();
				}
			}
		}
		if (copySubDirs)
		{
			DirectoryInfo[] array2 = directories;
			foreach (DirectoryInfo directoryInfo3 in array2)
			{
				string destDirName2 = Path.Combine(destDirName, directoryInfo3.Name);
				DirectoryCopy(directoryInfo3.FullName, destDirName2, copySubDirs);
			}
		}
	}

	private static bool FilesAreEqual(FileInfo first, FileInfo second)
	{
		if (first.Length != second.Length)
		{
			return false;
		}
		if (!(first.CreationTime != second.CreationTime))
		{
			if (first.LastWriteTime != second.LastWriteTime)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static void Terminate()
	{
		try
		{
			Process.GetProcessesByName("Relogger").FirstOrDefault()?.Kill();
			int num = 60;
			ilog_0.ErrorFormat($"Restart pc in {60} seconds", Array.Empty<object>());
			Process.Start("shutdown", "/r /t " + num);
			LokiPoe.Memory.Process.Kill();
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat(ex.Message ?? "", Array.Empty<object>());
		}
	}
}
