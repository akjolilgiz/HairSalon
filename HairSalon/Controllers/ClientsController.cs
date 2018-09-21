using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }
    [HttpGet("/clients/add")]
    public ActionResult CreateForm()
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View(allStylists);
      }
    [HttpPost("/clients")]
    public ActionResult Create()
    {
      Client newClient = new Client(Request.Form["clientsName"],  Int32.Parse(Request.Form["stylist"]));
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      return RedirectToAction("Index", allClients);
    }
    [HttpGet("/clients/{id}")]
      public ActionResult Details(int id)
      {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Client newClient = Client.Find(id);
        int stylistId = newClient.stylist_id;
        Stylist newStylist = Stylist.Find(stylistId);
        model.Add("Client", newClient);
        model.Add("Stylist", newStylist);
        return View(model);
      }

    [HttpGet("/clients/{id}/update")]
      public ActionResult UpdateForm(int id)
      {
        Dictionary<string, object> newDictionary = new Dictionary<string, object>();
        List<Stylist> allStylists = Stylist.GetAll();
        Client foundClient = Client.Find(id);
        newDictionary.Add("Stylist", allStylists);
        newDictionary.Add("Client", foundClient);
        return View(newDictionary);
      }

    [HttpPost("/clients/{id}/update")]
      public ActionResult Update(int id)
      {
          Client thisClient = Client.Find(id);

          thisClient.Edit(Request.Form["updateName"], Int32.Parse(Request.Form["stylist"]));
          return RedirectToAction("Index");
      }

  }
}
