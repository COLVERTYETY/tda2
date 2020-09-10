using System;

namespace extra
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=Convert.ToInt32(Console.ReadLine());
            char[] temp;
            for(int i=0;i<=n;i++){
                Console.Write(i);
                temp = i.ToString().ToCharArray();
                foreach(char lettre in temp){
                    switch(lettre){
                        case '3':
                            Console.Write("fizz");
                            break;
                        case '7':
                            Console.Write("buzz");
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
