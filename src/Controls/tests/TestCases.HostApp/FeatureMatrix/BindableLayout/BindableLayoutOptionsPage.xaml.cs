namespace Maui.Controls.Sample;

public partial class BindableLayoutOptionsPage : ContentPage
{
	private BindableLayoutViewModel _viewModel;
	public BindableLayoutOptionsPage(BindableLayoutViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	private void ApplyButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnEmptyViewChanged(object sender, CheckedChangedEventArgs e)
		{
			if (EmptyViewNone.IsChecked)
			{
				_viewModel.EmptyView = null;
			}
			else if (EmptyViewString.IsChecked)
			{
				_viewModel.EmptyView = "No Items Available(String)";
			}
			else if (EmptyViewGrid.IsChecked)
			{
				Grid grid = new Grid
				{
					BackgroundColor = Colors.LightGray,
					Padding = new Thickness(10),
				};
				grid.Children.Add(new Label
				{
					Text = "No Items Available(Grid View)",
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					TextColor = Colors.Blue
				});
				_viewModel.EmptyView = grid;
			}
		}


		private void OnEmptyViewTemplateChanged(object sender, CheckedChangedEventArgs e)
		{
			if (EmptyViewTemplateNone.IsChecked)
			{
				_viewModel.EmptyViewTemplate = null;
			}
			else if (EmptyViewTemplateGrid.IsChecked)
			{
				_viewModel.EmptyViewTemplate = new DataTemplate(() =>
				{
					Grid grid = new Grid
					{
						BackgroundColor = Colors.LightGray,
						Padding = new Thickness(10)
					};
					grid.Children.Add(new Label
					{
						Text = "No Template Items Available(Grid View)",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						TextColor = Colors.Blue
					});
					return grid;
				});
			}
		}

		private void OnItemTemplateChanged(object sender, CheckedChangedEventArgs e)
		{
			if (ItemTemplateNone.IsChecked)
			{
				_viewModel.ItemTemplate = null;
			}
			else if (ItemTemplateBasic.IsChecked)
			{
				_viewModel.ItemTemplate = new DataTemplate(() =>
				{
					var label = new Label();
					label.SetBinding(Label.TextProperty, new Binding("Caption"));
					return label;
				});
			}
			else if (ItemTemplateGrid.IsChecked)
			{
				_viewModel.ItemTemplate = new DataTemplate(() =>
				{
					var grid = new Grid
					{
						ColumnDefinitions =
						{
							 new ColumnDefinition { Width = GridLength.Star },
							 new ColumnDefinition { Width = GridLength.Star }
						},
						Padding = new Thickness(10),
						BackgroundColor = Colors.LightBlue

					};

					var label1 = new Label
					{
						VerticalOptions = LayoutOptions.Center,
						HorizontalOptions = LayoutOptions.Start,
						FontAttributes = FontAttributes.Bold,
						TextColor = Colors.Green
					};
					label1.SetBinding(Label.TextProperty, "Caption");
					grid.Children.Add(label1);
					return grid;
				});
			}
		}

		private void OnItemsSourceChanged(object sender, CheckedChangedEventArgs e)
		{
			if (!(sender is RadioButton radioButton) || !e.Value)
				return;
			if (radioButton == ItemsSourceObservableCollection)
				_viewModel.ItemsSourceType = ItemsSourceType.ObservableCollectionT;
			else if (radioButton == ItemsSourceEmptyCollection)
				_viewModel.ItemsSourceType = ItemsSourceType.EmptyObservableCollectionT;
			else if (radioButton == ItemsSourceNone)
				_viewModel.ItemsSourceType = ItemsSourceType.None;
		}
        
		private void OnItemTemplateSelectorChanged(object sender, CheckedChangedEventArgs e)
		{
			if (!(sender is RadioButton radioButton) || !e.Value)
				return;

			if (radioButton == ItemTemplateSelectorNone)
			{
				_viewModel.ItemTemplateSelector = null;
			}
			else if (radioButton == ItemTemplateSelectorAlternate)
			{
				// use the view model's built-in selector (already created in constructor)
				_viewModel.ItemTemplateSelector = _viewModel.ItemTemplateSelector ?? new BindableLayoutViewModel.CustomDataTemplateSelector
				{
					Template1 = new DataTemplate(() => { var lbl = new Label(); lbl.SetBinding(Label.TextProperty, "Caption"); return lbl; }),
					Template2 = new DataTemplate(() => { var grid = new Grid { Padding = new Thickness(6) }; var lbl = new Label { TextColor = Colors.Blue }; lbl.SetBinding(Label.TextProperty, "Caption"); grid.Children.Add(lbl); return grid; })
				};
			}
		}
}  