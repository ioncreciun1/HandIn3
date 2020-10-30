using System.Collections.Generic;
using System.Threading.Tasks;
using HandIn3.Models;

namespace HandIn3.Database
{
    public interface DAOAdults
    {
        Task<IList<Adult>> getAdults();
        Task addAdult(Adult adult);
        Task deleteAdult(int adultID);
        Task updateAdult(int adultID);
    }
}