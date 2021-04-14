using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tamagochi2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        string nombre;
        int estado = 0;
        double decremento = 2.0;
        int contador = 0;
        DispatcherTimer t1;
        SoundPlayer musica = new SoundPlayer();

        public MainWindow()
        {
            InitializeComponent();
            musica.SoundLocation = Directory.GetCurrentDirectory()+"\\sonidos\\introS.wav";
            musica.Play();
            VentanaBienvenida pantallaInicio = new VentanaBienvenida(this);
            pantallaInicio.ShowDialog();

            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(1000.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
     
        }

        private void reloj(object sender, EventArgs e)
        {
            ++contador;
            this.pbAlimentar.Value -= decremento;
            this.pbDescansar.Value -= decremento;
            this.pbJugar.Value -= decremento;

            //DEFINICIÓN DE NIVELES,COLECCIONABLES Y LOGROS
            definirNiveles();

            //ESTADO NEGATIVO
            ponerEstadoNegativo();

            //ESTADO POSITIVO
            ponerEstadoPositivo();

            //FIN PARTIDA
            finalizarPartida();

        }

        private void resetearJuego()
        {
         
            contador = 0;
            decremento = 1.0;
            this.btnJugar.IsEnabled = true;
            this.btnDescansar.IsEnabled = true;
            this.btnAlimentar.IsEnabled = true;

            pbAlimentar.Value = 100;
            pbDescansar.Value = 100;
            pbJugar.Value = 100;

            imgNvl1.Opacity = 0.4;
            imgNvl2.Opacity = 0.4;
            imgNvl3.Opacity = 0.4;
            imgNvl4.Opacity = 0.4;
            imgNvl5.Opacity = 0.4;
            imgNvl6.Opacity = 0.4;
            imgNvl7.Opacity = 0.4;
            imgNvl8.Opacity = 0.4;
            imgNvl9.Opacity = 0.4;
            imgNvl10.Opacity = 0.4;
            imgNvl11.Opacity = 0.4;
            imgNvl12.Opacity = 0.4;
            imgNvl13.Opacity = 0.4;
            imgNvl14.Opacity = 0.4;
            imgNvl15.Opacity = 0.4;
            imgNvl16.Opacity = 0.4;

            img_Coleccionable.Visibility = Visibility.Hidden;
            img_Coleccionable2.Visibility = Visibility.Hidden;
            img_Coleccionable3.Visibility = Visibility.Hidden;
            img_Coleccionable4.Visibility = Visibility.Hidden;
            img_Coleccionable5.Visibility = Visibility.Hidden;
            img_Coleccionable6.Visibility = Visibility.Hidden;

            wpComida.Visibility = Visibility.Hidden;
            imgCollar.Visibility = Visibility.Hidden;
            imgGafas.Visibility = Visibility.Hidden;
            imgGorro.Visibility = Visibility.Hidden;

            listBox1.Items.Clear();

            pbJugar.Foreground = new SolidColorBrush(Colors.Green);
            pbDescansar.Foreground = new SolidColorBrush(Colors.Green);
            pbAlimentar.Foreground = new SolidColorBrush(Colors.Green);

            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(1000.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();
        }

        private void aniadirPremios(int num, int nivel)
        {
            switch(num){
                case 0:
                    listBox1.Items.Add("¡Has desbloqueado el nivel"+nivel+" !");
                    break;
                case 1:
                    listBox1.Items.Add("¡Has conseguido un coleccionable!");
                    break;
            }
        }

        private void definirNiveles()

        {
            //Niveles
            if (contador >= 5 && contador <= 7 && imgNvl1.Opacity != 100)
            {
                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\premioS.wav";
                musica.Play();
                imgNvl1.Opacity = 100;
                img_Coleccionable.Visibility = Visibility.Visible;
                aniadirPremios(0, 1);
                aniadirPremios(1, 1);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel"];
                sbaux.Begin();
            }

            if (contador >= 8 && contador <= 12 && imgNvl2.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                aniadirPremios(0, 2);
                Storyboard sbaux1 = (Storyboard)this.Resources["girarNivel2"];
                sbaux1.Begin();
            }

            if (contador >= 13 && contador <= 16 && imgNvl3.Opacity != 100)
            {
                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\premioS.wav";
                musica.Play();
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                img_Coleccionable2.Visibility = Visibility.Visible;
                aniadirPremios(0, 3);
                aniadirPremios(1, 3);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel3"];
                sbaux.Begin();
            }

            if (contador >= 17 && contador <= 20 && imgNvl4.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                aniadirPremios(0, 4);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel4"];
                sbaux.Begin();
            }

            if (contador >= 21 && contador <= 26 && imgNvl5.Opacity != 100)
            {
                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\premioS.wav";
                musica.Play();
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                img_Coleccionable6.Visibility = Visibility.Visible;
                aniadirPremios(0, 5);
                aniadirPremios(1, 5);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel5"];
                sbaux.Begin();
            }

            if (contador >= 27 && contador <= 32 && imgNvl6.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                
                aniadirPremios(0, 6);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel6"];
                sbaux.Begin();
            }

            if (contador >= 33 && contador <= 38 && imgNvl7.Opacity != 100)
            {
                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\premioS.wav";
                musica.Play();
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                img_Coleccionable3.Visibility = Visibility.Visible;
                aniadirPremios(0, 7);
                aniadirPremios(1, 7);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel7"];
                sbaux.Begin();
            }

            if (contador >= 39 && contador <= 47 && imgNvl8.Opacity != 100)
            {
               
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                aniadirPremios(0, 8);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel8"];
                sbaux.Begin();

            }

            if (contador >= 48 && contador <= 60 && imgNvl9.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                aniadirPremios(0, 9);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel9"];
                sbaux.Begin();
            }

            if (contador >= 61 && contador <= 73 && imgNvl10.Opacity != 100)
            {
                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\premioS.wav";
                musica.Play();
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                imgNvl10.Opacity = 100;
                img_Coleccionable4.Visibility = Visibility.Visible;
                aniadirPremios(0, 10);
                aniadirPremios(1, 10);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel10"];
                sbaux.Begin();
            }

            if (contador >= 74 && contador <= 85 && imgNvl11.Opacity != 100)
            {

                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                imgNvl10.Opacity = 100;
                imgNvl11.Opacity = 100;
                aniadirPremios(0, 11);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel11"];
                sbaux.Begin();
            }

            if (contador >= 86 && contador <= 96 && imgNvl12.Opacity != 100)
            {
                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\premioS.wav";
                musica.Play();
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                imgNvl10.Opacity = 100;
                imgNvl11.Opacity = 100;
                imgNvl12.Opacity = 100;
                img_Coleccionable5.Visibility = Visibility.Visible;
                aniadirPremios(0, 12);
                aniadirPremios(1, 12);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel12"];
                sbaux.Begin();
            }

            if (contador >= 97 && contador <= 105 && imgNvl13.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                imgNvl10.Opacity = 100;
                imgNvl11.Opacity = 100;
                imgNvl12.Opacity = 100;
                imgNvl13.Opacity = 100;
                aniadirPremios(0, 13);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel13"];
                sbaux.Begin();
            }

            if (contador >= 106 && contador <= 115 && imgNvl14.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                imgNvl10.Opacity = 100;
                imgNvl11.Opacity = 100;
                imgNvl12.Opacity = 100;
                imgNvl13.Opacity = 100;
                imgNvl14.Opacity = 100;
                aniadirPremios(0, 14);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel14"];
                sbaux.Begin();
            }

            if (contador >= 116 && contador <= 120 && imgNvl15.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                imgNvl10.Opacity = 100;
                imgNvl11.Opacity = 100;
                imgNvl12.Opacity = 100;
                imgNvl13.Opacity = 100;
                imgNvl14.Opacity = 100;
                imgNvl15.Opacity = 100;
                aniadirPremios(0, 15);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel15"];
                sbaux.Begin();
            }

            if (contador >= 121 && contador <= 130 && imgNvl16.Opacity != 100)
            {
                imgNvl1.Opacity = 100;
                imgNvl2.Opacity = 100;
                imgNvl3.Opacity = 100;
                imgNvl4.Opacity = 100;
                imgNvl5.Opacity = 100;
                imgNvl6.Opacity = 100;
                imgNvl7.Opacity = 100;
                imgNvl8.Opacity = 100;
                imgNvl9.Opacity = 100;
                imgNvl10.Opacity = 100;
                imgNvl11.Opacity = 100;
                imgNvl12.Opacity = 100;
                imgNvl13.Opacity = 100;
                imgNvl14.Opacity = 100;
                imgNvl15.Opacity = 100;
                imgNvl16.Opacity = 100;
                aniadirPremios(0, 16);
                Storyboard sbaux = (Storyboard)this.Resources["girarNivel16"];
                sbaux.Begin();
            }

        }

        private void btnDescansar_Click(object sender, RoutedEventArgs e)
        {
            musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\bostezoS.wav";
            musica.Play();

            this.pbDescansar.Value += 15;
            this.pbJugar.Value += 5;
            this.pbAlimentar.Value -= 8;
           
            this.btnDescansar.IsEnabled = false;

            DoubleAnimation cerrarOjoDer = new DoubleAnimation();
            cerrarOjoDer.From = 5;
            cerrarOjoDer.Duration = new Duration(TimeSpan.FromSeconds(2));
            //cerrarOjoDer.AutoReverse = true;
            cerrarOjoDer.Completed += new EventHandler(finCerrarOjoDer);

            DoubleAnimation cerrarOjoIzq = new DoubleAnimation();
            cerrarOjoIzq.From = 5;
            cerrarOjoIzq.Duration = new Duration(TimeSpan.FromSeconds(2));
            //cerrarOjoIzq.AutoReverse = true;


            elOjoDer.BeginAnimation(Ellipse.HeightProperty, cerrarOjoDer);
            elOjoIzq.BeginAnimation(Ellipse.HeightProperty, cerrarOjoIzq);

        }

        private void finCerrarOjoDer(object sender, EventArgs e)
        {
            this.btnDescansar.IsEnabled = true;
        }

        private void finJugar(object sender, EventArgs e)
        {
            this.btnJugar.IsEnabled = true;
        }

        private void finComer(object sender, EventArgs e)
        {
            this.btnAlimentar.IsEnabled = true;
            wpComida.Visibility = Visibility.Hidden;
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\pelota.wav";
            musica.Play();

            this.pbJugar.Value += 15;
            this.pbAlimentar.Value -= 8;
            this.btnJugar.IsEnabled = false;
           
            Storyboard sbaux = (Storyboard)this.Resources["animacionJugar"];
            sbaux.Completed += new EventHandler(finJugar);
            sbaux.Begin();
         
        }

        private void btnAlimentar_Click(object sender, RoutedEventArgs e)
        {
       
            wpComida.Visibility = Visibility.Visible;
            this.pbAlimentar.Value += 15;
            this.pbDescansar.Value += 5;
            this.btnAlimentar.IsEnabled = false;

        }

        private void img_Coleccionable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.imgFondo.Source = ((Image)sender).Source;
        }

        private void img_Coleccionable2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.imgFondo.Source = ((Image)sender).Source;
        }

        private void acercaDe(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show("Programa realizado por \nLaura Muñoz Jávega.\n\n ¿Desea Salir?", "Acerca de", MessageBoxButton.YesNo);

            switch (resultado)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
            txtMensaje.Content = "¡Bienvenid@ " + nombre + "!";
        }

        private void inicioArrastrarGorro(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void añadirObjeto(object sender, DragEventArgs e)
        {
            Image aux = (Image)e.Data.GetData(typeof(Image));
            switch (aux.Name)
            {
                case "img_Coleccionable4":
                    imgGorro.Visibility = Visibility.Visible;
                    break;
                case "img_Coleccionable3":
                    imgGafas.Visibility = Visibility.Visible;
                    break;
                case "img_Coleccionable5":
                    imgCollar.Visibility = Visibility.Visible;
                    florCollar.Visibility = Visibility.Hidden;
                    break;
                case "img_carne":
                    musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\comerS.wav";// direccion del sonido
                    musica.Play();

                    Storyboard sbaux = (Storyboard)this.Resources["animacionComer"];
                    sbaux.Completed += new EventHandler(finComer);
                    sbaux.Begin();
                    break;

                case "img_pizza":
                    musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\comerS.wav";// direccion del sonido
                    musica.Play();

                    sbaux = (Storyboard)this.Resources["animacionComer"];
                    sbaux.Completed += new EventHandler(finComer);
                    sbaux.Begin();
                    break;
                case "img_hamburguesa":
                    musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\comerS.wav";// direccion del sonido
                    musica.Play();

                    sbaux = (Storyboard)this.Resources["animacionComer"];
                    sbaux.Completed += new EventHandler(finComer);
                    sbaux.Begin();
                    break;
                case "img_fresas":
                    musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\comerS.wav";// direccion del sonido
                    musica.Play();

                    sbaux = (Storyboard)this.Resources["animacionComer"];
                    sbaux.Completed += new EventHandler(finComer);
                    sbaux.Begin();
                    break;
                case "img_lechuga":
                    musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\comerS.wav";// direccion del sonido
                    musica.Play();

                    sbaux = (Storyboard)this.Resources["animacionComer"];
                    sbaux.Completed += new EventHandler(finComer);
                    sbaux.Begin();
                    break;
                case "img_gamba":
                    musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\comerS.wav";// direccion del sonido
                    musica.Play();

                    sbaux = (Storyboard)this.Resources["animacionComer"];
                    sbaux.Completed += new EventHandler(finComer);
                    sbaux.Begin();
                    break;
            }
        }

        private void eliminarObjeto(object sender, DragEventArgs e)
        {
            Image aux = (Image)e.Data.GetData(typeof(Image));
            switch (aux.Name)
            {
                case "imgGorro":
                    imgGorro.Visibility = Visibility.Hidden;
                    break;
                case "imgGafas":
                    imgGafas.Visibility = Visibility.Hidden;
                    break;
                case "imgCollar":
                    imgCollar.Visibility = Visibility.Hidden;
                    florCollar.Visibility = Visibility.Visible;
                    break;


            }
        }

        private void inicioArrastrarGafas(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void inicioArrastrarCollar(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);

        }

        private void configurarRanking(string nombre, int puntos)
        {
            if (puntos > Convert.ToInt32(lblScore3.Content))
            {
                if (puntos > Convert.ToInt32(lblScore2.Content))
                {
                    if (puntos > Convert.ToInt32(lblScore1.Content))
                    {
                        lblJugador3.Content = lblJugador2.Content;
                        lblScore3.Content = lblScore2.Content;
                        lblJugador2.Content = lblJugador1.Content;
                        lblScore2.Content = lblScore1.Content;

                        lblJugador1.Content = nombre;
                        lblScore1.Content = puntos;
                    }
                    else
                    {
                        lblJugador3.Content = lblJugador2.Content;
                        lblScore3.Content = lblScore2.Content;

                        lblJugador2.Content = nombre;
                        lblScore2.Content = puntos;
                    }
                }
                else
                {
                    lblJugador3.Content = nombre;
                    lblScore3.Content = puntos;
                }
            }
        }

        private void inicioArrastrarComida(object sender, MouseButtonEventArgs e)
        {
            DataObject dataO = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, dataO, DragDropEffects.Move);
        }

        private void img_Coleccionable6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.imgFondo.Source = ((Image)sender).Source;
        }

        private void ponerEstadoNegativo()
        {
            //ESTADO NEGATIVO
            if (pbJugar.Value <= 15)
            {
                estado = 1;
                Storyboard sbaux = (Storyboard)this.Resources["ponertriste"];
                sbaux.Begin();
                pbJugar.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (pbDescansar.Value <= 15)
            {
                estado = 1;
                Storyboard sbaux = (Storyboard)this.Resources["ponertriste"];
                sbaux.Begin();
                pbDescansar.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (pbAlimentar.Value <= 15)
            {
                estado = 1;
                Storyboard sbaux = (Storyboard)this.Resources["ponertriste"];
                sbaux.Begin();
                pbAlimentar.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void ponerEstadoPositivo()
        {
            if (pbJugar.Value > 15 && pbDescansar.Value > 15 && pbAlimentar.Value > 15 && estado != 0)
            {
                Storyboard sbaux = (Storyboard)this.Resources["ponerfeliz"];
                sbaux.Begin();

            }

            if (pbJugar.Value > 15)
            {
                pbJugar.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (pbDescansar.Value > 15)
            {
                pbDescansar.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (pbAlimentar.Value > 15)
            {
                pbAlimentar.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        private void finalizarPartida()
        {
            if (pbJugar.Value == 0 || pbDescansar.Value == 0 || pbAlimentar.Value == 0)
            {
                t1.Stop();
                this.btnJugar.IsEnabled = false;
                this.btnDescansar.IsEnabled = false;
                this.btnAlimentar.IsEnabled = false;

                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\gameoverS.wav";// direccion del sonido
                musica.Play();

                MessageBoxResult result = MessageBox.Show("GAME OVER! \n Su puntuación ha sido de " + contador + " puntos. \n\n ¿Desea continuar jugando?", "Tamagotchi & Friends", MessageBoxButton.YesNo);
                configurarRanking(nombre, contador);

                switch (result)
                {
                    //reset juego
                    case MessageBoxResult.Yes:

                        MessageBoxResult result1 = MessageBox.Show("¿Quiere usar el mismo jugador o cambiar?", "Tamagotchi & Friends", MessageBoxButton.YesNo);

                        switch (result1)
                        {
                            case MessageBoxResult.Yes:
                                resetearJuego();
                                break;
                            case MessageBoxResult.No:
                                musica.SoundLocation = Directory.GetCurrentDirectory() + "\\sonidos\\introS.wav";// direccion del sonido
                                musica.Play();
                                VentanaBienvenida pantallaInicio1 = new VentanaBienvenida(this);
                                pantallaInicio1.ShowDialog();
                                resetearJuego();
                                break;
                        }

                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                }

            }
        }
    }

        
}
