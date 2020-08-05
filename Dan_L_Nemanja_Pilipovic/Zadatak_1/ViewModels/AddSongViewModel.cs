using System;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    public class AddSongViewModel : BaseViewModel
    {
        #region Objects

        AddSongView main;

        #endregion

        #region Constructors

        public AddSongViewModel(AddSongView mainOpen)
        {
            main = mainOpen;
            Song = new tblSong();
        }

        #endregion

        #region Properties

        private tblSong song;

        public tblSong Song
        {
            get { return song; }
            set 
            {
                song = value;
                OnPropertyChanged("Song");
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
                using (AudioPlayerDbEntities db = new AudioPlayerDbEntities())
                {
                    db.tblSongs.Add(Song);
                    db.SaveChanges();
                }

                MessageBox.Show("Song Added Successfully!");
                main.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if(String.IsNullOrEmpty(Song.Author) || String.IsNullOrEmpty(Song.Name) || String.IsNullOrEmpty(Song.SecondsLength.ToString()))
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

        #endregion
    }
}
