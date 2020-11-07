using System.Collections.Generic;
using System.Threading.Tasks;
using HandIn_3.Models;

namespace HandIn3.Database
{
    public interface UserDAO
    {
        Task<IList<User>> getUsers();
    }
}