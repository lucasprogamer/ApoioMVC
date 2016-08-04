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

        public List<Ativo> Lista(ISQLMapper<Ativo> mapper)
        {
            SqlParameter[] Param = new SqlParameter[]
            { };
            string SQL = "select * from Ativo";
            return mapper.MapAllFromSource(DB.ListaSQL(Param, SQL).Tables[0]);
        }

        public void ADD(Ativo Item)
        {
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Direction = ParameterDirection.Output;

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Descricao",Item.Descricao),
                new SqlParameter("@NumPatrimonio",Item.Num_Patrimonio),
                ID
            };

            DB.ExecSP("SP_ATIVO_INCLUIR", Param);
        }

        public void Update(Ativo Item)
        {

            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@Descricao",Item.Descricao),
                new SqlParameter("@NumPatrimonio",Item.Num_Patrimonio),
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_ATIVO_UPDATE", Param);
        }

        public void Delete(Ativo Item)
        {
            SqlParameter[] Param = new SqlParameter[]
            {
                new SqlParameter("@ID",Item.ID)
            };

            DB.ExecSP("SP_ATIVO_DELETE", Param);

        }

        void ISQLRepository<Ativo>.ADD(Ativo Item)
        {
            throw new NotImplementedException();
        }
    }
}