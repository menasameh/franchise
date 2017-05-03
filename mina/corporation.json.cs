using Starcounter;

namespace mina
{
    partial class corporation : Json, IExplicitBound<Corporation>
    {
       

        static corporation()
        {
            DefaultTemplate.Html.Bind = null;
            DefaultTemplate.save.Bind = null;
            DefaultTemplate.newOfficeName.Bind = null;
        }


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
            });
        }
    }
}
