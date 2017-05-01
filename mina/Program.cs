using System;
using Starcounter;

namespace mina
{
    class Program
    {
        static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());


            Handle.GET("/mina/start",
                () =>
                {
                    return Db.Scope(() =>
                    {
                        var corp = Db.SQL<Corporation>("SELECT C FROM Corporation C");
                        var json = new corp
                        {
                            corps = corp
                        };

                        if (Session.Current == null)
                        {
                            Session.Current = new Session(SessionOptions.PatchVersioning);
                        }
                        json.Session = Session.Current;
                        return json;
                    });
                });
        }
    }
}