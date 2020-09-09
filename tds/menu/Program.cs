using System;

namespace prgincomplet
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            // Console.WindowHeight = 50;
            // Console.WindowWidth = 100;
            const int exomin=1;
            const int exomax=10;
            int cursor = exomin-1;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "-exercice 1 : Dessiner une ligne\n"
                                 + "-exercice 2 : Dessiner une matrice\n"
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
                                    //1
                                    break;
                                case 2:
                                    //2
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
            Console.Clear();
            Console.WriteLine("merci et bon voyage !!");
            Console.Read();
        }
    }
}
