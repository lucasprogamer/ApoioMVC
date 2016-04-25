using ApoioMVC.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ApoioMVC.REPOSITORIO
{
    public class AtivoMapper : SqlMapperBase<Ativo>
    {
        public override Ativo MapFromSource(DataRow Record)
        {
            Ativo at = new Ativo();

            at.ID = (int)Record["ID"];
            at.Descricao = (string)Record["Descricao"];
            at.Num_Patrimonio = (string)Record["Num_Patrimonio"];
            return at;
        }
    }
}