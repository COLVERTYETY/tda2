// Création d'une matrice carrée d'entiers remplie d'une valeur saisie au clavier.

// La hauteur sera précisée au clavier

public static void Main(string[] args){
    disp(makemat());
}//TO COMPLETE
static int[,] makemat(){
    int h = Convert.ToInt32(Console.ReadLine());
    int val = Convert.ToInt32(Console.ReadLine());
    int[,] mat = new int[h,h];
    for(int i =0;i<h;i++){
        for(int j ‌﻿﻿‌‍‍﻿‌‌‌= 0;j<h;j++){
            mat[i,j]=val;
        }
    }
    return mat;
}
static void disp(int[,]mat1){
    for(int i =0;i<mat1.GetLength(0);i++){
        for(int j=0;j<mat1.GetLength(1);j++){
            Console.Write(mat1[i,j]);
        }
        Console.WriteLine();
    }
}