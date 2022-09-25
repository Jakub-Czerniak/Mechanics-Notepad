using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CarModel
    {
        public int ID { get; set; }
        public string LicensePlateNumber { get; set; }
        public string Owner { get; set; }
        public string PhoneNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public string Generation { get; set; }
        public string Engine { get; set; }
        public string Notes { get; set; }
    }
}
