using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace csv
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputArr = File.ReadAllLines(args[0].Split("=")[1]);

                int n = -1;
                if (args.Length > 1)
                    n = int.Parse(args[1].Split("=")[1]);

                var array = new List<string[]>();
                for (var i = 0; i < inputArr.Length; i++)
                {
                    var temp = Regex.Split(inputArr[i], ",(?=(?:(?:[^\"]*\"){2})*[^\"]*$)");

                    for (var j = 0; j < temp.Length; j++)
                    {
                        temp[j] = temp[j].Trim();
                        if (temp[j].StartsWith("\"") && temp[j].EndsWith("\""))
                        {
                            temp[j] = temp[j].Substring(1);
                            temp[j] = temp[j].Substring(0, temp[j].Length - 1);
                        }
                    }
                    array.Add(temp);
                }

                if (n > -1)
                    array = array.OrderBy(x => x[n]).ToList();

                for (var i = 0; i < array.Count; i++)
                {
                    var temp = array[i];
                    for (var j = 0; j < temp.Length; j++)
                    {
                        if (j != 0) Console.Write(" | ");
                        Console.Write(temp[j]);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine("Details: " + ex);
            }
        }
    }
}
