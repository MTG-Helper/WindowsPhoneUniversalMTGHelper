using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace WindowsUniversalMTGHelper.Model.VisualRepresentations
{
    public class PlayerScoreboardPostix
    {
        private Canvas myCanvas;
        private PlayerScoreboard owner;
        private TextBlock playerLifePointsNumberTextBlock;
        private TextBlock playerPoisonPointNumberTextBlock;

        public PlayerScoreboardPostix(PlayerScoreboard owner)
        {
            this.owner = owner;
            this.initializeCanvas();

        }

        private void initializeCanvas()
        {
            Rectangle shape = new Rectangle();
            shape.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            shape.StrokeThickness = 3;
            shape.Fill = this.getRamdomColor();
            shape.Width = 250;
            shape.Height = 150;

            this.myCanvas = new Canvas();
            this.myCanvas.Width = 250;
            this.myCanvas.Height = 150;
            this.myCanvas.Margin = new Thickness(0, 0, 0, 20);
            this.myCanvas.Children.Add(shape);

            TextBox playerNameTextBlock = new TextBox();
            playerNameTextBlock.FontSize = 20;
            playerNameTextBlock.BorderThickness = new Thickness(0, 0, 0, 0);
            playerNameTextBlock.Background = new SolidColorBrush(Windows.UI.Colors.Transparent);
            playerNameTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            playerNameTextBlock.Margin = new Thickness(5, 0, 0, 0);
            playerNameTextBlock.Text = this.owner.getPlayerName();

            TextBlock playerLifePointsTextBlock = new TextBlock();
            playerLifePointsTextBlock.FontSize = 20;
            playerLifePointsTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            playerLifePointsTextBlock.Margin = new Thickness(15, 0, 0, 0);
            playerLifePointsTextBlock.Text = "LIFE POINTS: ";

            TextBlock playerPoisonPointsTextBlock = new TextBlock();
            playerPoisonPointsTextBlock.FontSize = 20;
            playerPoisonPointsTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            playerPoisonPointsTextBlock.Margin = new Thickness(15, 0, 0, 0);
            playerPoisonPointsTextBlock.Text = "POISON POINTS: ";

            this.playerLifePointsNumberTextBlock = new TextBlock();
            this.playerLifePointsNumberTextBlock.FontSize = 20;
            this.playerLifePointsNumberTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerLifePointsNumberTextBlock.Margin = new Thickness(15, 0, 0, 0);
            this.playerLifePointsNumberTextBlock.Text = "" + this.owner.getLifePoints();

            this.playerPoisonPointNumberTextBlock = new TextBlock();
            this.playerPoisonPointNumberTextBlock.FontSize = 20;
            this.playerPoisonPointNumberTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            this.playerPoisonPointNumberTextBlock.Margin = new Thickness(15, 0, 0, 0);
            this.playerPoisonPointNumberTextBlock.Text = "" + this.owner.getPoisonPoints();

            TextBlock lpTextBlock = new TextBlock();
            lpTextBlock.FontSize = 20;
            lpTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            lpTextBlock.Margin = new Thickness(15, 0, 0, 0);
            lpTextBlock.Text = "LP: ";

            TextBlock ppTextBlock = new TextBlock();
            ppTextBlock.FontSize = 20;
            ppTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
            ppTextBlock.Margin = new Thickness(15, 0, 0, 0);
            ppTextBlock.Text = "PP: ";

            Button plusOneLpButton = new Button();
            plusOneLpButton.Name = "+1";
            plusOneLpButton.Content = "+1";
            plusOneLpButton.Margin = new Thickness(15, 0, 0, 0);
            plusOneLpButton.Click += new RoutedEventHandler(addOneLifePointsButtonCLick);

            Button subOneLpButton = new Button();
            subOneLpButton.Name = "-1";
            subOneLpButton.Content = "-1";
            subOneLpButton.Margin = new Thickness(15, 0, 0, 0);
            subOneLpButton.Click += new RoutedEventHandler(subOneLifePointsButtonCLick);

            Button plusFiveLpButton = new Button();
            plusFiveLpButton.Name = "+5";
            plusFiveLpButton.Content = "+5";
            plusFiveLpButton.Margin = new Thickness(15, 0, 0, 0);
            plusFiveLpButton.Click += new RoutedEventHandler(addFiveLifePointsButtonCLick);

            Button subFiveLpButton = new Button();
            subFiveLpButton.Name = "-5";
            subFiveLpButton.Content = "-5";
            subFiveLpButton.Margin = new Thickness(15, 0, 0, 0);
            subFiveLpButton.Click += new RoutedEventHandler(subFiveLifePointsButtonCLick);

            Button plusOnePpButton = new Button();
            plusOnePpButton.Name = "+1";
            plusOnePpButton.Content = "+1";
            plusOnePpButton.Margin = new Thickness(15, 0, 0, 0);
            plusOnePpButton.Click += new RoutedEventHandler(addOnePoisonPointsButtonCLick);

            Button subOnePpButton = new Button();
            subOnePpButton.Name = "-1";
            subOnePpButton.Content = "-1";
            subOnePpButton.Margin = new Thickness(15, 0, 0, 0);
            subOnePpButton.Click += new RoutedEventHandler(subOnePoisonPointsButtonCLick);

            Button plusFivePpButton = new Button();
            plusFivePpButton.Name = "+5";
            plusFivePpButton.Content = "+5";
            plusFivePpButton.Margin = new Thickness(15, 0, 0, 0);
            plusFivePpButton.Click += new RoutedEventHandler(addFivePoisonPointsButtonCLick);

            Button subFivePpButton = new Button();
            subFivePpButton.Name = "-5";
            subFivePpButton.Content = "-5";
            subFivePpButton.Margin = new Thickness(15, 0, 0, 0);
            subFivePpButton.Click += new RoutedEventHandler(subFivePoisonPointsButtonCLick);

            Canvas.SetTop(playerNameTextBlock, 0);
            Canvas.SetLeft(playerNameTextBlock, 0);
            this.myCanvas.Children.Add(playerNameTextBlock);

            Canvas.SetTop(playerLifePointsTextBlock, 25);
            Canvas.SetLeft(playerLifePointsTextBlock, 0);
            this.myCanvas.Children.Add(playerLifePointsTextBlock);

            Canvas.SetTop(playerLifePointsNumberTextBlock, 25);
            Canvas.SetLeft(playerLifePointsNumberTextBlock, 120);
            this.myCanvas.Children.Add(playerLifePointsNumberTextBlock);

            Canvas.SetTop(playerPoisonPointNumberTextBlock, 45);
            Canvas.SetLeft(playerPoisonPointNumberTextBlock, 155);
            this.myCanvas.Children.Add(playerPoisonPointNumberTextBlock);

            Canvas.SetTop(playerPoisonPointsTextBlock, 45);
            Canvas.SetLeft(playerPoisonPointsTextBlock, 0);
            this.myCanvas.Children.Add(playerPoisonPointsTextBlock);

            Canvas.SetTop(lpTextBlock, 75);
            Canvas.SetLeft(lpTextBlock, 0);
            this.myCanvas.Children.Add(lpTextBlock);

            Canvas.SetTop(plusOneLpButton, 75);
            Canvas.SetLeft(plusOneLpButton, 30);
            this.myCanvas.Children.Add(plusOneLpButton);

            Canvas.SetTop(subOneLpButton, 75);
            Canvas.SetLeft(subOneLpButton, 75);
            this.myCanvas.Children.Add(subOneLpButton);

            Canvas.SetTop(plusFiveLpButton, 75);
            Canvas.SetLeft(plusFiveLpButton, 120);
            this.myCanvas.Children.Add(plusFiveLpButton);

            Canvas.SetTop(subFiveLpButton, 75);
            Canvas.SetLeft(subFiveLpButton, 165);
            this.myCanvas.Children.Add(subFiveLpButton);

            Canvas.SetTop(ppTextBlock, 112);
            Canvas.SetLeft(ppTextBlock, 0);
            this.myCanvas.Children.Add(ppTextBlock);

            Canvas.SetTop(plusOnePpButton, 112);
            Canvas.SetLeft(plusOnePpButton, 30);
            this.myCanvas.Children.Add(plusOnePpButton);

            Canvas.SetTop(subOnePpButton, 112);
            Canvas.SetLeft(subOnePpButton, 75);
            this.myCanvas.Children.Add(subOnePpButton);

            Canvas.SetTop(plusFivePpButton, 112);
            Canvas.SetLeft(plusFivePpButton, 120);
            this.myCanvas.Children.Add(plusFivePpButton);

            Canvas.SetTop(subFivePpButton, 112);
            Canvas.SetLeft(subFivePpButton, 165);
            this.myCanvas.Children.Add(subFivePpButton);
        }

        private SolidColorBrush getRamdomColor()
        {
            List < SolidColorBrush > colors = new List<SolidColorBrush>();
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Beige));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Chocolate));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Cyan));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.DarkSalmon));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Blue));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.GreenYellow));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Gray));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Indigo));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Honeydew));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.OrangeRed));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.LemonChiffon));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.Lavender));
            colors.Add(new SolidColorBrush(Windows.UI.Colors.MistyRose));
            return colors.ElementAt(new Random().Next(0, colors.Count()-1));
        }

        public Canvas getShape()
        {
            return this.myCanvas;
        }

        private void updateLifePoints()
        {
            this.playerLifePointsNumberTextBlock.Text = "" + this.owner.getLifePoints();
        }

        private void updatePoisonPoints()
        {
            this.playerPoisonPointNumberTextBlock.Text = "" + this.owner.getPoisonPoints();
        }

        private void addOneLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addOneLifePoints();
            updateLifePoints();
        }

        private void addFiveLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addFiveLifePoints();
            updateLifePoints();
        }

        private void subOneLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subOneLifePoints();
            updateLifePoints();
        }

        private void subFiveLifePointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subFiveLifePoints();
            updateLifePoints();
        }

        private void addOnePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addOnePoisonPoint();
            updatePoisonPoints();
        }

        private void addFivePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.addFivePoisonPoints();
            updatePoisonPoints();
        }

        private void subOnePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subOnePoisonPoint();
            updatePoisonPoints();
        }

        private void subFivePoisonPointsButtonCLick(object sender, RoutedEventArgs e)
        {
            this.owner.subFivePoisonPoints();
            updatePoisonPoints();
        }

    }
}
