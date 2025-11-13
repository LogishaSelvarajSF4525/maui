namespace Maui.Controls.Sample;

public partial class BindableWithFlexControlPage : NavigationPage
{
	private BindableLayoutViewModel _viewModel;

	public BindableWithFlexControlPage(BindableLayoutViewModel viewModel)
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
}