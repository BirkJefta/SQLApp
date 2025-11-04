using Microsoft.IdentityModel.Tokens;
using SQLApp;
using System;

string connectionStringSearch = "Server=BIRKPC;Database=IMDB;User Id=DataReaderIMDB;Password=123456789; TrustServerCertificate=True;"; //kan se views
string connectionStringAdmin = "Server=BIRKPC;Database=IMDB;User Id=AdminIMDB;Password=123456789; TrustServerCertificate=True;"; //kan via stored procedures skrive til databasen, Add movie og name og update en titel

//id på den title der skal opdateres
int testIdTitle = 38496048;

Wildcard wc = new Wildcard();

//string primaryNameInput = null;

//while (string.IsNullOrEmpty(primaryNameInput))
//{
//    Console.WriteLine("Hvad er navnet på den person du vil tilføje ?");
//    primaryNameInput = Console.ReadLine();
//}

//Console.WriteLine("Hvad er fødselsåret?");
//string? birthYearInput = Console.ReadLine();
//short? birthYearParsed;
//if (string.IsNullOrEmpty(birthYearInput))
//{
//    birthYearParsed = null;
//}
//else
//{
//    birthYearParsed = short.Parse(birthYearInput);
//}

//Console.WriteLine("Hvad er dødsår?");
//string? deathYearInput = Console.ReadLine();
//short? deathYearParsed;
//if (!string.IsNullOrEmpty(deathYearInput))
//{
//    deathYearParsed = short.Parse(deathYearInput);
//}
//else
//{
//    deathYearParsed = null;
//}



//Name name = new Name(
//    primaryName: primaryNameInput,
//    birthYear: birthYearParsed,
//    deathYear: deathYearParsed
//);

Console.WriteLine("indtast id på titletype (1-11):");
List<string> types = new List<string>()
        {
            "0: short",
            "1: movie",
            "2: tvShort",
            "3: tvMovie",
            "4: tvEpisode",
            "5: tvSeries",
            "6: tvMiniSeries",
            "7: tvSpecial",
            "8: video",
            "9: videoGame",
            "10: tvPilot"
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
    if (typeIdParsed < 0 || typeIdParsed > 10)
    {
        typeIdInput = null;
        Console.WriteLine("Ugyldigt input. Prøv igen.");
    }
}
typeIdParsed = int.Parse(typeIdInput);








Title title = new Title(
    typeId: typeIdParsed,
    primaryTitle: ,
    originalTitle: ,
    isAdult: ,
    startyear: ,
    endyear: ,
    runtime: 
);

























////synes det var nemmest at lave nye objekter til insert og update, end at skrive direkte i metoderne. for er der to objekter til det.
//Title newmovie = new Title(
//    typeId: 1,
//    primaryTitle: "User Inserted Movie",
//    originalTitle: "User Inserted Original Title",
//    isAdult: false,
//    startyear: 2023,
//    endyear: null,
//    runtime: 95
//);


//Title updatedTitle = new Title(
//    typeId: 1,
//    primaryTitle: "Updated Movie Title ",
//    originalTitle: "Updated Original Title",
//    isAdult: false,
//    startyear: 2024,
//    endyear: null,
//    runtime: 120
//);


////tilføjer en ny name til databasen
//Console.WriteLine("tilføjer ny person");
//wc.AddName(connectionStringAdmin, newName);

////søger efter den nye name i databasen
//Console.WriteLine("søger efter nyindsat person");
//wc.WildcardName(connectionStringSearch, $"User Inserted Name {testIdTitle}");


////tilføjer en ny movie til databasen
//wc.AddMovie(connectionStringAdmin, newmovie);

////søger efter den nye movie i databasen
//Console.WriteLine("skriver user inserted movie som wildcardsøgning for at få nyindsatte film");
//wc.WildcardTitle(connectionStringSearch, "user inserted");

////opdaterer en eksisterende movie i databasen baseret på testIdTitle i toppen
//Console.WriteLine("opdaterer filmen");
//wc.UpdateMovie(connectionStringAdmin, updatedTitle, testIdTitle);

////søger efter den opdaterede movie i databasen
//Console.WriteLine("Søger på opdateret film");
//wc.WildcardTitle(connectionStringSearch, "updated movie t");


////sletter filmen
//Console.WriteLine("sletter den testfilm der blev opdateret");
//wc.DeleteMovie(connectionStringAdmin, testIdTitle);


