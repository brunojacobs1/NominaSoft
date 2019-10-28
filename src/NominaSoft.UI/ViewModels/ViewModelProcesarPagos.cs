using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaSoft.UI.ViewModels
{
    public class ViewModelProcesarPagos
    {
        public PeriodoPago PeriodoPago { get; set; }
        public IEnumerable<Contrato> Contratos { get; set; }
        public ICollection<Planilla> Planillas { get; set; }
        public int PeriodoNoActivo { get; set; }
        public int ProcesarPagos { get; set; }
        public int ContratosVigentes { get; set; }
    }
}
