using Starcounter;
using System;
using System.Collections.Generic;

namespace mina
{

    [Database]
    public class entity
    {
        public String name { get; set; }
    }


    public class addreasableEntity : entity
    {
        public String street { get; set; }
        public Int32 number { get; set; }
        public Int32 zipCode { get; set; }
        public String city { get; set; }
        public String country { get; set; }

        public String addrease
        {
            get
            {
                String add = "";
                if (street != "")
                    add += street;
                if (number != 0)
                    add += ", " + Convert.ToString(number);
                if (zipCode != 0)
                    add += ", " + Convert.ToString(zipCode);
                if (city != "")
                    add += ", " + city;
                if (country != "")
                    add += ", " + country;
                return add;
            }
        }
    }


    public class Corporation : entity
    {
        public IEnumerable<Office> Offices { get { return Db.SQL<Office>("SELECT O FROM Office O WHERE O.corp = ?", this); } }
    }


    public class Office : addreasableEntity
    {
        public Corporation corp;
        public IEnumerable<Home> homes { get { return Db.SQL<Home>("SELECT H FROM Home H WHERE H.office = ?", this); } }
    }


   
    public class Home : addreasableEntity
    {
        public Office office;
        public DateTime time { get; set; }
        public Double price { get; set; }
        public Double commission { get; set; }

    }
}
