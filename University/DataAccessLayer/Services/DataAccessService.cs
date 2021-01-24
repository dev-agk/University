using University.Data;
using University.Interfaces;

namespace University.Services
{
    public class DataAccessService : IDataInterface
    {
        public ApplicationDataSource GetDataSource(string dataSource)
        {
            if (dataSource == "InApplication")
            {
                var source = new ApplicationDataSource();
                return source;
            }
            else
            {
                return null;
            }
        }
    }
}
