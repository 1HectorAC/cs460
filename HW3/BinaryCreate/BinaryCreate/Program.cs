using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryCreate
{
    class Program
    {
        static void Main(string[] args)
        {
            //test Node
            Node<int> the = new Node<int>(5, null);
            the.data = 5;
            Console.WriteLine(the.data);
            Console.ReadLine();
        }
    }
}
