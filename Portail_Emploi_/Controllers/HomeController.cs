using Microsoft.AspNetCore.Mvc;
using Portail_Emploi_.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Portail_Emploi_.IService;

namespace Portail_Emploi_.Controllers
{
    public class HomeController : Controller
    {
        ICandidatService _candidatService = null;

        public HomeController(ICandidatService candidatService)
        {
            _candidatService = candidatService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SaveFile(FileUpload fileObj)
        {
            Candidat oCandidat = JsonConvert.DeserializeObject<Candidat>(fileObj.Candidat);
            if (fileObj.file.Length > 0)
            {
                using ( var ms = new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oCandidat.CV = fileBytes;

                    oCandidat = _candidatService.Save(oCandidat);
                    if(oCandidat.ID_Candidat > 0)
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed";
        }

        public JsonResult GetSavedCandidat()
        {
            var candidat = _candidatService.GetSavedCandidat();
            candidat.CV = this.GetImage(Convert.ToBase64String(candidat.CV));
            return Json(candidat);
        }

        private byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
    }
}