namespace BlackJack.Entities
{
    public class Card
    {
        private readonly string _Rank;
        private bool _IsHidden;

        public Card(string rank)
        {
            _Rank = rank;
        }

        public string Rank { get { return _Rank; }}

        public int Value
        {
            get
            {
                int result;
                if (int.TryParse(_Rank, out result))
                    return result;
                if (_Rank == "A")
                    return 1;
                return 10;
            }
        }

        public bool IsHidden { get { return _IsHidden; } }

        public void SetHidden()
        {
            _IsHidden = true;
        }
    }
}