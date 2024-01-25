using System;
using System.Collections.Generic;
using System.Text;

namespace practicaExamen2019
{
    internal abstract class Information
    {
        protected string username;
        protected string password;

        public string Username
        {
            get { return username; }
            set
            {
                if (value == null || value.Length < 3 || value.Length > 15)
                    throw new ArgumentException("Usuario no válido");
                username = value;
            }
        }

        public abstract bool Validate(string user, string key);

        public abstract bool Validate(string user);

        public override string ToString()
        {
            return $"Username: {this.username}";
        }

    }
}
