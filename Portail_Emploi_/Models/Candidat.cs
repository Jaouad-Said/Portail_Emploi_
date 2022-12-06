using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portail_Emploi_.Models
{
    public class Candidat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Candidat { get; set; }
        [Required]

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string N_Etude { get; set; }
        public int N_Experience { get; set; }
        public string D_Employeur { get; set; }
        public byte[] CV { get; set; }
    }
}
