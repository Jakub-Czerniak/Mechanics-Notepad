using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ServiceModel
    {
        public int ID;
        public string ShortDesc;
        public string Notes;
        public decimal Price;
        public string Status;
        public DateTime Date;
        public int CarID;
        public List<string> ToDoPoints;
        public List<Image> Photos;
    }
}
