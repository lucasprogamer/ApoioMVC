using ApoioMVC.INFRA;
using ApoioMVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApoioMVC.REPOSITORIO
{
    public class AtivoRepositorio : ISQLRepository<Ativo>
    {
        DBUtil DB = new DBUtil();

        public Ativo FindByID(int ID, ISQLMapper<Ativo> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_Ativo_BYID", ID));
        }

        public List<Curso> Lista(ISQLMapper<Curso> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Ativo";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public int ADD(Curso Item)
        {
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
                ID
            };

            DB.ExecSP("SP_ATIVO_ADD", Param);
            return Convert.ToInt32(ID.Value);
        }

        public void Update(Curso Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
            };

            DB.ExecSP("SP_ATIVO_UPDATE", Param);
        }

        public void Delete(Curso Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_ATIVO_DELETE", Param);

        }

    }
}