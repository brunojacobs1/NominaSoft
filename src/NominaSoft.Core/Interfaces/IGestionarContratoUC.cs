using NominaSoft.Core.DataTransferObjects;
using NominaSoft.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NominaSoft.Core.Interfaces
{
    public interface IGestionarContratoUC
    {
        void Setup(IRepository<Empleado> repositoryEmpleado,
                   IRepository<AFP> repositoryAFP,
                   IRepository<Contrato> repositoryContrato);

        GestionarContratoDTO BuscarEmpleado(String dni);
        GestionarContratoDTO CrearContrato(GestionarContratoDTO gestionarContratoDTO, int empleadoId);

        GestionarContratoDTO CrearNuevoContrato(int empleadoId,
                                                DateTime fechaInicio,
                                                DateTime fechaFin,
                                                string cargo,
                                                int afp,
                                                bool asignacionFamiliar,
                                                int valorHora,
                                                int totalHoras);

        GestionarContratoDTO EditarContrato(GestionarContratoDTO gestionarContratoDTO, int contratoId, int empleadoId);
        GestionarContratoDTO AnularContrato(int contratoId);
        Contrato RetornarContratoVigente(IEnumerable<Contrato> contratos);
        String RetornarMensajeError(Contrato contrato, int empleadoId, bool esEdicion);

    }
}
