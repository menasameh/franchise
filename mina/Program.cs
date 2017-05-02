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
                    var json = new corp();
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }
                    json.Session = Session.Current;
                    return json;
                });


            Handle.GET("/mina/corp",
                () =>
                {
                    return Db.Scope(() =>
                    {
                        var corp = Db.SQL<Corporation>("SELECT C FROM Corporation C").First;

                        var json = new corporation
                        {
                            Data = corp
                        };

                        if (Session.Current == null)
                        {
                            Session.Current = new Session(SessionOptions.PatchVersioning);
                        }
                        json.Session = Session.Current;
                        return json;
                    });
                });

            Handle.GET("/mina/corp/{?}", (string id) =>
            {
                var json = new office();
                json.Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id));
                return json;
            });
        }
    }
}