using SQLApp;
using System;

string connectionStringSearch = "Server=BIRKPC;Database=IMDB;User Id=DataReaderIMDB;Password=123456789; TrustServerCertificate=True;"; //kan se views
string connectionStringAdmin = "Server=BIRKPC;Database=IMDB;User Id=AdminIMDB;Password=123456789; TrustServerCertificate=True;"; //kan via stored procedures skrive til databasen, Add movie og name og update en titel

//id på den title der skal opdateres
int testIdTitle = 38496041;

Wildcard wc = new Wildcard();


//synes det var nemmest at lave nye objekter til insert og update, end at skrive direkte i metoderne. for er der to objekter til det.
Title newmovie = new Title(
    typeId: 1,
    primaryTitle: "User Inserted Movie",
    originalTitle: "User Inserted Original Title",
    isAdult: false,
    startyear: 2023,
    endyear: null,
    runtime: 95
);


Title updatedTitle = new Title(
    typeId: 1,
    primaryTitle: "Updated Movie Title",
    originalTitle: "Updated Original Title",
    isAdult: false,
    startyear: 2024,
    endyear: null,
    runtime: 120
);
Name newName = new Name(
    primaryName: "User Inserted Name",
    birthYear: 1990,
    deathYear: null
);

//tilføjer en ny name til databasen
wc.AddName(connectionStringAdmin, newName);
//tilføjer en ny movie til databasen
wc.AddMovie(connectionStringAdmin, newmovie);
Console.WriteLine("skriver user inserted movie");
//søger efter den nye movie i databasen
wc.WildcardTitle(connectionStringSearch, "user inserted");
//opdaterer en eksisterende movie i databasen baseret på testIdTitle i toppen
wc.UpdateMovie(connectionStringAdmin, updatedTitle, testIdTitle);
Console.WriteLine("opdateret movie");

Console.WriteLine("skriver opdateret film");
//søger efter den opdaterede movie i databasen
wc.WildcardTitle(connectionStringSearch, "updated mov");
Console.WriteLine("skriver user");
//søger efter den nye name i databasen
wc.WildcardName(connectionStringSearch, "User Inserted");
