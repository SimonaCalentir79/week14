using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs27Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCalendar myCalendar = new MyCalendar();
            myCalendar.Book(10, 20);    //true
            myCalendar.Book(50, 60);    //true
            myCalendar.Book(10, 40);    //true
            myCalendar.Book(5, 15);     //false
            myCalendar.Book(5, 10);     //true
            myCalendar.Book(25, 55);    //true
            myCalendar.Book(51, 65);    //false

            Console.WriteLine("\n //------------My Calendar------------//");
            foreach (var val in myCalendar.Booked)
            {
                Console.WriteLine($"\t start: {val.Key} --> end: {val.Value}");
            }

            //--------------------------------------------------//
            Console.WriteLine("\n //------------Goat Latin------------//");

            GoatLatin goatLatin = new GoatLatin();

            string input1 = "I speak Goat Latin";
            string output1 = goatLatin.Translate(input1);
            Console.WriteLine($"\n Original: {input1}");
            Console.WriteLine($" Translated: {output1}");

            string input2 = "The quick brown fox jumped over the lazy dog";
            string output2 = goatLatin.Translate(input2);
            Console.WriteLine($"\n Original: {input2}");
            Console.WriteLine($" Translated: {output2}");

            //--------------------------------------------------//

            Console.ReadLine();
        }
    }
}
