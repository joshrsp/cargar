using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace cargar
{
    public partial class MainPage : PhoneApplicationPage
    {
        public IsolatedStorageSettings settings;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            settings = IsolatedStorageSettings.ApplicationSettings;
            cargar();
        }

        public void cargar()
        {
            try
            {
                //Carga las configuraciones cuando se navega la pagina
                textBox1.Text = (String)settings["nombre"];
                textBox2.Text = (String)settings["edad"];
                textBox3.Text = (String)settings["sexo"];
               
            }
            catch (Exception)
            {
                //Aplicacion se usa por primera vez
                settings.Add("nombre", "");
                settings.Add("edad", "");
                settings.Add("sexo", "");
                settings.Save();
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Guardar las configuraciones cuando se abandona la pagina
            settings["nombre"] = textBox1.Text;
            settings["edad"] = textBox2.Text;
            settings["sexo"] = textBox3.Text;
            settings.Save();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {   //borra todo
            settings["nombre"] = "";
            settings["edad"] = "";
            settings["sexo"] = "";
            textBox1.Text="";
            textBox2.Text = "";
            textBox3.Text = "";
            settings.Save();
        }
    }
}