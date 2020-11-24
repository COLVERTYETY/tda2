using System;

namespace tdpoo
{
    class Program
    {
        static double getdouble(double mmin=0){
            double input = -1;
            while(!double.TryParse(Console.ReadLine(),out input) || input<mmin){
                Console.WriteLine("veuillez rentrer un double");
            }
            return input;
        }
        static int getint(int mmin=0,int mmax = 9){
            int input = -1;
            while(!int.TryParse(Console.ReadLine(),out input) || input<mmin || input>mmax){
                Console.WriteLine("veuillez rentrer un double");
            }
            return input;
        }
        static bool getbool(){
            bool input = false;
            int trye = -1;
            while((!int.TryParse(Console.ReadLine(),out trye)) || (trye!=0 && trye!=1)){
                Console.WriteLine("veuillez rentrer 1 ou 0");
            }
            input = (trye==1);
            return input;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("testing ARTICLE");
            Console.ReadLine();
            article patate = new article(1,"patates",4.60,200);
            article tomate = new article(2,"tomates",3.54,1);
            Console.WriteLine("premier article: ");
            Console.WriteLine(patate.Intitule);
            Console.WriteLine(patate.QuantiteEnStock);
            Console.WriteLine(patate.PrixHT);
            Console.WriteLine(patate.Prixttc);
            Console.WriteLine(patate.Reference);
            Console.WriteLine("autrement dit...");
            Console.WriteLine(patate.toString());
            Console.ReadLine();
            Console.WriteLine("deuxieme article: ");
            Console.WriteLine(tomate.Intitule);
            Console.WriteLine(tomate.QuantiteEnStock);
            Console.WriteLine(tomate.PrixHT);
            Console.WriteLine(tomate.Prixttc);
            Console.WriteLine(tomate.Reference);
            Console.WriteLine("autrement dit...");
            Console.WriteLine(tomate.toString());
            Console.ReadLine();
            Console.WriteLine("check egualité...");
            Console.WriteLine(patate.equals(tomate));
            Console.ReadLine();
            Console.WriteLine("test vente / achat");
            Console.WriteLine("stock is: ");
            Console.WriteLine(patate.QuantiteEnStock);
            Console.WriteLine("to remove until none");
            Console.ReadLine();
            bool res=true;
            while (res){
                res = patate.vendre(35);
                Console.WriteLine(patate.QuantiteEnStock);
            }
            Console.WriteLine("now to add to the stock");
            Console.ReadLine();
            for (int i =0;i<20;i++){
                patate.approvisionner(i);
                Console.WriteLine(patate.QuantiteEnStock);
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("test COMPTE BANCAIRE");
            Console.ReadLine();
            Console.Clear();
            compteBancaire filler = new compteBancaire();
            ConsoleKeyInfo cki;
            // Console.WindowHeight = 50;
            // Console.WindowWidth = 100;
            const int exomin=1;
            const int exomax=8;
            int cursor = exomin-1;
            compteBancaire temp;
            string nom;
            double mmontant;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu :\n"
                                 + "-exercice 1 : create account 0\n"
                                 + "-exercice 2 : create account 1\n"
                                 + "-exercice 3 : create account 2\n"
                                 + "-exercice 4 : view existing accounts\n"
                                 + "-exercice 5 : debit an account\n"
                                 + "-exercice 6 : credit an account\n"
                                 + "-exercice 7 : info accounts\n"
                                 + "-exercice 8 : unblock account\n"
                                 + "\n"
                                 + "select desired operation");
                
                
                Console.WriteLine("use keys to navigate, enter to confirm and escape to quit");
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
                                    //p
                                    Console.Clear();
                                    Console.WriteLine("un compte bancaire a été crée");
                                    temp = new compteBancaire();
                                    temp.disp();
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    //
                                    Console.Clear();
                                    Console.WriteLine("creation d'un compte bancaire");
                                    Console.WriteLine("veuillez rentrer le nom du compte");
                                    nom=Console.ReadLine();
                                    Console.WriteLine("veuillez rentrer le montant initial du compte");
                                    mmontant = getdouble();
                                    temp = new compteBancaire(nom,mmontant);
                                    Console.WriteLine("");
                                    temp.disp();
                                    Console.ReadLine();
                                    break;
                                case 3:
                                    //
                                    Console.Clear();
                                    Console.WriteLine("creation d'un compte bancaire");
                                    Console.WriteLine("veuillez rentrer le nom du compte");
                                    nom =Console.ReadLine();
                                    Console.WriteLine("veuillez rentrer le montant initial du compte");
                                    mmontant = getdouble();
                                    Console.WriteLine("veuillez rentrer la valeur du flag de bloquage(1 ou 0)");
                                    bool flag = getbool();
                                    temp = new compteBancaire(nom,mmontant,flag);
                                    Console.WriteLine("");
                                    temp.disp();
                                    Console.ReadLine();
                                    break;
                                case 4:
                                    dispall();
                                    Console.ReadLine();
                                    break;
                                case 5:
                                    //
                                    Console.Clear();
                                    Console.WriteLine("veuillez selectionner le compte bancaire a debiter");
                                    Console.ReadLine();
                                    temp = choseaccount();
                                    Console.Clear();
                                    Console.WriteLine("veuillez renter le montant a debiter");
                                    mmontant = getdouble();
                                    bool success = temp.debit(mmontant);
                                    if(success){
                                        Console.WriteLine("l'operation est un succes !!");
                                    }else{
                                        Console.WriteLine("l'operation est un echec . . .");
                                    }
                                    temp.disp();
                                    Console.ReadLine();
                                    break;
                                case 6:
                                    //
                                    Console.Clear();
                                    Console.WriteLine("veuillez selectionner le compte bancaire a crediter");
                                    Console.ReadLine();
                                    temp = choseaccount();
                                    Console.Clear();
                                    Console.WriteLine("veuillez renter le montant a debiter");
                                    mmontant = getdouble();
                                    bool succcess = temp.credit(mmontant);
                                    if(succcess){
                                        Console.WriteLine("l'operation est un succes !!");
                                    }else{
                                        Console.WriteLine("l'operation est un echec . . .");
                                    }
                                    temp.disp();
                                    Console.ReadLine();
                                    break;
                                case 7:
                                    //
                                    Console.Clear();
                                    Console.WriteLine("voici des infos sur les comptes");
                                    Console.Write("il nombre total de compte existant: ");
                                    Console.WriteLine(compteBancaire.nombreDeClients());
                                    Console.Write("quantite de compte bloqué: ");
                                    Console.WriteLine(compteBancaire.nombreDeClientsBloque());
                                    Console.Write("montant moyen: ");
                                    Console.WriteLine(compteBancaire.montantmoyen());
                                    Console.ReadLine();
                                    break;
                                case 8:
                                    //
                                    Console.Clear();
                                    Console.WriteLine("veuillez selectionner le compte bancaire a debloquer");
                                    Console.ReadLine();
                                    temp = choseaccount();
                                    temp.Block = false;
                                    Console.Clear();
                                    temp.disp();
                                    Console.ReadLine();
                                    break;

                                default:
                                    break;
                            }
                        break;
                    default:
                        Console.WriteLine("wrong key");
                        break;
                }
                cursor = ((cursor+exomax)%(exomax));
            } while (cki.Key != ConsoleKey.Escape);
            Console.Clear();
            Console.WriteLine("god speed !!");
            Console.Read();

        }
        static void dispall(){
            Console.Clear();
            Console.WriteLine("voici la liste des comptes bancaires: ");
            for(int i =0;i<compteBancaire.CLIENTS.Count;i++){
                Console.Write(i);
                Console.Write(" ");
                compteBancaire.CLIENTS[i].disp();
            }
        }
        static compteBancaire choseaccount(){
            dispall();
            Console.WriteLine("veuillez rentrer le numero du compte desiré");
            int nac = getint(0,compteBancaire.CLIENTS.Count-1);
            compteBancaire res = compteBancaire.CLIENTS[nac];
            return res;
        }
    }
}
