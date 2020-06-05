using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightControlPro.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            if (!Username.Equals("") && !Password.Equals(""))
            {
                return true;
            }
            else
                return false;
        }
    }
}
