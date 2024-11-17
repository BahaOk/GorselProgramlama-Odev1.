
namespace GorselProgramlamaOdev1;
public partial class VucutKiloIndex : ContentPage
{
	

	public VucutKiloIndex()
	{
		InitializeComponent();
		 
	}

  private void vkiHesaplama(object sender, TextChangedEventArgs e)
    {
       
        if (double.TryParse(KiloDegeri.Text, out double kilo) && double.TryParse(BoyDegeri.Text, out double boy))
        {
            double boyMetre = boy / 100;

         
            double vki = kilo / (boyMetre * boyMetre);

                string vkiAciklama = "";

                if (vki < 16)
                {
                    vkiAciklama = "İleri Zayıf";
                }
                else if (vki >= 16 && vki < 16.99)
                {
                    vkiAciklama = "Orta Zayıf";
                }
                else if (vki >= 17 && vki <= 18.49)
                {
                    vkiAciklama = "Hafif Zayıf";
                }
                else if (vki > 18.50 && vki <= 24.9)
                {
                    vkiAciklama = "Normal Kilolu";
                }
                else if (vki > 25 && vki <= 29.99)
                {
                    vkiAciklama = "Fazla Kilolu";
                }
                else if (vki > 30 && vki <= 34.99)
                {
                    vkiAciklama = "1.Derece Obez";
                }

                else if (vki > 35 && vki <= 39.99)
                {
                    vkiAciklama = "2.Derece Obez";
                }


                else if (vki > 40)
                {
                    vkiAciklama = "Mobrid Obez";
                }
    
           VkiLabel.Text = $"VKI: {vki:F2} - {vkiAciklama}";
        }
        else
        {
            VkiLabel.Text = "Lütfen geçerli bir kilo ve boy girin.";
        }

        
}

}