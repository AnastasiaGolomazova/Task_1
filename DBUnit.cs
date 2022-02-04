using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class DBUnit
    {
        private int id { get; set; }
        private string name { get; set; }
        private double longitude { get; set; }
        private double latitude { get; set; }

        public DBUnit(int id, string name, double latitude, double longitude)
        {
            this.id = id;
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
