﻿using ClientWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Services
{
    public class DistrictService : IDistrictService
    {
        APIService api;
        string baseRoute;

        public DistrictService()
        {
            api = new APIService();
            baseRoute = "district/";
        }

        async public Task<List<District>> GetAll()
        {
            try
            {
                List<District> districts = await api.Get<List<District>>(baseRoute);

                if (!districts.Any())
                {
                    throw new Exception("No districts found");
                }

                return districts;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
