using MuzeumApp;

List<Mutargy> mutargy = new List<Mutargy>();
int hibasSorokSzama = 0;

foreach (string sor in File.ReadAllLines("mutargy.txt").Skip(1))
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

    if(tipus == "M") mutargy.Add(new Mutargy(mezok[1].Trim(), ertek, extra));
    else if (tipus == "F") mutargy.Add(new Festmeny(mezok[1].Trim(), ertek, extra, extra));
    else mutargy.Add(new Mutargy(mezok[1].Trim(), ertek, extra));
}
