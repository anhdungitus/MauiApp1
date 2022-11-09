using MauiApp1.ViewModels;

namespace MauiApp1.Views.XAML;

public partial class VerticalListPage : ContentPage
{
	public VerticalListPage()
	{
		InitializeComponent();
		BindingContext = new MonkeysViewModel();
	}

    async void OnButtonClicked(object sender, EventArgs args)
    {
    }
}