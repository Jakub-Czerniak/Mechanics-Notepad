using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanic_s_Notepad.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string ShortDesc { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int CarID { get; set; }
        public List<string> ToDoPoints { get; set; }
        public List<Image> Photos { get; set; }
    }
}
