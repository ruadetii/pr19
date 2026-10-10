using Kino_Radosteva.Classes;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Kino_Radosteva.Pages.Kinoteatr
{
    public partial class Main : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        public Main()
        {
            InitializeComponent();

            foreach (KinoteatrContext item in AllKinoteatrs) 
            {
                parent.Children.Add(new Items.Item(item, this));
            }
        }

        private void AddRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Add());
        }
    }
}
