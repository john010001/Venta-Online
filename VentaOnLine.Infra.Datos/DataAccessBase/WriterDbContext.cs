using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Infra.Datos.DataAccessBase
{
    public class WriterDbContext: BaseDbContext
    {
        public WriterDbContext(string connectionString): base(connectionString)
        {

        }
    }
}
