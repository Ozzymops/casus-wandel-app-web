using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Diagnostics;

using WandelAppWeb.Models;
using WandelAppWeb.Services;

namespace WandelAppWeb.Controllers
{
    public class DatabaseController : ApiController
    {
        private UserRepository userRepository;

        public DatabaseController()
        {
            this.userRepository = new UserRepository();
        }

        // Gebruik met /api/database?username=a&password=b
        public User Get(string username, string password)
        {
            return userRepository.GetCorrectUser(username, password);
        }
    }
}
