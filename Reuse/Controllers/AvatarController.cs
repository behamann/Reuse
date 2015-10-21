using Reuse.Models;
using System.Web.Mvc;

namespace Reuse.Controllers
{
    public class AvatarController : Controller
    {
        private ReuseContext db = new ReuseContext();
        //
        // GET: /Avatar/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Avatar.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}