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
        DistrictService districtService;
        ObservableCollection<District> _districts;

        District _selectedDistrict;
        Store _selectedStore;

        public DistrictViewModel(){
            districtService = new DistrictService();
            GetDistricts();
            DeleteCommand = new RelayCommand(onDelete, canDelete);
        }

        private bool canDelete(object arg)
        {
            return SelectedStore != null;
        }

        private void onDelete(object obj)
        {
            SelectedDistrict.Stores.Remove(SelectedStore);
        }

        // Load all districts
        async void GetDistricts(){
            List<District> districts = await districtService.GetAll();
            Districts = new ObservableCollection<District>(districts);
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

        public Store SelectedStore
        {
            get { return _selectedStore; }
            set { _selectedStore = value; }
        }

        // Private set - constructor
        public ICommand DeleteCommand { get; private set; }

        #endregion
    }
}
