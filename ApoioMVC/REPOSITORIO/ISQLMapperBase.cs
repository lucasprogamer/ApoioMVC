using System.Collections.Generic;
using System.Data;

namespace ApoioMVC.REPOSITORIO
{
    public abstract class SqlMapperBase<TItem> : ISQLMapper<TItem>
    {
        public abstract TItem MapFromSource(DataRow Record);

        public virtual List<TItem> MapAllFromSource(DataTable Tabela)
        {
            List<TItem> allitems = new List<TItem>();
         
            foreach (DataRow Dr in Tabela.Rows)
            {
                allitems.Add(MapFromSource(Dr));
            }

            return allitems;
        }
    }
}
