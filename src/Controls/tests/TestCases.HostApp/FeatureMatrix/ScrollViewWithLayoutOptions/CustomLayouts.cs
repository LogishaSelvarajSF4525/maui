using System.Diagnostics;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.Controls.Sample;

public class CustomScroll : ScrollView
{
	public new static readonly BindableProperty OrientationProperty =
		BindableProperty.Create(
			nameof(Orientation),
			typeof(ScrollOrientation),
			typeof(CustomScroll),
			ScrollOrientation.Vertical,
			propertyChanged: OnOrientationChanged);
	public new ScrollOrientation Orientation
	{
		get => (ScrollOrientation)GetValue(OrientationProperty);
		set => SetValue(OrientationProperty, value);
	}

	static void OnOrientationChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is CustomScroll customScroll && newValue is ScrollOrientation newOrientation)
		{
			customScroll.SetOrientation(newOrientation);
			customScroll.InvalidateMeasure(); // Ensure layout re-measures with new scroll direction
			Debug.WriteLine($"[CustomScroll] Orientation changed {oldValue} -> {newOrientation}");
		}
	}

	void SetOrientation(ScrollOrientation orientation)
	{
		base.Orientation = orientation;
	}

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