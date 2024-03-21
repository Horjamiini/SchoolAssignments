using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SHAA3209
{
    public enum Suites
    {
        Spade,
        Heart,
        Diamond,
        Club
    }
    public class Card
    {
        public Suites Suite { get; private set; }
        public int Rank { get; private set; }
        public Card(Suites suite,int rank)
        {
            Suite = suite;
            Rank = rank;
        }
        public override string ToString()
        {
            return Suite + "#" + Rank;
        }
    }
    public class CardDeck
    {
        private static Random _rand = new Random();
        private List<Card> _cards;
        public List<Card> Cards { get { return _cards; } }
        public int CardCount { get { return _cards.Count; } }
        public CardDeck()
        {
            _cards = new List<Card>();
            foreach (Suites s in Enum.GetValues(typeof(Suites)))
            {
                for (int i = 14; i > 1; i--)
                {
                    _cards.Add(new Card(s, i));
                }
            }
        }
        public void Shuffle<Card>(List<Card> _cards)
        {
            for (int i = _cards.Count -1; i > 0; i--)
            {
                int k = _rand.Next(i + 1);
                Card value = _cards[k];
                _cards[k] = _cards[i];
                _cards[i] = value;
            }
        }
    }
    internal class Program
    {
        static void TestCardsAndDeck()
        {
            CardDeck deck = new CardDeck();
            // Test the deck and its card count
            Console.WriteLine($"Pakassa on {deck.CardCount} korttia: ");
            deck.Cards.ForEach(x => Console.WriteLine(x));
            // Test the shuffle method
            Console.WriteLine("\n**Shuffle the deck**\n");
            deck.Shuffle(deck.Cards);
            Console.WriteLine($"Pakassa on {deck.CardCount} korttia: ");
            deck.Cards.ForEach(x => Console.WriteLine(x));
        }
        static void Main(string[] args)
        {
            TestCardsAndDeck();
        }
    }
}
