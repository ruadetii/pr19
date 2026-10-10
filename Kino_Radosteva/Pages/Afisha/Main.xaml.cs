using Kino_Radosteva.Classes;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Kino_Radosteva.Pages.Afisha
{
    public partial class Main : Page
    {
        List<AfishaContext> AllAfishas= AfishaContext.Select();
        public Main()
        {
            InitializeComponent();

            foreach (AfishaContext item in AllAfishas)
            {
                parent.Children.Add(new Items.Item(item, this));
            }
        }

        private void AddRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Afisha.Add());
        }
    }
}
