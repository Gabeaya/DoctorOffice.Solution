using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class SpecialtiesController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public SpecialtiesController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Specialty> model = _db.Specialties.ToList();
      return View(model);
    }

    public ActionResult Create()
        {
          ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
          return View();
        }

    [HttpPost]
    public ActionResult Create(Specialty specialty, int DoctorId)
    {
      _db.Specialties.Add(specialty);
      _db.SaveChanges();
      if (DoctorId != 0)
      {
        _db.DoctorSpecialty.Add(new DoctorSpecialty() { DoctorId = DoctorId, SpecialtyId = specialty.SpecialtyId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
    var thisSpecialty = _db.Specialties
        .Include(specialty => specialty.JoinEntities2)
        .ThenInclude(join => join.Patient)
        .Include(specialty => specialty.JoinEntities3)
        .ThenInclude(join => join.Specialty)
        .FirstOrDefault(specialty => specialty.SpecialtyId == id);
    return View(thisSpecialty);
    }

    [HttpGet]
    public ActionResult DocSpecialty(int id)
    {
      var thisSpecialty = _db.Specialties.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View(thisSpecialty);
    }


    [HttpPost]
    public ActionResult DocSpecialty(Doctor doctor, int SpecialtyId)
    {
        if (SpecialtyId != 0)
        {
        _db.DoctorSpecialty.Add(new DoctorSpecialty() { SpecialtyId = SpecialtyId, DoctorId = doctor.DoctorId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisSpecialty = _db.Specialties.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    [HttpPost]
    public ActionResult Edit(Specialty specialty)
    {
      _db.Entry(specialty).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSpecialty = _db.Specialties.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSpecialty = _db.Specialties.FirstOrDefault(specialty => specialty.SpecialtyId == id);
      _db.Specialties.Remove(thisSpecialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
