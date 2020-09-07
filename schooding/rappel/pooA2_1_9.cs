// Le programme doit afficher le nombre de fois qu'un mot apparait dans une phrase.
//  On appelle phrase dans notre exercice une suite de mots séparés par des espaces, des points et des virgules.
//   Aucun autre signe de ponctuation n'est à prendre en compte.

public int Recherche(string phrase, string mot)
{
    string[] words = phrase.Split(new char[]{' ','.',','});
    int sum=0‌﻿﻿‌‍‍﻿‌‌‌;
    foreach(string i in words){
        if(i==mot){
            sum++;
        }
    }
    return sum;
}//TO COMPLETE