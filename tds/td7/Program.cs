using System;
using System.Collections.Generic;

namespace td7
{
    class Program
    {

        static Stack<int> melange(Stack<int> a, Stack<int> b)
        {
            Stack<int> result = new Stack<int>();
            Random rand = new Random();
            while(a.Count>0 && b.Count>0){
                if(rand.Next(0,100)>=50){
                    result.Push(a.Pop());
                }else{
                    result.Push(b.Pop());
                }
            }
            while(a.Count>0 ){
                result.Push(a.Pop());
            }
            while(b.Count>0 ){
                result.Push(b.Pop());
            }
            return result;
        }
        static void filterphone(List<string> numbers){
            int temp = 0;
            foreach(string a in numbers.ToArray())
            {
                if( !int.TryParse(a,out temp) || a.Length !=10 || !a[0].Equals("0"))
                {
                    numbers.Remove(a);
                }
            }
        }
        static int NPI(Stack<string> command)
        {
            int res = 0;
            string stringval ="";
            if(command.Count >0){
                stringval = command.Pop();
                switch (stringval)
                {
                    case "+":
                        res = NPI(command) + NPI(command);
                        break;
                    case "-":
                        res = NPI(command) - NPI(command);
                        break;
                    case "*":
                        res = NPI(command) * NPI(command);
                        break;
                    case "/":
                        int ttemp = NPI(command);
                        res = NPI(command) / ttemp;
                        break;
                    default:
                        res = Convert.ToInt32(stringval);
                        break;
                }
            }
            return res; 
        }
        static void exo1(){
            Stack<int> first = new Stack<int>();
            first.Push(1);
            first.Push(2);
            first.Push(3);
            first.Push(4);
            Stack<int> second = new Stack<int>();
            second.Push(5);
            second.Push(6);
            second.Push(7);
            second.Push(8);
            Stack<int> mel = melange(second, first);
            Console.WriteLine(string.Join(' ',mel));
        }
        static void exo2(){
            Stack<string> testadd = new Stack<string>();
            testadd.Push("3");
            testadd.Push("3");
            testadd.Push("+");
            Stack<string> testfull = new Stack<string>(); // 1 2 + 4 × 3 +
            testfull.Push("1");
            testfull.Push("2");
            testfull.Push("+");
            testfull.Push("4");
            testfull.Push("*");
            testfull.Push("3");
            testfull.Push("+");
            Stack<string> exo = new Stack<string>();// "3,3, 3,+,4,*,2,/" 
            exo.Push("3");//! this doesn t work cause abc+ doesn t exist
            exo.Push("3");
            exo.Push("3");
            exo.Push("+");
            exo.Push("4");
            exo.Push("*");
            exo.Push("2");
            exo.Push("/");
            Stack<string> myexo = new Stack<string>();// "3,3, 3,+,+,4,*,2,/"
            myexo.Push("3");
            myexo.Push("3");
            myexo.Push("+");
            myexo.Push("3");
            myexo.Push("+");
            myexo.Push("4");
            myexo.Push("*");
            myexo.Push("2");
            myexo.Push("/");
            Console.WriteLine(NPI(myexo));
        }
        
        static void annuaire(){
            SortedList<int, string> theannuaire = new SortedList<int, string>();
            ConsoleKeyInfo cki;
            const int exomin=1;
            const int exomax=10;
            int tempint = 0;
            string tempstring = "";
            int cursor = exomin-1;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "-exercice 1 : ajouter une personne\n"
                                 + "-exercice 2 : afficher tous\n"
                                 + "-exercice 3 : Dessiner une matrice avec diagonale\n"
                                 + "-exercice 4 : Dessiner un sablier\n"
                                 + "-exercice 5 : table de multiplication\n"
                                 + "-exercice 6 : inverser une chaine\n"
                                 + "-exercice 7 : rechercher une chaine\n"
                                 + "-exercice 8 : matrice de mon choix\n"
                                 + "-exercice 9 : matrice random\n"
                                 + "-exercice 10 : addition de matrice\n"
                                 + "\n"
                                 + "Sélectionnez l'exercice désiré ");
                
                
                Console.WriteLine("utilisez les fleches pour selectionner un exo ou quittez avec escape");
                Console.SetCursorPosition(0,cursor+1);
                cki = Console.ReadKey();
                switch(cki.Key){
                    case ConsoleKey.UpArrow:
                        cursor--;
                        break;
                    case ConsoleKey.DownArrow:
                        cursor++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        cursor++;
                        switch (cursor)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("ajout d'une personne sur l'annulaire");
                                    tempint = getvalidphonenumber();
                                    while(theannuaire.ContainsKey(tempint)){
                                        Console.WriteLine("ce numero existe deja...");
                                        tempint = getvalidphonenumber();
                                    }
                                    tempstring = getname();
                                    theannuaire.Add(tempint,tempstring);
                                    Console.WriteLine("ajout de la personne !!");
                                    Console.WriteLine("-> "+Convert.ToString(tempint)+" : "+(theannuaire[tempint]));
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    foreach(var pair in theannuaire){
                                        Console.WriteLine("-> "+Convert.ToString(pair.Key)+" : "+(pair.Value));
                                    }
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    //3
                                    break;
                                case 4:
                                    //4
                                    break;
                                case 5:
                                    //5
                                    break;
                                case 6:
                                    //6
                                    break;
                                case 7:
                                    //7
                                    break;
                                case 8:
                                    //8
                                    break;
                                case 9:
                                    //9
                                    break;
                                case 10:
                                    //10
                                    break;

                                default:
                                    break;
                            }
                        break;
                    default:
                        Console.WriteLine("mauvaise touche");
                        break;
                }
                cursor = ((cursor+exomax)%(exomax));
            } while (cki.Key != ConsoleKey.Escape);
        }
        static int getvalidphonenumber(){
            int input = -1;
            Console.WriteLine("veuilles rentrer un numéro de téléphone:");
            while(!int.TryParse(Console.ReadLine(),out input) || Convert.ToString(input).Length!=10){
                Console.WriteLine("veuillez rentrer un numero de telephone valid.");
                Console.WriteLine(" de la forme:");
                Console.WriteLine("             0C CC CC CC CC");
                Console.WriteLine("(sans les espaces..)");
            }
            return input;
        }
        static string getname(){
            string res = "";
            Console.WriteLine("veuilles rentrer un nom:");
            res = Console.ReadLine();
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            annuaire();
        }
    }
}
