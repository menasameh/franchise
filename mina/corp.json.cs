using Starcounter;

namespace mina
{
    partial class corp : Json
    {
        void Handle(Input.save action)
        {
            //Transaction.Commit();
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
