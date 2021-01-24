using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Data;
using University.Interfaces;
using University.Models;

namespace University.Services
{
    public class DataAccessService : IDataInterface
    {
        public ApplicationDataSource GetDataSource(string dataSource)
        {
            if (dataSource == "InApplication")
            {
                var source = new ApplicationDataSource().GetSeedData();
                return source;
            }
            else
            {
                return null;
            }
        }
    }
}
