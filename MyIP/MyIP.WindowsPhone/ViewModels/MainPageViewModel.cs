using MyIP.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyIP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<IPInfoItem> IPInformation { get; set; }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }

        private int _profileCount;
        public int ProfileCount
        {
            get { return _profileCount; }
            set { _profileCount = value; OnPropertyChanged(); }
        }

        #region INotifyPropertyChanged 関係
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        public MainPageViewModel()
        {
            this.IPInformation  = new ObservableCollection<IPInfoItem>();
            this.IsLoading      = false;
            this.ProfileCount   = 0;
        }

        public async void GetIPInfomation()
        {
            this.IPInformation.Clear();
            this.IsLoading = true;

            var ips = new IPInfoItems();
            await ips.GetIPInfomation();
            foreach (var ip in ips)
            {
                this.IPInformation.Add(ip);
            }

            this.ProfileCount = ips.Count;
            this.IsLoading = false;
        }
    }
}
