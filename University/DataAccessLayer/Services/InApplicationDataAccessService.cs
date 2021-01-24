using University.Data;
using University.Interfaces;

namespace University.Services
{
    public class InApplicationDataAccessService : IDataInterface
    {
        public ApplicationDataSource GetDataSource()
        {
            var source = new ApplicationDataSource();
            return source;
        }
    }
}
