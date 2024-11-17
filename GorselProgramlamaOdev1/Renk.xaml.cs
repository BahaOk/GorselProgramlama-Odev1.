namespace GorselProgramlamaOdev1;

public partial class Renk : ContentPage
{
    public Renk()
    {
        InitializeComponent();
       
    }
    private void RenkSliderDeger(object sender, ValueChangedEventArgs e)
    {
        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

        RedValueLabel.Text = red.ToString();
        GreenValueLabel.Text = green.ToString();
        BlueValueLabel.Text = blue.ToString();

        ColorPreviewBox.BackgroundColor = Color.FromRgb(red, green, blue);
        HtmlCodeLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";
    }

    private async void RenkKoduClicked(object sender, EventArgs e)
    {
       
        string htmlCode = HtmlCodeLabel.Text;

       
        await Clipboard.Default.SetTextAsync(htmlCode);

        
        await DisplayAlert("Kopyalandı", $"HTML kodu ({htmlCode}) panoya kopyalandı!", "Tamam");
    }
}
