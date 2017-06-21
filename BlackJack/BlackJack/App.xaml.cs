using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BlackJack.Views;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
        //    int verbose = 0;
        //    var optionSet = new OptionSet
        //{
        //    { "v|verbose", "verbose output, repeat for more verbosity.",   
        //            arg => verbose++ }
        //};

        //    var extra = optionSet.Parse(e.Args);
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
