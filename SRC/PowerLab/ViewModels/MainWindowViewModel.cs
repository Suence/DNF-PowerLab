using Prism.Mvvm;

namespace PowerLab.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "PowerLab";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
