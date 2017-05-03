using System;
using Starcounter;

namespace mina
{
    partial class office : Json
    {

        public string address => getAddress(street, number, zipCode, city, country);
        public string homeAddress => getAddress(homeStreet, homeNumber, homeZipCode, homeCity, homeCountry);

        private string getAddress(string street, decimal number, decimal zipCode, string city, string country)
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

        void Handle(Input.saveSettings action)
        {
            Transaction.Commit();
        }


        void Handle(Input.addHome action)
        {
            Db.Transact(() =>
            {

                Home home = new Home
                {
                    name = homeName,
                    street = homeStreet,
                    number = (int)homeNumber,
                    zipCode = (int)homeZipCode,
                    city = homeCity,
                    country = homeCountry,
                    date = DateTime.ParseExact(date, "yyyy-MM-dd", null),
                    price = (double)price,
                    commission = (double)commission,
                    office = (Office)Data
                };
            });
        }

    }
}
