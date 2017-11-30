using ClientWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Services
{
    public interface IDistrictService
    {
        Task<List<District>> GetAll();
    }
}
