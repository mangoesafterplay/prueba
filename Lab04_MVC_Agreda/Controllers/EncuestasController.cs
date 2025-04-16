using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab04_MVC_Agreda.Models;

namespace Lab04_MVC_Agreda.Controllers
{
    public class EncuestasController : Controller
    {
        private clsEncuestas encuesta;

        // GET: Encuestas

        public EncuestasController()
        {
            if (System.Web.HttpContext.Current.Session["encuesta"] == null)
            {
                encuesta = new clsEncuestas();

                //Definir el titulo de la encuesta
                encuesta.titulo = "¿Cuál es tu lenguaje de programación favorito?";
                encuesta.cantidadTotal = 0;
                encuesta.alternativa = new List<clsAlternativa>();

                //Definir las alternativas de la pregunta
                clsAlternativa alternativa1 = new clsAlternativa();

                alternativa1.titulo = "Visual Basic";
                alternativa1.cantidad = 0;
                alternativa1.porcentaje = 0;

                encuesta.alternativa.Add(alternativa1);

                clsAlternativa alternativa2 = new clsAlternativa();

                alternativa2.titulo = "JavaScript";
                alternativa2.cantidad = 0;
                alternativa2.porcentaje = 0;

                encuesta.alternativa.Add(alternativa2);

                clsAlternativa alternativa3 = new clsAlternativa();

                alternativa3.titulo = "C#";
                alternativa3.cantidad = 0;
                alternativa3.porcentaje = 0;

                encuesta.alternativa.Add(alternativa3);

                clsAlternativa alternativa4 = new clsAlternativa();

                alternativa4.titulo = "Android";
                alternativa4.cantidad = 0;
                alternativa4.porcentaje = 0;

                encuesta.alternativa.Add(alternativa4);

                System.Web.HttpContext.Current.Session["encuesta"] = encuesta;
            }
            else
            {
                encuesta = System.Web.HttpContext.Current.Session["encuesta"] as clsEncuestas;
            }
        }

        [HttpGet]
        public ActionResult Index(clsEncuestas Encuesta)
        {
            return View(encuesta);
        }

        [HttpPost]
        public ActionResult Index()
        {
            int index = Int32.Parse(Request["index"].ToString());

            clsAlternativa alternativa = encuesta.alternativa[index];

            alternativa.cantidad++;

            encuesta.cantidadTotal = encuesta.alternativa.Sum(x => x.cantidad);

            foreach (clsAlternativa alt in encuesta.alternativa)
            {
                alt.porcentaje = alt.cantidad * 100 / encuesta.cantidadTotal;
            }

            System.Web.HttpContext.Current.Session["encuesta"] = encuesta;

            return View(encuesta);
        }
    }
}
