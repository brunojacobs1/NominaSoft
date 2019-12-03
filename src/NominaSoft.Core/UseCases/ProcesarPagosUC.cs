using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Specifications;
using NominaSoft.Core.DataTransferObjects;

namespace NominaSoft.Core.UseCases
{
    public class ProcesarPagosUC : IProcesarPagosUC
    {
        public IRepository<AFP> _repositoryAFP { get; set; }
        public IRepository<Contrato> _repositoryContrato { get; set; }
        public IRepository<Empleado> _repositoryEmpleado { get; set; }
        public IRepository<BoletaPago> _repositoryBoletaPago { get; set; }
        public IRepository<PeriodoPago> _repositoryPeriodoPago { get; set; }
        public IRepository<ConceptosDePago> _repositoryConceptosDePago { get; set; }

        public void Setup(IRepository<AFP> repositoryAFP,
                                        IRepository<Contrato> repositoryContrato,
                                        IRepository<Empleado> repositoryEmpleado,
                                        IRepository<BoletaPago> repositoryBoletaPago,
                                        IRepository<PeriodoPago> repositoryPeriodoPago,
                                        IRepository<ConceptosDePago> repositoryConceptosDePago)
        {
            _repositoryAFP = repositoryAFP;
            _repositoryContrato = repositoryContrato;
            _repositoryEmpleado = repositoryEmpleado;
            _repositoryBoletaPago = repositoryBoletaPago;
            _repositoryPeriodoPago = repositoryPeriodoPago;
            _repositoryConceptosDePago = repositoryConceptosDePago;
        }

        // [GET] ProcesarPagosController.ProcesarPagos
        public ProcesarPagosDTO ProcesarPagos()
        {
            try
            {
                ProcesarPagosDTO procesarPagosDTO = new ProcesarPagosDTO
                {
                    PeriodoPago = _repositoryPeriodoPago.Get(new BusquedaPeriodoActivoSpecification()),
                };

                if (procesarPagosDTO.PeriodoPago == null)
                    procesarPagosDTO.PeriodoActivo = 1;

                return procesarPagosDTO;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        // [POST] ProcesarPagosController.VerificarProcesado
        public ProcesarPagosDTO VerificarProcesado()
        {
            try
            {
                ProcesarPagosDTO procesarPagosDTO = new ProcesarPagosDTO 
                {
                    PeriodoPago = _repositoryPeriodoPago.Get(new BusquedaPeriodoActivoSpecification())
                };

                if (procesarPagosDTO.PeriodoPago == null)
                    return new ProcesarPagosDTO{ PeriodoActivo = 1 };
                if (DateTime.Now <= procesarPagosDTO.PeriodoPago.FechaFin)
                    return new ProcesarPagosDTO{ ProcesarPagos = 1 };

                procesarPagosDTO.Contratos = new List<Contrato>();
                IEnumerable<ConceptosDePago> conceptosDePagos = _repositoryConceptosDePago.List(new BusquedaConceptosPeriodoActivoSpecification());

                foreach(ConceptosDePago concepto in conceptosDePagos)
                {
                    procesarPagosDTO.Contratos.Add(concepto.Contrato);
                }

                if(procesarPagosDTO.Contratos.Count() == 0)
                    return new ProcesarPagosDTO{ ContratosVigentes = 1 };

                BoletaPago boletaPago;
                procesarPagosDTO.Filas = new List<Tuple<Contrato, BoletaPago>>();

                foreach (Contrato contrato in procesarPagosDTO.Contratos)
                {
                    if(contrato.VerificarVigencia())
                    {
                        Contrato tempContrato = _repositoryContrato.Get(new BusquedaContratoIncludesSpecification(contrato.IdContrato));

                        contrato.AFP = _repositoryAFP.GetById(tempContrato.AFP.IdAFP);
                        contrato.Empleado = _repositoryEmpleado.GetById(tempContrato.Empleado.IdEmpleado);

                        ConceptosDePago conceptosDePago = _repositoryConceptosDePago.Get(new BusquedaConceptoPagoSpecification(contrato.IdContrato, procesarPagosDTO.PeriodoPago.IdPeriodoPago));
                        boletaPago = GenerarBoleta(procesarPagosDTO.PeriodoPago, contrato, conceptosDePago);
                        _repositoryBoletaPago.Add(boletaPago);

                        procesarPagosDTO.Filas.Add(new Tuple<Contrato, BoletaPago>(contrato, boletaPago));
                    }
                }

                procesarPagosDTO.PagosProcesados = 1;

                return procesarPagosDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Funciones genéricas
        
        public BoletaPago GenerarBoleta(PeriodoPago periodoPago, Contrato contrato, ConceptosDePago conceptosDePago)
        {
            return new BoletaPago 
            {
                FechaPago = periodoPago.FechaFin,
                Contrato = contrato,
                PeriodoPago = periodoPago,
                ConceptosDePago = conceptosDePago
            };
        }
    }
}
