using System;
using System.Collections.Generic;
namespace tdpoo
{
    class compteBancaire
    {
        public static List<compteBancaire> CLIENTS = new List<compteBancaire>();
        
        public static int nombreDeClients(){
            return CLIENTS.Count;
        }
        public static double montantmoyen(){
            double res=-1;
            if(CLIENTS.Count>0){
                res = CLIENTS[0].montant;
                for(int i =1;i<CLIENTS.Count;i++){
                    res+=CLIENTS[i].montant;
                }
                res/=nombreDeClients();
            }
            return res;
        }
        public static int nombreDeClientsBloque(){
            int res=0;
            for(int i =0;i<CLIENTS.Count;i++){
                if(CLIENTS[i].block){
                    res++;
                }
            }
            return res;
        }
        private string nomClient;
        private double montant;
        private bool block;
        private int nEssaie=0;
        public bool Block{
            get{return block;}
            set{block=value;}
        }
        public int NEssaie{
            get{
                return nEssaie;
            }
            set{
                nEssaie=value;
                if(nEssaie>2){
                    block=true;
                }
            }
        }
        public compteBancaire(string nom_,double montant_,bool block_){
            this.nomClient = nom_;
            this.montant = montant_;
            this.block = block_;
            CLIENTS.Add(this);
        }
        public compteBancaire(string nom_,double montant_){
            this.nomClient = nom_;
            this.montant = montant_;
            this.block = false;
            CLIENTS.Add(this);
        }
        public compteBancaire(){
            Random rnd = new Random();
            this.nomClient = "cb_auto";
            this.montant = (double)rnd.Next();
            this.block = false;
            CLIENTS.Add(this);
        }
        ~compteBancaire(){
            CLIENTS.Remove(this);
        }
        public bool debit(double valDebit){
            bool succes= false;
            if(valDebit<=this.montant && !this.block){
                this.montant-=valDebit;
                succes = true;
            }else{
                this.NEssaie++;
            }
            return succes;
        }
        public bool credit(double valcredit){
            bool succes= false;
            if(!this.block){
                this.montant-=valcredit;
                succes = true;
                NEssaie=3;
            }
            return succes;
        }
        public void disp(){
            Console.Write(this.nomClient);
            Console.Write(" ");
            if(this.montant>0){
                Console.BackgroundColor = ConsoleColor.Green;
            }else if(this.montant <0){
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.Write(this.montant);
            Console.ResetColor();
            Console.Write(" ");
            if(!this.block){
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }else if(this.block){
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            Console.Write(this.block);
            Console.ResetColor();
            Console.Write(" ");
            if(this.nEssaie>0){
                Console.Write(this.nEssaie);
                Console.Write(" ");
            }
            Console.WriteLine(";");
        }

        public string toString(){
            string res="";
            res+=this.nomClient;
            res+=" ";
            res+=Convert.ToString(this.montant);
            res+=" ";
            res+=Convert.ToString(this.block);
            res+=" ";
            res+=Convert.ToString(NEssaie);
            return res;
        }
    }
}
