using ApoioMVC.MODEL;
using System.Data;

namespace ApoioMVC.REPOSITORIO
{
    public class CursoMapper : SqlMapperBase<Curso>
    {
        public override Curso MapFromSource(DataRow Record)
        {
            Curso cs = new Curso();

            cs.ID = (int)Record["ID"];
            cs.Nome = (string)Record["Nome"];
            return cs;
        }
    }
}