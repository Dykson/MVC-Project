using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCProject.Entity;
using MVCProject.Service;
using System.Data.SQLite;

namespace MVCProject.Service
{
    class UserService
    {
        public string GetFullName(User user)
        {
            return user.Firstname + " " + user.Lastname;
        }
        public void GetUserById(int id)
        {
            Hashtable response = SqliteDBService.UserTableRequest(string.Format("SELECT * FROM users WHERE id = {0}", id));

        }
    }
}
