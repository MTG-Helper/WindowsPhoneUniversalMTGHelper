using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsUniversalMTGHelper.AppModel;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsUniversalMTGHelper
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private PlayerScoreboardAppModel boardAppModel;

        public MainPage()
        {
            this.boardAppModel = new PlayerScoreboardAppModel(this);
            this.InitializeComponent();
        }

        private void AddPlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {
            this.PlayerScoreboardPanel.Children.Add(this.boardAppModel.addAPlayerScoreboard());
        }

        private void removePlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.PlayerScoreboardPanel.Children.Count > 0)
            {
                this.PlayerScoreboardPanel.Children.Remove((Canvas)this.PlayerScoreboardPanel.Children.Last());
            }
        }

        public void removeSpecificPlayerScoreBoard(Canvas canvas)
        {
            this.PlayerScoreboardPanel.Children.Remove(canvas);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (object child in PlayerScoreboardPanel.Children)
            {
                //(((Canvas)child).Children[0]);
            }
        }
    }
}
