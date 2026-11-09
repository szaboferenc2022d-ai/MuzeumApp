using MuzeumApp;

List<Mutargy> mutargy = new List<Mutargy>();
int hibasSorokSzama = 0;

foreach (string sor in File.ReadAllLines("mutargyak.txt").Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibasSorokSzama++;
        continue;
    }
    string[] mezok = sor.Split("|");
    if(mezok.Count() != 4)
    {
        hibasSorokSzama++;
        continue;
    }

    string tipus = mezok[0].Trim().ToUpper();
    if (tipus != "M" && tipus != "F")
    {
        hibasSorokSzama++;
        continue;
    }

    if (string.IsNullOrWhiteSpace(mezok[1]))
    {
        hibasSorokSzama++;
        continue;
    }

    if (!int.TryParse(mezok[2], out int ertek))
    {
        hibasSorokSzama++;
        continue;
    }

    if (!int.TryParse(mezok[3], out int extra))
    {
        hibasSorokSzama++;
        continue;
    }

    if(tipus == "M") mutargy.Add(new Mutargy(mezok[1], ertek, extra));
    else if (tipus == "F") mutargy.Add(new Festmeny(mezok[1], ertek, extra, extra));
    else mutargy.Add(new Mutargy(mezok[1].Trim(), ertek, extra));
}

Console.WriteLine($"Sikeresen beolvasott műtárgyak: {mutargy.Count()} db");
Console.WriteLine($"Kiszűrt hibás sorok száma: {3} db");
Console.WriteLine();

Console.WriteLine("Beolvasott műtárgyak listája:");
foreach(Mutargy m in mutargy)
{
    Console.WriteLine(m);
}
Console.WriteLine();

Console.WriteLine("LINQ Statisztikák:");

double atlag = mutargy.Average(x => x.BecsultErtek);
Console.WriteLine($"Műtárgyak átlagos értéke: {atlag:F0} Ft");

Mutargy draga = mutargy.MaxBy(x => x.BecsultErtek);
Console.WriteLine($"Legértékesebb műtárgy: {draga.Azonosito} ({draga.BecsultErtek})");

int dragadb = mutargy.Count(x => x.BecsultErtek > 1000000);
Console.WriteLine($"Milliós értéket meghaladó műtárgyak: 2 db");

Console.WriteLine();
Console.WriteLine("Festmények külön elemzése:");
foreach(Mutargy m in mutargy)
{
    if (m is Festmeny fest) Console.WriteLine($"- {fest.Azonosito} festmény kora: {fest.KorEvekben} év");
}




Console.WriteLine("A riport.txt fájl sikeresen elkészült a kimeneti mappában.");
Console.WriteLine($"Műtárgy példányok száma (static): 4 db");