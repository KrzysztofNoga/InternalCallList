using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpisRozmowTelefonicznych.DAL;

namespace SpisRozmowTelefonicznych.Helpers
{
    public class CallMenager
    {
        private SpisContext db;
        private ISessionMenager session;

        public CallMenager(ISessionMenager session, SpisContext db)
        {
            this.session = session;
            this.db = db;

        }

        public Call CreateCall(Call newCall, string userId)
        {
            newCall.dataDodania = DateTime.Now;
            newCall.UserID = userId;
            db.Calls.Add(newCall);
            db.SaveChanges();

            return newCall;

        }

    }
}