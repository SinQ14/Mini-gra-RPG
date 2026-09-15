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
    static (int zycie,int maxzycie,int atak,int zloto) AdminConsole()
    {
        Console.WriteLine();
        Console.WriteLine("--Console--");
        Console.WriteLine("zycie:");
         int zycie = int.Parse(Console.ReadLine() ?? "0");
         int maxzycie = zycie;
        Console.WriteLine("atak:");
        int atak = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("zloto:");
        int zloto = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Nowe statystyki ustawione!");
        return (zycie,maxzycie,atak,zloto);
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
    static (string imie,int zycie,int maxzycie, int atak, int zloto) TworzeniePostaci()
    {
        Console.WriteLine();
        Console.WriteLine("--Tworzenie postaci--");
        Console.WriteLine("Podaj imie bohatera");
        string imie = Console.ReadLine() ?? "";
        int maxzycie = 100;
        int zycie = 100;
        int atak = 10;
        int zloto = 250;
        Console.WriteLine($"Twoja postac to: {imie}");
        return (imie, zycie,maxzycie, atak, zloto);
    }
    static (int zycie,int zloto) EnemyEncounter(string imie, int zycie,int maxzycie, int atak, int zloto,
        string pNazwa, int pHp, int pAtk, int pDef)
    {
        Console.WriteLine();

        Potwor potwor1 = new Potwor( pNazwa, random.Next(pHp - 2, pHp + 3), random.Next(pAtk - 1, pAtk + 2), random.Next(pDef - 1, pDef + 2) );

        Console.WriteLine($"Napotykasz na swojej drodze {potwor1.Nazwa} " + $"o HP:{potwor1.HP}, Ataku:{potwor1.Atak} i Obronie:{potwor1.Obrona}!" );
        Console.WriteLine("Co zrobisz?");

        int ucieczka = 0;

        while (potwor1.HP > 0 && ucieczka == 0)
        {
            Console.WriteLine();
            Console.WriteLine($"Twoje HP: {zycie}");
            Console.WriteLine($"HP potwora: {potwor1.HP}");
            Console.WriteLine("1. Atakuj");
            Console.WriteLine("2. Leczenie");
            Console.WriteLine("3. Uciekaj");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine();

                    int obrazenia = atak + random.Next(-3, 4) - potwor1.Obrona;

                    if (obrazenia < 1)
                    {
                        obrazenia = 1;
                    }
                    potwor1.HP -= obrazenia;
                    Console.WriteLine($"Zadajesz {obrazenia} obrażeń!");
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine();
                    int heal = random.Next(1, 11);
                    zycie += heal;
                    if (zycie > maxzycie)
                    {
                        zycie = maxzycie;
                    }
                    Console.WriteLine($"Uleczyłeś się o {heal} HP!");

                    break;
                
                case ConsoleKey.D3:
                    Console.WriteLine();

                    if (random.Next(1, 11) > 6)
                    {
                        ucieczka = 1;
                        Console.WriteLine("Udało ci się uciec!");
                    }
                    else
                    {
                        Console.WriteLine("Nie udało ci się uciec!");
                    }
                    break;
                
                default:
                    Console.WriteLine();
                    Console.WriteLine("Podaj poprawny wybór!");
                    break;
            }
            zycie -= potwor1.Atak + random.Next(-3, 4);
            Console.WriteLine($"{potwor1.Nazwa} zadaje ci {potwor1.Atak} obrazen!");
        }

        if (potwor1.HP <= 0)
        {
            Console.WriteLine();
            Console.WriteLine($"Pokonałeś {potwor1.Nazwa}!");
            int tempzloto = random.Next(10, 28);
            Console.WriteLine($"Otrzymujesz {tempzloto}!");
            zloto += tempzloto;
        }

        return (zycie, zloto);
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
        int maxzycie;
        int atak;
        int zloto;
        (imie,zycie,maxzycie,atak,zloto)=TworzeniePostaci();
        //(zycie,maxzycie,atak,zloto)=AdminConsole();
        WyswietlStatystyki(imie,zycie,atak,zloto);
        WaitClearScreen();
        (zycie,zloto)=EnemyEncounter(imie,zycie,maxzycie,atak,zloto,"Goblin",20,5,3);
        Console.ReadKey();
    }
}