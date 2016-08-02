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

            int maxLength = di.GetObjects().Select(x => x.Name.Length).Max();
            foreach(var file in di.GetObjects().OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{file.Name.PadRight(maxLength)}\t{file.CreateDate}");
            }
#if DEBUG
            Console.ReadLine();
#endif
        }
    }

    public static class ItemListExtensions
    {
        public static IEnumerable<FileSystemObject> GetObjects(this DirectoryInfo directoryInfo)
        {
            return directoryInfo.GetFiles().Select(x => new FileSystemObject { Name = x.Name, CreateDate = x.CreationTime })
                .Union(directoryInfo.GetDirectories().Select(x => new FileSystemObject { Name = "+" + x.Name, CreateDate = x.CreationTime }));
        }
    }

    public class FileSystemObject
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
