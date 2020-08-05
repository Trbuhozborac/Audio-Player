using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        #region Objects

        UserView main;

        #endregion

        #region Constructors

        public UserViewModel(UserView mainOpen)
        {
            main = mainOpen;
            Songs = GetAllSongs();
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


        private List<tblSong> songs;

        public List<tblSong> Songs
        {
            get { return songs; }
            set 
            {
                songs = value;
                OnPropertyChanged("Songs");
            }
        }


        #endregion

        #region Commands

        private ICommand addSong;
        public ICommand AddSong
        {
            get
            {
                if (addSong == null)
                {
                    addSong = new RelayCommand(param => AddSongExecute(), param => CanAddSongExecute());
                }
                return addSong;
            }
        }

        #endregion

        #region Functions

        private void AddSongExecute()
        {
            AddSongView view = new AddSongView();
            view.ShowDialog();
            Songs = GetAllSongs();
        }

        private bool CanAddSongExecute()
        {
            return true;
        }

        private List<tblSong> GetAllSongs()
        {
            List<tblSong> songs = new List<tblSong>();

            try
            {
                using (AudioPlayerDbEntities db = new AudioPlayerDbEntities())
                {
                    songs = db.tblSongs.Where(s => s.Id > 0).ToList();
                    return songs;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
