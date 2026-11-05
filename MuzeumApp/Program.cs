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
    if (mezok[0] != "M" && mezok[0] != "F")
    {
        hibasSorokSzama++;
        continue;
    }
}
