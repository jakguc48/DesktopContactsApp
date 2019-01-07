using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact cont;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            this.cont = contact;

            nameTextBox.Text = cont.Name;
            emailTextBox.Text = cont.Email;
            phoneNumberTextBox.Text = cont.Phone;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            cont.Name = nameTextBox.Text;
            cont.Email = emailTextBox.Text;
            cont.Phone = phoneNumberTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(cont);
            }

            Close();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(cont);
            }

            Close();    
        }
    }
}
