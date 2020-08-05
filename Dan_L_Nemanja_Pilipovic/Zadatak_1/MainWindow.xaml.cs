using System;
using System.Windows;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;
using Zadatak_1.Views;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool _logged;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using(AudioPlayerDbEntities db = new AudioPlayerDbEntities())
                {
                    foreach (tblUser user in db.tblUsers)
                    {
                        if(user.Username == txtUsername.Text && user.Password == txtPassword.Password)
                        {
                            _logged = true;
                            UserView view = new UserView();
                            view.ShowDialog();
                            break;
                        }
                        else
                        {
                            continue; ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            if(_logged == false)
            {
                MessageBox.Show("Username or Password Incorrect.");
            }
        }
    }
}
