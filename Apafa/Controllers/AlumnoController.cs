using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DA;

namespace Apafa.Controllers
{
    public class AlumnoController : Controller
    {
        private apafaEntities db = new apafaEntities();

        // GET: Alumno
        public ActionResult Index()
        {
            return View(db.Alumno.ToList());
        }

        // GET: Alumno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: Alumno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Apellidos,Nombres,Dni,Grado,Seccion,Direccion,Sexo,FechaNacimiento,Celular,Correo,NombreApoderado,DniApoderado,CelularApoderado,NombrePadre,DniPadre,CelularPadre,NombreMadre,DniMadre,CelularMadre")] Alumno alumno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    alumno.NombreCompleto = alumno.Apellidos + " " + alumno.Nombres;
                    db.Alumno.Add(alumno);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(alumno);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        // GET: Alumno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Apellidos,Nombres,NombreCompleto,Dni,Grado,Seccion,Direccion,Sexo,FechaNacimiento,Celular,Correo,NombreApoderado,DniApoderado,CelularApoderado,NombrePadre,DniPadre,CelularPadre,NombreMadre,DniMadre,CelularMadre")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumno alumno = db.Alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumno alumno = db.Alumno.Find(id);
            db.Alumno.Remove(alumno);
            db.SaveChanges();
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
