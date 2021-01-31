using System;

namespace formatsafe
{
    static class Program
    {
        static void Main(string[] args)
        {
            var body = "here is 0: {0}, 1: {1}, 2: {2} and 14: {14}";
            Console.WriteLine("body: " + body);
            Console.WriteLine();

            Console.WriteLine("Too few parameters. All elems are in body, but body expects also {14}");
            var res = FormatSafe15(body, "a", "b", "c");
            Console.WriteLine(res);

            Console.WriteLine("'d' is not in body");
            res = FormatSafe15(body, "a", "b", "c", "d");
            Console.WriteLine(res);

            Console.WriteLine("Too many parameters. '16' is more than FormatSafe15 will handle. It will be ignored");
            res = FormatSafe15(body, "a1", "b1", "c1", "d1", "e1", "a2", "b2", "c2", "d2", "e2", "a3", "b3", "c3", "d3", "e3", "16");
            Console.WriteLine(res);

            Console.WriteLine("-------------");

            body = "here is 0: {0}, 1: {1}, 2: {2} and 9: {9}";
            Console.WriteLine("body: " + body);
            Console.WriteLine();

            Console.WriteLine("Too many parameters. body don't include 'a3'");
            res = FormatSafe15(body, "a1", "b1", "c1", "d1", "e1", "a2", "b2", "c2", "d2", "e2", "a3");
            Console.WriteLine(res);
        }

        public static string FormatSafe15(string body, params string[] shortArr)
        {
            var longArr = new string[]{"","","","","","","","","","","","","","",""};
            var shortArrLength = shortArr.Length;
            var elemsToCopy = shortArrLength;

            // if shortArr is longer than longArr then only use len of longArr
            if (shortArrLength > 15)
            {
                elemsToCopy = 15;
            }
            // put shortArr into longArr
            Array.Copy(shortArr, longArr, elemsToCopy);

            // when body has max {14}, then it is safe todo Format() now
            var retVal = string.Format(body, 
                longArr[0], longArr[1], longArr[2], longArr[3], longArr[4], 
                longArr[5], longArr[6], longArr[7], longArr[8], longArr[9], 
                longArr[10], longArr[11], longArr[12], longArr[13], longArr[14]
            );
            return retVal;
        }
    }
}
