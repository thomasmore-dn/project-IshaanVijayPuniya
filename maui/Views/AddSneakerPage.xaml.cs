namespace maui;
using maui.Services;
using maui.Models;
using maui.ViewModels;

public partial class AddSneakerPage : ContentPage
{
    public AddSneakerPage(AddSneakerVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        //SetupBindings(viewModel);
        //Setup Bindings has initilization of View Model arising from Add Sneaker
    }
}