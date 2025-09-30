using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using AbsoluteLayoutFlags = Microsoft.Maui.Layouts.AbsoluteLayoutFlags;

namespace Maui.Controls.Sample;

public partial class BindableLayoutControlPage : NavigationPage
{
	private BindableLayoutViewModel _viewModel;
	public BindableLayoutControlPage()
	{
		_viewModel = new BindableLayoutViewModel();
		PushAsync(new BindableLayoutControlMainPage(_viewModel));
	}
}

public partial class BindableLayoutControlMainPage : ContentPage
{
	private BindableLayoutViewModel _viewModel;

	Grid _mainGrid;
	AbsoluteLayout _mainAbsolute;

	public BindableLayoutControlMainPage(BindableLayoutViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;

		_mainAbsolute = new AbsoluteLayout { HeightRequest = 200 };
		AbsoluteContainer.Content = _mainAbsolute;

		_mainAbsolute.SetBinding(BindableLayout.ItemsSourceProperty, nameof(BindableLayoutViewModel.ItemsSource));
		_mainAbsolute.SetBinding(BindableLayout.ItemTemplateProperty, nameof(BindableLayoutViewModel.ItemTemplate));
		_mainAbsolute.SetBinding(BindableLayout.ItemTemplateSelectorProperty, nameof(BindableLayoutViewModel.ItemTemplateSelector));
		_mainAbsolute.SetBinding(BindableLayout.EmptyViewProperty, nameof(BindableLayoutViewModel.EmptyView));
		_mainAbsolute.SetBinding(BindableLayout.EmptyViewTemplateProperty, nameof(BindableLayoutViewModel.EmptyViewTemplate));

		BindableLayout.SetItemTemplate(_mainAbsolute, new DataTemplate(() =>
		{
			var lbl = new Label { BackgroundColor = Colors.LightBlue, Padding = 8 };
			lbl.SetBinding(Label.TextProperty, "Caption");
			return lbl;
		}));

		_mainGrid = new Grid();
		_mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
		_mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
		_mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

		GridContainer.Content = _mainGrid;

		_mainGrid.SetBinding(BindableLayout.ItemsSourceProperty, nameof(BindableLayoutViewModel.ItemsSource));
		_mainGrid.SetBinding(BindableLayout.ItemTemplateProperty, nameof(BindableLayoutViewModel.ItemTemplate));
		_mainGrid.SetBinding(BindableLayout.ItemTemplateSelectorProperty, nameof(BindableLayoutViewModel.ItemTemplateSelector));
		_mainGrid.SetBinding(BindableLayout.EmptyViewProperty, nameof(BindableLayoutViewModel.EmptyView));
		_mainGrid.SetBinding(BindableLayout.EmptyViewTemplateProperty, nameof(BindableLayoutViewModel.EmptyViewTemplate));

		BindableLayout.SetItemTemplate(_mainGrid, new DataTemplate(() =>
		{
			var border = new Border { Stroke = Colors.Gray, StrokeThickness = 1, Padding = 5, Margin = 4 };
			var lbl = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			lbl.SetBinding(Label.TextProperty, "Caption");
			border.Content = lbl;
			return border;
		}));

		_mainGrid.SizeChanged += (s, e) => UpdateGridLayout();
		_mainAbsolute.SizeChanged += (s, e) => UpdateAbsoluteLayout();

		this.Appearing += (s, e) =>
		{
			UpdateGridLayout();
			UpdateAbsoluteLayout();
		};
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new BindableLayoutViewModel();
		await Navigation.PushAsync(new BindableLayoutOptionsPage(_viewModel));
	}

	void UpdateGridLayout()
	{
		if (_mainGrid == null)
			return;

		int columns = _mainGrid.ColumnDefinitions?.Count ?? 1;
		if (columns <= 0)
			columns = 1;

		var children = _mainGrid.Children;
		int count = children?.Count ?? 0;
		int rowsNeeded = (count + columns - 1) / columns;

		_mainGrid.RowDefinitions.Clear();
		for (int r = 0; r < rowsNeeded; r++)
			_mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

		for (int i = 0; i < count; i++)
		{
			var child = children[i];
			int row = i / columns;
			int col = i % columns;

			if (child is BindableObject bobj)
			{
				Grid.SetRow(bobj, row);
				Grid.SetColumn(bobj, col);
			}
		}
	}

	void UpdateAbsoluteLayout()
	{
		if (_mainAbsolute == null)
			return;

		var children = _mainAbsolute.Children;
		int count = children?.Count ?? 0;
		if (count == 0)
			return;

		int columns = 3;
		double widthFrac = 1.0 / columns;
		double heightFrac = 1.0 / Math.Max(1, (count + columns - 1) / columns);

		double absWidth = _mainAbsolute.Width;
		double absHeight = _mainAbsolute.Height;
		if (absWidth <= 0 || absHeight <= 0)
		{
			for (int i = 0; i < count; i++)
			{
				var child = children[i];
				int row = i / columns;
				int col = i % columns;

				double x = col * widthFrac;
				double y = row * heightFrac;

				if (child is BindableObject bobj)
				{
					AbsoluteLayout.SetLayoutBounds(bobj, new Rect(x, y, widthFrac, heightFrac));
					AbsoluteLayout.SetLayoutFlags(bobj, AbsoluteLayoutFlags.All);
				}
			}
			return;
		}

		for (int i = 0; i < count; i++)
		{
			var child = children[i];
			int row = i / columns;
			int col = i % columns;

			double xFrac = col * widthFrac;
			double yFrac = row * heightFrac;

			double xPx = xFrac * absWidth;
			double yPx = yFrac * absHeight;
			double wPx = widthFrac * absWidth;
			double hPx = heightFrac * absHeight;

			if (child is BindableObject bobj)
			{
				AbsoluteLayout.SetLayoutBounds(bobj, new Rect(xPx, yPx, wPx, hPx));
				AbsoluteLayout.SetLayoutFlags(bobj, AbsoluteLayoutFlags.None);
			}
		}
	}
}