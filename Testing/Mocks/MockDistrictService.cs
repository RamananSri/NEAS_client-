using ClientWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientWPF.Models;

namespace Testing.Mocks
{
    public class MockDistrictService : IDistrictService
    {
        async public Task<List<District>> GetAll()
        {
            SalesPerson s1 = new SalesPerson { ID = 1, FirstName = "Ole" };
            SalesPerson s2 = new SalesPerson { ID = 2, FirstName = "Bent" };
            SalesPerson s3 = new SalesPerson { ID = 3, FirstName = "Brian" };

            Store st1 = new Store { ID = 1, Franchise = "Bilka" };
            Store st2 = new Store { ID = 2, Franchise = "Netto" };
            Store st3 = new Store { ID = 3, Franchise = "Fakta" };

            List<Store> storeList = new List<Store>();
            storeList.Add(st1);
            storeList.Add(st2);
            storeList.Add(st3);

            List<Store> storeList2 = new List<Store>();
            storeList2.Add(st1);
            storeList2.Add(st2);

            List<SalesPerson> personList = new List<SalesPerson>();
            personList.Add(s2);
            personList.Add(s3);

            District d1 = new District
            {
                ID = 1,
                Name = "Nordjylland",
                PrimarySalesPerson = s1,
                Personnel = personList,
                Stores = storeList
            };

            District d2 = new District
            {
                ID = 2,
                Name = "Sønderjylland",
                PrimarySalesPerson = s2,
                Personnel = personList,
                Stores = storeList2
            };

            List<District> districts = new List<District>();
            districts.Add(d1);
            districts.Add(d2);
            return districts;
        }
    }
}
