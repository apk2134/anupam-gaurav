

using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApplication14
{
    class HoldContenstAndMark
    {
        public string Name { get; set; }

        public int NoOfQuestionStartDec { get; set; }

        public int NoOfQEndJa { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("tu gandu");
            
            List<HoldContenstAndMark> list = new List<HoldContenstAndMark>();

            list.Add(new HoldContenstAndMark { Name = "A", NoOfQuestionStartDec = 5, NoOfQEndJa = 7 });
            list.Add(new HoldContenstAndMark { Name = "B", NoOfQuestionStartDec = 2, NoOfQEndJa = 9 });
            list.Add(new HoldContenstAndMark { Name = "C", NoOfQuestionStartDec = 3, NoOfQEndJa = 5 });
            list.Add(new HoldContenstAndMark { Name = "D", NoOfQuestionStartDec = 4, NoOfQEndJa = 11 });
            list.Add(new HoldContenstAndMark { Name = "E", NoOfQuestionStartDec = 1, NoOfQEndJa = 6 });

            string Name = null;

            foreach (var item in list)
            {

            }

        }
    }
}
