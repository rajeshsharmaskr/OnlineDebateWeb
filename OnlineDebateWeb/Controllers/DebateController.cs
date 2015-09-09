using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using OnlineDebateWeb.Models;

namespace OnlineDebateWeb.Controllers
{
    [Authorize]
    public class DebateController : Controller
    {
        private OnlineDebateDB db = new OnlineDebateDB();

        // GET: /Debate/
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await db.DebateTopics.ToListAsync());
        }

        // GET: /Debate/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebateTopics debatetopics = await db.DebateTopics.FindAsync(id);
            if (debatetopics == null)
            {
                return HttpNotFound();
            }
            return View(debatetopics);
        }

        // GET: /Debate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Debate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,CategoryID,UserID,Topic,LikesCount,AddedOn")] DebateTopics debatetopics)
        {
            if (ModelState.IsValid)
            {
                db.DebateTopics.Add(debatetopics);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(debatetopics);
        }

        // GET: /Debate/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebateTopics debatetopics = await db.DebateTopics.FindAsync(id);
            if (debatetopics == null)
            {
                return HttpNotFound();
            }
            return View(debatetopics);
        }

        // POST: /Debate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,CategoryID,UserID,Topic,LikesCount,AddedOn")] DebateTopics debatetopics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debatetopics).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(debatetopics);
        }

        // GET: /Debate/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebateTopics debatetopics = await db.DebateTopics.FindAsync(id);
            if (debatetopics == null)
            {
                return HttpNotFound();
            }
            return View(debatetopics);
        }

        // POST: /Debate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DebateTopics debatetopics = await db.DebateTopics.FindAsync(id);
            db.DebateTopics.Remove(debatetopics);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
