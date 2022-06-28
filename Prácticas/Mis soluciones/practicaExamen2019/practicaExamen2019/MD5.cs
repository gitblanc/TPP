using System;
using System.Collections.Generic;
using System.Text;

namespace practicaExamen2019
{
    internal class MD5 : Information
    {
        public string Password
        {
            private get { return password; }
            set { password = Utils.CreateMd5(value); }
        }

        public override bool Validate(string user, string key)
        {
            key = Utils.CreateMd5(key);
            return this.username.Equals(user) && this.password.Equals(key);
        }

        public override bool Validate(string user)
        {
            return this.username.Equals(user);
        }
    }
}
