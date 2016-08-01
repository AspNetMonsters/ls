using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ls
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string workingDirectory = args.Length == 0 ? "." : args[0];
            DirectoryInfo di = new DirectoryInfo(workingDirectory);
            int maxLength = di.GetFiles().Select(x => x.Name.Length).Max();
            foreach(var file in di.GetFiles().OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{file.Name.PadRight(maxLength)}\t{file.CreationTime}");
            }
            Console.ReadLine();
        }
    }
}
