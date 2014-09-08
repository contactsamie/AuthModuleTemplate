using System.Web.Mvc;

namespace authModule.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class UIController : Controller
    {
        public ActionResult Index(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j, string k, string l)
        {
            var route = (a ?? "index.html") +
                       (string.IsNullOrEmpty(b) ? "" : "/" + b) +
                        (string.IsNullOrEmpty(c) ? "" : "/" + c)+
                        (string.IsNullOrEmpty(d) ? "" : "/" + d)+
                        (string.IsNullOrEmpty(e) ? "" : "/" + e)+
                        (string.IsNullOrEmpty(f) ? "" : "/" + f) +
                       (string.IsNullOrEmpty(g) ? "" : "/" + g) +
                        (string.IsNullOrEmpty(h) ? "" : "/" + h) +
                        (string.IsNullOrEmpty(i) ? "" : "/" + i) +
                        (string.IsNullOrEmpty(j) ? "" : "/" +j) +
                        (string.IsNullOrEmpty(k) ? "" : "/" + k) +
                        (string.IsNullOrEmpty(l) ? "" : "/" + l);
        

            var parts = route.Split('.');
            var type = parts[parts.Length - 1];

            var foreType = (type == "png" || type == "jpg" || type == "jpeg" || type == "gif") ? "image" : "text";


            if (type == "cshtml") return PartialView("~/Views/"+route);
          //  if (type == "cshtml") return PartialView("~/ui/app/" + route);
            var result = new FilePathResult("~/ui/app/" + route, foreType+"/" + type);
            return result;
        }
    }
}
