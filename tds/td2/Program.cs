using System;
using System.Collections.Generic;

namespace prgincomplet
{
    class Program
    {
        static int[] insertionsort(int[] tab){
            int temp=0;
            for(int _=0;_<tab.Length;_++){
                for(int i=0;i<tab.Length-1;i++){
                    if(tab[i]>tab[i+1]){
                        temp = tab[i];
                        tab[i]=tab[i+1];
                        tab[i+1]=temp;
                    }
                }
            }
            // la complexité est 0(n)=n**2
            // l espace memoire est constant
            return tab;
        }
        static bool testcarremagic(int[,] mat){
            bool res=true;
            int sum=0;
            int standard=0;
            for(int i =0;i<mat.GetLength(0);i++){
                standard+=mat[i,0];
            }
            for(int i =0;i<mat.GetLength(0);i++){//chaue ligne
                sum=0;
                for(int j=0;j<mat.GetLength(1);j++){
                    sum+=mat[i,j];
                }
                if(sum!=standard){
                    res = false;
                }
            }
            for(int i =0;i<mat.GetLength(1);i++){//chaue colone
                sum=0;
                for(int j=0;j<mat.GetLength(0);j++){
                    sum+=mat[j,i];
                }
                if(sum!=standard){
                    res = false;
                }
            }
            sum=0;
            for(int i =0;i<mat.GetLength(1);i++){//diag1
                for(int j=0;j<mat.GetLength(0);j++){
                    if(i==j){
                        sum+=mat[j,i];
                    }                
                }       
            }
            if(sum!=standard){
                res = false;
            }
            sum=0;
            for(int i =0;i<mat.GetLength(0);i++){
                for(int j =0;j<mat.GetLength(1);j++){
                    if((mat.GetLength(0)-i-1)==j){
                        sum+=mat[i,j];
                    }
                }
            }
            if(sum!=standard){
                res = false;
            }
            return res;
        }
        static int[,] produitmatriciel(int[,] mata, int[,] matb){

            /// <summary>
            /// returns the matrix multiplication of both 2D matrices
            /// input:
            ///     mata.shape = (m,n)
            ///     matb.shape = (n,p)
            /// output:
            ///     res = (m,p)
            /// </summary>
            
            int[,] res= new int[0,0];// empty for when not possible
            if(isvalidmat(mata) && isvalidmat(matb)){//neither null nor empty
                if(mata.GetLength(1)==matb.GetLength(0)){ // are the mats compatible for the operation?
                    res = new int[mata.GetLength(0),matb.GetLength(1)];
                    int temp;
                    for(int i =0;i<res.GetLength(0);i++){// iterate throu each cell of the output matrix
                        for(int j=0;j<res.GetLength(1);j++){
                            temp = 0;
                            for(int x=0;x<mata.GetLength(0);x++){//calculate value by reading input matrixes
                                for(int y=0;y<matb.GetLength(1);y++){
                                    Console.WriteLine("___");
                                    Console.WriteLine(x);
                                    Console.WriteLine(y);
                                    Console.WriteLine(i);
                                    Console.WriteLine(j);
                                    temp+=mata[x,i]*matb[j,y];   //! here things might be mixed up
                                }
                            }
                            res[i,j]=temp;
                        }
                    }
                }
            }
            return res;
        }
        static int[] unravel(int[,] mat){
            int[] res =new int[mat.GetLength(0)*mat.GetLength(1)];
            for(int i=0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    res[i*mat.GetLength(1)+j]=mat[i,j];
                }
            }
            return res;
        }
        static int[,] ravel(int[] tab,int l0,int l1){
            int[,] res = new int[l0,l1];
            for(int i =0;i<tab.Length;i++){
                res[(int)(i/l0),i%l0] = tab[i];
            }
            return res;
        }
        static void shift(int[] tab,int n=1){
            for(int j=0;j<n;j++){
                int tempshift=tab[tab.Length-1];
                int tempswap = 0;
                for(int i=0;i<tab.Length;i++){
                    // temp = tab[(i+tab.Length+1)%tab.Length];
                    // tab[(i+tab.Length+1)%tab.Length] = tab[i];
                    // tab[i]=temp;
                    tempswap = tab[i];
                    tab[i]=tempshift;
                    tempshift = tempswap;

                }
            }
            
        }
        static int[,] nshift(int[,] mat,int n){
            int[] temp = unravel(mat);
            shift(temp,n);
            return ravel(temp,mat.GetLength(0),mat.GetLength(1));
        }
        static int[,] rndmat(int m,int n){
            Random rnd = new Random();
            int[,] mat = new int[m,n];
            for(int i=0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    mat[i,j] = rnd.Next(10);
                }
            }
            return mat;
        }
        static int[,] convolution(int[,] input,int[,] kernel){
            int centerx = kernel.GetLength(0)/2;
            int centery = kernel.GetLength(1)/2;
            int sum=0;
            int[,] output = new int[input.GetLength(0),input.GetLength(1)];
            for(int x=0;x<output.GetLength(0);x++){
                for(int y=0;y<output.GetLength(1);y++){
                    sum=0;
                    for(int i=0;i<kernel.GetLength(0);i++){
                        for(int j=0;j<kernel.GetLength(1);j++){
                            sum+=input[(x+i-centerx+input.GetLength(0))%input.GetLength(0),(y+j-centery+input.GetLength(1))%input.GetLength(1)]*kernel[i,j];
                        }
                    }
                    output[x,y] = sum;
                }
            }
            return output;
        }
        static bool isvalidmat(int[,] mat){
            bool res = false;
            if(mat!=null){
                if(mat.GetLength(0)>0 && mat.GetLength(1)>0){
                    res = true;
                }
            }
            return res;
        }
        static int getint(int mmin=0){
            int input = -1;
            while(!int.TryParse(Console.ReadLine(),out input) || input<mmin){
                Console.WriteLine("veuillez rentrer un entier naturel.");
            }
            return input;
        }
        public struct memomatrice
        {
            public string Name {get;set;}
            public int[,] Mat {get;set;}
            public memomatrice(string name, int[,] mat){
                Name = name;
                Mat = mat;
            }
            
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            List<memomatrice> memory = new List<memomatrice>();
            memory.Add(new memomatrice("h",new int[,] {{1,1,1}}));
            memory.Add(new memomatrice("v",new int[,] {{1},{2},{3}}));
            // Console.WindowHeight = 50;
            // Console.WindowWidth = 100;
            const int exomin=1;
            const int exomax=10;
            int cursor = exomin-1;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "-exercice 1 : creer matrice\n"
                                 + "-exercice 2 : creer matrice aleatoire\n"
                                 + "-exercice 3 : visualiser les matrices\n"
                                 + "-exercice 4 : creer produit matriciel\n"
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
                                    Console.Clear();
                                    editnewmat(memory);
                                    break;
                                case 2:
                                    //2
                                    Console.Clear();
                                    rndeditmap(memory);
                                    break;
                                case 3:
                                    prettydisp(getmatfrom(memory));
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    //4
                                    multnewmat(memory);
                                    break;
                                case 5:
                                    Console.WriteLine(string.Join(' ',insertionsort(new int[]{9,2,3,4,5})));
                                    Console.ReadLine();
                                    break;
                                case 6:
                                    //6
                                    Console.WriteLine(testcarremagic(new int[,]{{8,1,6},{3,5,7},{4,9,2}}));
                                    Console.WriteLine(testcarremagic(new int[,]{{2,1,6},{3,5,7},{4,9,2}}));
                                    Console.ReadLine();
                                    break;
                                case 7:
                                    //7
                                    int[,] test = new int[,]{{1,2,3},{4,5,6},{7,8,9}};
                                    test=nshift(test,3);
                                    prettydisp(test);
                                    Console.ReadLine();
                                    break;
                                case 8:
                                    //8
                                    int[,] image = new int[,]{{1,2,3,4},{5,6,7,8},{9,10,11,12},{13,14,15,16}};
                                    int[,] kernel = new int[,]{{1,1,1},{1,1,1},{1,1,1}};
                                    prettydisp(convolution(image,kernel));
                                    Console.ReadLine();
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
        static void disp(int[,]mat1){
            for(int i =0;i<mat1.GetLength(0);i++){
                for(int j=0;j<mat1.GetLength(1);j++){
                    Console.Write(mat1[i,j]);
                }
                Console.WriteLine();
            }
        }
        static int prettydisp(int[,] mat){
            int len =0;
            int temp;
            for(int i =0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    temp = mat[i,j].ToString().Length;
                    if(len<temp){
                        len = temp;
                    }
                }
            }
            for(int i =0;i<mat.GetLength(0);i++){
                for(int j=0;j<mat.GetLength(1);j++){
                    Console.Write(mat[i,j].ToString().PadLeft(len+1));
                }
                Console.WriteLine();
            }
            return len;
        }
        static int editdisp(int[,] mat){
            Console.WriteLine("use arrows and enter to edit the matrix, confirm with escape.");
            return(prettydisp(mat));
        }
        static int[,] editloop(int w,int h){
            int[,] res = new int[h,w];
            ConsoleKeyInfo cki;
            int[] cursor = new int[]{0,0};
            int temp=0;
            int vpad=1;
            int hpad=1;
            int vstep=1;
            int hstep=2;
            do{
                Console.Clear();
                hstep = editdisp(res)+1;//adjust to max word size
                Console.SetCursorPosition(cursor[0]*hstep+hpad,cursor[1]*vstep+vpad);
                cki = Console.ReadKey();
                switch(cki.Key){
                    case ConsoleKey.UpArrow:
                        cursor[1]--;
                        break;
                    case ConsoleKey.DownArrow:
                        cursor[1]++;
                        break;
                    case ConsoleKey.RightArrow:
                        cursor[0]++;
                        break;
                    case ConsoleKey.LeftArrow:
                        cursor[0]--;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("please enter an int");
                        temp = getint();
                        res[cursor[1],cursor[0]]= temp;
                        Console.Clear();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("confirmed, enter");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("mauvaise touche");
                        Console.ReadLine();
                        break;
                }
                cursor[0] = ((cursor[0]+w)%(w));
                cursor[1] = ((cursor[1]+h)%(h));
            }while (cki.Key != ConsoleKey.Escape);
            return res;
        }
        static void editnewmat(List<memomatrice> memory){
            Console.WriteLine("la matrice aura la forme (m,n)");
            Console.WriteLine("veuillez entrer m");
            int m = getint(1);
            Console.WriteLine("veuillez entrer n");
            int n = getint(1);
            Console.WriteLine("veuillez rentrer le nom de la matrice");
            string name = Console.ReadLine();
            int [,] tobeedit = editloop(m,n);
            memory.Add(new memomatrice(name,tobeedit));
        }
        static void rndeditmap(List<memomatrice> memory){
            Console.WriteLine("la matrice aleatoire aura la forme (m,n)");
            Console.WriteLine("veuillez entrer m");
            int m = getint(1);
            Console.WriteLine("veuillez entrer n");
            int n = getint(1);
            Console.WriteLine("veuillez rentrer le nom de la matrice");
            string name = Console.ReadLine();
            int [,] tobeedit = rndmat(n,m);
            memory.Add(new memomatrice(name,tobeedit));
        }
        static void multnewmat(List<memomatrice> memory){
            Console.WriteLine("produit matricielle de A*B=C");
            Console.WriteLine("veuillez selectioner la matrice A");
            Console.ReadLine();
            int[,] A = getmatfrom(memory);
            Console.Clear();
            Console.WriteLine("veuillez selectioner la matrice B");
            Console.ReadLine();
            int[,] B = getmatfrom(memory);
            Console.Clear();
            int [,] C = produitmatriciel(A,B);
            if(isvalidmat(C)){
                Console.WriteLine("veuillez rentrer le nom de la matrice pour savegarder");
                string name = Console.ReadLine();
                prettydisp(C);
                memory.Add(new memomatrice(name,C));
            }else{
                Console.WriteLine("sauvegarder: rien");
            }
            Console.ReadLine();
            
        }
        static void dispmemory(List<memomatrice> memory){
            Console.Clear();
            Console.WriteLine("choisisez une matrice avec les fleches, confirmez avec enter");
            for(int i=0;i<memory.Count;i++){
                Console.Write(i);
                Console.Write(". ");
                Console.WriteLine(memory[i].Name);
            }
        }
        static int[,] getmatfrom(List<memomatrice> memory){
            int[,] res = new int[0,0];
            if(memory.Count>0){
                ConsoleKeyInfo cki;
                int vpad=1;
                int cursor=0;
                do{
                    dispmemory(memory);
                    Console.SetCursorPosition(0,cursor+vpad);
                    cki = Console.ReadKey();
                    switch(cki.Key){
                        case ConsoleKey.UpArrow:
                            cursor--;
                            break;
                        case ConsoleKey.DownArrow:
                            cursor++;
                            break;
                        case ConsoleKey.Enter:
                            res = memory[cursor].Mat;
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("pas de selection");
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("mauvaise touche");
                            Console.ReadLine();
                            break;
                    }
                    cursor = ((cursor+memory.Count)%(memory.Count));
                }while (cki.Key != ConsoleKey.Escape && cki.Key!=ConsoleKey.Enter);
            }
            if(res.GetLength(0)==res.GetLength(1) && res.GetLength(0)==0){
                Console.WriteLine("aucune matrice sélectioné");
                Console.WriteLine("veillez a en créer");
                Console.ReadLine();
            }
            Console.Clear();
            return res;
        }

    }
}
