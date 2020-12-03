﻿using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;


namespace Lista3_Programowanie3_Ilona_Kwasniok
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [XmlArray("DaaGridXAML"), XmlArrayItem(typeof(List<Person>), ElementName = "Person")]
        public static List<Person> PersonList = new List<Person>();
        Window1 window1 = new Window1();

        public MainWindow()
        {
            InitializeComponent();
            //window1.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Person>));

            try
            {
                using (FileStream fs=new FileStream("C:/Users/ilona/source/xmlText/listaXml.xml", FileMode.Create))
                {
                    ser.Serialize(fs, PersonList);
                }
            }
            catch(Exception blad)
            {
                MessageBox.Show(blad.Message);
            }

            
        }

        private void Refreshwindow(object sender, RoutedEventArgs e)
        {
            ListViewXAML.ItemsSource = null;
            ListViewXAML.ItemsSource = PersonList;

        }

        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Pesel { get; set; }
            public string City { get; set; }
            public string Adress { get; set; }

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            window1.Show();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var mySerializer = new XmlSerializer(typeof(List<Person>));
                var myFileStream = new FileStream("C:/Users/admin/source/xmlText/listaXml.xml", FileMode.Open);
                PersonList = (List<Person>)mySerializer.Deserialize(myFileStream);
                ListViewXAML.ItemsSource = PersonList;
            }
            catch(Exception blad)
            {
                MessageBox.Show(blad.Message);
            }
        }
    }
}
