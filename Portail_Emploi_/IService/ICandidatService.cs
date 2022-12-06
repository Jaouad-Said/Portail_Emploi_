using Portail_Emploi_.Models;

namespace Portail_Emploi_.IService
{
    public interface ICandidatService
    {
        Candidat Save(Candidat oCandidat);
        Candidat GetSavedCandidat();
    }
}
