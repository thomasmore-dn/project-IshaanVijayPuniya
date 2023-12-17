namespace maui.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

using Plugin.ValidationRules;

using maui.Models;
using maui.Services;
using maui.Validations;
  //// The AddSneakerVM class represents the ViewModel for adding a new sneaker.
public partial class AddSneakerVM : SneakerVM// VM here meaning view model as described in class
{
    IDataService _dataService;

    [ObservableProperty]
    Sneaker sneak;

    ValidationUnit _unit1;
    //// ValidationUnit to manage validations for different properties
    public Validatable<string> Title { get; set; }
    public Validatable<string> Description { get; set; }
    public Validatable<string> Price { get; set; }
    public Validatable<string> PicturePath { get; set; }


    public AddSneakerVM(IDataService dataService)
    {
        this._dataService = dataService;
        Sneak = new();

        Title = new();
        Description = new();
        Price = new();
        PicturePath = new();
         // Initializing the validatable properties
        _unit1 = new ValidationUnit(Title, Description, Price, PicturePath);

        AddValidations();
    }

    private void AddValidations()
    {
          // the only thing about these validations is they happen one by one.
        Title.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "A title is required for the shoe."});
        Description.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "A description is required for the shoe"});
        Price.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "a price is required for the shoe"}); 
        PicturePath.Validations.Add(new IsNotNullOrEmptyRule<string>{ValidationMessage = "a picture is required for the shoe"});
    }


    [RelayCommand]
    public async void SelectImage()
    {
        FileResult result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick Image",
            FileTypes = FilePickerFileType.Images
        });

        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            Random random = new Random();
            int randomNumber = random.Next(1, 6);

            // Combine the random number with the filename
            string randomFileName = $"sneaker{randomNumber}.jpg";
            // FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
            PicturePath.Value = randomFileName;
        }
        else 
        {
            PicturePath.Value = "Sneaker.jpg";
        }

        return;
    }

    public bool Validate()
    {
        return _unit1.Validate();
    }

    [RelayCommand]
    public async void ConfirmButton()
    {
        var isValid = this.Validate();

        Sneak.Title = "Nike";

        if(isValid)
        {
            // Populate Sneaker details if the form is valid
            Sneak.Title = this.Title.Value;
            Sneak.Description = this.Description.Value;
            Sneak.Price = double.Parse(this.Price.Value);
            Sneak.Picture = this.PicturePath.Value;

            await _dataService.AddSneakerAsync(Sneak);

            await App.Current.MainPage.DisplayAlert(":)", "Sneaker added successfully to your collection!", "OK");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert(":(", "Invalid form details to add shoe", "OK");
        }
    }
}
