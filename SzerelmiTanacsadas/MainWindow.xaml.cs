using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SzerelmiTanacsadas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox[] tbViragokArai;
        Button[] btnNapok;
        string[] viragokNevei = new string[] { "rózsa", "tulipán", "nárcisz", "liliom", "nefelejcs", "margareta", "szegfu" };

        public MainWindow()
        {
            InitializeComponent();
            TextBoxokOsszegyujtese();
            ArakFeltoltese();
            ButtonokOsszegyujtese();
        }

        private void ButtonokOsszegyujtese()
        {
            btnNapok = new Button[] { btnHetfo, btnKedd, btnSzerda, btnCsutortok, btnPentek, btnSzombat, btnVasarnap };
        }
        
        private void TextBoxokOsszegyujtese()
        {
            tbViragokArai = new TextBox[] {tbRozsa, tbTulipan, tbNarcisz,
            tbLilion, tbNefelejcs, tbMargareta, tbSzegfu};
        }

        private void ArakFeltoltese()
        {
            tbRozsa.Text = "250";
            tbTulipan.Text = "160";
            tbNarcisz.Text = "220";
            tbLilion.Text = "350";
            tbNefelejcs.Text = "120";
            tbMargareta.Text = "180";
            tbSzegfu.Text = "90";
        }

        private void btnKilepes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nap_Click(object sender, RoutedEventArgs e)
        {
            int melyikNap = 0;

            while (sender != btnNapok[melyikNap])
            {
                melyikNap++;
            }

            tbOsszes.Text = Szamol(melyikNap).ToString();
        }

        private int Szamol(int i)
        {
            return Convert.ToInt32(tbViragokArai[i].Text) * viragokNevei[i].Length;
        }

        private void btnLegdragabb_Click(object sender, RoutedEventArgs e)
        {
            int max = 0;
            string melyikNap = "";

            for (int i = 0; i < btnNapok.Length; i++)
            {
                if (max <  Szamol(i))
                {
                    max = Szamol(i);
                    melyikNap = btnNapok[i].Content.ToString();
                }
            }

            MessageBox.Show($"{melyikNap} nap a legdrágább, értéke: {max} Ft.", "Mikor kell leányt kérni", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
