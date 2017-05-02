using Starcounter;

namespace mina
{
    partial class corporation : Json
    {

        void Handle(Input.save action)
        {
            Db.Transact(() =>
            {
                Office office = new Office
                {
                    name = action.App.newOfficeName,
                    street = "",
                    number = 0,
                    zipCode = 0,
                    city = "",
                    country = "",
                    corp = (Corporation) Data
                };
                office newOffice = (office) Self.GET("/mina/corp/" + office.GetObjectID());
                Offices.Add(newOffice);
            });
        }
    }
}
