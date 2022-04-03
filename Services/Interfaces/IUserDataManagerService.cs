using Monefy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services
{
    public interface IUserDataManagerService
    {
        public void Update(UserData userData);

        public UserData? FetchData(string filepath);
        public string? FetchJson(string filepath);
    }
}
