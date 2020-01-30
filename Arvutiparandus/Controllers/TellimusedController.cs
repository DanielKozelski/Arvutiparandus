using Arvutiparandus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arvutiparandus.Controllers
{
    public class TellimusedController:Controller
    {
        ArvutiparandusDB _db = new ArvutiparandusDB();

        public ActionResult Uus()
        {
            var model = new TellimusViewModel();

            List<SelectListItem> ArvutityypNimekiri = new List<SelectListItem>();
            ArvutityypNimekiri.Add(new SelectListItem { Text = "Sülearvuti", Value = "Sülearvuti" });
            ArvutityypNimekiri.Add(new SelectListItem { Text = "Lauaarvuti", Value = "Lauaarvuti" });
            model.ArvutityypNimekiri = ArvutityypNimekiri;

            List<SelectListItem> TeenusedNimekiri = new List<SelectListItem>();
            TeenusedNimekiri.Add(new SelectListItem { Text = "Vali Teenus", Value = "" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Diagnostika", Value = "Diagnostika: 20€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "BIOS Uuendus", Value = "BIOS Uuendus: 30€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Tolmupuhastus", Value = "Tolmupuhastus: 10€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Viiruste eemaldamine", Value = "Viiruste eemaldamine: 25€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Arvutipuhastus ebavajalikest failidest", Value = "Arvutipuhastus ebavajalikest failidest: 15€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Tarkvara paigaldus", Value = "Tarkvara paigaldus: 15€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Ekraani parandus", Value = "Ekraani parandus: 40€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Muutmäli lisamine", Value = "Muutmäli lisamine: 60€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Viirusetõrje paigaldus", Value = "Viirusetõrje paigaldus: 25€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Kõvaketta vahetus", Value = "Kõvaketta vahetus: 40€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Helikaardi vahetus", Value = "Helikaardi vahetus: 30€" });
            TeenusedNimekiri.Add(new SelectListItem { Text = "Videokaardi vahetus", Value = "Videokaardi vahetus: 90€" });
            model.TeenusedNimekiri = TeenusedNimekiri;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Uus(TellimusViewModel tellimus)
        {
            Tellimus uusTellimus = new Tellimus();

            uusTellimus.Arvutityyp = tellimus.Arvutityyp;
            uusTellimus.Teenused = tellimus.Teenused;
            uusTellimus.Klient = tellimus.Klient;

            _db.Tellimused.Add(uusTellimus);
            _db.SaveChanges();
            return RedirectToAction("Uus", "Tellimused");
        }

        public ActionResult Tellimused()
        {
            var model = _db.Tellimused.ToList();
            return View(model);
        }

        public ActionResult Maksmiseks()
        {
            var model = from r in _db.Tellimused.ToList() where r.Makstud == false && r.Tehtud == true select r;
            return View(model);
        }

        public ActionResult Taitmiseks()
        {
            var model = from r in _db.Tellimused.ToList() where r.Tehtud == false select r;
            return View(model);
        }

        public ActionResult KustutaTellimus(int id)
        {
            _db.Tellimused.Remove(_db.Tellimused.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Tellimused", "Tellimused");
        }

        public ActionResult MaksaTellimus(int id)
        {
            Tellimus tellimus = _db.Tellimused.Find(id);
            tellimus.Makstud = true;
            _db.Entry(tellimus).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Maksmiseks", "Tellimused");
        }

        public ActionResult MargiTehtuksTellimus(int id)
        {
            Tellimus tellimus = _db.Tellimused.Find(id);
            tellimus.Tehtud = true;
            _db.Entry(tellimus).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Taitmiseks", "Tellimused");
        }
    }
}