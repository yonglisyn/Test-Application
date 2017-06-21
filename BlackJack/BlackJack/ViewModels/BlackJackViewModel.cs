using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BlackJack.Entities;
using BlackJack.Enums;

namespace BlackJack.ViewModels
{
    public class BlackJackViewModel : INotifyPropertyChanged
    {
        private readonly GameTable _Game;

        public BlackJackViewModel(GameTable game)
        {
            _Game = game;
        }

        private int _PlayerHandScore;
        public int PlayerHandScore
        {
            get { return _PlayerHandScore; }
            set
            {
                _PlayerHandScore = value;
                OnPropertyChanged("PlayerHandScore");
            }
        }

        public ICommand HitCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _Game.Hit();
                    PropertyChange();
                });
            }
        }

        private void PropertyChange()
        {
            PlayerHand = _Game.PlayerHand.Select(x => x.Rank).ToList();
            PlayerHandScore = _Game.PlayerHandScore;
            PlayerPoint = _Game.PlayerPoint;
            DealerHand = _Game.DealerHand.Select(GetDisplay).ToList();
            DealerPoint = _Game.DealerPoint;
            TurnName = _Game.Turn == Turn.Player ? "Player" : "Dealer";
            IsShowGameActionButton = _Game.GameStatus == GameStatus.PlayerInProcess;
            HitText = _Game.GameStatus == GameStatus.End ? "Continue" : "Hit";
        }

        public ICommand StayCommand
        {
            get { return new DelegateCommand(() =>
            {
                _Game.Stay();
                _Game.Hit();
                PropertyChange();
            }); }
        }

        public ICommand StartCommand
        {
            get { return new DelegateCommand(() =>
            {
                _Game.GameStart(); 
                PropertyChange();
            }); }
        }

        public int DealerHandScore
        {
            get { return 0; }
        }

        private int _PlayerPoint;
        public int PlayerPoint
        {
            get { return _PlayerPoint; }
            set
            {
                _PlayerPoint = value;
                OnPropertyChanged("PlayerPoint");
            }
        }

        private int _DealerPoint;
        public int DealerPoint
        {
            get { return _DealerPoint; }
            set
            {
                _DealerPoint = value;
                OnPropertyChanged("DealerPoint");
            }
        }

        private List<string> _DealerHand;
        public List<string> DealerHand
        {
            get { return _DealerHand ?? _Game.DealerHand.Select(GetDisplay).ToList(); }
            set
            {
                _DealerHand = value;
                OnPropertyChanged("DealerHand");
            }
        }

        private List<string> _PlayerHand; 
        public List<string> PlayerHand
        {
            get { return _PlayerHand; }
            set
            {
                _PlayerHand = value;
                OnPropertyChanged("PlayerHand");
            }
        }

        private bool _IsShowGameActionButton;
        public bool IsShowGameActionButton
        {
            get { return true; }
            set
            {
                _IsShowGameActionButton = value;
                OnPropertyChanged("IsShowGameActionButton");
            }
        }


        private string _TurnName;
        public string TurnName
        {
            get { return _TurnName; }
            set
            {
                _TurnName = value;
                OnPropertyChanged("TurnName");
            }
        }

        private string _HitText;
        public string HitText
        {
            get { return string.IsNullOrEmpty(_HitText)?"Hit":_HitText; }
            set
            {
                _HitText = value;
                OnPropertyChanged("HitText");
            }
        }

        private string GetDisplay(Card card)
        {
            return card.IsHidden ? "X" : card.Rank;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}