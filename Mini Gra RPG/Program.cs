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
    static (int zycie,int atak,int zloto) adminConsole()
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
    static void wyswietlStatystyki(string imie, int zycie, int atak, int zloto)
    {
        //Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine();
        Console.WriteLine("--Twoja postac--");
        Console.WriteLine($"Imie {imie}");
        Console.WriteLine($"Zycie {zycie}");
        Console.WriteLine($"Atak {atak}");
        Console.WriteLine($"Zloto {zloto}");
    }
    static (string imie,int zycie, int atak, int zloto) tworzeniePostaci()
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
    static void enemyEncounter(string imie,int zycie,int atak,int zloto,string pNazwa,int pHp,int pAtk,int pDef)
    {
        Console.WriteLine();
        Potwor Potwor1 = new Potwor(pNazwa,random.Next(pHp - 2, pHp + 3),random.Next(pAtk - 1, pAtk + 2),random.Next(pDef - 1, pDef + 2));

        Console.WriteLine($"Napotykasz na swojej drodze {Potwor1.Nazwa} o HP:{Potwor1.HP}, Ataku:{Potwor1.Atak} i Obronie:{Potwor1.Obrona}!");
        Console.WriteLine("Co zrobisz?");

        int ucieczka = 0;
        while (Potwor1.HP > 0 || ucieczka == 1 )
        {
            Console.WriteLine("1.Atakuj\n2.Leczenie\n3.Uciekaj");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine();
                    Console.WriteLine("bruh");
                    break;
            }
        }

    }
    static void waitClearScreen()
    {
        Console.Write("->");
        Console.ReadKey();
        Console.Clear();
    }
    static void Main()
    {
        string imie="";
        int zycie;
        int atak;
        int zloto;
        (imie,zycie,atak,zloto)=tworzeniePostaci();
        (zycie,atak,zloto)=adminConsole();
        wyswietlStatystyki(imie,zycie,atak,zloto);
        waitClearScreen();
        enemyEncounter(imie,zycie,atak,zloto,"Goblin",10,5,3);
    }
}