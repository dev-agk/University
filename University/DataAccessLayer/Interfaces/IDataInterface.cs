using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Data;
using University.Models;

namespace University.Interfaces
{
    public interface IDataInterface
    {
        public ApplicationDataSource GetDataSource();
    }
}
