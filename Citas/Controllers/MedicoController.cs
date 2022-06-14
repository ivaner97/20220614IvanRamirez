using Citas.Context;
using Citas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citas.Controllers
{
    public class MedicoController : Controller
    {
        DBContext dBContext = new DBContext();
        public IActionResult Index()
        {
            List<Medico> medicos = dBContext.GetMedico().ToList();
            return View(medicos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Medico model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dBContext.CreateMedico(model);
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

            Medico model = dBContext.GetMedico(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Medico model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dBContext.UpdateMedico(model);
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
                Medico model = dBContext.GetMedico(id);
                if (model == null)
                {
                    return NotFound();
                }
                dBContext.DeleteMedico(model.IdMedico);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
