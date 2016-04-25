using ApoioMVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ApoioMVC.REPOSITORIO
{
    public class ReservaMapper : SqlMapperBase<Reserva>
    {
        public override Reserva MapFromSource(DataRow Record)
        {
            Reserva res = new Reserva();

            res.ID = (int)Record["ID"];
            res.IDCurso = (int)Record["ID_Curso"];
            res.IDProfessor = (int)Record["ID_Professor"];
            res.DtReserva = (DateTime)Record["Dt_Reserva"];
            res.DtAgendamento = (DateTime)Record["Dt_Agendamento"];
            res.IDSala = (int)Record["ID_Sala"];
            return res;
        }
    }
}