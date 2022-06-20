﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Junio2015

{

    public class Office {

        public Office(string number, string building) {
            Number = number; 
            Building = building;
        }

        public readonly string Number;
        public readonly string Building;

        public override string ToString() {
            return String.Format("[Office: {0}\\{1}]", Number, Building);
        }
    }
}
