using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DreamPoeBot.Loki.Common.Controls;

[TemplatePart(Name = "SplitElement", Type = typeof(UIElement))]
public class SplitButton : Button
{
	private const string string_0 = "SplitElement";

	private UIElement uielement_0;

	private ContextMenu contextMenu_0;

	private DependencyObject dependencyObject_0;

	private Point point_0;

	private ObservableCollection<object> observableCollection_0 = new ObservableCollection<object>();

	public Collection<object> ButtonMenuItemsSource => observableCollection_0;

	private bool IsMouseOverSplitElement { get; set; }

	public SplitButton()
	{
		base.DefaultStyleKey = typeof(SplitButton);
	}

	public override void OnApplyTemplate()
	{
		if (uielement_0 != null)
		{
			uielement_0.MouseEnter -= uielement_0_MouseEnter;
			uielement_0.MouseLeave -= uielement_0_MouseLeave;
			uielement_0 = null;
		}
		if (contextMenu_0 != null)
		{
			contextMenu_0.Opened -= contextMenu_0_Opened;
			contextMenu_0.Closed -= contextMenu_0_Closed;
			contextMenu_0 = null;
		}
		if (dependencyObject_0 != null)
		{
			RemoveLogicalChild(dependencyObject_0);
			dependencyObject_0 = null;
		}
		method_1();
		uielement_0 = GetTemplateChild("SplitElement") as UIElement;
		if (uielement_0 == null)
		{
			return;
		}
		uielement_0.MouseEnter += uielement_0_MouseEnter;
		uielement_0.MouseLeave += uielement_0_MouseLeave;
		contextMenu_0 = ContextMenuService.GetContextMenu(uielement_0);
		if (contextMenu_0 != null)
		{
			contextMenu_0.IsOpen = true;
			DependencyObject parent = contextMenu_0;
			do
			{
				dependencyObject_0 = parent;
				parent = LogicalTreeHelper.GetParent(parent);
			}
			while (parent != null);
			contextMenu_0.IsOpen = false;
			AddLogicalChild(dependencyObject_0);
			contextMenu_0.Opened += contextMenu_0_Opened;
			contextMenu_0.Closed += contextMenu_0_Closed;
		}
	}

	protected override void OnClick()
	{
		if (IsMouseOverSplitElement)
		{
			OpenButtonMenu();
		}
		else
		{
			base.OnClick();
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (Key.Down == e.Key || Key.Up == e.Key)
		{
			base.Dispatcher.BeginInvoke(new Action(OpenButtonMenu));
		}
		else
		{
			base.OnKeyDown(e);
		}
	}

	protected void OpenButtonMenu()
	{
		if (0 < observableCollection_0.Count && contextMenu_0 != null)
		{
			contextMenu_0.HorizontalOffset = 0.0;
			contextMenu_0.VerticalOffset = 0.0;
			contextMenu_0.IsOpen = true;
		}
	}

	private void uielement_0_MouseEnter(object sender, MouseEventArgs e)
	{
		IsMouseOverSplitElement = true;
	}

	private void uielement_0_MouseLeave(object sender, MouseEventArgs e)
	{
		IsMouseOverSplitElement = false;
	}

	private void contextMenu_0_Opened(object sender, RoutedEventArgs e)
	{
		point_0 = TranslatePoint(new Point(0.0, base.ActualHeight), contextMenu_0);
		method_0();
		base.LayoutUpdated += SplitButton_LayoutUpdated;
	}

	private void contextMenu_0_Closed(object sender, RoutedEventArgs e)
	{
		base.LayoutUpdated -= SplitButton_LayoutUpdated;
		method_2();
	}

	private void SplitButton_LayoutUpdated(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		Point point = default(Point);
		Point point2 = point_0;
		contextMenu_0.HorizontalOffset = point2.X - point.X;
		contextMenu_0.VerticalOffset = point2.Y - point.Y;
		if (FlowDirection.RightToLeft == base.FlowDirection)
		{
			contextMenu_0.HorizontalOffset *= -1.0;
		}
	}

	void method_1()
	{
		base.OnApplyTemplate();
	}

	bool method_2()
	{
		return Focus();
	}
}
