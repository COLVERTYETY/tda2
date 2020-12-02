using System;

namespace td6
{
    class personnage
    {
        private Labyrinth mylab;
        private position mypos;
        public personnage( Labyrinth lab){
            this.mylab = lab;
            this.mypos = lab.Depart;
        }
        public bool EstArrivee(){
            return this.mypos.EstEgale(this.mylab.Arrivee);
        }
        public void DeplacementSuivant(){
            Console.Clear();
            Console.WriteLine(this.mylab.toString());
            ConsoleKeyInfo cki = Console.ReadKey();
            position temppos = new position(this.mypos);//a copy not reference
            switch(cki.Key){
                case ConsoleKey.UpArrow:
                    temppos.x-=1;
                    break;
                case ConsoleKey.DownArrow:
                    temppos.x+=1;
                    break;
                case ConsoleKey.RightArrow:
                    temppos.y+=1;
                    break;
                case ConsoleKey.LeftArrow:
                    temppos.y-=1;
                    break;
                default:
                    break;
            }
            if (this.mylab.MarquerPassage(temppos)){
                this.mypos = temppos;
            }
        }
    }
}
