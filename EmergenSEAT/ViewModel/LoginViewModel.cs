using System.ComponentModel;
using System.Windows.Input;

namespace EmergenSEAT.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Login(string username, string password)
        {
            return true;
        }
    }
}
