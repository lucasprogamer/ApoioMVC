using ApoioMVC.MODEL;
using System.Data;

namespace ApoioMVC.REPOSITORIO
{
    public class ProfessorMapper : SqlMapperBase<Professor>
    {
        public override Professor MapFromSource(DataRow Record)
        {
            Professor pf = new Professor();

            pf.ID = (int)Record["ID"];
            pf.Nome = (string)Record["Nome"];
            return pf;
        }
    }
}