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
using System.Windows.Threading;

namespace EsercitazioneThread
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri uriLepre = new Uri("Lepre1.png",UriKind.Relative);
        readonly Uri uriGhepardo = new Uri("Ghepardo.png", UriKind.Relative);
        readonly Uri uriGiraffa = new Uri("Giraffa.png", UriKind.Relative);

        DispatcherTimer timer = new DispatcherTimer();

        int posX = 130;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_Tick;


            ImageSource imm = new BitmapImage(uriLepre);
            imgLepre.Source = imm;

            imm = new BitmapImage(uriGhepardo);
            imgGhepardo.Source = imm;

            imm = new BitmapImage(uriGiraffa);
            imgGiraffa.Source = imm;

            // timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            posX += 10;
           imgLepre.Margin= new Thickness(posX, 80, 0, 0);

        }


        }
}
