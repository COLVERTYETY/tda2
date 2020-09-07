// Dessine la table de multiplication jusqu'à 10 d'un nombre. Ce nombre peut être compris entre 1 et 10.

// Vous ferez en sorte d'insérer entre 2 caractères un espace. Attention la sortie doit être exactement celle attendue

// Exemple pour la valeur 3

// 1 2 3 4 5 6 7 8 9 10

// 2 4 6 8 10 12 14 16 18 20

// 3 6 9 12 15 18 21 24 27 30

public void TableDeMultiplication(int dimension)
{
   for(int i=1;i<=dimension;i++){
       for(int j =1;j<=10;j‌‌‌‌++){
           Console.Write(i*j);
           Console.Write(" ");
       }
       Console.WriteLine();
   }
}