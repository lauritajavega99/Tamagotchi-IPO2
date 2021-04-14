using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tamagochi2
{
    /// <summary>
    /// Lógica de interacción para VentanaBienvenida.xaml
    /// </summary>
    public partial class VentanaBienvenida : Window
    {
        MainWindow padre;

        public VentanaBienvenida(MainWindow padre)
        {
            InitializeComponent();
            this.padre = padre;
        }


        private void enviarNombre(object sender, RoutedEventArgs e)
        {
            if(txtNombre.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("Por favor introduzca un nombre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else{
                padre.setNombre(txtNombre.Text);
                this.Close();
            }
        }

        private void instruccionesJuego(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("El objetivo del juego mantener con vida al tamagotchi el numero máximo de segundos.\nPara ello, deberás darle de comer, que descanse o juegue.\n¡Pero ojo! Sin pasarse, ya que puede ser que el uso continuo de una función tenga efectos negativos en otra.\n\nEl número de segundos que aguante tu tamagotchi determinará tu puntuación, y cuanto esta sea mayor mayores serán tus logros y desbloquerás más niveles y coleccionables que podrás usar en tu tamagotchi. ", "Instrucciones de uso", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
