Kolibri Könyvtár
================

A szoftver egy Blazor frontenddel megvalósuló webalkalmazás. Az alkalmazás adati adatbázisban tárolódnak, ezért egy SQL Server Management Studio alkalmazás használata ajánlott.  
A program futtatásához szükséges az alábbi .NET moduloknak a telepítése:
> Entity Framework Core  
> Identity Framework  
  
Ezeknek a telepítése a következőképpen történik a Package Managerben:  

_Entity FrameWork Core:_

> Install-Package EntityFramework  

_Identity Framework Core (és SQLServer):_

> Install-Package Microsoft.EntityFrameworkCore.SqlServer

----------
Az adatbázis
------------

Az adatbázis egy MSSQL alapú adatbázisra épül, aminek az elérése a projektben: _(localdb)\MSSQLLocalDB_  

Az adatbázisnak a táblái és rekordjai a Data/ mappán belül találhatóak amik egy modell alapján épülnek fel. Ezen okból egy migrációs fájlt kell generálni, hogy létrejöjjön a tábla az egyes modellekhez.

Ez a következőképpen tehető meg:

***Első lépés:*** dotnet-ef telepítése.

> A NuGet Package Manager-be írjuk be a következő parancsot:  
> _dotnet tool install --global dotnet-ef_

***Második lépés:*** Inicializáljuk a migrációt.

> Szintén a NuGet Package Managerbe írjuk be a következő parancsot:  
> _dotnet-ef migrations add InitDb --project 'Library Project'_

***Harmadik lépés:*** Frissítsük a migrációt.

> A NuGet Package Manager használatával:  
> _dotnet-ef database update --project 'Library Project'_

Ezek után már használhatóvá válik az adatbázis az alkalmazás számára.

----------------------------------------------------------------
Admin Panel
----------------------------------------------------------------

Az admin panel megvalósítása a könnyebb elérhetőség végett Regisztrációt tartalmaz és egy bejelentkezés funkciót. A regisztráció során az Identity FrameWork miatt létrejön a felhasználó amivel utána már szabadon be lehet jelentkezni a felületre.

Fontos, hogy ez csak a könnyebb elérhetőség miatt van. A végleges alkalmazásban mindössze már csak egy Bejelentkezés funkció lesz elérhető, ahova előre megadott admin adatokkal lehet belépni.

Az admin panelen elérhetőek azok a listák, amik az ügyfél előtt jelennek meg ahol a CRUD szabvány szerint szabadon módosítható/bővíthető/törölhető-ek az adatok.

A különböző nevek validációja az adatbázis *Model* fájljából származik, ahol egy RegEx végzi, hogy a név ne tartalmazhasson számot és/vagy speiciális karaktereket.

A Kölcsönzés felvitele esetén figyeli a program, hogy az adott **Tag** már létezik-e az **Tagok** oldal adatbázisában. Ha nem létezik, akkor a kölcsönzés nem fog létrejönni/nem kerül be az adatbázisba.

A könyvnek az ISBN száma ha helytelenül került megadásra, a program automatikusan javítja a már regisztrált könyv szerint.

Ha egy könyvből már nem áll rendelkezésre a könyvkölcsönzés szintén nem fog létrejönni.

A kölcsönzés során a könyv címének könnyű hozzárendelése érdekében egy dropdown menü kilistázza az eddig összes felvitt könyv címét.

--------------------
User Panel
-----------------

Itt két menüpont jelenik meg a felhasználó számára:  
Az egyik a Könyvek a másik pedig a Kölcsönzés lekérése.

A Könyvek menüpont alatt látható, hogy milyen könyvek érhetőek el éppen kölcsönzésre. A Könyvek kölcsönezhetősége attól függ, hogy az adott könyvből mennyi áll rendelkezésre jelenleg. Minden új kölcsönzés során az adott könyv száma mindig csökken egyel, amíg már az nem kölcsönözhető, azaz 0 darab lesz belőle.

A Kölcsönzéseim menüpont alatt láthatóak a különböző kölcsönzések és a kereső segítségével a saját nevére az ügyfél rákereshet, hogy milyen kölcsönzések vannak hozzárendelve valamint a visszaviteli időpontot.