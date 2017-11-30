using System;
using ClientWPF.Services;
using Testing.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using ClientWPF.ViewModels;
using System.Collections.Generic;
using ClientWPF.Models;
using System.Threading.Tasks;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        IDistrictService districtService;
        IStoreService storeService;

        [TestInitialize]
        public void initialize()
        {
            districtService = new MockDistrictService();
            storeService = new MockStoreService();
        }

        [TestMethod]
        public async Task TestDistrictGet()
        {
            // Arrange          
            ObservableCollection<District> actual = null;
            ObservableCollection<District> expected = new ObservableCollection<District>();
            ICollection<District> response = await districtService.GetAll();
            foreach (var item in response)
            {
                expected.Add(item);
            }

            // Act 
            DistrictViewModel districtVM = new DistrictViewModel(districtService, storeService);
            actual = districtVM.Districts;

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
