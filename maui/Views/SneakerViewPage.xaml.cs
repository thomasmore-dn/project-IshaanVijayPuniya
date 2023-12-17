namespace maui;
using maui.Services;
using maui.Models;
using maui.ViewModels;

public partial class SneakerViewPage : ContentPage
{
    public SneakerViewPage(SneakerDetailVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}