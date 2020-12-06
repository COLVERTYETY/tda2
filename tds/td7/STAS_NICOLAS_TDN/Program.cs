using System;
using System.Collections;
using System.Collections.Generic;

namespace td7
{
    class Program
    {

        static Stack<int> melange(Stack<int> a, Stack<int> b)
        {
            Stack<int> result = new Stack<int>();
            Random rand = new Random();
            while(a.Count>0 && b.Count>0){
                if(rand.Next(0,100)>=50){
                    result.Push(a.Pop());
                }else{
                    result.Push(b.Pop());
                }
            }
            while(a.Count>0 ){
                result.Push(a.Pop());
            }
            while(b.Count>0 ){
                result.Push(b.Pop());
            }
            return result;
        }
        static void filterphone(List<string> numbers){
            int temp = 0;
            foreach(string a in numbers.ToArray())
            {
                if( !int.TryParse(a,out temp) || a.Length !=10 || !a[0].Equals("0"))
                {
                    numbers.Remove(a);
                }
            }
        }
        static int NPI(Stack<string> command)
        {
            int res = 0;
            string stringval ="";
            if(command.Count >0){
                stringval = command.Pop();
                switch (stringval)
                {
                    case "+":
                        res = NPI(command) + NPI(command);
                        break;
                    case "-":
                        res = NPI(command) - NPI(command);
                        break;
                    case "*":
                        res = NPI(command) * NPI(command);
                        break;
                    case "/":
                        int ttemp = NPI(command);
                        res = NPI(command) / ttemp;
                        break;
                    default:
                        res = Convert.ToInt32(stringval);
                        break;
                }
            }
            return res; 
        }
        static Stack<int> rndstack(int length=0){
            Stack<int> mstack = new Stack<int>();
            Random rnd = new Random();
            if(length<=0){
                length = rnd.Next(1,20);
            }
            for(int i=0;i<length;i++){
                mstack.Push(rnd.Next(1,14));
            }
            return mstack;
        }
        static void exo1(){
            Stack<int> first = new Stack<int>();
            first.Push(1);
            first.Push(2);
            first.Push(3);
            first.Push(4);
            Stack<int> second = new Stack<int>();
            second.Push(5);
            second.Push(6);
            second.Push(7);
            second.Push(8);
            Stack<int> mel = melange(second, first);
            Console.WriteLine(string.Join(' ',mel));
        }
        static void demo1(){
            Console.Clear();
            Console.WriteLine("demonstartion de melange de stack");
            Console.WriteLine("stack A:");
            Stack<int> A = rndstack(5);
            Console.WriteLine(string.Join(";",A));
            Console.WriteLine("stack B:");
            Stack<int> B = rndstack(5);
            Console.WriteLine(string.Join(";",B));
            Console.WriteLine("melange:");
            Stack<int> C = melange(A,B);
            Console.WriteLine(string.Join(";",C));
            Console.ReadLine(); 
        }
        static void exo2(){
            Stack<string> testadd = new Stack<string>();
            testadd.Push("3");
            testadd.Push("3");
            testadd.Push("+");
            Stack<string> testfull = new Stack<string>(); // 1 2 + 4 × 3 +
            testfull.Push("1");
            testfull.Push("2");
            testfull.Push("+");
            testfull.Push("4");
            testfull.Push("*");
            testfull.Push("3");
            testfull.Push("+");
            Stack<string> myexo = new Stack<string>();// "3,3, 3,+,+,4,*,2,/"
            myexo.Push("3");
            myexo.Push("3");
            myexo.Push("+");
            myexo.Push("3");
            myexo.Push("+");
            myexo.Push("4");
            myexo.Push("*");
            myexo.Push("2");
            myexo.Push("/");
            Console.WriteLine(NPI(myexo));
        }
        static void demoexo2(){
            Console.Clear();
            Console.WriteLine("demontsration de NPI:");
            Console.WriteLine("(notation polonaise inversé)");
            Console.WriteLine("veuillez rentrer une commande ne NPI séparé par des espaces");
            Console.WriteLine("ex: 3 3 + 4 * 2 /");
            string input = Console.ReadLine();
            string[] temparr = input.Split(" ");
            bool correct = true;
            int res;
            foreach(string i in temparr){
                if(!int.TryParse(i,out res)){
                    if(i!="+" && i!="-" && i!="/" && i!="*"){
                        correct = false;
                    }
                }
            }
            if(correct){
                Console.WriteLine("resultat: ");
                Stack<string> nice = new Stack<string>(temparr);
                Console.WriteLine(NPI(nice));
                
            }else{
                Console.WriteLine("oups npi stack non valide");
            }
            Console.ReadLine();
        }
        
        static void annuaire(){
            SortedList<int, string> theannuaire = new SortedList<int, string>();
            theannuaire.Add(1111111111,"AAA");
            theannuaire.Add(1111111112,"ZZZ");
            theannuaire.Add(1111111114,"ABC");
            theannuaire.Add(1111111110,"CCC");
            ConsoleKeyInfo cki;
            const int exomin=1;
            const int exomax=6;
            int tempint = 0;
            string tempstring = "";
            int cursor = exomin-1;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "-exercice 1 : ajouter une personne\n"
                                 + "-exercice 2 : afficher tous\n"
                                 + "-exercice 3 : obtenir numero par nom\n"
                                 + "-exercice 4 : obtenir un nom par un numero\n"
                                 + "-exercice 5 : demonstartion melange de stack\n"
                                 + "-exercice 6 : demonstartion NPI\n"
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
                                    Console.Clear();
                                    Console.WriteLine("ajout d'une personne sur l'annulaire");
                                    tempint = getvalidphonenumber();
                                    while(theannuaire.ContainsKey(tempint)){
                                        Console.WriteLine("ce numero existe deja...");
                                        tempint = getvalidphonenumber();
                                    }
                                    tempstring = getname();
                                    theannuaire.Add(tempint,tempstring);
                                    Console.WriteLine("ajout de la personne !!");
                                    Console.WriteLine("-> "+Convert.ToString(tempint)+" : "+(theannuaire[tempint]));
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    foreach(var pair in theannuaire){
                                        Console.WriteLine("-> "+Convert.ToString(pair.Key)+" : "+(pair.Value));
                                    }
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    string building="";
                                    Console.Clear();
                                    Console.WriteLine("tapez le nom: ");
                                    Console.WriteLine(building);
                                    disp_partial_name(building,theannuaire);
                                    ConsoleKeyInfo input = Console.ReadKey(intercept:true);
                                    while (input.Key != ConsoleKey.Enter){
                                        
                                        if(input.Key == ConsoleKey.Backspace && building.Length>0){
                                            building = building.Remove(building.Length-1);
                                        }else{
                                            if( char.IsLetterOrDigit(input.KeyChar)){
                                                building+=input.KeyChar;
                                            }
                                        }
                                        Console.Clear();
                                        Console.WriteLine("get a name from a number: ");
                                        Console.WriteLine(building);
                                        disp_partial_name(building,theannuaire);
                                        input = Console.ReadKey(intercept:true);

                                    }
                                    Console.Clear();
                                    if(theannuaire.ContainsValue(building)){
                                        Console.Clear();
                                        Console.WriteLine("couple séléctionné: ");
                                        disp_partial_name(building, theannuaire);
                                        Console.WriteLine("si vous souhaitez effacer ce contact veuillez taper \"oui\"");
                                        if(Console.ReadLine()=="oui"){
                                            theannuaire.RemoveAt(theannuaire.IndexOfValue(building));
                                            Console.WriteLine("vous avez effacer le contact");
                                        }else{
                                            Console.WriteLine("vous n'avez pas effacé le contact");
                                        }
                                        
                                    }else{
                                        Console.WriteLine("nom inconnue");
                                        Console.WriteLine("verifier la capitalisation?");
                                    }
                                    Console.WriteLine("appuyé sur enter pour continuer...");
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    string buildings="";
                                    int test;
                                    Console.Clear();
                                    Console.WriteLine("tapez le numero: ");
                                    Console.WriteLine(buildings);
                                    disp_partial_name(buildings,theannuaire);
                                    ConsoleKeyInfo inputs = Console.ReadKey(intercept:true);
                                    while (inputs.Key != ConsoleKey.Enter){
                                        
                                        if(inputs.Key == ConsoleKey.Backspace && buildings.Length>0){
                                            buildings = buildings.Remove(buildings.Length-1);
                                        }else{
                                            if( char.IsDigit(inputs.KeyChar)){
                                                buildings+=inputs.KeyChar;
                                            }
                                        }
                                        if(int.TryParse(buildings, out test)){
                                            Console.Clear();
                                            Console.WriteLine("tapez le numero: ");
                                            Console.WriteLine(buildings);
                                            disp_partial_key(test,theannuaire);
                                        }else{
                                            Console.Clear();
                                            Console.WriteLine("vous n avez pas rentré un chiffre valide");
                                            Console.WriteLine("tapez le numero: ");
                                            Console.WriteLine(buildings);
                                        }
                                        inputs = Console.ReadKey(intercept:true);
                                    }
                                    Console.Clear();
                                    if(int.TryParse(buildings, out test)){
                                        if(theannuaire.ContainsKey(test)){
                                            Console.Clear();
                                            Console.WriteLine("couple séléctionné: ");
                                            Console.WriteLine("-> "+Convert.ToString(test)+" : "+(theannuaire[test]));
                                            Console.WriteLine("si vous souhaitez effacer ce contact veuillez taper \"oui\"");
                                            if(Console.ReadLine()=="oui"){
                                                theannuaire.Remove(test);
                                                Console.WriteLine("vous avez effacer le contact");
                                            }else{
                                                Console.WriteLine("vous n'avez pas effacé le contact");
                                            }
                                            
                                        }else{
                                            Console.WriteLine("the key was not found");
                                        }
                                    }else{
                                        Console.WriteLine("invalid key");
                                    }
                                    Console.WriteLine("appuyé sur enter pour continuer...");
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    //5
                                    demo1();
                                    break;
                                case 6:
                                    demoexo2();
                                    break;
                                default:
                                    //wow
                                    break;
                            }
                        break;
                    default:
                        Console.WriteLine("mauvaise touche");
                        break;
                }
                cursor = ((cursor+exomax)%(exomax));
            } while (cki.Key != ConsoleKey.Escape);
        }

        static void disp_partial_key(int value, SortedList<int ,string> thelist){
            foreach( var i in thelist){
                if(partialmatchint(value,i)){
                    Console.WriteLine("-> "+Convert.ToString(i.Key)+" : "+(i.Value));
                }
            }
        }
        static void disp_partial_name(string value, SortedList<int ,string> thelist){
            foreach( var i in thelist){
                if(partialmatchname(value,i)){
                    Console.WriteLine("-> "+Convert.ToString(i.Key)+" : "+(i.Value));
                }
            }
        }
        static bool partialmatchint(int test, KeyValuePair<int , string> pair){
            return Convert.ToString(pair.Key).ToUpper().Contains(Convert.ToString(test).ToUpper());
        }
        static bool partialmatchname(string test, KeyValuePair<int , string> pair){
            return pair.Value.ToUpper().Contains(test.ToUpper());
        }
        static int getvalidphonenumber(){
            int input = -1;
            Console.WriteLine("veuilles rentrer un numéro de téléphone:");
            while(!int.TryParse(Console.ReadLine(),out input) || Convert.ToString(input).Length!=10){
                Console.WriteLine("veuillez rentrer un numero de telephone valid.");
                Console.WriteLine(" de la forme:");
                Console.WriteLine("             0C CC CC CC CC");
                Console.WriteLine("(sans les espaces..)");
            }
            return input;
        }
        static string getname(){
            string res = "";
            Console.WriteLine("veuilles rentrer un nom:");
            res = Console.ReadLine();
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            annuaire();
        }
    }
}
