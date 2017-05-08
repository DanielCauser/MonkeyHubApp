using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (SetProperty(ref _searchTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }

        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
        }

        private bool CanExecuteSearchCommand()
        {
            return string.IsNullOrEmpty(SearchTerm) == false;
        }

        async private void ExecuteSearchCommand()
        {
            await Task.Delay(2000);
            await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por '{SearchTerm}'", "Ok");
            //Debug.WriteLine($"Clicou no botão! {DateTime.Now.ToString("dd/MM/yyyy")}");
        }
    }
}
