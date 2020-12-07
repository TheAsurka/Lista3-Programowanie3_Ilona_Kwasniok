﻿using System;
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
using System.IO;
using Microsoft.Win32;

namespace Lista3_Programowanie3_Ilona_Kwasniok
{
   

    public partial class Window1 : Window
    {

        private string namefield;
        private string surnamefield;
        private string peselfield;
        private string cityfield;
        private string adressfield;
        string tmpName;
        string tmpSurname;
        string tmpCity;
        string tmpAdress;
        private BitmapImage imageyes;






        public Window1()
        {
            InitializeComponent();
        }


        private void LetterValidationTextBoxName(object sender, TextCompositionEventArgs e)
        {
            

            string input = (sender as TextBox).Text;
            if (Name.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[A-Z]{1}[a-z]{1,81}$"))
                {
                    MessageBox.Show("Wielka litera!");
                    Name.Text = tmpName;
                   
                }
                tmpName = Name.Text;
            }



        }

        private void LetterValidationTextBoxSurname(object sender, TextCompositionEventArgs e)
        {


            string input = (sender as TextBox).Text;
            if (Surname.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[A-Z]{1}[a-z]{1,81}$"))
                {
                    MessageBox.Show("Wielka litera!");
                    Surname.Text = tmpSurname;

                }
                tmpSurname = Surname.Text;
            }



        }

        private void LetterValidationTextBoxCity(object sender, TextCompositionEventArgs e)
        {


            string input = (sender as TextBox).Text;
            if (City.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[A-Z]{1}[a-z]{1,81}$"))
                {
                    MessageBox.Show("Wielka litera!");
                    City.Text = tmpCity;

                }
                tmpCity = City.Text;
            }

        }


        private void LetterValidationTextBoxAdress(object sender, TextCompositionEventArgs e)
        {


            string input = (sender as TextBox).Text;
            if (Adress.Text.Length > 1)
            {
                if (!Regex.IsMatch(input, @"^[A-Z]{1}[a-z]{1,81}$"))
                {
                    MessageBox.Show("Wielka litera!");
                    Adress.Text = tmpAdress;

                }
                tmpAdress = Adress.Text;
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
           
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);

            
        }


        private void Img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                string filePath;
                openFileDialog.InitialDirectory = Environment.CurrentDirectory;
                openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == true)
                {

                    filePath = openFileDialog.FileName;
                    Uri uri1 = new Uri(filePath);
                    ImgFile.Source = new BitmapImage(uri1);
                    imageyes = new BitmapImage(uri1);
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            namefield = Name.Text;
            surnamefield = Surname.Text;
            peselfield = Pesel.Text;
            cityfield = City.Text;
            adressfield = Adress.Text;


            if (Surname.Text.Length < 1 || Name.Text.Length < 1 || City.Text.Length < 1 || Adress.Text.Length < 1)
            {
                MessageBox.Show("Pola nie mogą być puste");
            }
            else
            {
                try
                {
                    MainWindow.PersonList.Add(new MainWindow.Person() { Name = namefield, Surname = surnamefield, Pesel = peselfield, City = cityfield, Adress = adressfield, Img = imageyes });
                }
                catch (Exception blad)
                {
                    MessageBox.Show(blad.Message);
                }
            }
        }
    }
}
