using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AdminLoginRepository
    {
        private MyCmsContext _Context;

        public AdminLoginRepository(MyCmsContext db) 
        {
            _Context=db;
        }

        public bool IsExistUser(string username,string password)
        {
            return _Context.AdminLogins.Any(p=>p.UserName== username && p.Password == password);
        }


    }
}
