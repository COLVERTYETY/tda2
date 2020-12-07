using System;
using System.IO;

namespace td8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Banque mybanque = new Banque("Clients.csv","name");
            mybanque.Add(new clients("bond",700F,false));
            mybanque.WriteFile();
        }
    }
}
