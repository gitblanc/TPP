using System;

namespace TPP.ObjectOrientation.Overload {


    class IntegerDemo {

        static void Main() {
            Integer e1 = new Integer(1), e2, e3;
            // * Implicit conversion overload
            e2 = 2;//2
            // * + operator overload
            e3 = e1 + e2;//3
            System.Console.WriteLine(e1 + "\n" + e2 + "\n" + e3);//prints 1 2 3
            // * The += operator is automatically obtained
            e3 += e3;//6
            // * prefix and postfix +++
            System.Console.WriteLine(e3++);//6 'cause it's late sum
            System.Console.WriteLine(++e3);//8 'cause it's early sum
            // * [] operator
            System.Console.WriteLine(e3[0]);//prints 0
            e3[0] = e1;
            System.Console.WriteLine(e3);//prints 1
        }


    }
}