using System.Collections.Generic;
using System.Windows;
using BlackJack.Entities;
using BlackJack.ViewModels;

namespace BlackJack.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dealer dealer= new Dealer(new List<Deck>{new Deck()},0 );
            Player player = new Player(0);
            GameTable game= new GameTable(dealer,player, new AceAsOneOrElevenSettlementProvider().Settlement);
            DataContext = new BlackJackViewModel(game);
        }
    }
}
