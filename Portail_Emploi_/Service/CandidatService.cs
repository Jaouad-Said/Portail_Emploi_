using Portail_Emploi_.Context;
using Portail_Emploi_.IService;
using Portail_Emploi_.Models;

namespace Portail_Emploi_.Service
{
    public class CandidatService : ICandidatService
    {
        private readonly CandidaturesContext _context;
        public CandidatService(CandidaturesContext context)
        {
            _context = context;
        }

        public Candidat GetSavedCandidat()
        {
            return _context.Candidats.SingleOrDefault();
        }

        public Candidat Save(Candidat oCandidat)
        {
            _context.Candidats.Add(oCandidat);
            _context.SaveChanges();
            return oCandidat;
        }
    }
}
