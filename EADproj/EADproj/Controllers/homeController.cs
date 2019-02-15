using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EADproj.Models;

namespace EADproj.Controllers
{
    public class homeController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        //
        // GET: /home/
       

        public ActionResult index()
        {
            return View();
        }

        public ActionResult manu()
        {
            return View();
        }

        public ActionResult manc()
        {
            return View();
        }

        public ActionResult chelsea()
        {
            return View();
        }

        public ActionResult LFC()
        {
            return View();
        }

        public ActionResult arsenal()
        {
            return View();
        }
        public ActionResult Add()
        {
            Session["myId"] = "";
            user p = new user();
            
            p.uname = Request["uname"];

            if (dc.users.Any(k => k.uname == p.uname))
            {
                TempData["err"] = "Username already used.";
                return RedirectToAction("form");
            }
            p.password = Request["password"];
            p.email = Request["email"];
            if (dc.users.Any(k => k.email == p.email))
            {
                TempData["err"] = "Email already used.";
                return RedirectToAction("form");
            }
            p.phone = Request["phone"];
            if (dc.users.Any(k => k.phone == p.phone))
            {
                TempData["err"] = "Username already used.";
                return RedirectToAction("form");
            }

            dc.users.InsertOnSubmit(p);
            dc.SubmitChanges();

            return RedirectToAction("loginform");
        }

        
       

        public ActionResult Delete(int id)
        {
            var d = dc.users.First(k => k.Id == id);

            dc.users.DeleteOnSubmit(d);
            dc.SubmitChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult about()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult addPlayer()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult form()
        {
            return View();
        }

        public ActionResult loginform()
        {
            return View();
        }

        public ActionResult loginFunct()
        {
            
            

            var email = Request["email"];
            var password = Request["password"];


            if (dc.users.Any(k => k.email == email && k.password == password))
            {
                Session["uname"] = dc.users.First(k => k.email == email).uname;
                Session["type"] = dc.users.First(k => k.email == email).type;

                return RedirectToAction("Categories");
            }

            TempData["err"] = "Invalid email/password.";
            return RedirectToAction("loginform");
        }

        public ActionResult logout()
        {



            Session["uname"] = null;
            Session["type"] = null;

            
            return RedirectToAction("index");
        }

        public ActionResult players(int? cid)
        {
            if (cid == null)
            {
                return RedirectToAction("index");
            }
            

            return View(dc.players.Where(k=>k.cid == cid).ToList());
        }

        public ActionResult deletePlayer(int? pid, int? cid)
        {
            if (pid == null)
            {
                return RedirectToAction("index");
            }

            if (cid == null)
            {
                return RedirectToAction("index");
            }

            if (dc.players.Any(k => k.pid == pid))
            {
                var d = dc.players.First(k => k.pid == pid);

                dc.players.DeleteOnSubmit(d);
                dc.SubmitChanges();

                return RedirectToAction("players", "Home", new { cid = cid });


            }
            else
            {
                TempData["err"] = "Player Does not exist.";
                return RedirectToAction("players", "Home", new {cid = cid });
            }

        }

        public ActionResult addPlayerFunct()
        {
            
            Session["myId"] = "";
            player pl = new player();
            
            pl.pname = Request["pname"];

            if (dc.players.Any(k => k.pname == pl.pname))
            {
                TempData["err"] = "player name already used.";
                return RedirectToAction("addPlayer");
            }
            pl.age = int.Parse(Request["age"]);
            pl.goals = int.Parse(Request["goals"]);
            
            pl.nationality = Request["nationality"];
            
            pl.assists = int.Parse(Request["assists"]);
            pl.cid = int.Parse(Request["cid"]);
            dc.players.InsertOnSubmit(pl);
            dc.SubmitChanges();

            return RedirectToAction("addPlayer");
            //return RedirectToAction("players", "Home", new { cid = cid });
        }

        public ActionResult editPlayer(int? id)
        {
            return View(dc.players.First(j => j.pid == id));
        }

        public ActionResult editPlayerFunct(int? id)
        {
            var s = dc.players.First(k => k.pid == id);

            s.pname = Request["pname"];
            s.age = int.Parse(Request["age"]);
            s.assists = int.Parse(Request["assists"]);
            s.goals = int.Parse(Request["goals"]);
            s.nationality = Request["nationality"];

            dc.SubmitChanges();
            return RedirectToAction("Categories");

        }
        

    }
}
