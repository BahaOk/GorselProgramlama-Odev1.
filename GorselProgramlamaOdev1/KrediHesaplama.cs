namespace GorselProgramlamaOdev1;
public partial class KrediHesaplama : ContentPage
{

    public double faiz_kkdf = 0.0;
    public double faiz_bsmv = 0.0;


    private void OnVadeEntryChanged(object sender, TextChangedEventArgs e)
    {
        if (double.TryParse(VadeDegeri.Text, out double vade))
        {
            if (vade >= VadeSlider.Minimum && vade <= VadeSlider.Maximum)
            {
                VadeSlider.Value = vade;
            }
        }
    }
    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        VadeDegeri.Text = ((int)VadeSlider.Value).ToString();
    }

	private void KrediPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KrediPicker.SelectedIndex == -1)
                return; 

            string selectedKredi = KrediPicker.Items[KrediPicker.SelectedIndex];

         
  
            switch (selectedKredi)
            {
                case "İhtiyaç Kredisi":
                    faiz_kkdf = 0.15;
                    faiz_bsmv = 0.1;
                    break;

                case "Konut Kredisi":
                     faiz_kkdf = 0;
                     faiz_bsmv = 0;
                    break;

                case "Taşıt Kredisi":
                    faiz_kkdf = 0.15;
                    faiz_bsmv = 0.05;
                    break;

                case "Ticari Kredi":
                    faiz_bsmv= 0.05;
                    faiz_kkdf = 0;
                    break;
            }
        }

	public KrediHesaplama()
	{
		InitializeComponent();
	}

    private void Kredi_Hesaplama(object sender, EventArgs e)
    {
        string tutar = KrediTutari.Text;
        string faiz = FaizOrani.Text;
        string vade = VadeDegeri.Text;

        double KrediTutar;
        double KrediOran;
        int KrediVade;
         
         bool tutarDonusum = double.TryParse(tutar,out KrediTutar);   
         bool faizDonusum = double.TryParse(faiz, out KrediOran);
         bool vadeDonusum = int.TryParse(vade, out KrediVade); 


        double brut_faiz =((KrediOran + (KrediOran *  faiz_bsmv) + (KrediOran * faiz_kkdf)) / 100);
        double taksit = Math.Pow(1 + brut_faiz, KrediVade) * brut_faiz / (Math.Pow(1 + brut_faiz, KrediVade) - 1) * KrediTutar;
        double toplam = taksit * KrediVade;
        double toplamFaiz = toplam - KrediTutar;

        ToplamOdeme.Text  = $"Toplam Odeme: {toplam.ToString()}";
        AylikTaksit.Text = $"Aylık Taksit: {taksit.ToString()}";
        ToplamFaiz.Text = $"Toplam Faiz : {toplamFaiz.ToString()}";
    }

}
