using System.Collections.Generic;
using System.IO;
using System;

namespace td8
{
    public class Banque
    {
        private float augmentation = 1.1F;
        public string nom_de_banque;
        private string path;
        private List<clients> listedeclients = new List<clients>();
        public Banque(string path, string _nom){
            this.path = path;
            this.nom_de_banque = _nom;
            ReadFile();
        }

        public void ReadFile(){
            StreamReader thereader = null;
            string[] activestring;
            char [] seperator = {';'};
            string tempname;
            float tempvalue;
            bool tempblock=false;
            System.Exception temperror;
            try
            {
                thereader = new StreamReader(this.path);
            }
            catch (FileNotFoundException)
            {
                temperror = new System.Exception("the client file was not found, please check path");
                throw temperror;
            }
            while(! thereader.EndOfStream){
                activestring = thereader.ReadLine().Split(seperator);
                temperror = new System.Exception("data invalide");
                if(activestring.Length!=3){
                    throw temperror;
                }
                tempname = activestring[0];
                if(! float.TryParse(activestring[1],out tempvalue)){
                    throw temperror;
                }
                if(activestring[2]!="t" && activestring[2]!="f"){
                    throw temperror;
                }else{
                    if(activestring[2]=="t"){
                        tempblock = true;
                    }else if (activestring[2]=="f"){
                        tempblock = false;
                    }
                }
                this.listedeclients.Add(new clients(tempname,tempvalue,tempblock));
            }
            thereader.Close();
        }
        public void augmente(){
            foreach(clients sam in this.listedeclients){
                if(! sam.blocked){
                    sam.value*=this.augmentation;
                }
            }
        }
        public void WriteFile(){
            StreamWriter thewriter = new StreamWriter(this.path);
            foreach(clients sam in this.listedeclients){
                thewriter.WriteLine(sam.tostring());
            }
            thewriter.Close();
        }
        public void Add(clients sam){
            this.listedeclients.Add(sam);
        }
    }
}