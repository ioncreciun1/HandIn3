using System.Collections.Generic;
using System.Threading.Tasks;
using HandIn3.Models;

namespace HandIn3.Database
{
    public interface DAOAdults
    {
        Task<IList<Adult>> getAdults( string firstName,
            string lastName,
            string jobTitle,
            string hairColor,
            string eyeColor,
            string sex,
            int? age,
            int? AdultID);
        Task addAdult(Adult adult);
        Task deleteAdult(int adultID);
        Task updateAdult(int adultID);
    }
}