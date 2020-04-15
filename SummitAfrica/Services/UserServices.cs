using Microsoft.EntityFrameworkCore;
using SummitAfrica.Data;
using SummitAfrica.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SummitAfrica.Services
{
    public class UserServices
    {
        private readonly ApplicationDbContext _Context;
        public UserServices(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public List<UserDataTable> GetUserinfo(int SNo)
        {
            var ui = new SqlParameter("@SNo", SNo);
            List<UserDataTable> UserList = new List<UserDataTable>();
            try
            {
                UserList = _Context.UserDataTables.FromSql("Exec GetList @SNo", ui).ToList();
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex);
            }
            return UserList;
        }

        public void UpdateUserDetails(Userxml Userxml)
        {
            var Uservar = new SqlParameter("@User", Userxml.GetXml());
            try
            {
                _Context.Database.ExecuteSqlCommand("Exec Userdetails @User", Uservar);
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex);
            }
        }

        public void DeleteUserInfo(int SNo)
        {
            var Sno = new SqlParameter("@SNo", SNo);
            try
            {
                _Context.Database.ExecuteSqlCommand("Exec DeleteUser @SNo", Sno);
            }
            catch(Exception Ex)
            {
                Console.WriteLine(Ex);
            }
        }
           
    }
}
