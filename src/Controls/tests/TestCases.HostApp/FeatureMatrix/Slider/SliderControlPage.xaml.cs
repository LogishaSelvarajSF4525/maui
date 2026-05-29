using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	public class SliderControlPage : NavigationPage
	{
		private SliderViewModel _viewModel;

		public SliderControlPage()
		{
			_viewModel = new SliderViewModel();
			PushAsync(new SliderControlMainPage(_viewModel));
		}
	}

	public partial class SliderControlMainPage : ContentPage
	{
		private SliderViewModel _viewModel;

		public SliderControlMainPage(SliderViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;
		}

		private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
		{
			_viewModel.Reset();
			ReInitializeSlider();
			await Navigation.PushAsync(new SliderOptionsPage(_viewModel));
		}

		private void ReInitializeSlider()
		{
			SliderGrid.Children.Clear();

			var slider = new Slider
			{
				Margin = new Thickness(0, 100, 0, 100),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				AutomationId = "SliderControl"
			};

			// Set up bindings
			slider.SetBinding(Slider.MinimumProperty, new Binding("Minimum"));
			slider.SetBinding(Slider.MaximumProperty, new Binding("Maximum"));
			slider.SetBinding(Slider.ValueProperty, new Binding("Value"));
			slider.SetBinding(Slider.ThumbColorProperty, new Binding("ThumbColor"));
			slider.SetBinding(Slider.MinimumTrackColorProperty, new Binding("MinTrackColor"));
			slider.SetBinding(Slider.MaximumTrackColorProperty, new Binding("MaxTrackColor"));
			slider.SetBinding(Slider.BackgroundColorProperty, new Binding("BackgroundColor"));
			slider.SetBinding(Slider.IsVisibleProperty, new Binding("IsVisible"));
			slider.SetBinding(Slider.IsEnabledProperty, new Binding("IsEnabled"));
			slider.SetBinding(Slider.FlowDirectionProperty, new Binding("FlowDirection"));
			slider.SetBinding(Slider.ThumbImageSourceProperty, new Binding("ThumbImageSource"));
			slider.SetBinding(Slider.DragStartedCommandProperty, new Binding("DragStartedCommand"));
			slider.SetBinding(Slider.DragCompletedCommandProperty, new Binding("DragCompletedCommand"));
			slider.SetBinding(VisualElement.HeightRequestProperty, new Binding("HeightRequest"));
			slider.SetBinding(VisualElement.WidthRequestProperty, new Binding("WidthRequest"));
			slider.SetBinding(VisualElement.OpacityProperty, new Binding("Opacity"));

			slider.ValueChanged += OnSliderValueChanged;

			SliderGrid.Children.Add(slider);
		}

		private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			if (BindingContext is SliderViewModel vm)
			{
				vm.ValueChangedStatus = "Raised";
				vm.OldValue = e.OldValue;
				vm.NewValue = e.NewValue;						
			}
		}
	}
}
