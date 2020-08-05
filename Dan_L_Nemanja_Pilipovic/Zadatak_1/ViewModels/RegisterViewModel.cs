using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Objects

        RegisterView main;

        #endregion

        #region Constructors

        public RegisterViewModel(RegisterView mainOpen)
        {
            main = mainOpen;
            User = new tblUser();
        }

        #endregion

        #region Properties

        private tblUser user;

        public tblUser User
        {
            get { return user; }
            set 
            {
                user = value;
                OnPropertyChanged("User");
            }
        }


        #endregion

        #region Commands

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        #endregion

        #region Functions

        private void SaveExecute()
        {
            try
            {
                if (CheckUsername(User.Username))
                {
                    if (CheckPassword(User.Password))
                    {
                        try
                        {
                            using(AudioPlayerDbEntities db = new AudioPlayerDbEntities())
                            {
                                db.tblUsers.Add(User);
                                db.SaveChanges();
                            }
                            MessageBox.Show("Registrated Successfully!");
                            main.Close();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password Min Lenght 6 and password must contain at least 2 Upper Letters");
                    }
                }
                else
                {
                    MessageBox.Show("Username is already in use, please try another one.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if(String.IsNullOrEmpty(User.Username) || String.IsNullOrEmpty(User.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void CloseExecute()
        {
            main.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        private bool CheckUsername(string username)
        {
            try
            {
                using(AudioPlayerDbEntities db = new AudioPlayerDbEntities())
                {
                    if (db.tblUsers.Any(u => u.Username == username))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private bool CheckPassword(string password)
        {
            if(password.Length >= 6 && PasswordLetterCheck(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool PasswordLetterCheck(string password)
        {
            int upperLetterCounter = 0;

            foreach (char letter in password)
            {
                if (char.IsUpper(letter))
                {
                    upperLetterCounter++;
                }
            }

            if(upperLetterCounter < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
