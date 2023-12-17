using CommunityToolkit.Mvvm.ComponentModel;


namespace maui.ViewModels;

public partial class SneakerVM : ObservableObject // ObservableObject : INotifyPropertyChanged includes implememntaion
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;    // referring to when we are refreshing  the page and its loading 

    public bool IsNotBusy => !IsBusy;
}
