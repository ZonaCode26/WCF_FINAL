using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebPractFinal.ServiceReference1;

namespace WebPractFinal.Controllers
{
    public class IndexController : Controller
    {
        Service1Client service = new Service1Client();
        // GET: Index


        int numereg = 10;


        public ActionResult Listado(int ? pag=0)
        {
            int c = service.listaClientes().Count();

            ViewBag.numereg = (c % numereg != 0) ? (c / numereg + 1) : (c / numereg);


            int pagact = (int)pag;
            int regini = pagact * numereg;
            int regfin = regini + numereg;

            List<clientes> lista = new List<clientes>();

            for (int i = regini; i < regfin; i++) {
                if (i == c) break;
                lista.Add(service.listaClientes().ToList()[i]);
            }
            
            return View( lista);
        }





        public ActionResult Eliminar(string id) {
            var reg = service.listaClientes().Where(x => x.idcliente == id).FirstOrDefault();

            if (reg == null) RedirectToAction("Listado");

            ViewBag.mensaje = service.EliminarCliente(id);

            return RedirectToAction("Listado");
        }

        public ActionResult Agregar() {

            ViewBag.pais = new SelectList(service.listaPaises(), "idpais", "nombrepais");
            
            return View(new clientes());
        }

        [HttpPost]
        public ActionResult Agregar(clientes reg)
        {
            if (reg == null) return RedirectToAction("Listado");

            ViewBag.pais = new SelectList(service.listaPaises(), "idpais", "nombrepais",reg.idpais);

            ViewBag.mensaje = service.AgregarCliente(reg);

            return View(reg);
        }




    }
}