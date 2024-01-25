using System;
using System.Collections.Generic;
using System.Text;

namespace Junio2019
{
    internal class InformationMD5 : Information
    {
        private string username;
        private string password;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value == null || value.Length < 3 || value.Length > 15)
                    throw new ArgumentException("Usuario no válido.");
                username = value;
            }
        }

        public string Password
        {
            private get
            {
                return password;
            }
            set
            {
                password = Utils.CreateMd5(value);
            }
        }


        public bool Validate(string username, string key)
        {
            key = Utils.CreateMd5(key);
            if (username.Equals(this.username) && key.Equals(this.password))
            {
                return true;
            }
            return false;
        }

        public bool Validate(string username)
        {
            return this.username.Equals(username);
        }

        public override string ToString()
        {
            return $"Username: {this.username}";
        }
    }
}
