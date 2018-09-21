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
    [HttpGet("clients/add")]
    public ActionResult CreateForm()
      {
        List<Stylist> allStylists = Stylist.GetAll();
        return View(allStylists);
      }
    [HttpPost("/clients")]
    public ActionResult Create()
    {
      Client newClient = new Client(Request.Form["clientsName"],  int.Parse(Request.Form["stylist"]));
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      return RedirectToAction("Index");
    }
  }
}
