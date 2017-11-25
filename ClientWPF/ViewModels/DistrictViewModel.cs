using ClientWPF.Models;
using ClientWPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClientWPF.ViewModels
{
    public class DistrictViewModel
    {
        ObservableCollection<District> _districts;
        District _selectedDistrict;

        DistrictService districtService; 

        public DistrictViewModel()
        {
            districtService = new DistrictService();
            GetDistricts();
        }

        void GetDistricts()
        {
            List<District> districts = districtService.GetAll();
            Districts = new ObservableCollection<District>(districts);
        }

        #region Properties

        public ObservableCollection<District> Districts
        {
            get { return _districts;}
            set{ _districts = value;}
        }
        public District SelectedDistrict
        {
            get { return _selectedDistrict; }
            set { _selectedDistrict = value; }
        }

        #endregion
    }
}
