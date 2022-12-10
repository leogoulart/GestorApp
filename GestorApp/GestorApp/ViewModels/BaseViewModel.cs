using GestorApp.Entities;
using GestorApp.Services;
using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace GestorApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;
        private bool _isBusy;
        
        public IDataStore<Client> DataStore => DependencyService.Get<IDataStore<Client>>();

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
