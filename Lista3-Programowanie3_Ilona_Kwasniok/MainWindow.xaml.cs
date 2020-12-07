using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            XmlSerializer ser = new XmlSerializer(typeof(List<Person>));

            try
            {

                using (FileStream fs = new FileStream("C:/Users/Ilona/source/xmlText/xmlText.xml", FileMode.Create))
                {
                    ser.Serialize(fs, PersonList);
                }

            }

            catch (Exception blad)
            {

                MessageBox.Show(blad.Message);

            }


        }

        private void Refreshwindow(object sender, RoutedEventArgs e)
        {
            ListViewXAML.ItemsSource = null;
            ListViewXAML.ItemsSource = PersonList;

        }


        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedIndex;
            if (item > -1)
            {
                Window2 win3 = new Window2(item);
                win3.Show();
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Pesel { get; set; }
            public string City { get; set; }
            public string Adress { get; set; }
            [XmlIgnore()]
            public BitmapImage Img { get; set; }
            [XmlElement("Imgxml")]
            public string imgxml { get { return Img.UriSource.ToString(); } set { Img = new BitmapImage(new Uri(value)); } }

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
           
            try
            {
                var mySerializer = new XmlSerializer(typeof(List<Person>));
                var myFileStream = new FileStream("C:/Users/Ilona/source/xmlText/xmlText.xml", FileMode.Open);
                PersonList = (List<Person>)mySerializer.Deserialize(myFileStream);
                ListViewXAML.ItemsSource = PersonList;
            }
            catch (Exception blad)
            {
                MessageBox.Show(blad.Message);
            }
        }
    }
   
}


//"C:/Users/Ilona/source/xmlText/xmlText.xml"
//openFileDialog.FileName