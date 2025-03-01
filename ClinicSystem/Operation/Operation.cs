using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Main
{
    public class Operation
    {
        private int code;
        private string name;
        private DateTime dateAdded;
        private double price;
        private string description;

        public Operation(int code, string name, DateTime dateAdded, double price, string description)
        {
            this.code = code;
            this.name = name;
            this.dateAdded = dateAdded.Date;
            this.price = price;
            this.description = description;
        }

        public int getCode()
        {
            return code;
        }
        public string getName()
        {
            return name;
        }
        public DateTime getDateAdded()
        {
            dateAdded.ToString("yyyy-MM-dd");
            return dateAdded;
        }
        public double getPrice()
        {
            return price;
        }   
        public string getDescription()
        {
            return description;
        }
    }
}
