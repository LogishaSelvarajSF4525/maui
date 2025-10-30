using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample;

public class ScrollViewViewModel : INotifyPropertyChanged
{
	private bool _isVisible = true;
	private bool _isEnabled = true;
	private FlowDirection _flowDirection = FlowDirection.LeftToRight;
	private ScrollBarVisibility _horizontalScrollBarVisibility = ScrollBarVisibility.Never;
	private ScrollBarVisibility _verticalScrollBarVisibility = ScrollBarVisibility.Never;
	private Size _contentSize;
	private string _contentText;
	public string ContentSizeString => $"{ContentSize.Width:F0} x {ContentSize.Height:F0}";
	private double _scrollX;
	private double _scrollY;
	public int ScrollXInt => (int)Math.Round(ScrollX);
	public int ScrollYInt => (int)Math.Round(ScrollY);
	private View _content;
	private ScrollOrientation _orientation = ScrollOrientation.Vertical;
	private bool _isScrollToVisible = true;
	private bool _isButtonsVisible = false;
	private int _labelCount = 3;
	private Layout _dynamicStackLayout;


	public ScrollViewViewModel()
	{
		Content = new Label
		{
			Text = string.Join(Environment.NewLine, Enumerable.Range(1, 60).Select(i => $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod, urna eu tincidunt consectetur, nisi nisl aliquam enim, eget facilisis enim nisl nec elit . Sed euismod, urna eu tincidunt consectetur, nisi nisl aliquam enim Eget facilisis enim nisl nec elit Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae. Nullam ac erat at dui laoreet aliquet. Praesent euismod, justo at dictum facilisis, urna erat dictum enim.{i}")),
			FontSize = 18,
			Padding = 10
		};
	}
	public bool IsVisible
	{
		get => _isVisible;
		set { if (_isVisible != value) { _isVisible = value; OnPropertyChanged(); } }
	}

	public bool IsEnabled
	{
		get => _isEnabled;
		set { if (_isEnabled != value) { _isEnabled = value; OnPropertyChanged(); } }
	}

	public FlowDirection FlowDirection
	{
		get => _flowDirection;
		set { if (_flowDirection != value) { _flowDirection = value; OnPropertyChanged(); } }
	}

	public ScrollBarVisibility HorizontalScrollBarVisibility
	{
		get => _horizontalScrollBarVisibility;
		set { if (_horizontalScrollBarVisibility != value) { _horizontalScrollBarVisibility = value; OnPropertyChanged(); } }
	}

	public ScrollBarVisibility VerticalScrollBarVisibility
	{
		get => _verticalScrollBarVisibility;
		set { if (_verticalScrollBarVisibility != value) { _verticalScrollBarVisibility = value; OnPropertyChanged(); } }
	}

	public string ContentText
	{
		get => _contentText;
		set
		{
			if (_contentText != value)
			{
				_contentText = value;
				Content = new Label { Text = _contentText }; // Update Content when ContentText changes
				OnPropertyChanged();
			}
		}
	}

	public View Content
	{
		get => _content;
		set
		{
			if (_content != value)
			{
				_content = value;
				OnPropertyChanged();
			}
		}
	}

	public Size ContentSize
	{
		get => _contentSize;
		set
		{
			if (_contentSize != value)
			{
				_contentSize = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ContentSizeString));
			}
		}
	}

	public double ScrollX
	{
		get => _scrollX;
		set
		{
			if (_scrollX != value)
			{
				_scrollX = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ScrollXInt));
			}
		}
	}

	public double ScrollY
	{
		get => _scrollY;
		set
		{
			if (_scrollY != value)
			{
				_scrollY = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ScrollYInt));
			}
		}
	}
	private ScrollToPosition _selectedScrollToPosition = ScrollToPosition.MakeVisible;
	public ScrollToPosition SelectedScrollToPosition
	{
		get => _selectedScrollToPosition;
		set { if (_selectedScrollToPosition != value) { _selectedScrollToPosition = value; OnPropertyChanged(); } }
	}

	public ScrollOrientation Orientation
	{
		get => _orientation;
		set { if (_orientation != value) { _orientation = value; OnPropertyChanged(); } }
	}

	public bool IsScrollToVisible
	{
		get => _isScrollToVisible;
		set
		{
			if (_isScrollToVisible != value)
			{
				_isScrollToVisible = value;
				OnPropertyChanged();
			}
		}
	}

	public bool IsButtonsVisible
	{
		get => _isButtonsVisible;
		set
		{
			if (_isButtonsVisible != value)
			{
				_isButtonsVisible = value;
				OnPropertyChanged();
			}
		}
	}

	public int LabelCount
	{
		get => _labelCount;
		set
		{
			if (_labelCount != value)
			{
				_labelCount = value;
				OnPropertyChanged();
			}
		}
	}

	public Layout DynamicStackLayout
	{
		get => _dynamicStackLayout;
		set
		{
			if (_dynamicStackLayout != value)
			{
				_dynamicStackLayout = value;
				OnPropertyChanged();
			}
		}
	}

	public Label CreateLabel(int number)
	{
		return new Label
		{
			Text = $"Label {number}",
			FontSize = 18,
			Padding = new Thickness(10),
			AutomationId = $"DynamicLabel{number}"
		};
	}

	public void AddLabel()
	{
		if (DynamicStackLayout == null)
			return;
		LabelCount++;
		DynamicStackLayout.Children.Add(CreateLabel(LabelCount));
		UpdateDynamicStackSize();
		ForceRelayout();
	}

	public void RemoveLabel()
	{
		if (DynamicStackLayout == null)
			return;
		if (DynamicStackLayout.Children.Count == 0)
			return;
		DynamicStackLayout.Children.RemoveAt(DynamicStackLayout.Children.Count - 1);
		LabelCount--;
		UpdateDynamicStackSize();
		ForceRelayout();
	}

	private void UpdateDynamicStackSize()
	{
		if (DynamicStackLayout == null)
			return;
		// Only fill width if parent is wider; never force height so blank space is avoided.
		DynamicStackLayout.HorizontalOptions = LayoutOptions.Start;
		if (DynamicStackLayout.Parent is VisualElement parent && parent.Width > 0 && parent.Width > DynamicStackLayout.Width)
		{
			DynamicStackLayout.HorizontalOptions = LayoutOptions.Fill;
		}
	}

	private void ForceRelayout()
	{
		// Workaround: after removing children a ScrollView may keep old extent; force measure invalidation
		DynamicStackLayout.InvalidateMeasure();
		if (DynamicStackLayout?.Parent is VisualElement ve)
		{
			ve.InvalidateMeasure();
		}
		if (DynamicStackLayout?.Parent?.Parent is VisualElement grand)
		{
			grand.InvalidateMeasure();
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	public class CustomScroll : ScrollView
	{
		protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
		{
			return base.MeasureOverride(widthConstraint, heightConstraint);
		}

		protected override Size ArrangeOverride(Rect bounds)
		{
			return base.ArrangeOverride(bounds);
		}
	}

	public class CustomStack : StackLayout
	{
		protected override Size MeasureOverride(double widthConstraint, double heightConstraint)
		{
			return base.MeasureOverride(widthConstraint, heightConstraint);
		}

		protected override Size ArrangeOverride(Rect bounds)
		{
			return base.ArrangeOverride(bounds);
		}
	}
}