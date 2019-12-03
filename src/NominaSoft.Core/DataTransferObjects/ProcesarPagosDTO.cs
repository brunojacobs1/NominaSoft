using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NominaSoft.Core.DataTransferObjects
{
    public class ProcesarPagosDTO
    {
        public PeriodoPago PeriodoPago { get; set; }
        public IList<Contrato> Contratos { get; set; }
        public IList<Tuple<Contrato, BoletaPago>> Filas { get; set; }
        public int PeriodoActivo { get; set; }
        public int ProcesarPagos { get; set; }
        public int ContratosVigentes { get; set; }
        public int PagosProcesados { get; set; }
    }
}
