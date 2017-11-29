using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientWPF.Models;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            SalesPerson s1 = new SalesPerson { ID = 1, Name = "Ole" };
            SalesPerson s2 = new SalesPerson { ID = 2, Name = "Bent" };
            SalesPerson s3 = new SalesPerson { ID = 3, Name = "Brian" };

            Store st1 = new Store { ID = 1, Name = "Bilka" };
            Store st2 = new Store { ID = 2, Name = "Netto" };
            Store st3 = new Store { ID = 3, Name = "Fakta" };

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
                SecondarySalesPersonel = personList,
                Stores = storeList
            };

            District d2 = new District
            {
                ID = 2,
                Name = "Sønderjylland",
                PrimarySalesPerson = s2,
                SecondarySalesPersonel = personList,
                Stores = storeList2
            };

            List<District> districts = new List<District>();
            districts.Add(d1);
            districts.Add(d2);
        }
    }
}
