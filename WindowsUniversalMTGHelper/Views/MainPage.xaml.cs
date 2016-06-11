using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using WindowsUniversalMTGHelper.AppModel;
using WindowsUniversalMTGHelper.Model;
using WindowsUniversalMTGHelper.Model.VisualRepresentations;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsUniversalMTGHelper
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private BoardAppModel boardAppModel;

        public MainPage()
        {
            this.boardAppModel = new BoardAppModel();
            this.InitializeComponent();
        }

        private void AddPlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerScoreboardPanel.Children.Add(this.boardAppModel.addAPlayerScoreboard());
        }

        private void removePlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
