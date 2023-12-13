using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Data
{
    public interface IDatabaseAccessMethodes
    {
        Task<Response<TEntity>> CallDatabaseResponseAsync<TEntity>(DatabaseAccessModel accessModel);
    }
}
