using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verlof.Data;

namespace Verlof.Repositories
{
    enum Status
    {
        Nieuw_ingevoerd,
        Goedgekeurd,
        Afgekeurd
    }
    public class AanvragenRepository
    {
        private AanvragenContext db;
        public AanvragenRepository(AanvragenContext context)
        {
            db = context;
        }
        internal void addAanvraag(Aanvragen aanvragen)
        {
            aanvragen.StatusAanvraag =  Status.Nieuw_ingevoerd.ToString();
            db.Aanvragen.Add(aanvragen);
            db.SaveChanges();
        }

        internal List<Aanvragen> GetAlleAanvragen()
        {
            return db.Aanvragen.Select(a => a).ToList();
        }

        internal void updateAanvraag(Aanvragen aanvragen, int id)
        {
            Aanvragen aanvraagOud = getAanvraag(id);
            aanvraagOud.StatusAanvraag = aanvragen.StatusAanvraag ?? aanvraagOud.StatusAanvraag;
            aanvraagOud.NaamManager = aanvragen.NaamManager ?? aanvraagOud.NaamManager;
            aanvraagOud.MotivatieManager = aanvragen.MotivatieManager ?? aanvraagOud.MotivatieManager;
            db.Aanvragen.Update(aanvraagOud);
            db.SaveChanges();
        }

        internal Aanvragen getAanvraag(int id)
        {
            return db.Aanvragen.Where(a => a.Id == id).Select(a => a).FirstOrDefault();
        }
    }
}
