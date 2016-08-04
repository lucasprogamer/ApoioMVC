using System.Collections.Generic;
using System.Data;

namespace ApoioMVC.REPOSITORIO
{
    public interface ISQLMapper<T>
    {
        T MapFromSource(DataRow Record);
        List<T> MapAllFromSource(DataTable Tabela);
    }
}
