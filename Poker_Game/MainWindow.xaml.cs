using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poker_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Card deck;
        public MainWindow()
        {
            deck = new Card();
            InitializeComponent();
            deck.CreateDeck();
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            deck.PlayerDraw();
        }//Draws a card for the player

        private void PlayerTotal_TextInput(object sender, TextCompositionEventArgs e)
        {
            PlayerTotal.Text = deck.PlayerTotal.ToString();
        }//Writes player hand total

        private void DealerTotal_TextInput(object sender, TextCompositionEventArgs e)
        {
            DealerTotal.Text = deck.DealerTotal.ToString();
        }//Writes dealer hand total
    }
    class Card
    {
        string[] Number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };
        string[] Suit = { "Spades", "Hearts", "Clovers", "Diamonds" };
        List<string> FullDeck = new List<string>();

        List<int> PlayerHand = new List<int>();
        List<int> DealerHand = new List<int>();

        public int PlayerTotal = 0;
        public int DealerTotal = 0;

        int FirstDraw = 0;
        public void CreateDeck()
        {
            for (int i = 0; i < Suit.Length; i++)
            {
                for (int j = 0; j < Number.Length; j++)
                {
                    if (Number[j] == "1")
                    {
                        FullDeck.Add("Ace" + " of " + Suit[i]);
                    }
                    else if (Number[j] == "11")
                    {
                        FullDeck.Add("Jack" + " of " + Suit[i]);
                    }
                    else if (Number[j] == "12")
                    {
                        FullDeck.Add("Queen" + " of " + Suit[i]);
                    }
                    else if (Number[j] == "13")
                    {
                        FullDeck.Add("King" + " of " + Suit[i]);
                    }
                    else
                    {
                        FullDeck.Add(Number[j] + " of " + Suit[i]);
                    }
                }
            }
        }//Renaming suits
        public void PlayerDraw() //First Draw
        {
            Random draw = new Random();
            FirstDraw = draw.Next(FullDeck.Count);
            PlayerHand.Add(FirstDraw);
            Console.WriteLine(FullDeck[FirstDraw]);
            FullDeck.Remove(FullDeck[FirstDraw]);
        }
        public void DealerDraw() //First Draw
        {
            Random draw = new Random();
            FirstDraw = draw.Next(FullDeck.Count);
            DealerHand.Add(FirstDraw);
            Console.WriteLine(FullDeck[FirstDraw]);
            FullDeck.Remove(FullDeck[FirstDraw]);
        }
    }
}
