using System;
//nicolas stas
namespace prgincomplet
{
    class Program
    {
        static int getint(int mmin=0){
            int input = -1;
            while(!int.TryParse(Console.ReadLine(),out input) || input<mmin){
                Console.WriteLine("veuillez rentrer un entier naturel.");
            }
            return input;
        }
        static char getcharfromarray(char[] choices){
            char input=getchar();
            while(! new string(choices).Contains(input)){
                Console.WriteLine("please enter a char from the following list:");
                Console.WriteLine(string.Join(' ',choices));
                input = getchar();
            }
            return input;
        }
        static char getchar(){
            char[] inputs=Console.ReadLine().ToCharArray();
            while(inputs.Length<1){
                Console.WriteLine("veuillez entrer un char ou un string");
                inputs=Console.ReadLine().ToCharArray();
            }
            return inputs[0];
        }
        static int[,] rndmat(int dim){
            Random rnd = new Random();
            int[,] mat = new int[dim,dim];
            for(int i=0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    mat[i,j] = rnd.Next(10);
                }
            }
            return mat;
        }
        static int[,] addmat(int[,] mat1, int[,] mat2){
            int[,] res = new int[mat1.GetLength(0),mat1.GetLength(1)];
            for(int i =0;i<mat1.GetLength(0);i++){
                for(int j=0;j<mat1.GetLength(1);j++){
                    res[i,j] = mat1[i,j]+mat2[i,j];
                }
            }
            return res;
        }
        static int[,] makemat(){
            Console.WriteLine("entrer la taille de la matricez carree");
            int h = getint();
            Console.WriteLine("entrer le nombre de remplissage");
            int val = getint();
            int[,] mat = new int[h,h];
            for(int i =0;i<h;i++){
                for(int j = 0;j<h;j++){
                    mat[i,j]=val;
                }
            }
            return mat;
        }
        static int Recherche(string phrase, string mot)
        {
            string[] words = phrase.Split(new char[]{' ',',','.'});
            int sum=0;
            foreach(string i in words){
                if(i==mot){
                    sum++;
                }
            }
            return sum;
        }
        static void inverse(string mot){
            char[] word = mot.ToCharArray();
            Array.Reverse(word);
            Console.WriteLine(new string(word));
        }
        static void matricemult(int dimension){
            int[,] mat = new int[10,dimension];
            for(int i=0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    mat[i,j] = (i+1)*(j+1);
                }
            }
            // disp(mat); car formatage
            int big = Convert.ToString(10*dimension).Length+1;
            for(int i=0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    Console.Write(Convert.ToString(mat[i,j]).PadLeft(big));
                }
                Console.WriteLine();
            }

        }
        static void DessineMoiUneLigne(int dim,char c='X'){
            Console.WriteLine(new string(c,dim));
        }
        static void DessineMoiUneMatrice (char symbole, int dimension){
            for(int i=0;i<dimension;i++){
                DessineMoiUneLigne(dimension,symbole);
            }
        } 
        static void DessineMoiUneDiagonale (char symbole,char symboleDiag,int dimension, char direction){
            for(int i =0;i<=dimension;i++){
                for(int j =0;j<=dimension;j++){
                    if((i==j && direction=='D')||((dimension-i)==j && direction=='M')){
                        Console.Write(symboleDiag);
                    }else{
                        Console.Write(symbole);
                    }
                }
                Console.WriteLine();
            }
        }
        static void sablier(int hauteur){
            for(int i =0;i<hauteur;i+=2){
                Console.Write(new string(' ',(int)i/2));
                Console.Write(new string('X',hauteur-i));
                Console.WriteLine();
            }
            for(int i =2+(hauteur%2);i<=hauteur;i+=2){
                Console.Write(new string(' ',hauteur/2 - i/2));
                Console.Write(new string('X',i));
                Console.WriteLine();
            }
        }
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
                        int l;
                        char c;
                        char c2;
                        char dir;
                        string phrase;
                        string mot;
                        switch (cursor)
                            {
                                case 1:
                                    Console.WriteLine("Dessiner une ligne !!");
                                    Console.WriteLine("veuillez rentrer la longueur de la ligne: ");
                                    l = getint();
                                    DessineMoiUneLigne(l);
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Dessiner une matrice !!");
                                    Console.WriteLine("veuillez rentrer la longueur de la matrice: ");
                                    l = getint();
                                    Console.WriteLine("veuillez rentrer le char de remplissage: ");
                                    c = getchar();
                                    DessineMoiUneMatrice(c,l);
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Dessiner une matrice avec diagonale !!");
                                    Console.WriteLine("veuillez rentrer la longueur de la matrice: ");
                                    l = getint();
                                    Console.WriteLine("veuillez rentrer le char de remplissage: ");
                                    c = getchar();
                                    Console.WriteLine("veuillez rentrer le char de remplissagede la diagonale: ");
                                    c2 = getchar();
                                    Console.WriteLine("veuillez rentrer le sens de la diagonale: ");
                                    Console.WriteLine(" ( M pour montant, D pour descendant)");
                                    dir = getcharfromarray(new char[]{'M','D'});
                                    DessineMoiUneDiagonale(c,c2,l,dir);
                                    Console.ReadLine();
                                    break;
                                case 4:
                                Console.Clear();
                                    Console.WriteLine("Dessinage d'un sablier !!");
                                    Console.WriteLine("entrer la hauteur de la base du sablier");
                                    sablier(getint());
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Dessinage des tables de multipliucations !!");
                                    Console.WriteLine("entrer la table max a afficher");
                                    matricemult(getint());
                                    Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("inversion d'une chaine !!");
                                    Console.WriteLine("entrer une chaine a inverser");
                                    inverse(Console.ReadLine());
                                    Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("rechercher des mots dans une phrase !!");
                                    Console.WriteLine("entrer la pharse");
                                    phrase = Console.ReadLine();
                                    Console.WriteLine("entrer le mot à chercher");
                                    mot = Console.ReadLine();
                                    Console.Write("Le mot apparait ");
                                    Console.Write(Recherche(phrase,mot));
                                    Console.WriteLine(" fois.");
                                    Console.ReadLine();
                                    break;
                                case 8:
                                    Console.WriteLine("Matrice de votre choix !!");
                                    disp(makemat());
                                    Console.ReadLine();
                                    break;
                                case 9:
                                    Console.WriteLine("generer une matrice aleatoire !!");
                                    Console.WriteLine("entrer la taille de la matricez carree");
                                    l = getint();
                                    disp(rndmat(l));
                                    Console.ReadLine();
                                    break;
                                case 10:
                                    Console.WriteLine("somme de matrices !!");
                                    Console.WriteLine("configuration de la premiere matrice: ");
                                    int[,] a = makemat();
                                    Console.WriteLine("configuration de la deuxieme matrice: ");
                                    int[,] b = makemat();
                                    if(a.GetLength(0)==b.GetLength(0)){
                                        Console.WriteLine("matrices compatibles !!");
                                        Console.WriteLine("voici leur addition: ");
                                        disp(addmat(a,b));
                                    }else{
                                        Console.WriteLine("Matrices incompatibles...");
                                        Console.WriteLine("veillez a la taille des matrices");
                                    }
                                    Console.ReadLine();
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
        static void disp(int[,] mat){
            for(int i=0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    Console.Write(mat[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
