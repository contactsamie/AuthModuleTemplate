using System.Web.Mvc;

namespace authModule.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class UIController : Controller
    {
        public ActionResult Index(string a, string b, string c, string d, string e,string f)
        {
            var route = (a ?? "index.html") +
                       (string.IsNullOrEmpty(b) ? "" : "/" + b) +
                        (string.IsNullOrEmpty(c) ? "" : "/" + c)+
                        (string.IsNullOrEmpty(d) ? "" : "/" + d)+
                        (string.IsNullOrEmpty(e) ? "" : "/" + e)+
                        (string.IsNullOrEmpty(f) ? "" : "/" + f);
        

            var parts = route.Split('.');
            var type = parts[parts.Length - 1];

            if (type == "cshtml") return PartialView("~/ui/app/" + route);
            var result = new FilePathResult("~/ui/app/" + route, "text/" + type);
            return result;
        }
    }
}
