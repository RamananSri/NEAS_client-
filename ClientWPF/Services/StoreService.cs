using ClientWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Services
{
    public class StoreService : IStoreService
    {
        APIService api;
        string baseRoute;

        public StoreService()
        {
            api = new APIService();
            baseRoute = "store/";
        }

        async public void UpdateStore(Store obj)
        {
            try
            {
                Response res = await api.Put(baseRoute, obj);

                if (!res.Success)
                {
                    throw new Exception(res.Message);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
