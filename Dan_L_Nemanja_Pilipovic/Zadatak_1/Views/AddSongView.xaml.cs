using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for AddSongView.xaml
    /// </summary>
    public partial class AddSongView : Window
    {
        public AddSongView()
        {
            InitializeComponent();
            this.DataContext = new AddSongViewModel(this);
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LetterAndNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 ]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
