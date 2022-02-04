using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_1
{
    class DBUnit 
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public DBUnit(int ID, string Name, double Latitude, double Longitude)
        {
            this.ID = ID;
            this.Name = Name;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }

    }
}
