using ApoioMVC.MODEL;
using ApoioMVC.INFRA;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ApoioMVC.REPOSITORIO
{
    public class CursoRepositorio : ISQLRepository<Curso>
    {
        DBUtil DB = new DBUtil();

        public Curso FindByID(int ID, ISQLMapper<Curso> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_CURSO_BYID", ID));
        }

        public List<Curso> Lista(ISQLMapper<Curso> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Curso";
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

            DB.ExecSP("SP_CURSO_ADD", Param);
            return Convert.ToInt32(ID.Value);
        }

        public void Update(Curso Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
            };

            DB.ExecSP("SP_CLIENTE_UPDATE", Param);
        }

        public void Delete(Curso Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_CURSO_DELETE", Param);

        }
    }
}