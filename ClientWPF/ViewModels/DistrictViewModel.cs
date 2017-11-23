using ClientWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.ViewModels
{
    public class DistrictViewModel
    {
        public ObservableCollection<District> Districts { get; set; }
        public District SelectedDistrict { get; set; }

        public DistrictViewModel()
        {
            Store s1 = new Store { ID = 1, Name = "Fakta" };
            Store s2 = new Store { ID = 2, Name = "Bilka" };



        }

    }
}
