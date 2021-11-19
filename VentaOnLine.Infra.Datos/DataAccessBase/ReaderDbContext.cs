using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Infra.Datos.DataAccessBase
{
    public class ReaderDbContext: BaseDbContext
    {
        public ReaderDbContext(string connectionString): base(connectionString)
        {

        }
    }
}
