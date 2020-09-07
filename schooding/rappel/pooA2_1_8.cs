
// Enoncé
// Création d'une matrice carrée d'entiers initialisée avec une valeur saisie au clavier. Une autre valeur marquera les 2 diagonales principales

// Pour cela vous saisirez d'abord la hauteur, la valeur entière par défaut de la matrice puis la valeur entière pour les diagonales 

// Enfin, vous afficherez le contenu de votre matrice

// TO COMPLETE, (les using, namespace et class Program sont pré-définis)
// Vous devez écrire la méthode Main et les méthodes qui créent les matrices avec initialisation des cases et des diagonales
// Et une méthode d'affichage
// Attention : Respecter l'ordre des saisies des valeurs dans le programme principal !!!
public static void Main(string[] args){
    disp(makemat());
}
static int[,] makemat(){
    int h = Convert.ToInt32(Console.ReadLine());
    int val = Convert.ToInt32(Console.ReadLine());
    int diag = Convert.ToInt32(Console.ReadLine());
    int[,] mat = new int[h,h];
    for(int i =0;i<h;i++){
        for(int j = 0;j<h;j++){
            if(i==j || j==(h-i-1)){
                mat[i,j]=diag;
            }else{
                mat[i,j]=val;
            }
            
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