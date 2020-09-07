// Demander à l'utilisateur de saisir une hauteur

// Demander à l'utilisateur de saisir une valeur qui permettra d' initialiser toutes les cases de la matrice

// Créer une première matrice

// Répéter cette opération une deuxième fois avec le même ordre

// Afficher la somme de ces 2 matrices

public static void Main(string[] args){
    disp(add(makemat(),makemat()));
}// TO COMPLETE

static int[,] makemat(){
    int h = Convert.ToInt32(Console.ReadLine());
    int val = Convert.ToInt32(Console.ReadLine());
    int[,] mat = new int[h,h];
    for(int i =0;i<h;i++){
        for(int j = 0;j<h;j++){
            mat[i,j]=val;
        }
    }
    return mat;
}

static int[,] add(int[,] mat1, int[,] mat2){
    int[,] res = new int[mat1.GetLength(0),mat1.GetLength(1)];
    for(int i =0;i<mat1.GetLength(0);i++){
        for(int j=0;j<mat1.GetLength(1);j++){
            res[i,j] = mat1[i,j]+mat2[i,j];
        }
    }
    return res;
}
static void disp(int[,]mat1){
    for(int i =0;i<mat1.GetLength(0);i++){
        for(int j=0;j<mat1.GetLength(1);j++){
            Console.Write(mat1[i,j]);
        }
        Console.WriteLine();
    }
}