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

        public string getAddress()
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


    public class Corporation : entity
    {
        public QueryResultRows<Office> offices { get { return Db.SQL<Office>("SELECT O FROM Office O WHERE O.corp = ?", this); } }
    }


    public class Office : addreasableEntity
    {

        public Corporation corp;
        public QueryResultRows<Home> homes { get { return Db.SQL<Home>("SELECT H FROM Home H WHERE H.office = ?", this); } }
        public decimal totalSold { get { return Db.SQL<decimal>("SELECT COUNT(H) FROM Home H WHERE H.office = ?", this).First; } }
        public double totalCom { get { return Db.SQL<double>("SELECT SUM(H.commission) FROM Home H WHERE H.office = ?", this).First; } }
        public double avgCom { get { return Db.SQL<double>("SELECT AVG(H.commission) FROM Home H WHERE H.office = ?", this).First; } }
        public decimal trend { get { return Db.SQL<decimal>("SELECT COUNT(H) FROM Home H WHERE H.office = ?", this).First; } }
        public string ID { get { return this.GetObjectID(); } }
    }



    public class Home : addreasableEntity
    {
        public Office office;
        public DateTime date { get; set; }
        public Double price { get; set; }
        public Double commission { get; set; }
        public string address { get { return getAddress(); } }
    }
}
