using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        
        int posLeX = 130;
        int posGhX = 130;
        int posGiX = 130;
        int limit = 520;
        enum scelta { Lepre, Ghepardo, Giraffa};
        scelta animale;
        int vincitore = 0;
        string vittoria = "";
        

        public MainWindow()
        {
            InitializeComponent();

            
            Thread t1 = new Thread(new ThreadStart(muoviLepre));
            Thread t2 = new Thread(new ThreadStart(muoviGhepardo));
            Thread t3 = new Thread(new ThreadStart(muoviGiraffa));


            ImageSource imm = new BitmapImage(uriLepre);
            imgLepre.Source = imm;

            imm = new BitmapImage(uriGhepardo);
            imgGhepardo.Source = imm;

            imm = new BitmapImage(uriGiraffa);
            imgGiraffa.Source = imm;


           
            t1.Start();
            t2.Start();
            t3.Start();
            

        }

        public void muoviLepre()
        {
            

            while(posLeX<520)
            {
                animale = scelta.Lepre;

                Thread.Sleep(TimeSpan.FromMilliseconds(200));

                if(animale==scelta.Lepre)
                    posLeX += 10;
                else if (animale == scelta.Ghepardo)
                    posGhX += 10;
                else if (animale == scelta.Giraffa)
                    posGiX += 10;


                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgLepre.Margin = new Thickness(posLeX, 80, 0, 0);
                }));
            }

            vincitore++;

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                vittoria += vincitore + " Lepre \r\n";
                lblVincitore.Content = vittoria;
            }));


        }

        public void muoviGhepardo()
        {
            while (posGhX < 520)
            {
                animale = scelta.Ghepardo;

                Thread.Sleep(TimeSpan.FromMilliseconds(200));

                if (animale == scelta.Lepre)
                    posLeX += 10;
                else if (animale == scelta.Ghepardo)
                    posGhX += 10;
                else if (animale == scelta.Giraffa)
                    posGiX += 10;

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgGhepardo.Margin = new Thickness(posGhX, 148, 0, 0);
                }));
            }

            vincitore++;

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                vittoria += vincitore + " Ghepardo \r\n";
                lblVincitore.Content = vittoria;
            }));


        }

        public void muoviGiraffa()
        {
            while (posGiX < 520)
            {
                animale = scelta.Giraffa;

                Thread.Sleep(TimeSpan.FromMilliseconds(200));

                if (animale == scelta.Lepre)
                    posLeX += 10;
                else if (animale == scelta.Ghepardo)
                    posGhX += 10;
                else if (animale == scelta.Giraffa)
                    posGiX += 10;

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgGiraffa.Margin = new Thickness(posGiX, 200, 0, 0);
                }));
            }

            vincitore++;

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                vittoria += vincitore + " Giraffa \r\n";
                lblVincitore.Content = vittoria;
            }));



        }

        

       
    }
}
