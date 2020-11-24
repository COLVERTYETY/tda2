using System;

namespace td5
{
    class Commune
    {
        private string name;
        private int departement;
        private string pays;
        private int nhabitant;
        private string maire;

        public string Name{
            get{return name;}
            set{}
        }
        public string Maire{
            get{return "";}
            set{this.maire=value.ToLower();}
        }
        public int Nhabitant{
            get{return nhabitant;}
            set{
                if(value>=0){
                    nhabitant = value;
                }else{
                    nhabitant = -1;
                }
            }
        }
        public int Departement{
            get{return 0;}
            set{
                if(value>=0){
                    departement = value;
                }else{
                    departement = -1;
                }
            }
        }
        static string randomstring(int mmax){
            Random rnd = new Random();
            
            string letters = "azertyuiopqsdfghjklmwxvbn";
            int len = rnd.Next(2,mmax);
            string name ="";
            for( int i=0;i<len;i++){
                name+=letters[rnd.Next(0,letters.Length)];
            }
            return name;
        }
        public Commune(){
            Random rnd = new Random();
            this.name = randomstring(5).ToUpper();
            this.departement = rnd.Next(99);
            this.pays = randomstring(3).ToUpper();
            this.Nhabitant=rnd.Next(999999);
            this.maire = randomstring(6);
        }
        public Commune(string _name){
            Random rnd = new Random();
            this.name = _name;
            this.departement = rnd.Next(99);
            this.pays = randomstring(3).ToUpper();
            this.Nhabitant=rnd.Next(999999);
            this.maire = randomstring(6);
        }
        public Commune(string _name,int _departement,string _pays,int _nhabitant,string _maire){
            this.name = _name.ToUpper();
            this.departement = _departement;
            this.pays = _pays.ToUpper();
            this.nhabitant = _nhabitant;
            this.maire = _maire;
        }

        public string tostring(){
            string res="";
            res+=this.name;
            res+=" ";
            res+=this.pays;
            res+=" ";
            res+=this.departement;
            res+=" ";
            res+=Convert.ToString(this.nhabitant);
            res+=" ";
            res+=this.maire;
            return res;
        }
        public bool equals(Commune other){
            return (this.nhabitant==other.nhabitant);
        }
        public static bool equalstatic(Commune A,Commune B){
            return A.equals(B);
        }
    }
}
