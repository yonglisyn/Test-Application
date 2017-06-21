using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Entities
{
    public class Player
    {
        private List<Card> _Hand;
        private int _Point;
        public Player(int point)
        {
            _Point = point;
            _Hand = new List<Card>();
        }

        public List<Card> Hand { get { return _Hand; }}

        public int HandScore
        {
            //TODO: replace with HighestHandScore and fix tests
            get { return HighestHandScore; }
        }

        public int HighestHandScore
        {
            get
            {
                var result = Hand.Sum(x => x.Value);
                var aceCount = Hand.Count(x => x.Rank == "A");
                for (int i = aceCount; i >0; i--)
                {
                    if (result + 10*i <= 21)
                    {
                        result = result + 10*i;
                        break;
                    }
                }
                return result;
            }
        }

        public int Point { get { return _Point; }}
        public bool IsBlackJack { get { return _Hand.Count == 2 && HighestHandScore == 21; } }
        internal bool IsExplode { get { return HighestHandScore > 21; } }

        public void Hit(Card card)
        {
            _Hand.Add(card);
        }

        public void AddPoint(int points)
        {
            _Point += points;
        }

        public void Clear()
        {
            _Hand = new List<Card>();
        }

        public void Reset()
        {
            _Point = 0;
            _Hand = new List<Card>();
        }
    }
}
