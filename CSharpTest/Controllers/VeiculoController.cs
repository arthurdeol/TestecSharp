using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.DAL;
using CSharpTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpTest.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculosDAL _dal;
        public VeiculoController(IVeiculosDAL dal)
        {
            _dal = dal;
        }

        public IActionResult Index(string chassi)
        {
            var lstVeiculos = _dal.GetAllVeiculos().ToList();
            if (!String.IsNullOrEmpty(chassi))
            {
                lstVeiculos = _dal.GetFiltraVeiculo(chassi).ToList();
            }

            if(!lstVeiculos.Any())
            {
                TempData["$AlertMessage$"] = "Nenhum veiculo encontrado com o numero desse chassi";
            }

            return View(lstVeiculos);
        }

        public ActionResult AddEditVeiculo(int itemId)
        {
            Veiculo model = new Veiculo();
            if (itemId > 0)
            {
                model = _dal.GetVeiculo(itemId);
            }
            return PartialView("_veiculoForm", model);
        }

        [HttpPost]
        public ActionResult Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                if (veiculo.IdVeiculo > 0)
                {
                    _dal.UpdateVeiculo(veiculo);
                }
                else
                {
                    bool hasVeiculo = _dal.GetAllVeiculos().Where(x => x.Chassi == veiculo.Chassi).FirstOrDefault() != null;
                    if (!hasVeiculo)
                    {

                        _dal.AddVeiculo(veiculo);
                    }
                    else
                    {
                        TempData["$AlertMessage$"] = "Número de chassi já existente, veículo não inserido.";
                    }

                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _dal.DeleteVeiculo(id);
            return RedirectToAction("Index");
        }
    }
}
