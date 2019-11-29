using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NominaSoft.Core.Entities;
using NominaSoft.Core.Interfaces;
using NominaSoft.Core.Specifications;

namespace NominaSoft.Core.UseCases
{
    public class GestionarContratoUseCases
    {
        public readonly IRepository<Empleado> _repositoryEmpleado;
        public readonly IRepository<AFP> _repositoryAFP;
        public readonly IRepository<Contrato> _repositoryContrato;

        public GestionarContratoUseCases(IRepository<Empleado> repositoryEmpleado,
                                            IRepository<AFP> repositoryAFP,
                                            IRepository<Contrato> repositoryContrato)
        {
            _repositoryEmpleado = repositoryEmpleado;
            _repositoryAFP = repositoryAFP;
            _repositoryContrato = repositoryContrato;
        }

        public AFP RetornarAFPValida(int idAFP) => idAFP != 0 ? _repositoryAFP.GetById(idAFP) : null;

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
            // AFP
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
