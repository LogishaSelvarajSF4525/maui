using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Controls.Sample
{

	public partial class SliderOptionsPage : ContentPage
	{
		private SliderViewModel _viewModel;

		public SliderOptionsPage(SliderViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;
			SetHorizontalOptionsRadioButton(_viewModel.HorizontalOptions);
			SetVerticalOptionsRadioButton(_viewModel.VerticalOptions);
		}

		private void ApplyButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

		private void OnMinimumChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(MinimumEntry.Text, out double min))
			{
				_viewModel.Minimum = min;
			}
		}

		private void OnMaximumChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(MaximumEntry.Text, out double max))
			{
				_viewModel.Maximum = max;
			}
		}

		private void OnValueChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(ValueEntry.Text, out double value))
			{
				_viewModel.Value = value;
			}
		}
		private void MinTrackColorButton_Clicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			if (button.Text == "Green")
				_viewModel.MinTrackColor = Colors.Green;
			else if (button.Text == "Yellow")
				_viewModel.MinTrackColor = Colors.Yellow;
		}

		private void MaxTrackColorButton_Clicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			if (button.Text == "Red")
				_viewModel.MaxTrackColor = Colors.Red;
			else if (button.Text == "Orange")
				_viewModel.MaxTrackColor = Colors.Orange;
		}

		private void BackgroundColorButton_Clicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			if (button.Text == "Gray")
				_viewModel.BackgroundColor = Colors.Gray;
			else if (button.Text == "Light Blue")
				_viewModel.BackgroundColor = Colors.LightBlue;
		}
		private void ThumbColorButton_Clicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			if (button.Text == "Red")
				_viewModel.ThumbColor = Colors.Red;
			else if (button.Text == "Green")
				_viewModel.ThumbColor = Colors.Green;
		}

		private void OnFlowDirectionChanged(object sender, EventArgs e)
		{
			_viewModel.FlowDirection = FlowDirectionLTR.IsChecked ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
		}

		private void OnIsEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			_viewModel.IsEnabled = IsEnabledTrueRadio.IsChecked;
		}

		private void OnIsVisibleCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			_viewModel.IsVisible = IsVisibleTrueRadio.IsChecked;
		}

		private void ThumbImageSourceButton_Clicked(object sender, EventArgs e)
		{
			_viewModel.ThumbImageSource = "coffee.png";
		}

		private void ThumbImageResetButton_Clicked(object sender, EventArgs e)
		{
			_viewModel.ThumbImageSource = null;
		}

		private void OnHeightRequestChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(HeightRequestEntry.Text, out double height))
			{
				_viewModel.HeightRequest = height;
			}
		}

		private void OnWidthRequestChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(WidthRequestEntry.Text, out double width))
			{
				_viewModel.WidthRequest = width;
			}
		}

		private void OnOpacityChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(OpacityEntry.Text, out double opacity))
			{
				_viewModel.Opacity = opacity;
			}
		}

		private void OnHorizontalOptionsCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			if (e.Value && sender is RadioButton radioButton)
				_viewModel.HorizontalOptions = GetLayoutOptions(radioButton);
		}

		private void OnVerticalOptionsCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			if (e.Value && sender is RadioButton radioButton)
				_viewModel.VerticalOptions = GetLayoutOptions(radioButton);
		}

		private static LayoutOptions GetLayoutOptions(RadioButton radioButton) =>
			radioButton.Content?.ToString() switch
			{
				"Start" => LayoutOptions.Start,
				"Center" => LayoutOptions.Center,
				"End" => LayoutOptions.End,
				"Fill" => LayoutOptions.Fill,
				_ => throw new ArgumentOutOfRangeException(nameof(radioButton), radioButton.Content, "Unsupported layout option.")
			};

		private void SetHorizontalOptionsRadioButton(LayoutOptions layoutOptions)
		{
			if (layoutOptions == LayoutOptions.Start)
				HorizontalOptionsStartRadio.IsChecked = true;
			else if (layoutOptions == LayoutOptions.End)
				HorizontalOptionsEndRadio.IsChecked = true;
			else if (layoutOptions == LayoutOptions.Fill)
				HorizontalOptionsFillRadio.IsChecked = true;
			else
				HorizontalOptionsCenterRadio.IsChecked = true;
		}

		private void SetVerticalOptionsRadioButton(LayoutOptions layoutOptions)
		{
			if (layoutOptions == LayoutOptions.Start)
				VerticalOptionsStartRadio.IsChecked = true;
			else if (layoutOptions == LayoutOptions.End)
				VerticalOptionsEndRadio.IsChecked = true;
			else if (layoutOptions == LayoutOptions.Fill)
				VerticalOptionsFillRadio.IsChecked = true;
			else
				VerticalOptionsCenterRadio.IsChecked = true;
		}
	}
}
