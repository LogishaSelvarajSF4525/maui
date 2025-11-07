using System.Diagnostics;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.Controls.Sample;

public class CustomScroll : ScrollView
{
	protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
	{
		var size = base.MeasureOverride(widthConstraint, heightConstraint);
		Debug.WriteLine($"[CustomScroll] MeasureOverride: orientation={base.Orientation} available=({widthConstraint},{heightConstraint}) result={size}");
		return size;
	}

	protected override Size ArrangeOverride(Rect bounds)
	{
		var size = base.ArrangeOverride(bounds);
		Debug.WriteLine($"[CustomScroll] ArrangeOverride: bounds={bounds} arranged={size}");
		return size;
	}
}

public class CustomStack : StackLayout
{
	public Size LastMeasuredSize { get; private set; }
	public Rect LastArrangedBounds { get; private set; }

	protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
	{
		var size = base.MeasureOverride(widthConstraint, heightConstraint);
		LastMeasuredSize = size;
		Debug.WriteLine($"[CustomStack] MeasureOverride: orientation={Orientation} available=({widthConstraint},{heightConstraint}) result={size}");
		return size;
	}

	protected override Size ArrangeOverride(Rect bounds)
	{
		var size = base.ArrangeOverride(bounds);
		LastArrangedBounds = bounds;
		Debug.WriteLine($"[CustomStack] ArrangeOverride: orientation={Orientation} bounds={bounds} arranged={size}");
		return size;
	}
}