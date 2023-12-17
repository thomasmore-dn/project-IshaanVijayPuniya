using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

using maui.Services;
using maui.Models;

namespace maui.ViewModels;

    public partial class MainPageVM : SneakerVM
    {
        // DataService for retrieving sneaker data
        IDataService _dataService;

        // Collection to store the list of sneakers
        public ObservableCollection<Sneaker> Sneakers { get; } = new();

        // Property for the upper title
        public string UpperTitle { get; set; }

        // Property for indicating whether the view is refreshing
        [ObservableProperty]
        bool isRefreshing = true;

        // Property for the selected sneaker
        [ObservableProperty]
        Sneaker selectedsneaker;

        // Constructor
        public MainPageVM(IDataService dataService)
        {
            UpperTitle = "SNEAKY";
            this._dataService = dataService;
        }

        // Command to asynchronously retrieve sneakers
        [RelayCommand]
        public async Task GetSneakersAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                // Retrieve sneakers from the data service
                var sneakers = await _dataService.GetAllSneakerAsync();

                // Clear the existing sneakers in the collection
                if (Sneakers.Count != 0)
                    Sneakers.Clear();

                // Add the retrieved sneakers to the collection
                foreach (var sneaker in sneakers)
                    Sneakers.Add(sneaker);
            }
            catch (System.Exception ex)
            {
                // Log any exceptions that occur during the data retrieval
                Debug.WriteLine($"Unable to get sneakers: {ex.Message}");
            }
            finally
            {
                // Reset busy and refreshing states
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        // Command to navigate to the AddSneakerPage
        [RelayCommand]
        async Task AddSneakerClicked()
        {
            await Shell.Current.GoToAsync("AddSneakerPage");
        }

        // Command to navigate to the SneakerViewPage with selected sneaker data
        [RelayCommand]
        async Task NavigateToDetail()
        {
            if (selectedsneaker == null)
                return;

            // Prepare navigation parameters
            var navigationParamater = new Dictionary<string, object>
            {
                {"Sneaker", selectedsneaker}
            };

            // Navigate to SneakerViewPage with the selected sneaker data
            await Shell.Current.GoToAsync(nameof(SneakerViewPage), true, navigationParamater);
        }
    }

