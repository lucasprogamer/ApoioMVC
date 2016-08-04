using ApoioMVC.MODEL;
using System.Data;

namespace ApoioMVC.REPOSITORIO
{
    public class SalaMapper : SqlMapperBase<Sala>
    {
        public override Sala MapFromSource(DataRow Record)
        {
            Sala sl = new Sala();

            sl.ID = (int)Record["ID"];
            sl.Salas = (string)Record["Sala"];
            return sl;
        }
    }
}