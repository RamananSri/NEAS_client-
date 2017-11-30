using ClientWPF.Commands;
using ClientWPF.Models;
using ClientWPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.ComponentModel;

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

        // Constructors - dependency injection (user IoC containers instead)
        public DistrictViewModel(IDistrictService districtService, IStoreService storeService)
        {
            this.districtService = districtService;
            this.storeService = storeService;

            _districts = new ObservableCollection<District>();
            loadCommands();
            GetDistricts();
        }
        public DistrictViewModel(){
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

        // Delete store 
        private void onRemoveStore(object obj)
        {
            SelectedDistrict.Stores.Remove(SelectedStore);

            //try
            //{
            //    storeService.UpdateStore(SelectedStore);
            //    GetDistricts(); 
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        // Load all districts
        async void GetDistricts(){

            try
            {
                List<District> districts = await districtService.GetAll();

                foreach (var item in districts)
                {
                    _districts.Add(item);
                }

                //_districts = new ObservableCollection<District>(districts);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }

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
