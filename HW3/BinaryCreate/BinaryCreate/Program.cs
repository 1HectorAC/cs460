using System;
using System.Collections.Generic;
using System.Text;
namespace BinaryCreate
{
    /// <summary>
    /// The program will take in an input number n and then produce every binary number from 1 to n.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This method will make a linkedList containing the binary numbers from 1 to n where n is the input.
        /// </summary>
        /// <param name="n"> The max value that will be represented in binary. </param>
        /// <returns> A LinkedList representation of binary numbers from 1 to n. </returns>
        static LinkedList<string> GeneratedBinaryRepresentation(int n)
        {
            // Create an empty queue of string to perform the traversal.
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            // List conaining resulting binary values.
            LinkedList<string> output = new LinkedList<string>();

            if(n < 1)
            {
                // It will not represent negative values so return empty list.
                return output;
            }

            q.Push(new StringBuilder("1"));

            // BFS
            while (n-- > 0)
            {
                // Print front of queue.
                StringBuilder sb = q.Pop();
                output.AddLast(sb.ToString());

                // Make a copy.
                StringBuilder sbc = new StringBuilder(sb.ToString());

                // Left child.
                sb.Append('0');
                q.Push(sb);

                // Right child.
                sbc.Append('1');
                q.Push(sbc);
            }
            return output;
        }

        /// <summary>
        /// Sets up the output and input needed to use GeneratedBinaryRepresentation() and output result.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n = 10;
            if(args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\t./BinaryCreate.exe 12");
                return;
            }
            try
            {
                n = Int32.Parse(args[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
                return;
            }
            LinkedList<string> output = Program.GeneratedBinaryRepresentation(n);
            // Print result right justified with longest string being the last.
            // Print enough spaces to have proper distance.
            int maxLength = output.Last.Value.Length;
  
            foreach(string s in output)
            {
                for(int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }
    }
}
