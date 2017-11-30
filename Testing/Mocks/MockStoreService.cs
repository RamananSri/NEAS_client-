using ClientWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientWPF.Models;

namespace Testing.Mocks
{
    public class MockStoreService : IStoreService
    {
        public void UpdateStore(Store obj)
        {
            throw new NotImplementedException();
        }
    }
}
