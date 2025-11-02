using SQLApp;
using System;

string connectionStringSearch = "Server=BIRKPC;Database=IMDB;User Id=DataReaderIMDB;Password=123456789; TrustServerCertificate=True;"; //kan se views
string connectionStringAdmin = "Server=BIRKPC;Database=IMDB;User Id=AdminIMDB;Password=123456789; TrustServerCertificate=True;"; //kan via stored procedures skrive til databasen, Add movie og name og update en titel

int testIdTitle = 38496041;
int testIdName = 21954875;

Wildcard wc = new Wildcard();


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

wc.AddName(connectionStringAdmin, newName);

wc.AddMovie(connectionStringAdmin, newmovie);
Console.WriteLine("skriver user inserted movie");

wc.WildcardTitle(connectionStringSearch, "user inserted");
wc.UpdateMovie(connectionStringAdmin, updatedTitle, testIdTitle);
Console.WriteLine("opdateret movie");

Console.WriteLine("skriver opdateret film");
wc.WildcardTitle(connectionStringSearch, "updated mov");
Console.WriteLine("skriver user");
wc.WildcardName(connectionStringSearch, "User Inserted");
