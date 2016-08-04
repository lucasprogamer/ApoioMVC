using ApoioMVC.INFRA;
using ApoioMVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApoioMVC.REPOSITORIO
{
    public class SalaRepositorio : ISQLRepository<Sala>
    {
        DBUtil DB = new DBUtil();

        public Sala FindByID(int ID, ISQLMapper<Sala> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_SALA_BYID", ID));
        }

        public List<Sala> Lista(ISQLMapper<Sala> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
             { };
            string SQL = "select * from Sala";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(Sala Item)
        {
          
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Sala",Item.Salas),
                ID
            };

            DB.ExecSP("SP_SALA_INCLUIR", Param);
        }

        public void Update(Sala Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Sala",Item.Salas),
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_SALA_UPDATE", Param);
        }

        public void Delete(Sala Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_SALA_DELETE", Param);

        }
    }
}