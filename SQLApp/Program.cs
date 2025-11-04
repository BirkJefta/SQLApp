using Microsoft.IdentityModel.Tokens;
using SQLApp;
using System;

string connectionStringSearch = "Server=BIRKPC;Database=IMDB;User Id=DataReaderIMDB;Password=123456789; TrustServerCertificate=True;"; //kan se views
string connectionStringAdmin = "Server=BIRKPC;Database=IMDB;User Id=AdminIMDB;Password=123456789; TrustServerCertificate=True;"; //kan via stored procedures skrive til databasen, Add movie og name og update en titel

//id på den title der skal opdateres
int testIdTitle = 38496052;

Wildcard wc = new Wildcard();

string primaryNameInput = null;

while (string.IsNullOrEmpty(primaryNameInput))
{
    Console.WriteLine("Hvad er navnet på den person du vil tilføje ?");
    primaryNameInput = Console.ReadLine();
}

Console.WriteLine("Hvad er fødselsåret?");
string? birthYearInput = Console.ReadLine();
short? birthYearParsed;
if (string.IsNullOrEmpty(birthYearInput))
{
    birthYearParsed = null;
}
else
{
    birthYearParsed = short.Parse(birthYearInput);
}

Console.WriteLine("Hvad er dødsår?");
string? deathYearInput = Console.ReadLine();
short? deathYearParsed;
if (!string.IsNullOrEmpty(deathYearInput))
{
    deathYearParsed = short.Parse(deathYearInput);
}
else
{
    deathYearParsed = null;
}



Name name = new Name(
    primaryName: primaryNameInput,
    birthYear: birthYearParsed,
    deathYear: deathYearParsed
);


Console.WriteLine("Tilføj en ny titel til databasen.");

Console.WriteLine("indtast id på titletype (1-11):");
List<string> types = new List<string>()
        {
            "1: short",
            "2: movie",
            "3: tvShort",
            "4: tvMovie",
            "5: tvEpisode",
            "6: tvSeries",
            "7: tvMiniSeries",
            "8: tvSpecial",
            "9: video",
            "10: videoGame",
            "11: tvPilot"
        };

foreach (var type in types)
{
    Console.WriteLine(type);
}

string typeIdInput = null;
int typeIdParsed;

typeIdInput = Console.ReadLine();
while (typeIdInput.IsNullOrEmpty())
{
    Console.WriteLine("indtast id på titletype (1-11):");
    typeIdInput = Console.ReadLine();
    typeIdParsed = int.Parse(typeIdInput);
    if (typeIdParsed < 1 || typeIdParsed > 11)
    {
        typeIdInput = null;
        Console.WriteLine("Ugyldigt input. Prøv igen.");
    }
}
typeIdParsed = int.Parse(typeIdInput);
Console.WriteLine($"Du har valgt type id: {typeIdParsed}");


string primaryTitle = null;
while (string.IsNullOrWhiteSpace(primaryTitle))
{
    Console.WriteLine("Indtast primary title (må ikke være tom):");
    primaryTitle = Console.ReadLine();
}

Console.WriteLine("Indtast original title:");
string originalTitle = Console.ReadLine();


bool isAdultParsed;
while (true)
{
    Console.WriteLine("Er denne titel for voksne? (true/false):");
    string isAdultInput = Console.ReadLine();

    if (bool.TryParse(isAdultInput, out isAdultParsed))
    {
        break;
    }

    Console.WriteLine("Ugyldigt input. Skriv 'true' eller 'false'.");
}


Console.WriteLine("Indtast startår:");
string? startYearInput = Console.ReadLine();
short? startYearParsed;
if (string.IsNullOrEmpty(startYearInput))
{
    startYearParsed = null;
}
else
{
    startYearParsed = short.Parse(startYearInput);
}


Console.WriteLine("Indtast slutår:");
string? endYearInput = Console.ReadLine();
short? endYearParsed;
if (string.IsNullOrEmpty(endYearInput))
{
    endYearParsed = null;
}
else
{
    endYearParsed = short.Parse(endYearInput);
}


Console.WriteLine("Indtast runtime i minutter:");
string? runtimeInput = Console.ReadLine();
int? runtimeParsed;
if (string.IsNullOrEmpty(runtimeInput))
{
    runtimeParsed = null;
}
else
{
    runtimeParsed = int.Parse(runtimeInput);
}



Title title = new Title(
    typeId: typeIdParsed,
    primaryTitle: primaryTitle,
    originalTitle: originalTitle,
    isAdult: isAdultParsed,
    startyear: startYearParsed ?? default,
    endyear: endYearParsed ?? default,
    runtime: runtimeParsed ?? default
);





// fungerer ligesom med indsæt, men vi hardcoder det her, da det er repetitivt at lave det hele igen
Title updatedTitle = new Title(
    typeId: 2,
    primaryTitle: "opdateretFilm",
    originalTitle: "originalTitle",
    isAdult: true,
    startyear: 2024,
    endyear: 2025,
    runtime: 105
);

//tilføjer en ny name til databasen
Console.WriteLine("tilføjer ny person");
wc.AddName(connectionStringAdmin, name);

//søger efter den nye name i databasen
Console.WriteLine("søger efter nyindsat person");
wc.WildcardName(connectionStringSearch, name.PrimaryName);

//tilføjer en ny movie til databasen
wc.AddMovie(connectionStringAdmin, title);

Console.WriteLine("Indsæt søgeord til titel:");
string? søgeord = Console.ReadLine();
wc.WildcardTitle(connectionStringSearch, søgeord ?? "");

//opdaterer en eksisterende movie i databasen baseret på testidtitle i toppen
Console.WriteLine("opdaterer filmen");
wc.UpdateMovie(connectionStringAdmin, updatedTitle, testIdTitle);

//sletter filmen
Console.WriteLine("sletter den testfilm der blev opdateret");
//wc.DeleteMovie(connectionStringAdmin, testIdTitle);


