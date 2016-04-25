using ApoioMVC.INFRA;
using ApoioMVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApoioMVC.REPOSITORIO
{
    public class ReservaRepositorio : ISQLRepository<Reserva>
    {
        DBUtil DB = new DBUtil();

        public Reserva FindByID(int ID, ISQLMapper<Reserva> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_RESERVA_BYID", ID));
        }

        public List<Reserva> Lista(ISQLMapper<Reserva> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Reserva";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public int ADD(Reserva Item)
        {
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Dt_Reserva",Item.DtReserva),
                new SqlParameter("@ID_Sala",Item.IDSala),
                new SqlParameter("@ID_Curso",Item.IDCurso),
                new SqlParameter("@ID_Professor",Item.IDProfessor),
                new SqlParameter("@Dt_Agendamento",Item.DtAgendamento),
                ID
            };

            DB.ExecSP("SP_Reserva_ADD", Param);
            return Convert.ToInt32(ID.Value);
        }

        public void Update(Reserva Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Dt_Reserva",Item.DtReserva),
                new SqlParameter("@ID_Sala",Item.IDSala),
                new SqlParameter("@ID_Curso",Item.IDCurso),
                new SqlParameter("@ID_Professor",Item.IDProfessor),
                new SqlParameter("@Dt_Agendamento",Item.DtAgendamento),
            };

            DB.ExecSP("SP_RESERVA_UPDATE", Param);
        }

        public void Delete(Reserva Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_RESERVA_DELETE", Param);

        }
    }
}