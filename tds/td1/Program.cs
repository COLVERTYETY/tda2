using System;

namespace td1
{
    class Program
    {
        static int add(int a,int b){
            return a+b; 
        }
        static string mettreEnMinuscule(string mot){
            return mot.ToLower();
        }
        static void exo1a(){
            Console.WriteLine(mettreEnMinuscule(Console.ReadLine()));
        }
        static void exo1b(){
            Console.WriteLine(add(Convert.ToInt32(Console.ReadLine()),Convert.ToInt32(Console.ReadLine())));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("its started!");
        }
    }
}
