
// Enoncé
// Afficher la chaîne inversée de celle donnée en paramètre

public static void Main (string[] args){
    Console.WriteLine(inverse(Console.readLine()));
}
static string inverse(string recto){
    return new string(recto.ToCharArray().Reverse().ToArray() );
}
//TO COMPLETE Vous devez écrire sim‌﻿﻿‌‍‍﻿‌‌‌plement (les using et class Program sont déjà pré-programmés)
// La méthode Main qui demande à l'utilisateur de saisir une chaine, appelle la méthode d'inversion et affiche le mot inversé
// La méthode qui inverse une chaine de caractères