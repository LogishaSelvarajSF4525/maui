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

	public BindableLayoutControlMainPage(BindableLayoutViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;

	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new BindableLayoutViewModel();
		await Navigation.PushAsync(new BindableLayoutOptionsPage(_viewModel));
	}

	private void RemoveItems_Clicked(object sender, EventArgs e)
	{
		var text = IndexEntry.Text?.Trim();
		if (string.IsNullOrEmpty(text))
		{
			_viewModel.RemoveLastItem();
		}
		else if (int.TryParse(text, out int index))
		{
			_viewModel.RemoveItemAtIndex(index);
		}

		IndexEntry.Text = string.Empty;
	}

	private void AddItems_Clicked(object sender, EventArgs e)
	{
		var text = IndexEntry.Text?.Trim();
		if (string.IsNullOrEmpty(text))
		{
			_viewModel.AddSequentialItem();
		}
		else if (int.TryParse(text, out int index))
		{
			_viewModel.AddItemAtIndex(index);
		}

		IndexEntry.Text = string.Empty;
	}

	private void ReplaceItems_Clicked(object sender, EventArgs e)
	{
		var text = IndexEntry.Text?.Trim();
		if (string.IsNullOrEmpty(text))
		{
			_viewModel.ReplaceItem();
		}
		else if (int.TryParse(text, out int index))
		{
			_viewModel.ReplaceItemAtIndex(index);
		}
		IndexEntry.Text = string.Empty;
	}
}