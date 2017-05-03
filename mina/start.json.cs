using System;
using Starcounter;

namespace mina
{
    partial class start : Json
    {
        void Handle(Input.save action)
        {
            Db.Transact(() =>
            {
                new Corporation
                {
                    name = action.App.newCorpName
                };
            });
        }
    }
}