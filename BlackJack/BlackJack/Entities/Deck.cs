using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Entities
{
    public class Deck
    {
        private List<Card> _Cards;
        private readonly List<string> _Ranks = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" }; 

        public Deck()
        {
            Init();
        }

        private void Init()
        {
            _Cards = new List<Card>();
            for (var i = 0; i < 4; i++)
            {
                _Cards.AddRange(_Ranks.Select(x => new Card(x)));    
            }

        }

        public List<Card> Cards { get { return _Cards; } } 
    }
}