using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApoioMVC.MODEL
{
    public class Reserva
    {
        public int ID { get; set; }
        public DateTime DtReserva { get; set; }
        public int IDSala { get; set; }
        public int IDProfessor { get; set; }
        public int IDCurso { get; set; }
        public DateTime DtAgendamento { get; set; }
    }
}