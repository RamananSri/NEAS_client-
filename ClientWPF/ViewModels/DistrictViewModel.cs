using ClientWPF.Commands;
using ClientWPF.Models;
using ClientWPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace ClientWPF.ViewModels
{
    public class DistrictViewModel
    {
        IDistrictService districtService;
        IStoreService storeService;

        ObservableCollection<District> _districts;
        District _selectedDistrict;
        Store _selectedStore;
        string _errorMessage;

        // Constructors - dependency injection (use IoC containers instead)
        public DistrictViewModel(IDistrictService districtService, IStoreService storeService)
        {
            this.districtService = districtService;
            this.storeService = storeService;

            _districts = new ObservableCollection<District>();
            loadCommands();
            GetDistricts();
        }
        public DistrictViewModel()
        {
            districtService = new DistrictService();
            storeService = new StoreService();
            _districts = new ObservableCollection<District>();
            loadCommands();
            GetDistricts();
        }

        // Instatiate all commands
        void loadCommands()
        {
            RemoveStoreCommand = new RelayCommand(onRemoveStore, canRemoveStore);
        }

        // Determine if item is selected to delete
        private bool canRemoveStore(object arg)
        {
            return SelectedStore != null;
        }

        // Remove store 
        private void onRemoveStore(object obj)
        {
            Store updatedStore = _selectedStore;
            updatedStore.DistrictID = null;

            try{
                storeService.UpdateStore(updatedStore);
                // UI doesnt update - INotifyPropertyChanged ??
                SelectedDistrict.Stores.Remove(SelectedStore);
            }
            catch (Exception e){
                ErrorMessage = e.Message;
            }            
        }

        // Load all districts
        async void GetDistricts(){
            try{
                List<District> districts = await districtService.GetAll();

                foreach (var item in districts)
                {
                    _districts.Add(item);
                }
            }
            catch (Exception e){
                ErrorMessage = e.Message;
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void RaisePropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        #region Properties

        public ObservableCollection<District> Districts
        {
            get
            {
                return _districts;
            }
            set
            {
                _districts = value;
            }
        }

        public District SelectedDistrict
        {
            get
            {
                return _selectedDistrict;
            }
            set
            {
                _selectedDistrict = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }

        public Store SelectedStore
        {
            get
            {
                return _selectedStore;
            }
            set
            {
                _selectedStore = value;
            }
        }

        public ICommand RemoveStoreCommand { get; private set; }

        #endregion
    }
}
