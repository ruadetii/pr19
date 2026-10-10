using Kino_Radosteva.Classes;
using Kino_Radosteva.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Kino_Radosteva.Pages.Afisha
{
    public partial class Add : Page
    {
        AfishaContext afisha;
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();

            foreach (var item in AllKinoteatrs)
                kinoteatrs.Items.Add(item.Name);

            kinoteatrs.Items.Add("Выберите ...");

            if (afisha != null)
            {
                this.afisha = afisha;
                kinoteatrs.SelectedIndex = AllKinoteatrs.FindIndex(x => x.Id == afisha.IdKinoteatr);
                name.Text = afisha.Name;
                date.Text = afisha.Time.ToString("yyyy-MM-dd");
                time.Text = afisha.Time.ToString("HH:mm");
                price.Text = afisha.Price.ToString();

                btnAdd.Content = "Изменить";
            }
            else 
            {
                kinoteatrs.SelectedIndex = kinoteatrs.Items.Count - 1;
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            DateTime dateAfisha;
            TimeSpan timeAfisha;
            int priceInt = -1;

            if (name.Text == "")
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }

            if (kinoteatrs.SelectedIndex == kinoteatrs.Items.Count - 1) 
            {
                MessageBox.Show("Выбериие кинотеатр");
                return;
            }

            if (date.Text == "") 
            {
                MessageBox.Show("Необходимо указать дату");
                return;
            }

            if (time.Text == "" || TimeSpan.TryParse(time.Text, out timeAfisha) == false) 
            {
                MessageBox.Show("Необходимо указать время");
                return;
            }

            if (price.Text == "" || int.TryParse(price.Text, out priceInt) == false)
            {
                MessageBox.Show("Необходимо указать цену");
                return;
            }

            DateTime.TryParse(date.Text, out dateAfisha);
            dateAfisha.Add(timeAfisha);

            if (this.afisha == null)
            {
                AfishaContext newAfisha = new AfishaContext(
                    0,
                    AllKinoteatrs.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dateAfisha,
                    priceInt
                );
                newAfisha.Add();
                MessageBox.Show("Запись успешно добавлена");
            }
            else
            {
                afisha = new AfishaContext(
                    afisha.Id,
                    AllKinoteatrs.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dateAfisha,
                    priceInt
                );
                afisha.Update();
                MessageBox.Show("Запись успешно обновлена");
            }
            MainWindow.init.OpenPage(new Pages.Afisha.Main());
        }
    }
}
