using OnlineDebateWeb.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;

namespace OnlineDebateWeb.Controllers
{
    public class HomeController : Controller
    {
        private OnlineDebateDB db = new OnlineDebateDB();

        // GET: /Debate/
        public async Task<ActionResult> Index()
        {
            return View(await db.DebateTopics.ToListAsync());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}