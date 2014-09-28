using System;

namespace Composite
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("======= Demonstration of Composite =======");
            // make the root of my hard disk
            IComponent root = new Folder("Root");
            // create some folder in a hierarchy
            // root
            //   --- a
            //       --- b
            //   --- c
            IComponent folderA = new Folder("FolderA");
            root.AddComponent(folderA);

            IComponent folderB = new Folder("FolderB");
            folderA.AddComponent(folderB);

            IComponent folderC = new Folder("FolderC");
            root.AddComponent(folderC);

            // add some 'files' to the a folder
            IComponent fileX = new File("FileX", 1000);
            IComponent fileY = new File("FileY",3000);
            IComponent fileZ = new File("FileZ",5000);

            folderA.AddComponent(fileX);
            folderA.AddComponent(fileY);
            folderA.AddComponent(fileZ);

            // add some 'files' to the b folder
            IComponent file1 = new File("File1",30);
            IComponent file2 = new File("File2",20);
            IComponent file3 = new File("File3",10);

            folderB.AddComponent(file1);
            folderB.AddComponent(file2);
            folderB.AddComponent(file3);

            // leaf operation
            Console.WriteLine("File 1 has size " + file1.Size() +
                              " (Correct: 30)");
            // composite operation
            Console.WriteLine("Folder b has size " + folderB.Size() +
                              " (Correct: 60)");
            Console.WriteLine("Folder root has size " + root.Size() +
                              " (Correct: 9060)");

            Console.WriteLine("Printing the root folder/file structure:");
            root.Print(0);

            Console.WriteLine("Deleting root...");
            root.Delete();
            Console.WriteLine("Folder root has size " + root.Size() +
                              " (Correct: 0)");

            Console.ReadKey();
        }
    }
}
