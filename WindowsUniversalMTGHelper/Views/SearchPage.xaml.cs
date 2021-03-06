﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsUniversalMTGHelper.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        string[] selectionItems;
        string actualMultiverseId;
        string actualSet = "SOI.txt";
        //string actualSet = "EMA.txt";

        public SearchPage()
        {
            GenerateCardsList();
            this.InitializeComponent();
            myListBox.ItemsSource = selectionItems;
            this.initializeBackFunction();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
        }

        private void MyAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            var filtered = selectionItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;
        }

        private void MyAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null) // bugFix
            {
                MostrarDatosDeLaCartaSeleccionada(args.ChosenSuggestion.ToString());
                this.cambiarFondoConCarta(JObject.Parse(RetornaUnaCarta(args.ChosenSuggestion.ToString())));
            }
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
  //          MostrarDatosDeLaCartaSeleccionada(myListBox.SelectedItem.ToString());
  //          this.cambiarFondoConCarta(JObject.Parse(RetornaUnaCarta(myListBox.SelectedItem.ToString())));
        }

        private void cambiarFondoConCarta(JObject card)
        {
            ImageBrush cardImage = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(CreateUrlWithId((string)card["multiverseid"]), UriKind.Absolute))
            };

            cardImage.ImageFailed += MyImage_ImageOpened;
            SearchPageGrid.Background = cardImage;

        }

        void verImagen_Click(object sender, RoutedEventArgs e)
        {
            CloseMyPanelOpenTmpPanel();
            //LoadImage(actualMultiverseId);
            MyAutoSuggestBox.Visibility = Visibility.Collapsed;
        }

        private void MostrarDatosDeLaCartaSeleccionada(string nombreDeLaCarta)
        {
            //Stats
            App.stats.SearchedCard();
            App.stats.Post();
            App.stats.Reset();
            //

            MyImage.Visibility = Visibility.Collapsed;
            MyAutoSuggestBox.Visibility = Visibility.Collapsed;
            CloseListOpenMyPanel();

            //casos especiales if rarity equal "Basic Land"
            //datos iguales, cambia imagen y multiverseid

            var card = RetornaUnaCarta(nombreDeLaCarta);

            JObject cardJO = JObject.Parse(card);

            myStackPanel.Children.Clear();

            Thickness textMargin = new Thickness(0, 0, 0, 12);
            if (cardJO["name"] != null)
            {
                TextBlock name = new TextBlock();
                name.Text = (string)cardJO["name"];
                name.Margin = textMargin;
                name.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(name);
            }
            if (cardJO["manaCost"] != null)
            {
                TextBlock manaCost = new TextBlock();
                manaCost.Text = (string)cardJO["manaCost"];
                manaCost.Margin = textMargin;
                manaCost.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(manaCost);
            }
            if (cardJO["type"] != null)
            {
                TextBlock type = new TextBlock();
                type.Text = (string)cardJO["type"];
                type.Width = 310;
                type.TextWrapping = TextWrapping.Wrap;
                type.Margin = textMargin;
                type.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(type);
            }
            if (cardJO["text"] != null)
            {
                TextBlock text = new TextBlock();
                text.Text = (string)cardJO["text"];
                text.Width = 310;
                text.TextWrapping = TextWrapping.Wrap;
                text.Margin = textMargin;
                text.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(text);
            }
            if (cardJO["flavor"] != null)
            {
                TextBlock flavor = new TextBlock();
                flavor.Text = (string)cardJO["flavor"];
                flavor.Width = 310;
                flavor.TextWrapping = TextWrapping.Wrap;
                flavor.Margin = textMargin;
                flavor.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(flavor);
            }
            if (cardJO["power"] != null)
            {
                TextBlock power = new TextBlock();
                power.Text = (string)cardJO["power"] + " / " + (string)cardJO["toughness"];
                power.Width = 310;
                power.TextWrapping = TextWrapping.Wrap;
                power.Margin = textMargin;
                power.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(power);
            }
            if (cardJO["rarity"] != null)
            {
                TextBlock rarity = new TextBlock();
                rarity.Text = "Rarity: " + (string)cardJO["rarity"];
                rarity.Width = 310;
                rarity.TextWrapping = TextWrapping.Wrap;
                rarity.Margin = textMargin;
                rarity.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(rarity);
            }
            if (cardJO["number"] != null)
            {
                TextBlock number = new TextBlock();
                number.Text = "Card number: " + (string)cardJO["number"];
                number.Width = 310;
                number.TextWrapping = TextWrapping.Wrap;
                number.Margin = textMargin;
                number.FontWeight = FontWeights.Bold;
                myStackPanel.Children.Add(number);
            }

            Button verImagen = new Button();
            verImagen.Content = "Ver Imagen";
            verImagen.Click += verImagen_Click;
            myStackPanel.Children.Add(verImagen);

            if (cardJO["multiverseid"] != null)
                actualMultiverseId = (string)cardJO["multiverseid"];
            //(string)cardJO["cmc"];
            //(string)cardJO["colors"];
        }

        public string RetornaUnaCarta(string nombreDeLaCarta)
        {
            JObject jsonSet = JObject.Parse(File.ReadAllText(@actualSet)); //this method not work if the file not has json extencion
            JToken tokenCard;

            int multiverseid = FixNombreDeCartas(nombreDeLaCarta);
            if (multiverseid != 0)
            {
                tokenCard = jsonSet.SelectToken("$.cards[?(@.multiverseid ==" + multiverseid.ToString() + ")]");
            }
            else
                tokenCard = jsonSet.SelectToken("$.cards[?(@.name == '" + nombreDeLaCarta + "')]");

            return tokenCard.ToString();
        }

        private void LoadImage(string multiverseid)
        {

            var url = CreateUrlWithId(multiverseid);
            Uri uri = new Uri(url, UriKind.Absolute);
            //IRandomAccessStream a = await RandomAccessStreamReference.CreateFromUri(uri).OpenReadAsync();
            //BitmapImage i = new BitmapImage();
            //await i.SetSourceAsync(a);
            //MyImage.Source = i;
            MyImage.Source = new BitmapImage(uri);
            
        }

        static string CreateUrlWithId(string multiverseid)
        {
            string urlStart = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=";
            string urlEnd = "&type=card";
            return urlStart + multiverseid + urlEnd;
        }

        private void GenerateCardsList()
        {
            //selectionItems = System.IO.File.ReadAllLines(@"SOI_CardsName.txt");
            List<string> myList = new List<string>();

            string lastItem = ""; //Fix nombres repetidos
            foreach (var item in RetornaTodasLasCartas())
            {
                // FIX nombres repetidos
                string actualItem = (string)item["name"];
                string fixItem = FixNombreDeCartasRepetidas(actualItem, lastItem);
                lastItem = fixItem;

                myList.Add(fixItem);
            }
            selectionItems = myList.ToArray<string>();
            Array.Sort(selectionItems);
        }

        public IEnumerable<JToken> RetornaTodasLasCartas()
        {
            JObject jsonSet = JObject.Parse(File.ReadAllText(@actualSet));
            IEnumerable<JToken> tokenCards = jsonSet.SelectTokens("$.cards[?(@.name != 'trash')]");
            return tokenCards;
        }

        private void MyImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            MyImage.Visibility = Visibility.Collapsed;
            myStackPanel.Visibility = Visibility.Visible;
        }

        private void CloseListOpenMyPanel()
        {
            myListBox.Visibility = Visibility.Collapsed;
            myStackPanel.Visibility = Visibility.Visible;
        }

        private void ClosePanelOpenMyList()
        {
            myListBox.Visibility = Visibility.Visible;
            myStackPanel.Visibility = Visibility.Collapsed;
            MyAutoSuggestBox.Visibility = Visibility.Visible;
        }

        private void CloseMyPanelOpenMyImage()
        {
            myStackPanel.Visibility = Visibility.Collapsed;
            MyImage.Visibility = Visibility.Visible;
        }

        private void CloseMyPanelOpenTmpPanel()
        {
            myStackPanel.Visibility = Visibility.Collapsed;
            //tmpPanel.Visibility = Visibility.Visible;
        }

        private void CloseTmpPanelOpenMyImage()
        {
            tmpPanel.Visibility = Visibility.Collapsed;
            //MyImage.Visibility = Visibility.Visible;
        }

        private int FixNombreDeCartas(string nombreDeLaCarta)
        {
            int multiverseid;

            switch (nombreDeLaCarta)
            {
                case "Forest3":
                    multiverseid = 410066;
                    break;
                case "Forest2":
                    multiverseid = 410065;
                    break;
                case "Forest1":
                    multiverseid = 410064;
                    break;
                case "Mountain3":
                    multiverseid = 410063;
                    break;
                case "Mountain2":
                    multiverseid = 410062;
                    break;
                case "Mountain1":
                    multiverseid = 410061;
                    break;
                case "Swamp1":
                    multiverseid = 410060;
                    break;
                case "Swamp2":
                    multiverseid = 410059;
                    break;
                case "Swamp3":
                    multiverseid = 410058;
                    break;
                case "Island1":
                    multiverseid = 410057;
                    break;
                case "Island2":
                    multiverseid = 410056;
                    break;
                case "Island3":
                    multiverseid = 410055;
                    break;
                case "Avacyn's Judgment":
                    multiverseid = 409895;
                    break;
                case "Cathar's Companion":
                    multiverseid = 409747;
                    break;
                case "Chaplain's Blessing":
                    multiverseid = 409748;
                    break;
                case "Geralf's Masterpiece":
                    multiverseid = 409808;
                    break;
                case "Ghoulcaller's Accomplice":
                    multiverseid = 409860;
                    break;
                case "Gisa's Bidding":
                    multiverseid = 409862;
                    break;
                case "Gryff's Boon":
                    multiverseid = 409758;
                    break;
                case "Inquisitor's Ox":
                    multiverseid = 409763;
                    break;
                case "Jace's Scrutiny":
                    multiverseid = 409813;
                    break;
                case "Liliana's Indignation":
                    multiverseid = 409870;
                    break;
                case "Murderer's Axe":
                    multiverseid = 410025;
                    break;
                case "Nahiri's Machinations":
                    multiverseid = 409767;
                    break;
                case "Olivia's Bloodsworn":
                    multiverseid = 409877;
                    break;
                case "Sigarda, Heron's Grace":
                    multiverseid = 410015;
                    break;
                case "Slayer's Plate":
                    multiverseid = 410031;
                    break;
                case "Tamiyo's Journal":
                    multiverseid = 410032;
                    break;
                case "Thalia's Lieutenant":
                    multiverseid = 409783;
                    break;
                case "Ulrich's Kindred":
                    multiverseid = 409943;
                    break;
                case "Wolf of Devil's Breach":
                    multiverseid = 409949;
                    break;
                case "Devils' Playground":
                    multiverseid = 409903;
                    break;
                default:
                    multiverseid = 0;
                    break;
            }
            return multiverseid;
        }

        private string FixNombreDeCartasRepetidas(string nombreDeLaCartaActual, string nombreDeLaCartaAnterior)
        {
            string name;

            switch (nombreDeLaCartaActual)
            {
                case "Forest":
                    if (nombreDeLaCartaAnterior.Equals("Forest1"))
                        name = "Forest2";
                    else if (nombreDeLaCartaAnterior.Equals("Forest2"))
                        name = "Forest3";
                    else
                        name = "Forest1";
                    break;
                case "Mountain":
                    if (nombreDeLaCartaAnterior.Equals("Mountain1"))
                        name = "Mountain2";
                    else if (nombreDeLaCartaAnterior.Equals("Mountain2"))
                        name = "Mountain3";
                    else
                        name = "Mountain1";
                    break;
                case "Swamp":
                    if (nombreDeLaCartaAnterior.Equals("Swamp1"))
                        name = "Swamp2";
                    else if (nombreDeLaCartaAnterior.Equals("Swamp2"))
                        name = "Swamp3";
                    else
                        name = "Swamp1";
                    break;
                case "Island":
                    if (nombreDeLaCartaAnterior.Equals("Island1"))
                        name = "Island2";
                    else if (nombreDeLaCartaAnterior.Equals("Island2"))
                        name = "Island3";
                    else
                        name = "Island1";
                    break;
                default:
                    name = nombreDeLaCartaActual;
                    break;
            }
            return name;
        }

        private void MyImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            SearchPageGrid.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Resources/cardback.jpg", UriKind.Absolute))
            };


        }

        private void initializeBackFunction()
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
            {
                if (myStackPanel.Visibility == (Visibility.Collapsed) &&
                myListBox.Visibility == (Visibility.Collapsed) &&
                MyAutoSuggestBox.Visibility == (Visibility.Collapsed))
                {
                    myStackPanel.Visibility = Visibility.Visible;
                    a.Handled = true;
                }
                else
                {
                    if (myStackPanel.Visibility == (Visibility.Visible) &&
                        myListBox.Visibility == (Visibility.Collapsed) &&
                        MyAutoSuggestBox.Visibility == (Visibility.Collapsed))
                        {
                            SearchPageGrid.Background = new ImageBrush
                            {
                                ImageSource = new BitmapImage(new Uri("ms-appx:/Resources/logoMTG.jpg", UriKind.Absolute))
                            };
                        ClosePanelOpenMyList();
                            a.Handled = true;
                        }
                    else
                    {
                        if (Frame.CanGoBack)
                        {
                            Frame.GoBack();
                            a.Handled = true;
                        }
                    }
                }
            };
        }

        private void myListBox_ItemClick(object sender, ItemClickEventArgs e)
        {   
            MostrarDatosDeLaCartaSeleccionada(e.ClickedItem.ToString());
            this.cambiarFondoConCarta(JObject.Parse(RetornaUnaCarta(e.ClickedItem.ToString())));
        }
    }
}
