public class Potwor
{
    public string Nazwa { get; set; }
    public int HP { get; set; }
    public int Atak { get; set; }
    public int Obrona { get; set; }
    public Potwor(string nazwa, int hp, int atak, int obrona)
    {
        Nazwa = nazwa;
        HP = hp;
        Atak = atak;
        Obrona = obrona;
    }
}
class Program {
    public static Random random = new Random();
    static (int zycie,int atak,int zloto) AdminConsole()
    {
        Console.WriteLine();
        Console.WriteLine("--Console--");
        Console.WriteLine("zycie:");
         int zycie = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("atak:");
        int atak = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("zloto:");
        int zloto = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Nowe statystyki ustawione!");
        return (zycie,atak,zloto);
    }
    static void WyswietlStatystyki(string imie, int zycie, int atak, int zloto)
    {
        //Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine("--Twoja postac--");
        Console.WriteLine($"Imie {imie}");
        Console.WriteLine($"Zycie {zycie}");
        Console.WriteLine($"Atak {atak}");
        Console.WriteLine($"Zloto {zloto}");
    }
    static (string imie,int zycie, int atak, int zloto) TworzeniePostaci()
    {
        Console.WriteLine();
        Console.WriteLine("--Tworzenie postaci--");
        Console.WriteLine("Podaj imie bohatera");
        string imie = Console.ReadLine() ?? "";
        int zycie = 100;
        int atak = 5;
        int zloto = 250;
        Console.WriteLine($"Twoja postac to: {imie}");
        return (imie, zycie, atak, zloto);
    }
    static void EnemyEncounter(string imie,int zycie,int atak,int zloto,string pNazwa,int pHp,int pAtk,int pDef)
    {
        Console.WriteLine();
        Potwor potwor1 = new Potwor(pNazwa,random.Next(pHp - 2, pHp + 3),random.Next(pAtk - 1, pAtk + 2),random.Next(pDef - 1, pDef + 2));

        Console.WriteLine($"Napotykasz na swojej drodze {potwor1.Nazwa} o HP:{potwor1.HP}, Ataku:{potwor1.Atak} i Obronie:{potwor1.Obrona}!");
        Console.WriteLine("Co zrobisz?");

        int ucieczka = 0;
        while (potwor1.HP > 0 || ucieczka == 1 )
        {
            Console.WriteLine("1.Atakuj\n2.Leczenie\n3.Uciekaj");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    Console.WriteLine("bruh1");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine();
                    Console.WriteLine("bruh2");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine();
                    if (random.Next(1, 11) > 5)
                    {
                        ucieczka = 1;
                        Console.WriteLine("Udalo ci sie uciec!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nie udalo ci sie uciec! Walka nadal trwa");
                        break;
                    }
                default:
                    Console.WriteLine();
                    Console.WriteLine("Podaj poprawny wybor!");
                    break;
            }
        }

    }
    static void WaitClearScreen()
    {
        Console.Write("> ");
        Console.ReadKey();
        Console.Clear();
    }
    static void Main()
    {
        string imie="";
        int zycie;
        int atak;
        int zloto;
        (imie,zycie,atak,zloto)=TworzeniePostaci();
        (zycie,atak,zloto)=AdminConsole();
        WyswietlStatystyki(imie,zycie,atak,zloto);
        WaitClearScreen();
        EnemyEncounter(imie,zycie,atak,zloto,"Goblin",10,5,3);
    }
}