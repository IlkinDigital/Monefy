using Monefy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Services
{
    public class UserDataService : IUserDataService
    {
        private string _filepath = "UserData.json";
        public string Filepath { get => _filepath; set => _filepath = value; }

        public void Update(UserData userData)
        {
            throw new NotImplementedException();
        }

        public UserData? FetchData()
        {
            throw new NotImplementedException();
        }

        public string? FetchJson()
        {
            throw new NotImplementedException();
        }
    }
}
