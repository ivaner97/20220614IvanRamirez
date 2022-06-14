using Citas.Context;
using Citas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Controllers
{
    public class CitaController : Controller
    {
        DBContext dBContext = new DBContext();
        DateTime hoy = DateTime.Now;
        public IActionResult Index()
        {
            List<Cita> model = dBContext.GetCita().ToList();
            return View(model);
        }

        public ActionResult Cliente(int id)
        {
            
            Cliente cliente = dBContext.GetClientes(id);
            
            Cita model = new Cita
            {
                Fecha = hoy,
                Hora = Convert.ToDateTime(hoy.ToShortTimeString()),
                cliente = cliente.Nombre + " " + cliente.Apellido,
                Idcliente = cliente.IdCliente,
                ListaMedicos = dBContext.GetMedico().ToList()
            };
            return View(model);
        }

        public ActionResult Create()
        {
            Cita model = new Cita
            {
                Fecha = hoy,
                Hora = Convert.ToDateTime(hoy.ToShortTimeString()),
                ListaMedicos = dBContext.GetMedico().ToList(),
                ListaClientes = dBContext.GetClientes().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Cita model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dBContext.CreateCita(model);
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
            if (id == 0)
            {
                return NotFound();
            }

            Cita model = dBContext.GetCita(id);
            model.ListaMedicos = dBContext.GetMedico().ToList();
            model.ListaClientes = dBContext.GetClientes().ToList();
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Cita model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dBContext.UpdateCita(model);
                    return RedirectToAction(nameof(Index));
                }
                model.ListaMedicos = dBContext.GetMedico().ToList();
                model.ListaClientes = dBContext.GetClientes().ToList();
                return View(model);
            }
            catch (Exception)
            {
                model.ListaMedicos = dBContext.GetMedico().ToList();
                model.ListaClientes = dBContext.GetClientes().ToList();
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Cita model = dBContext.GetCita(id);
                if (model == null)
                {
                    return NotFound();
                }
                dBContext.DeleteCita(model.IdCita);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }
        public IActionResult Finalizar(int id)
        {
            Cita model = dBContext.GetCita(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Finalizar(Cita model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dBContext.FinalizarCita(model);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public IActionResult Diagnostico()
        {
            List<Cita> model = dBContext.GetCitaFin().ToList();
            return View(model);
        }

        
    }
}
