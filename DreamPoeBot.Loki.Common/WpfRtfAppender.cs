using System;
using System.Collections.Concurrent;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using log4net.Appender;
using log4net.Core;

namespace DreamPoeBot.Loki.Common;

public class WpfRtfAppender : AppenderSkeleton
{
	private delegate void Delegate2(LoggingEvent loggingEvent);

	private readonly RichTextBox richTextBox_0;

	private readonly ScrollViewer scrollViewer_0;

	private int int_0;

	private DispatcherTimer dispatcherTimer_0;

	private Paragraph paragraph_0;

	private readonly ConcurrentQueue<LoggingEvent> concurrentQueue_0 = new ConcurrentQueue<LoggingEvent>();

	public SolidColorBrush InfoBrush { get; set; }

	public SolidColorBrush DebugBrush { get; set; }

	public SolidColorBrush ErrorBrush { get; set; }

	public SolidColorBrush WarnBrush { get; set; }

	public WpfRtfAppender(ScrollViewer scrollViewer, RichTextBox rtb)
	{
		scrollViewer_0 = scrollViewer;
		richTextBox_0 = rtb;
		InfoBrush = Brushes.White;
		DebugBrush = Brushes.Orange;
		ErrorBrush = Brushes.Red;
		WarnBrush = Brushes.Yellow;
		InfoBrush.Freeze();
		DebugBrush.Freeze();
		ErrorBrush.Freeze();
		WarnBrush.Freeze();
		dispatcherTimer_0 = new DispatcherTimer(TimeSpan.FromMilliseconds(100.0), DispatcherPriority.Normal, method_0, rtb.Dispatcher);
		dispatcherTimer_0.Start();
	}

	private void method_0(object sender, EventArgs e)
	{
		try
		{
			dispatcherTimer_0.Stop();
			SolidColorBrush solidColorBrush = InfoBrush;
			StringBuilder stringBuilder = new StringBuilder();
			Action<StringBuilder, SolidColorBrush> action = method_1;
			if (paragraph_0 == null)
			{
				richTextBox_0.Document.Blocks.Clear();
				paragraph_0 = new Paragraph();
				paragraph_0.Margin = new Thickness(0.0);
				richTextBox_0.Document.Blocks.Add(paragraph_0);
			}
			if (int_0 >= 2000)
			{
				paragraph_0.Inlines.Clear();
				int_0 = 0;
			}
			LoggingEvent result;
			while (concurrentQueue_0.TryDequeue(out result))
			{
				result.Fix = (FixFlags)268435455;
				string value = ((AppenderSkeleton)this).RenderLoggingEvent(result);
				SolidColorBrush solidColorBrush2 = result.Level.Name switch
				{
					"WARN" => WarnBrush, 
					"ERROR" => ErrorBrush, 
					"DEBUG" => DebugBrush, 
					_ => InfoBrush, 
				};
				if (!object.Equals(solidColorBrush2, solidColorBrush))
				{
					action(stringBuilder, solidColorBrush);
					stringBuilder.Clear();
					solidColorBrush = solidColorBrush2;
				}
				stringBuilder.AppendLine(value);
				int_0++;
			}
			if (stringBuilder.Length != 0)
			{
				action(stringBuilder, solidColorBrush);
				int_0++;
			}
			if (scrollViewer_0.ScrollableHeight.Equals(scrollViewer_0.ContentVerticalOffset))
			{
				scrollViewer_0.ScrollToEnd();
			}
		}
		finally
		{
			dispatcherTimer_0.Start();
		}
	}

	protected override void Append(LoggingEvent loggingEvent)
	{
		concurrentQueue_0.Enqueue(loggingEvent);
	}

	public void Clear()
	{
		paragraph_0.Inlines.Clear();
		int_0 = 0;
	}

	private void method_1(StringBuilder stringBuilder_0, SolidColorBrush solidColorBrush_4)
	{
		paragraph_0.Inlines.Add(new Run(stringBuilder_0.ToString())
		{
			Foreground = solidColorBrush_4
		});
	}
}
