using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public DoctorsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Doctor> model = _db.Doctors.ToList();
      return View(model);
    }

    [HttpGet]
    public ActionResult Create()
    {
      ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor, int SpecialtyId)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
    var thisDoctor = _db.Doctors
        .Include(doctor => doctor.JoinEntities)
        .ThenInclude(join => join.Patient)
        .FirstOrDefault(doctor => doctor.DoctorId == id);
    return View(thisDoctor);
    }
    
    public ActionResult Edit(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Doctor doctor)
    {
      _db.Entry(doctor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctor => doctor.DoctorId == id);
      _db.Doctors.Remove(thisDoctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}