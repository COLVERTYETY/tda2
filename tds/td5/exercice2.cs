using System;
using System.Collections.Generic;

namespace td5
{
    class region
    {
        private List<Commune> myCommunes = new List<Commune>();
        private string prefet;
        private Commune chefLieu;
        private string name;
        public region(string _name,string _prefet, Commune _cheflieu){
            this.name = _name;
            this.prefet = _prefet;
            this.chefLieu = _cheflieu;
            this.myCommunes.Add(_cheflieu);
        }
        public region(string _name,string _prefet,int nofcommune){
            this.name = _name;
            this.prefet = _prefet;
            for(int _=0;_<=nofcommune;_++){
                myCommunes.Add(new Commune());
            }
            this.chefLieu = myCommunes[0];

        }
        public region(string _name,string _prefet, Commune _cheflieu,List<Commune> liste){
            this.name = _name;
            this.prefet = _prefet;
            this.chefLieu = _cheflieu;
            this.myCommunes = liste;
            if(!this.appartenance(this.chefLieu)){
                this.myCommunes.Add(this.chefLieu);
            }
        }
        public string tostring(){
            string res = "";
            res+=this.name;
            res+=" ";
            res+=this.prefet;
            res+=" ";
            res+= this.chefLieu.Name;
            res+=" ";
            res+=Convert.ToString(this.myCommunes.Count);
            return res;
        }
        public void disp(){
            for(int i=0;i<this.myCommunes.Count;i++){
                Console.WriteLine(this.myCommunes[i].tostring());
            }
        }
        public bool appartenance(Commune other){
            bool res = false;
            for(int i =0;i<this.myCommunes.Count;i++){
                if(this.myCommunes[i].equals(other)){
                    res = true;
                    break;
                }
            }
            return res;
        }
        public int popTotal(){
            int res=0;
            for(int i =0;i<this.myCommunes.Count;i++){
                res+=this.myCommunes[i].Nhabitant;
            }
            return res;
        }

        public void alphasort() 
        { 
            Commune [] array = this.myCommunes.ToArray();
            bubblesort(array);
            this.myCommunes = new List<Commune>(array);
        } 
        static void bubblesort(Commune [] arr){
            Commune temp;
            for (int j = 0; j <= arr.Length - 2; j++) {
                for (int i = 0; i <= arr.Length - 2; i++) {
                if (Comparestr(arr[i].Name,arr[i+1].Name)>0) {
                    temp= arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                }
                }
            }
        }

        public void Add(Commune acomm){
            this.myCommunes.Add(acomm);
        }
        static int Comparestr(string A,string B){
            int res = 0;
            int temp;
            for(int i=0;i<A.Length;i++){
                if(i>=B.Length){
                    break;
                }else{
                    temp = compchar(A[i],B[i]);
                    if(temp!=0){
                        res = temp;
                        break;
                    }
                }
            }
            return res;
        }

        static int compchar(char A,char B){
            return A-B;
        }

    }
}
