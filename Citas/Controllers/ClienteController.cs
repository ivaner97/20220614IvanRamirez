using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Citas.Context;
using Citas.Models;

namespace Citas.Controllers
{
    public class ClienteController : Controller
    {
        DBContext dBContext = new DBContext();
        public IActionResult Index()
        {
            List<Cliente> ClienteList = dBContext.GetClientes().ToList();
            return View(ClienteList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dBContext.CreateCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            Cliente cliente = dBContext.GetClientes(id);
            if(cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dBContext.UpdateCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                Cliente cliente = dBContext.GetClientes(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                dBContext.DeleteCliente(cliente.IdCliente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
