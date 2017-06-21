using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Extensions;

namespace BlackJack.Entities
{
    public class Dealer:Player
    {
        private readonly List<Card> _Cards = new List<Card>(); 
        private readonly List<Card> _UsedCards;
        public Dealer(List<Deck> decks, int point):base(point)
        {
            decks.ForEach(x => _Cards.AddRange(x.Cards));
            _UsedCards = new List<Card>();
        }

        public int RemainingCardsCount { get { return _Cards.Count; } }

        public Card DealCard()
        {
            if (_Cards.Count == 0)
            {
                _UsedCards.Shuffle(new Random());
                _Cards.AddRange(_UsedCards);
            }
            var card = _Cards.Take(1).First();
            _Cards.RemoveAt(0);
            _UsedCards.Add(card);
            return card;
        }

        public void Shuffle()
        {
            _Cards.Shuffle(new Random());
        }

    }
}
