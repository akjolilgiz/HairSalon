using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {
    [HttpGet("/specialties")]
    public ActionResult Index()
      {
        List<Specialty> allSpecialties = Specialty.GetAll();
        return View(allSpecialties);
      }

    [HttpGet("/specialties/add")]
    public ActionResult CreateForm()
      {
        Dictionary<string, object> newDictionary = new Dictionary<string, object> {};
        List<Stylist> allStylists = Stylist.GetAll();
        List<Specialty> allSpecialties = Specialty.GetAll();
        newDictionary.Add("Stylist", allStylists);
        newDictionary.Add("Specialty", allSpecialties);
        return View(newDictionary);
      }

    [HttpPost("/specialties")]
      public ActionResult Create()
      {
        Specialty newSpecialty = new Specialty(Request.Form["specialtyDescription"]);
        newSpecialty.Save();
        Stylist newStylist = newSpecialty.AddStylist(newStylist);
        List<Specialty> allSpecialties = Specialty.GetAll();
        return View("Index", allSpecialties);
      }

    [HttpGet("/specialties/{id}")]
      public ActionResult Details(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Specialty selectedSpecialty = Specialty.Find(id);
        List<Stylist> specialtyStylists = selectedSpecialty.GetStylist();

        model.Add("Specialty", selectedSpecialty);
        model.Add("specialtyStylists", specialtyStylists);
        return View(model);
      }
  }
}
