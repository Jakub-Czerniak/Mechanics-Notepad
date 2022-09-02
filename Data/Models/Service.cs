using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Service
    {
        string ShortDesc;
        string Notes;
        decimal Price;
        string Status;
        DateTime date;
        int CarID;
        List<string> ToDoPoints;
        List<Image> Photos;
    }
}
