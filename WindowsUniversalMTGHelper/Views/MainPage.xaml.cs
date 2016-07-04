using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsUniversalMTGHelper.AppModel;
using WindowsUniversalMTGHelper.Model;
using WindowsUniversalMTGHelper.Views;
using WindowsUniversalMTGHelper.Views.ObjectVisualsRepresentations;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsUniversalMTGHelper
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private PlayerScoreboardAppModel boardAppModel;
        private StackPanel PlayerScoreboardPanel;

        public MainPage()
        {
            this.initializeComponents();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
        }

        /// <summary>
        /// Initialize the components for this class.
        /// </summary>
        private void initializeComponents()
        {
            this.InitializeComponent();
            this.boardAppModel = new PlayerScoreboardAppModel(this);
            this.PlayerScoreboardPanel = new StackPanel();
            this.scrollViewer.Content = this.PlayerScoreboardPanel;

        }

        /// <summary>
        /// Add one player scoreboard on screen.
        /// </summary>
        private void AddPlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {
            this.PlayerScoreboardPanel.Children.Add(this.boardAppModel.addAPlayerScoreboard());
        }

        /// <summary>
        /// Remove the last player scoreboard on screen.
        /// </summary>
        private void removePlayerScoreboardButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.PlayerScoreboardPanel.Children.Count > 0)
            {
                this.PlayerScoreboardPanel.Children.Remove((Canvas)this.PlayerScoreboardPanel.Children.Last());
            }
        }

        /// <summary>
        /// Remove the selected player scoreboard on screen.
        /// </summary>
        public void removeSpecificPlayerScoreBoard(Canvas canvas)
        {
            this.PlayerScoreboardPanel.Children.Remove(canvas);
        }

        /// <summary>
        /// Reset all player scoreboard on screen.
        /// </summary>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (object child in PlayerScoreboardPanel.Children)
            {
                ((PlayerScoreboard)((Canvas)child).DataContext).reset();
            }
        }

        /// <summary>
        /// Comeback to the player scoreboard view.
        /// </summary>
        public void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.scrollViewer.Content = this.PlayerScoreboardPanel;
        }

        /// <summary>
        /// Flip a coin.
        /// </summary>
        private void CoinButton_Click(object sender, RoutedEventArgs e)
        {
            this.scrollViewer.Content = (new TokenGenerator(this)).flipCoin();

        }

        /// <summary>
        /// Roll a dice.
        /// </summary>
        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.scrollViewer.Content = (new TokenGenerator(this)).rollDice();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchPage));
        }
    }
}
