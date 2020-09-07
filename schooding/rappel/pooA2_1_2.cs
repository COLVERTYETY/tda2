
// Enoncé
// Afficher une matrice carrée dont la hauteur H et le symbole S 

// Vous utiliserez la signature suivante : void DessineUneMatrice(int H, char S)
public void DessineUneMatrice(int H, char S)
{
    for(int i=0‌‌‌;i<H;i++){
        Console.WriteLine(new String(S,H));
    }
}