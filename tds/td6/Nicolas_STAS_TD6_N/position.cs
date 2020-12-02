using System;

namespace td6
{
    class position
    {
        private int lignne;
        private int colonne;
        public int Lignne{
            get{return this.lignne;}
            set{this.lignne = Math.Abs(value);}
        }
        public int Colonne{
            get{return this.colonne;}
            set{this.colonne = Math.Abs(value);}
        }
        public int x{
            get{return this.colonne;}
            set{this.colonne = Math.Abs(value);}
        }
        public int y{
            get{return this.lignne;}
            set{this.lignne = Math.Abs(value);}
        }
        public position(int _x, int _y){
            this.Lignne = _y;
            this.Colonne = _x;
        }
        public position(position pos){
            this.x = pos.x;
            this.y = pos.y;
        }
        public string tostring(){
            string res = "|| ";
            res+=Convert.ToString(this.x);
            res+=" | ";
            res+=Convert.ToString(this.y);
            res+=" ||";
            return res;
        }
        public bool EstEgale(position pos){
            bool res = false;
            if(pos.x == this.x && pos.y == this.y){
                res = true;
            }
            return res;
        }

    }
}
