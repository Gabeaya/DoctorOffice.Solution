using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class PatientsController : Controller
  {
    private readonly DoctorsOfficeContext _db;
    public PatientsController(DoctorsOfficeContext db)
    {
      _db = db;
    }
    
    [HttpGet]
    public ActionResult Index()
    {
      return View(_db.Patients.ToList());
    }
    
    [HttpGet]
    public ActionResult Details(int id)
    {
        var thisPatient = _db.Patients//this produces a list of patient objects from the database
            .Include(patient => patient.JoinEntities)//this loades the join entities property of each patient
            .ThenInclude(join => join.Doctor)//this loads the doctor of each DoctorPatient relationship
            .FirstOrDefault(patient => patient.PatientId == id);//this specifies which patient from the database were working with
        return View(thisPatient);
    }
    
    [HttpGet]
    public ActionResult Create()
    {
        ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Patient patient, int DoctorId)
    {
        _db.Patients.Add(patient);
        _db.SaveChanges();
        if (DoctorId != 0)
        {
            _db.DoctorPatient.Add(new DoctorPatient() { DoctorId = DoctorId, PatientId = patient.PatientId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
        ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
        return View(thisPatient);
    }

    [HttpPost]
    public ActionResult Edit(Patient patient, int DoctorId)
    {
        if (DoctorId != 0)
        {
          _db.DoctorPatient.Add(new DoctorPatient() { DoctorId = DoctorId, PatientId = patient.PatientId });
        }
        _db.Entry(patient).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public ActionResult AddDoctor(int id)
    {
        var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
        ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
        return View(thisPatient);
    }

    [HttpPost]
    public ActionResult AddDoctor(Patient patient, int DoctorId)
    {
        if (DoctorId != 0)
        {
        _db.DoctorPatient.Add(new DoctorPatient() { DoctorId = DoctorId, PatientId = patient.PatientId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
        var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
        return View(thisPatient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
        _db.Patients.Remove(thisPatient);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteDoctor(int joinId)
    {
        var joinEntry = _db.DoctorPatient.FirstOrDefault(entry => entry.DoctorPatientId == joinId);
        _db.DoctorPatient.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


  }
}