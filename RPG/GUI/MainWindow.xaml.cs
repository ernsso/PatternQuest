using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RPG;

namespace GUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimpleSimulation_Button_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gw = new GameWindow(1);
            gw.Show();
            this.Close();
        }

        private void LabyrinthSimulation_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuestSimulation_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
