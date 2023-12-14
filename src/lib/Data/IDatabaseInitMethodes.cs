using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.Data
{
    public interface IDatabaseInitMethodes
    {
        void InitializeDatabase();
        string DatabasePath { get;  }
        void CreateDatabase();
    }
}
