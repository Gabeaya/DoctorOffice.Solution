using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class PatientsController : Controllers
  {
    private readonly DoctorsOfficeContext _db;
    public PatientsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patients.ToList());
    }

    public ActionResult Details(int id)
    {
        var thisPatient = _db.Patients//this produces a list of patient objects from the database
            .Include(patient => patient.JoinEntities)//this loades the join entities property of each patient
            .ThenInclude(join => join.Doctor)//this loads the doctor of each DoctorPatient relationship
            .FirstOrDefault(patient => patient.PatientId == id);//this specifies which patient from the database were working with
        return View(thisPatient);
    }

  }
}