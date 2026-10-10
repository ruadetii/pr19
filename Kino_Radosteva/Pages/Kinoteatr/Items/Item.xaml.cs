using Kino_Radosteva.Classes;
using System.Windows.Controls;

namespace Kino_Radosteva.Pages.Kinoteatr.Items
{
    public partial class Item : UserControl
    {
        KinoteatrContext kinoteatr;
        Main main;
        public Item(KinoteatrContext kinoteatr, Main main)
        {
            InitializeComponent();

            name.Text = kinoteatr.Name;
            countZal.Text = kinoteatr.CountZal.ToString();
            count.Text = kinoteatr.Count.ToString();

            this.kinoteatr = kinoteatr;
            this.main = main;
        }

        private void EditRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Add(this.kinoteatr));
        }

        private void DeleteRecord(object sender, System.Windows.RoutedEventArgs e)
        {
            kinoteatr.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
