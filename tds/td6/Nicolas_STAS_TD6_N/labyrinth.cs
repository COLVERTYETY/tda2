using System;

namespace td6
{
    class Labyrinth
    {
        private int[,] matrice;
        private int nbLignes;
        private int nbColonnes;
        private position depart;
        private position arrivee;

        public position Depart{
            get{return this.depart;}
        }
        public position Arrivee{
            get{return this.arrivee;}
        }
        public Labyrinth(string [] map, int _nbligne, int _nbcolone){
            this.nbLignes = _nbligne;
            this.nbColonnes = _nbcolone;
            this.matrice = new int[_nbligne,_nbcolone];
            int test = map[0].Length;
            bool stillokay = true;
            //toutes les colones ont la meme taille
            foreach(string lligne in map){
                if(test!= lligne.Length){
                    stillokay = false;
                    break;
                }
            }
            if(! stillokay){
                throw new ArgumentException("erreur de dimesnion");
            }
            if(stillokay){
                for(int x = 0; x<this.matrice.GetLength(0);x++){
                    for(int y = 0; y<this.matrice.GetLength(1);y++){
                        char temp = map[x][y];
                        switch(temp){
                            case '*':
                                this.matrice[x,y] = 1;
                                break;
                            case 'd':
                                this.matrice[x,y] = 2;
                                this.depart = new position(x,y);
                                break;
                            case '-':
                                this.matrice[x,y] = 0;
                                break;
                            case 'a':
                                this.matrice[x,y] = 3;
                                this.arrivee = new position(x,y);
                                break;
                            default:
                                this.matrice[x,y] = 99;
                                break;
                        }
                    }                
                }
            }
            
            // un point de depart et d arrivée existe
            if(this.depart==null || this.arrivee==null){
                stillokay = false;
            }
            if(! stillokay){
                throw new ArgumentException("les points de departs et arrive mal config");
            }
            //check les murs sont bien present
            if(stillokay){
                for(int x = 0; x<this.matrice.GetLength(0);x++){
                    for(int y = 0; y<this.matrice.GetLength(1);y++){
                        int temp = this.matrice[x,y];
                        if(x==0 || x==this.matrice.GetLength(0)-1 || y ==0 || y==this.matrice.GetLength(1)-1){
                            if(temp != 1){
                                stillokay = false;
                                break;
                            }
                        }
                    }
                }
            }
            if(! stillokay){
                throw new ArgumentException("murs pas continu");
            }
        }
        public bool EstUnMur(position pos){
                return this.matrice[pos.x,pos.y]==1;
            }
        public bool EstOccupee(position pos){
            return this.matrice[pos.x,pos.y]==4;
        }
        public bool MarquerPassage(position pos) {
            bool res = false;
            if(!EstOccupee(pos) && !EstUnMur(pos)){
                this.matrice[pos.x,pos.y]=4;
                res = true;
            }
            return res;
        }
        public string toString(){
            string res = "";
            for(int x = 0; x<this.matrice.GetLength(0);x++){
                for(int y = 0; y<this.matrice.GetLength(1);y++){
                    switch(this.matrice[x,y]){
                        case 1://mur
                            res+="*";
                            break;
                        case 2://depart
                            res+="d";
                            break;
                        case 0://vide
                            res+=" ";
                            break;
                        case 3:
                            res+="a";
                            break;
                        case 4:
                            res+=".";
                            break;
                        default:
                        res+="?";
                            break;
                    }
                }
                res+="\n";              
            }
            return res;
        }
    }
}
