namespace maui.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using maui.Models;
using maui.Services;

[QueryProperty(nameof(Sneaker), "Sneaker")]
public partial class SneakerDetailVM : SneakerVM
{
    IDataService _dataService;

    public SneakerDetailVM(IDataService dataService)
    {
        this._dataService = dataService;
    }

    [ObservableProperty]
    Sneaker sneaker;

    [RelayCommand]
    async Task DeleteButton()
    {
        await _dataService.DeleteSneakerAsync(sneaker.Id);
        await App.Current.MainPage.Navigation.PopAsync();
    }
}