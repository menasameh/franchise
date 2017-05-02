using System;
using Starcounter;
using System.Collections;
using System.Collections.Generic;

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
                    var corp = Db.SQL<Corporation>("SELECT C FROM Corporation C").First;


                    var elem = new corporation
                    {
                        Data = corp
                    };

                    var json = new corp
                    {
                        corpe = elem
                    };


                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    json.Session = Session.Current;
                    return json;
                    });
        }
    }
}