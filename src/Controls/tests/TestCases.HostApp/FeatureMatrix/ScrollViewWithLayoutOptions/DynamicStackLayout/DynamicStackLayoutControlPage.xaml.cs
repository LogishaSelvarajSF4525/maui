namespace Maui.Controls.Sample;

public partial class DynamicStackLayoutControlPage : ContentPage
{
	private LayoutViewModel _viewModel;
	private Layout _currentLayout;
	public DynamicStackLayoutControlPage()
	{
		InitializeComponent();
		_viewModel = new LayoutViewModel();
		BindingContext = _viewModel;

		_currentLayout = DynamicStack;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		BuildDynamicStack();
	}

	private void BuildDynamicStack()
	{
		DynamicStack.Children.Clear();

		if (_viewModel.Orientation == ScrollOrientation.Horizontal)
		{
			DynamicStack.Orientation = StackOrientation.Horizontal;
			DynamicStack.BackgroundColor = Colors.Pink;
		}
		else
		{
			DynamicStack.Orientation = StackOrientation.Vertical;
			DynamicStack.BackgroundColor = Colors.Yellow;
		}

		for (int i = 1; i <= _viewModel.LabelCount; i++)
		{
			DynamicStack.Children.Add(CreateLabel(i));
		}

	}

	private Label CreateLabel(int index)
	{
		return new Label
		{
			Text = $"Label {index}",
			FontSize = 18,
			Padding = new Thickness(10)
		};
	}
	private void OnAddChildClicked(object sender, EventArgs e)
	{
		if (_currentLayout == null)
			return;
		_viewModel.LabelCount++;
		_currentLayout.Children.Add(CreateLabel(_viewModel.LabelCount));
	}

	private void OnRemoveChildClicked(object sender, EventArgs e)
	{
		if (_currentLayout == null)
			return;

		if (_currentLayout.Children.Count > 0)
		{
			_currentLayout.Children.RemoveAt(_currentLayout.Children.Count - 1);
			_viewModel.LabelCount--;
		}
	}

	private void OnOrientationClicked(object sender, EventArgs e)
	{
		if (_viewModel.Orientation == ScrollOrientation.Vertical)
		{
			_viewModel.Orientation = ScrollOrientation.Horizontal;
		}
		else
		{
			_viewModel.Orientation = ScrollOrientation.Vertical;
		}

		BuildDynamicStack();
	}
}