using ExercicesControlleursEtVue.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExercicesControlleursEtVue.Controllers
{
    public class OperationController : Controller
    {
        public ActionResult Historique()
        {
            int nombreOperations = DataAccess.GetNombreOperationsEnBdd();
            List<Operation> operations = DataAccess.RecupererListeOperationsEffectuees();
            HistoriqueModel model = new HistoriqueModel(nombreOperations, operations);

            return View(model);
        }
    }
}