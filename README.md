Antaganden och planerade tillägg:
---------------
Möjligheter för konfigurerbara databassträngar, olika beroende på kund.

Implementering av databaslager, inklusive databasmodeller, mapping emellan dessa t.ex. via Entity Framework Core

Hela modulen kan t.ex. leverera som Nuget-paket, så att den enkelt kan integreras i olika applikationer med olika front-end.


Tänkta databastabeller:

Kravspecifikationen beskriver variabelt baspris. För att enkelt kunna konfigurera nya priser både för olika kunder och för olika biltyper, föreslås vi att dessa konfigurationer lagras i en databas. I ett senare skede kan även ett admingränssnitt skapas för att göra uppdateringar för dessa.
En ändring på antingen BasKmPris eller BasDygnHyra skapar en ny rad i databas för specificerat datumintervall och bilkategori.

Om en kund vill ha nya biltyper så läggs de till i denna tabell, och en mappning måste skapas i BilUthyrningKalkylator.cs och BilKategoriEnum.cs
För existerande biltyper som har en annan prissättning kan kolumnerna för basdygnshyra och kilometerpris användas.
Ett förslag för att göra det enklare att variera prissättningen beroende på kund är att ta bort multiplarna från BilUthyrningKalkylator.cs, och istället bygga in dessa multiplar i priserna i BasPris-tabellen. Eventuellt kan då samma formel användas för alla kategorier:
(basDygnsHyra * antalDygn) + (basKmPris * antalKm)
BasKmPris kan sättas till 0 för småbilar.

BilKategori: Tabell för bilkategorier.
-----
BilKategoriId
BilTypEnumId -- För att matcha koden där olika typer har olika beräkningsformler.
Namn -- Kategorins namn
BasKmPris -- Konfigurerbart pris per kilometer.
BasDygnsHyra -- Konfigurerarbar basdygnshyra.
EffectiveDateFrom: Från vilket datum priset gäller.
EffectiveDateTo: Till vilket datum priset gäller (Inget värde beskriver att det gäller framöver)

Uthyrning: Tabell som beskriver uthyrning av en bil till en kund.
-----
UthyrningId
BilId -- För att kunna koppla uthyrningen till en specifik bil, och för att kunna utvidga systemet och se hur många uthyrningar som görs mot en viss bil; och för att kunna se vilka bilar som är tillgängliga.
UserId -- För att kunna koppla uthyrningen till en specifik användare. Bokningsnummer -- Unikt ID för bokningen som ges till användaren.
DatumTidpunktUtlamning 
DatumTidpunktInlamning 
AktuellMatarstallningUthyrning -- Läses av från bilen vid uthyrning
AktuellMatarstallningInlamning -- Läses av från bilen vid återlämning.
BeraknatPrisUthyrning -- Beräknas vid återlämning av bil.

Bil: Tabell som beskriver en bil
-----
BilId
RegistrationsNummer
BilKategoriId

Föreslagen utvidgning - en tabell för användare - så att vi kan ha en användare som kan logga in (t.ex. vanlig login eller med Bank ID om vi implementerar det) och sedan ha en sida med information om pågående och avslutade uthyrningar.
User: Tabell som beskriver en användare.
-----
UserId
PersonNummer
Losenord
Anvandarnamn
Email
Adress
PostNummer