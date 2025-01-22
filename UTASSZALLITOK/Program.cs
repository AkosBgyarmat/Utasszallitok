using System.Threading.Channels;

class Sebessegkategoria
{
    private int Utazosebesseg;
    public string Kategorianev
    {
        get
        {
            if (Utazosebesseg < 500) return "Alacsony sebességű";
            else if (Utazosebesseg < 1000) return "Szubszonikus";
            else if (Utazosebesseg < 1200) return "Transzszonikus";
            else return "Szuperszonikus";
        }
    }

    class Repulogep
    {


        public string Tipus { get; set; }
        public int Ev { get; set; }
        public string UtasSzam { get; set; }
        public string Szemelyzet { get; set; }
        public int UtazoSebesseg { get; set; }
        public int FelszalloTomeg { get; set; }
        public string Fesztav { get; set; }

        public Repulogep(string tipus, int ev, string utasSzam, string szemelyzet, int utazoSebesseg, int felszalloTomeg, string fesztav)
        {
            Tipus = tipus;
            Ev = ev;
            UtasSzam = utasSzam;
            Szemelyzet = szemelyzet;
            UtazoSebesseg = utazoSebesseg;
            FelszalloTomeg = felszalloTomeg;
            Fesztav = fesztav;
        }

    }


    static void Main()
    {
        string filepath = "C:\\Users\\ny20Bhornyáká\\source\\repos\\Utasszallitok\\Utasszallitok\\UTASSZALLITOK\\utasszallitok.txt";

        List<Repulogep> repulogepLista = new List<Repulogep>();

        string[] sorok = File.ReadAllLines(filepath);

        for (int i = 1; i < sorok.Length; i++)
        {
            string[] mezok = sorok[i].Split(";");

            string tipus = mezok[0];
            int ev = int.Parse(mezok[1]);
            string utasSzam = mezok[2];
            string szemelyzet = mezok[3];
            int utazoSebesseg = int.Parse(mezok[4]); 
            int felszalloTomeg = int.Parse(mezok[5]);
            string fesztav = mezok[6];

            Repulogep repulogep = new Repulogep(tipus, ev, utasSzam, szemelyzet, utazoSebesseg,  felszalloTomeg, fesztav);

            repulogepLista.Add(repulogep);
        }



        //4. feladat
        int adatSorok = repulogepLista.Count;
        Console.WriteLine($"4. feladat\nAdatsorok száma: {adatSorok}");

        Console.WriteLine();
        //5. feladat
        Console.WriteLine( );

        int BoeingDarab = repulogepLista.Where(x => x.Tipus.StartsWith("Boeing")).Count();
        Console.WriteLine($"5. feladat\nBoeing típusok száma: {BoeingDarab}");


        Console.WriteLine();
        //6.feladat
        Console.WriteLine("6.feladat");

        Repulogep legtobbUtasRepulogep = null;
        int maxUtas = 0;

        foreach (var repulo in repulogepLista)
        {
            if (repulo.UtasSzam.Contains("-"))
            {
                int aktualisMaxUtas = int.Parse(repulo.UtasSzam.Split('-')[1]);
                if (aktualisMaxUtas > maxUtas)
                {
                    maxUtas = aktualisMaxUtas;
                    legtobbUtasRepulogep = repulo;
                }
            }
        }

        if (legtobbUtasRepulogep != null)
        {
            Console.WriteLine($"A legtöbb utas szállítására alkalmas repülőgép:");
            Console.WriteLine($"Típus: {legtobbUtasRepulogep.Tipus}");
            Console.WriteLine($"Első felszállás: {legtobbUtasRepulogep.Ev}");
            Console.WriteLine($"Utasok száma: {legtobbUtasRepulogep.UtasSzam}");
            Console.WriteLine($"Személyzet: {legtobbUtasRepulogep.Szemelyzet}");
            Console.WriteLine($"Utazósebesség: {legtobbUtasRepulogep.UtazoSebesseg} km/h");
            ;

        }

        Console.WriteLine();
        //7.feladat
        Console.WriteLine();


    }
}