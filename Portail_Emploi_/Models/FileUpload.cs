using Microsoft.AspNetCore.Http;
namespace Portail_Emploi_.Models
{
    public class FileUpload
    {
        public IFormFile file { get; set; }
        public string Candidat { get; set; }
    }
}
