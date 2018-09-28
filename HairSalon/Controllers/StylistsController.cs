using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    [HttpGet("/stylists")]
    public ActionResult Index()
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View(allStylists);
      }

    [HttpGet("/stylists/add")]
    public ActionResult CreateForm()
      {
        Dictionary<string, object> newDictionary = new Dictionary<string, object> {};
        List<Stylist> allStylists = Stylist.GetAll();
        List<Specialty> allSpecialties = Specialty.GetAll();
        newDictionary.Add("Stylist", allStylists);
        newDictionary.Add("Specialty", allSpecialties);
        return View(newDictionary);
      }

    [HttpPost("/stylists")]
      public ActionResult Create()
      {
        Stylist newStylist = new Stylist(Request.Form["stylistsName"]);
        newStylist.Save();
        Specialty newSpecialty = Specialty.Find(Int32.Parse(Request.Form["specialty"]));
        newStylist.AddSpecialty(newSpecialty);
        List<Specialty> allSpecialties = Specialty.GetAll();
        return RedirectToAction("Index");
      }

    [HttpGet("/stylists/{id}")]
      public ActionResult Details(int id)
      {
        Dictionary<string, object> secondDictionary = new Dictionary<string, object>();
        Stylist selectedStylist = Stylist.Find(id);
        List<Client> stylistClients = selectedStylist.GetClient();
        List<Specialty> stylistSpecialties = selectedStylist.GetSpecialty();
        List<Specialty> allSpecialties = Specialty.GetAll();
        secondDictionary.Add("Stylist", selectedStylist);
        secondDictionary.Add("Client", stylistClients);
        secondDictionary.Add("Specialty", stylistSpecialties);
        secondDictionary.Add("Specialties", allSpecialties);
        return View(secondDictionary);
      }

    [HttpPost("/stylists/{id}/addSpecialty")]
      public ActionResult AddSpecialty(int id)
      {
        Stylist newStylist = Stylist.Find(id);
        Specialty newSpecialty = Specialty.Find(Int32.Parse(Request.Form["specialties"]));
        newStylist.AddSpecialty(newSpecialty);
        List<Specialty> allSpecialties = Specialty.GetAll();
        return RedirectToAction("Details");
      }

    [HttpGet("/stylists/{id}/update")]
      public ActionResult UpdateForm(int id)
      {
        Stylist stylist = Stylist.Find(id);
        return View(stylist);
      }

    [HttpPost("/stylists/{id}/update")]
      public ActionResult Update(int id)
      {
          Stylist thisStylist = Stylist.Find(id);

          thisStylist.Edit(Request.Form["newName"]);
          return RedirectToAction("Index");
      }


  }
}
