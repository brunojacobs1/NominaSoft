using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Specifications;
using NominaSoft.Core.DataTransferObjects;

namespace NominaSoft.Infraestructure.UseCases
{
    public class GestionarContratoUC
    {
        public IRepository<Empleado> _repositoryEmpleado { get; set; }
        public IRepository<AFP> _repositoryAFP { get; set; }
        public IRepository<Contrato> _repositoryContrato { get; set; }

        public void Setup(IRepository<Empleado> repositoryEmpleado,
                                            IRepository<AFP> repositoryAFP,
                                            IRepository<Contrato> repositoryContrato)
        {
            _repositoryEmpleado = repositoryEmpleado;
            _repositoryAFP = repositoryAFP;
            _repositoryContrato = repositoryContrato;
        }

        // [GET] GestionarContratoController.BuscarEmpleado
        public GestionarContratoDTO BuscarEmpleado(String dni){
            try
            {
                GestionarContratoDTO gestionarContratoDTO = new GestionarContratoDTO
                {
                    Empleado = _repositoryEmpleado.Get(new BusquedaPorDniSpecification(dni)),
                    Contratos = _repositoryContrato.List(new BusquedaContratosSpecification(dni))
                };

                if (gestionarContratoDTO.Empleado != null)
                {
                    gestionarContratoDTO.AFPs = _repositoryAFP.List();
                    gestionarContratoDTO.Contrato = RetornarContratoVigente(gestionarContratoDTO.Contratos);
                }
                else
                    gestionarContratoDTO.EmpleadoNoEncontrado = 1;

                return gestionarContratoDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // [POST] GestionarContratoController.CrearContrato
        public GestionarContratoDTO CrearContrato(GestionarContratoDTO gestionarContratoDTO, int empleadoId)
        {
            try
            {
                Contrato contrato = new Contrato()
                {
                    Empleado = _repositoryEmpleado.GetById(empleadoId),
                    FechaInicio = gestionarContratoDTO.Contrato.FechaInicio,
                    FechaFin = gestionarContratoDTO.Contrato.FechaFin,
                    Cargo = gestionarContratoDTO.Contrato.Cargo,
                    EsAsignacionFamiliar = gestionarContratoDTO.Contrato.EsAsignacionFamiliar,
                    ValorHora = gestionarContratoDTO.Contrato.ValorHora,
                    TotalHorasSemanales = gestionarContratoDTO.Contrato.TotalHorasSemanales,
                    EsAnulado = false,
                    AFP = gestionarContratoDTO.Contrato.AFP.IdAFP != 0 ? _repositoryAFP.GetById(gestionarContratoDTO.Contrato.AFP.IdAFP) : null
                };

                gestionarContratoDTO = new GestionarContratoDTO();

                gestionarContratoDTO.MensajeError += RetornarMensajeError(contrato, empleadoId);

                if (!String.IsNullOrEmpty(gestionarContratoDTO.MensajeError))
                {
                    gestionarContratoDTO.ErrorDatosContrato = 1;
                    return gestionarContratoDTO;
                }

                _repositoryContrato.Add(contrato);
                return new GestionarContratoDTO{ ContratoCreado = 1 };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // [POST] GestionarContratoController.CrearNuevoContrato
        public GestionarContratoDTO CrearNuevoContrato(int empleadoId,
                                                        DateTime fechaInicio,
                                                        DateTime fechaFin,
                                                        string cargo,
                                                        int afp,
                                                        bool asignacionFamiliar,
                                                        int valorHora,
                                                        int totalHoras)
        {
            try
            {
                GestionarContratoDTO gestionarContratoDTO = new GestionarContratoDTO();

                Contrato contrato = new Contrato()
                {
                    Empleado = _repositoryEmpleado.GetById(empleadoId),
                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,
                    Cargo = cargo,
                    EsAsignacionFamiliar = asignacionFamiliar,
                    ValorHora = valorHora,
                    TotalHorasSemanales = totalHoras,
                    EsAnulado = false,
                    AFP = _repositoryAFP.GetById(afp)
                };

                gestionarContratoDTO.MensajeError += RetornarMensajeError(contrato, empleadoId);

                if (!String.IsNullOrEmpty(gestionarContratoDTO.MensajeError))
                {
                    gestionarContratoDTO.ErrorDatosContrato = 1;
                    return gestionarContratoDTO;
                }

                _repositoryContrato.Add(contrato);

                return new GestionarContratoDTO{ ContratoCreado = 1};
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // [POST] GestionarContratoController.EditarContrato
        public GestionarContratoDTO EditarContrato(GestionarContratoDTO gestionarContratoDTO, int contratoId, int empleadoId)
        {
            try
            {
                gestionarContratoDTO.Contrato.Empleado = _repositoryEmpleado.GetById(empleadoId);

                gestionarContratoDTO.MensajeError += RetornarMensajeError(gestionarContratoDTO.Contrato, empleadoId);

                if (!String.IsNullOrEmpty(gestionarContratoDTO.MensajeError))
                {
                    gestionarContratoDTO.ErrorDatosContrato = 1;
                    gestionarContratoDTO.Contrato = null;

                    return gestionarContratoDTO;
                }

                Contrato contrato = _repositoryContrato.GetById(contratoId);
                contrato.FechaInicio = gestionarContratoDTO.Contrato.FechaInicio;
                contrato.FechaInicio = gestionarContratoDTO.Contrato.FechaInicio;
                contrato.FechaFin = gestionarContratoDTO.Contrato.FechaFin;
                contrato.Cargo = gestionarContratoDTO.Contrato.Cargo;
                contrato.AFP = _repositoryAFP.GetById(gestionarContratoDTO.Contrato.AFP.IdAFP);
                contrato.EsAsignacionFamiliar = gestionarContratoDTO.Contrato.EsAsignacionFamiliar;
                contrato.ValorHora = gestionarContratoDTO.Contrato.ValorHora;
                contrato.TotalHorasSemanales = gestionarContratoDTO.Contrato.TotalHorasSemanales;

                _repositoryContrato.Edit(contrato);

                return new GestionarContratoDTO{ ModificacionesContrato = 1 };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // [POST] GestionarContratoController.AnularContrato
        public GestionarContratoDTO AnularContrato (int contratoId)
        {
            try
            {
                Contrato contrato = _repositoryContrato.GetById(contratoId);
                contrato.EsAnulado = true;
                _repositoryContrato.Edit(contrato);

                return new GestionarContratoDTO{ ContratoAnulado = 1 };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Funciones genéricas

        public Contrato RetornarContratoVigente(IEnumerable<Contrato> contratos)
        {
            foreach (Contrato contrato in contratos.ToList())
            {
                if (contrato.VerificarVigencia())
                    return contrato;
            }

            return null;
        }

        public String RetornarMensajeError(Contrato contrato, int empleadoId)
        {
            if (contrato.AFP == null)
                return "AFP no seleccionada.";
            // R01
            else if (!contrato.VerificarVigencia())
                return "El contrato no es vigente.";
            // R02
            else if (!contrato.VerificarFechaInicio(_repositoryContrato.LastList(new BusquedaContratoUltimoCreadoSpecification(empleadoId)).SingleOrDefault()))
                return "La fecha inicio no es superior a la fecha fin del último contrato.";
            // R03
            else if (!contrato.VerificarFechaFin())
                return "La fecha fin es incorrecta.";
            // R04
            else if (!contrato.VerificarTotalHorasSemanales())
                return "El total de horas semanales es incorrecto.";
            // R05
            else if (!contrato.VerificarValorHora())
                return "El valor por hora es incorrecto.";

            return null;
        }
    }
}
