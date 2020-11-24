using System;

namespace tdpoo
{
    class article
    {
        private long reference;
        private string intitule;
        private double prixHT;
        private int quantiteEnStock;
        public long Reference{
            get =>reference;
            set =>reference=value;
        }
        public string Intitule{
            get =>intitule;
            set =>intitule=value;
        }
        public double PrixHT{
            get =>prixHT;
            set =>prixHT=value;
        }
        public int QuantiteEnStock{
            get =>quantiteEnStock;
            set =>quantiteEnStock=value;
        }
        public double Prixttc{
            get{return (double)(PrixHT*1.18);}
        }
        public article(long refer_,string inti_,double prixht_,int quantite_){
            this.reference = refer_;
            this.intitule = inti_;
            this.prixHT = prixht_;
            this.quantiteEnStock = quantite_;
        }
        public void approvisionner(int nombreUnites){
            this.QuantiteEnStock+=nombreUnites;
        }
        public bool vendre(int nombreUnites){
            bool res = false;
            if(QuantiteEnStock>=nombreUnites){
                QuantiteEnStock-=nombreUnites;
                res = true;
            }
            return res;
        }
        public String toString(){
            string res="";
            res+=Intitule;
            res+=" ";
            res+=Convert.ToString(Reference);
            res+=" ";
            res+=Convert.ToString(Prixttc);
            res+=" ";
            res+=Convert.ToString(QuantiteEnStock);
            return res;
        }
        public bool equals(article unArticle){
            return this.Reference==unArticle.Reference;
        }
    }
}
