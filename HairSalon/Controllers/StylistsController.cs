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
        return View();
      }

    [HttpPost("/stylists")]
      public ActionResult Create()
      {
        // description = Request.Form("itemDescription");
        Stylist newStylist = new Stylist(Request.Form["stylistsName"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View("Index", allStylists);
      }

    [HttpGet("/stylists/{id}")]
      public ActionResult Details(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Stylist selectedStylist = Stylist.Find(id);
        List<Client> stylistClients = selectedStylist.GetClient();

        model.Add("Stylist", selectedStylist);
        model.Add("Client", stylistClients);
        return View(model);
      }
  }
}
