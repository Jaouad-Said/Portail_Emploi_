using Microsoft.EntityFrameworkCore;
using Portail_Emploi_.Models;

namespace Portail_Emploi_.Context
{
    public class CandidaturesContext : DbContext
    {
        public CandidaturesContext(DbContextOptions<CandidaturesContext> options) : base(options)
        {

        }

        public DbSet<Candidat> Candidats { get; set; }
    }
}
