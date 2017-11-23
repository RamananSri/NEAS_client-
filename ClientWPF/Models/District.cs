using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Models
{
    public class District
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Store> Stores { get; set; }
        public SalesPerson PrimarySalesPerson { get; set; }
        public List<SalesPerson> SecondarySalesPersonel { get; set; }
    }
}
