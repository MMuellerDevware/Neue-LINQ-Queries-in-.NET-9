// CountBy()
var Patienten = new List<Patient>()
{
        new Patient("Hans", 1),
        new Patient("Sarah", 2),
        new Patient("Kai", 3),
        new Patient("Wurst", 4),
        new Patient("Hans", 5),
        new Patient("Sarah", 6),
};

var pflegerUeberlastung = Patienten.CountBy(p => p.Pfleger).Where(x => x.Value > 1);

foreach (var (pfleger, anzahl) in pflegerUeberlastung)
{
    Console.WriteLine($"{pfleger} hat {anzahl} Patienten");
}

Console.ReadLine();


// AggregateBy()
var Stationen = new List<Station>()
{
        new Station("Notaufnahme", 39),
        new Station("Radiologie", 10),
        new Station("Chirurgie", 14),
        new Station("Intensivstation", 38),
        new Station("Neurologie", 4),
};

var belegteIntensivbetten = Stationen.AggregateBy(keySelector: station => station.StationsName.Contains("Notaufnahme") || station.StationsName.Contains("Intensivstation"),
                                          seed: 0,
                                          (belegteBetten, curr) => belegteBetten + curr.BelegteBetten)
                                         .First(x => x.Key)
                                         .Value;


Console.WriteLine($"Belegte Betten im Intensivbereich: {belegteIntensivbetten}");

Console.ReadLine();

record Patient(string Pfleger, int PatientenNummer);
record Station(string StationsName, int BelegteBetten);