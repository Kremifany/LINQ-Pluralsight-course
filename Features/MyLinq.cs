using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static class MyLinq
    {
         public static int Count<T>(this IEnumerable<T> sequence)
        {
            int i = 0;
            foreach(var item in sequence)
            {
                i++;
            }
            return i;
        }
    }
}
