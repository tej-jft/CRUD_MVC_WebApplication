using CRUD_MVC_WebApplication.Models;
using CRUD_MVC_WebApplication.Repository;
using System.Web.Mvc;

namespace CRUD_MVC_WebApplication.Controllers
{
    public class RolesManagerController : Controller
    {
        // GET: RolesManager
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRoleManger()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRoleManger(RolesModel role)
        {
            RoleManagerRepo r = new RoleManagerRepo();
            r.AddRole(role);
            return RedirectToAction("ShowRoleManagers", "RolesManager");
        }
        public ActionResult ShowRoleManagers()
        {
            RoleManagerRepo r = new RoleManagerRepo();
            ModelState.Clear();
            return View(r.GetAllRoles());
        }
    }
}