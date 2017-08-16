using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaRodolfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contato()
        {
            ViewBag.Message = "Rodolfo Terra";

            return View();
        }

        public ActionResult Perguntas()
        {
            ViewBag.Pergunta = "Lista de perguntas respondidas";
            ViewBag.Tarefa = "Lista de tarefas realizadas";

            return View();
        }
    }
}