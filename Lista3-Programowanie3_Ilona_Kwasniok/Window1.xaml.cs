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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Lista3_Programowanie3_Ilona_Kwasniok
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private string namefield;
        private string surnamefield;
        private string peselfield;
        private string cityfield;
        private string adressfield;
        public Window1()
        {
            InitializeComponent();
        }


        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {

            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }


        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Podana wartość jest zła!", ex.Message);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            namefield = Name.Text;
            surnamefield = Surname.Text;
            peselfield = Pesel.Text;
            cityfield = City.Text;
            adressfield = Adress.Text;

            try
            {
                MainWindow.PersonList.Add(new MainWindow.Person() { Name = namefield, Surname = surnamefield, Pesel = peselfield, City = cityfield, Adress = adressfield });
            }
            catch(Exception blad)
            {
                MessageBox.Show(blad.Message);
            }
        }
    }
}
