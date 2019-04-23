using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicesControlleursEtVue.Models
{
    public class HistoriqueModel
    {
        public int NombreOperationsEnBDD { get; private set; }

        public List<Operation> OperationsDansLaBDD { get; private set; }

        public HistoriqueModel(int nombreOperationsEnBDD, List<Operation> operationsDansLaBdd)
        {
            this.NombreOperationsEnBDD = nombreOperationsEnBDD;
            this.OperationsDansLaBDD = operationsDansLaBdd;
        }
    }
}