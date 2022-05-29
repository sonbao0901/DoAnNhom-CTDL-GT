using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csdl
{
    public class WareHouse
    {
        private int id;
        private string name;
        private int year;
        public string GetName()
        {
            return name;
        }

        public int GetId()
        {
            return id;
        }

        public int GetYear()
        {
            return year;
        }

        public WareHouse(int id, string name, int year)
        {
            this.id = id;
            this.name = name;
            this.year = year;
        }

        override public string ToString()
        {
            return "Warehouse(" + id + "," + name + "," + year + ")";
        }
    }
}