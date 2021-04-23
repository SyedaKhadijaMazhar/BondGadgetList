using BondGadgetsList.Data;
using BondGadgetsList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BondGadgetsList.Controllers
{
    public class GadgetsController : Controller
    {
        // GET: Gadgets
        public ActionResult Index()
        {

            //Generate some fake data and send it to View
            
            List<GadgetModel> gadgets = new List<GadgetModel>();
            /*
            gadgets.Add(new GadgetModel(0, "Gun" , "A secret gun" , "Moonraker" , "Actor name"));

            gadgets.Add(new GadgetModel(1, "Knife", "A secret knife", "Moonraker", "Actor name"));

            gadgets.Add(new GadgetModel(2, "Rope", "A secret rope", "Moonraker", "Actor name"));

            gadgets.Add(new GadgetModel(3, "Car", "A secret car", "Moonraker", "Actor name"));
            */

            GadgetDAO gadgetDAO = new GadgetDAO();

            gadgets = gadgetDAO.FetchAll();

            return View("Index" , gadgets);
        }
        public ActionResult Details(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
          GadgetModel  gadget = gadgetDAO.FetchOne(id);

            return View("Details", gadget);
        }

        public ActionResult Create()
        {
           
            return View("GadgetForm");
        }

        public ActionResult Edit(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FetchOne(id);

            return View("GadgetForm", gadget);
        }

        public ActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            // save to the db
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.CreateOrUpdate(gadgetModel);
            return View("Details", gadgetModel);
        }
    }
}