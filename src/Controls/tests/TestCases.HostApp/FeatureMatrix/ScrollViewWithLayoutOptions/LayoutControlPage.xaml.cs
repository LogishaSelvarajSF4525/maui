using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample;

public class LayoutControlPage : NavigationPage
{
	private LayoutViewModel _viewModel;
	public LayoutControlPage()
	{
		_viewModel = new LayoutViewModel();

		PushAsync(new LayoutMainPage(_viewModel));
	}
}

public partial class LayoutMainPage : ContentPage
{
	private LayoutViewModel _viewModel;
	private Layout _currentLayout; // Tracks the current layout in ScrollView

	public LayoutMainPage(LayoutViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
		InitializeContent();
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		InitializeContent();
		if (_viewModel.IsStackLayoutVisible && LabelStack != null)
		{
			DynamicLayoutClicked();
		}
	}

	private void InitializeContent()
	{
		var defaultLayout = new VerticalStackLayout
		{
			BackgroundColor = Colors.LightGray,
			Children =
			{
				new Label { Text = "Welcome to LayoutPage" },
			}
		};

		MyScrollView.Content = defaultLayout;
		_currentLayout = defaultLayout;
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new LayoutViewModel();
		_viewModel.IsStackLayoutVisible = false;
		_viewModel.IsVisible = true;
		await Navigation.PushAsync(new LayoutOptionsPage(_viewModel));
	}

	private void OnScrollViewWithStackLayoutClicked(object sender, EventArgs e)
	{
		Layout layout;

		if (_viewModel.Orientation == ScrollOrientation.Horizontal)
		{
			layout = new HorizontalStackLayout
			{
				HorizontalOptions = _viewModel.HorizontalOptions,
				VerticalOptions = _viewModel.VerticalOptions,
				BackgroundColor = Colors.LightGray,
				Spacing = 10,
				Children =
				{
					new Label { Text = "StackLayout", VerticalOptions = LayoutOptions.Center  },
					new Button { Text = "Button1", VerticalOptions = LayoutOptions.Center },
					new Button { Text = "Button2", VerticalOptions = LayoutOptions.Center }
				}
			};
		}
		else
		{
			layout = new VerticalStackLayout
			{
				HorizontalOptions = _viewModel.HorizontalOptions,
				VerticalOptions = _viewModel.VerticalOptions,
				BackgroundColor = Colors.LightGray,
				Spacing = 10,
				Children =
				{
					new Label { Text = "StackLayout", HorizontalOptions = LayoutOptions.Center },
					new Button { Text = "Button1", HorizontalOptions = LayoutOptions.Center  },
					new Button { Text = "Button2", HorizontalOptions = LayoutOptions.Center }
				}
			};
		}

		// Add initial content
		layout.Children.Add(new Label
		{
			Text = "Dynamic StackLayout Content",
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		});

		MyScrollView.Content = layout;
	}


	private void OnGridWithChildrenClicked(object sender, EventArgs e)
	{
		var grid = new Grid
		{
			Padding = 15,
			BackgroundColor = Colors.LightGray,
			HorizontalOptions = _viewModel.HorizontalOptions,
			VerticalOptions = _viewModel.VerticalOptions,
			RowSpacing = 10,
			ColumnSpacing = 10
		};

		grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
		grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
		grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

		grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
		grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

		var button1 = new Button { Text = "Button 1", BackgroundColor = Colors.Orange, TextColor = Colors.White };
		var button2 = new Button { Text = "Button 2", BackgroundColor = Colors.Blue, TextColor = Colors.White };
		var button3 = new Button { Text = "Button 3", BackgroundColor = Colors.Green, TextColor = Colors.White };
		var button4 = new Button { Text = "Button 4", BackgroundColor = Colors.Red, TextColor = Colors.White };
		var button5 = new Button { Text = "Button 5", BackgroundColor = Colors.Purple, TextColor = Colors.White };
		var button6 = new Button { Text = "Button 6", BackgroundColor = Colors.Brown, TextColor = Colors.White };
		grid.Add(button1, 0, 0);
		grid.Add(button2, 1, 0);
		grid.Add(button3, 2, 0);
		grid.Add(button4, 0, 1);
		grid.Add(button5, 1, 1);
		grid.Add(button6, 2, 1);
		MyScrollView.Content = grid;

		MyScrollView.Content = _currentLayout = grid;
	}
	private void DynamicLayoutClicked()
	{
		_viewModel.IsStackLayoutVisible = true;
		_viewModel.IsVisible = false;
		if (LabelStack == null)
		{
			LabelStack = new CustomStack
			{
				Orientation = _viewModel.Orientation == ScrollOrientation.Vertical
					? StackOrientation.Vertical
					: StackOrientation.Horizontal,
				Spacing = 10,
				Padding = new Thickness(10),
				BackgroundColor = _viewModel.Orientation == ScrollOrientation.Horizontal
					? Colors.Pink
					: Colors.Yellow,
				HeightRequest = _viewModel.Orientation == ScrollOrientation.Horizontal
					? 200
					: -1,
				WidthRequest = _viewModel.Orientation == ScrollOrientation.Horizontal
					? 150
					: -1
			};

			CustomLayoutControl.Content = LabelStack;
		}

		LabelStack.Children.Clear();

		for (int i = 1; i <= _viewModel.LabelCount; i++)
		{
			LabelStack.Children.Add(CreateLabel(i));
		}

		_currentLayout = LabelStack;
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
		if (CustomLayoutControl.Content is Layout visibleLayout)
			_currentLayout = visibleLayout;

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
		}
	}
}