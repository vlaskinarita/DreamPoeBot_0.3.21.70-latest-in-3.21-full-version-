using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DreamPoeBot.WPFLocalizeExtension.TypeConverters;

internal class BitmapSourceTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		if (sourceType != null)
		{
			return sourceType.Equals(typeof(Bitmap));
		}
		return false;
	}

	public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
	{
		if (destinationType != null)
		{
			return destinationType.Equals(typeof(Bitmap));
		}
		return false;
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (!(value is Bitmap bitmap))
		{
			return null;
		}
		IntPtr hbitmap = bitmap.GetHbitmap();
		BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
		bitmapSource.Freeze();
		DeleteObject(hbitmap);
		return bitmapSource;
	}

	[DllImport("gdi32.dll")]
	private static extern int DeleteObject(IntPtr intptr_0);

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		BitmapSource bitmapSource = value as BitmapSource;
		if (value == null)
		{
			return null;
		}
		Bitmap bitmap = new Bitmap(bitmapSource.PixelWidth, bitmapSource.PixelHeight, PixelFormat.Format32bppPArgb);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(System.Drawing.Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
		bitmapSource.CopyPixels(Int32Rect.Empty, bitmapData.Scan0, bitmapData.Height * bitmapData.Stride, bitmapData.Stride);
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}
}
