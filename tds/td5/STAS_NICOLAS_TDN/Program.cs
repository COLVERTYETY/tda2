using System;
using System.Collections.Generic;
namespace td5
{
    class Program
    {
        static void Main(string[] args)
        {
            Commune paris = new Commune("Paris",75,"FRance",2200000,"Hidalgo");
            Commune rouen = new Commune("rouen",76,"FRance",111000,"Robert");
            paris.Nhabitant = 2220000;
            string s = paris.tostring();
            bool b = paris.equals(rouen);
            Console.WriteLine(s);
            Console.ReadLine();
            Console.Clear();
            Commune marly = new Commune("Marly");
            region IledeFrance = new region("Ile de FRance","prefet",new Commune("Paris"));
            IledeFrance.Add(new Commune("VErsaille"));
            IledeFrance.Add(marly);
            Console.WriteLine(IledeFrance.appartenance(new Commune()));
            Console.WriteLine(IledeFrance.appartenance(marly));
            Console.ReadLine();
            IledeFrance.disp();
            Console.ReadLine();
            Console.Clear();
            IledeFrance.alphasort();
            IledeFrance.disp();
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(IledeFrance.tostring());
            Console.WriteLine(IledeFrance.popTotal());
            Console.ReadLine();
            Console.Clear();
            region megapole = new region("big","unprefet",100);
            megapole.disp();
            Console.ReadLine();
            Console.Clear();
            megapole.alphasort();
            megapole.disp();
            Console.ReadLine();
        }
    }
}
