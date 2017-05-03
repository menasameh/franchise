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
                    var json = new start();
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

            Handle.GET("/mina/office/getJson/{?}", (string id) =>
            {
                var json = new office();
                json.Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id));
                return json;
            });


            Handle.GET("/mina/office/{?}", (string id) =>
            {
                var json = new office
                {
                    Data = DbHelper.FromID(DbHelper.Base64DecodeObjectID(id))
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