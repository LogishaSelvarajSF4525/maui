namespace Maui.Controls.Sample;

public partial class DynamicGridLayoutControlPage : ContentPage
{
	private LayoutViewModel _viewModel;
	private Grid _currentGrid;

	public DynamicGridLayoutControlPage()
	{
		InitializeComponent();
		_viewModel = new LayoutViewModel();
		BindingContext = _viewModel;

		_currentGrid = DynamicGrid;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		BuildDynamicGrid();
	}
	private void BuildDynamicGrid()
	{
		DynamicGrid.Children.Clear();
		DynamicGrid.RowDefinitions.Clear();
		DynamicGrid.ColumnDefinitions.Clear();

		int rows = _viewModel.RowCount > 0 ? _viewModel.RowCount : 2;
		int columns = _viewModel.ColumnCount > 0 ? _viewModel.ColumnCount : 2;

		for (int r = 0; r < rows; r++)
			DynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

		for (int c = 0; c < columns; c++)
			DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

		DynamicGrid.BackgroundColor = Colors.LightBlue;

		int index = 1;
		for (int r = 0; r < rows; r++)
		{
			for (int c = 0; c < columns; c++)
			{
				if (index > _viewModel.LabelCount)
					return;

				var lbl = CreateLabel(index++);
				Grid.SetRow(lbl, r);
				Grid.SetColumn(lbl, c);
				DynamicGrid.Children.Add(lbl);
			}
		}
	}
	private Label CreateLabel(int index)
	{
		return new Label
		{
			Text = $"Label {index}",
			FontSize = 18,
			Padding = new Thickness(10),
			BackgroundColor = Colors.White,
			Margin = new Thickness(5),
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		};
	}

	private void OnAddChildClicked(object sender, EventArgs e)
	{
		if (DynamicGrid == null)
			return;

		_viewModel.LabelCount++;

		if (DynamicGrid.RowDefinitions.Count == 0)
			DynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
		if (DynamicGrid.ColumnDefinitions.Count == 0)
			DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

		int columns = DynamicGrid.ColumnDefinitions.Count;
		int totalCells = DynamicGrid.RowDefinitions.Count * columns;

		if (_viewModel.LabelCount > totalCells)
		{
			DynamicGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			totalCells = DynamicGrid.RowDefinitions.Count * columns;
		}

		int newIndex = _viewModel.LabelCount - 1;
		int row = newIndex / columns;
		int column = newIndex % columns;

		var lbl = CreateLabel(_viewModel.LabelCount);
		Grid.SetRow(lbl, row);
		Grid.SetColumn(lbl, column);
		DynamicGrid.Children.Add(lbl);
	}

	private void OnRemoveChildClicked(object sender, EventArgs e)
	{
		if (DynamicGrid == null || DynamicGrid.Children.Count == 0)
			return;

		DynamicGrid.Children.RemoveAt(DynamicGrid.Children.Count - 1);
		_viewModel.LabelCount = Math.Max(0, _viewModel.LabelCount - 1);

	}
}