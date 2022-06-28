using System;
using System.Collections.Generic;
using System.Text;

namespace Junio2019
{
    internal interface Information
    {
        bool Validate(string username, string key);

        bool Validate(string username);

        string ToString();
    }
}
