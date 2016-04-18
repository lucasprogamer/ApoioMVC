using ApoioMVC.INFRA;
using ApoioMVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApoioMVC.REPOSITORIO
{
    public class ProfessorRepositorio : ISQLRepository<Professor>
    {
        DBUtil DB = new DBUtil();

        public Professor FindByID(int ID, ISQLMapper<Professor> mapper)
        {
            return mapper.MapFromSource(DB.GetByID("SP_PROFESSOR_BYID", ID));
        }

        public List<Professor> Lista(ISQLMapper<Professor> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Professor";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public int ADD(Professor Item)
        {
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
                ID
            };

            DB.ExecSP("SP_PROFESSOR_ADD", Param);
            return Convert.ToInt32(ID.Value);
        }

        public void Update(Professor Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Nome",Item.Nome),
            };

            DB.ExecSP("SP_CLIENTE_UPDATE", Param);
        }

        public void Delete(Professor Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_PROFESSOR_DELETE", Param);

        }
    }
}