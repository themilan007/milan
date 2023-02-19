﻿//1. óra, összegzés
//-----------------------



/*
/* ez egy  komment ami csak neked információ, nem csinál vele semmita program (skippeli) */

/* ez ugyanolyan komment. De amiért izgalmas
ez több sort is ismer, amíg nem zárod le
addig tudsz gépelni bele */

/* 
 EZ IS AZ
 Fontos, hogy ha több program kód füled van, mint ahogy tanuláskor is többet hozunk létre
a C# MS Visual Basic hibát fog dobni, mert bezavar a másik fülön levő kód.
Ezért ha valamiket ki akarsz zárni (régi kódok), akkor a teljes kódot ilyen "komment" közé tudod
illeszteni, onnantól nem törölted, de nem is fog futni. Én az első sor elé RETURN-t teszek
úgy kezdem, és az utolsó sor mögé is RETURN-t teszek, azzal jobban átlátom, és nem az írt kód
részeként látja a szemem, könnyebben találom meg, mint itt is látható.

Hagyhatsz benne üres helyet, mint itt felül egy üres sor. NE FELEJTSD EL LEZÁRNI SEM. 
*/

// van ilyen komment is, ez csak egy sorba írt szöveget képes kihagyni, ne hazsnáld több sorra

//hacsak nem így
// használod több sorra
// ennek a sor vége a vége, nem kell jelezni a programnak, hogy zárja le

// azért is jó, mert a kódod mögé is oda tudod írni, hogy ott mi történik, nem kell "külön" sor rá


// using System;



// ------------ JÓ TUDNI MIELŐTT NEKIVÁGUK (Visual Studio használt billentyű kombinációk ) ------------------------

// TAB --> elfogadod a listán megjelenő parancsot, amit beír
// CTRL + SPACE --> ha nem dobja fel a javaslatot, ezzel lehet rásegíteni, hogy tegye meg
// CTRL (lenyomva tart), majd K és D egymás után --> beigazítja a sorok formázását szépre, olvashatóra
// CTRL + R --> ha valamelyik változó fölé mész, és ott maradzs, kijelöli az összes hasonlót, ezzel tudsz átnevezni egyszerre mindent ????
// for begépelése után TAB-TAB (gyors), elvileg behozza az egész struktúráját, csak át kell írnunk, ahogy nekünk tetszik (máshol is?)




// ------------ TANANYAG (KEZDETEK) ------------------------

/*

Console.WriteLine ("Hello World"); // itt pl. a kód mögött hazsnálom, egysoros


Console.WriteLine ("Szia, ez az első programom"); // A Console-re (monitorra) dolgozom; A "." jelenti, hogy utána mit csinálok a konzolon
// a Writeline - sor kiírása, mindíg ( )-ek közé kerül, amit i akarok íratni, és utána kötelező a ";" ami a parancs végét jelzi
// ha sima szöveget akarok kiíratni, akkor a zárójelen belül ezt jelzem aprogramnak, hogy " " közé teszem



int n1 = 42; //az INT egy változó (egész szám), aminek értéket adhatsz. az "n1" itt a neve, de bármi lehet a név = számérték. ";" a végére
Console.WriteLine(n1); // itt az látszik, hogy ha (idézőjel nélkül) megadom az feljebb értéket kapott változót, akkor annak "tartalmát" adja

n1 = 36; // amíg az int-tel létrehozzuk a változót (n1) utána már nem kell int, ha az n-nek meg akarom változtatni az értékét, pl. 36-ra
Console.WriteLine(n1); // kiírom az új számot



int n2; // lehet így is. Először létrehozom az "n2"-t (deklarálás a neve)
n2 = -38; // utána adok neki értéket (definíció). Bármilyen plusz, mínusz, egész szám, nulla is lehet


int n3 = 3, n4 = 2, n5 = 36; // megadhatod előre, sorban is a változóid. Ilyenkor a változók kzött vessző, majd a végén a szokásos ";" van


int n6, n7, n8; // többet hozok létre, lehet így is
n6 = 8; // adok nekik értékeket 
n7 = 9;
n8 = 11;


int matek0 = 3 + 3; // létrehoztuk a matek0-t és egyből számoltatuk, 2 számmal
int matek1 = n3 + 2; // számoltatunk számmal és a változóban levő értékkel (ami szám)
int matek2 = n5 + n2 + n6 * (n8 - n7) / n4; // számoltatunk csak változókkal. MATEK SORREND! (itt: zárójel, majd szorzás, osztás és összeadás)

Console.WriteLine(matek0); //kiíratom, hogy lássuk az eredményeket
Console.WriteLine(matek1);
Console.WriteLine(matek2);

int matek4 = 10 / 3; // mivel INT csak egész számokat ír ki, nem tudjuk, mi a maradék, vág (nem kerekít, csak vág)
int matek5 = 10 % 3; // ez a MODULO jele, a fentihez képest meg csak a maradékot adja vissza


int matek6; // ez a szokásos. Először létrehozom
matek6 = n3 + 2; // aztán számolok, a képlet végeredménye az érték

Console.WriteLine(matek4);
Console.WriteLine(matek5);


matek6 = matek6 + 3; // itt a "matek6" kap új értéket. Mi ez? Vedd a mostani értékedet és adj hozzá 3-mat, legyen ez az új értéked
matek6 += 3; // ugyanaz rövidítve: matek6! adódj össze ("+=") egy másik értékkel, az legyan az új értéke.
// ez mind +, -, *, /, % esetében is működik

matek6 = matek6++; // nem azt írom ki, hogy "változóneve" + 1, hanem ha csak eggyel növelek, akkor elég a "++" ami eggyel növeli az értékét
matek6 = matek6--; // egyet kivonok belőle. (ez a kettő ilyen létezik)


Console.ReadLine(); //ez a sor így változó és más nélkül arra jó, hogy megállítsd a képernyőt ha kell (nyomnod kell Return-t a továbbhoz


// ------------------------------------------------------------------------------- 
// -----------------------------KÖVETKEZŐ PONT -----------------------------------
// ------------------------------------------------------------------------------- 

// TÖRTEK

float m1 = 55.33f; // 32 biten ábrázol, kevesebb hosszt tud mutatni. a "float" a tizedesek jelentése. ez IS változó, mint az INT. 
m1 = 55.56f; // az "f" kell a végére, hogy értse, hogy ő tört. Ugyanúgy létrehozás után változtatgathatjuk az értéket.
// azért float amit használunk, mert UNITY majd ezt tudja. Programozásban, simán lehet a másikat (az a "default" ott)

double m2 = 55.77; // 64 biten ábrázol, ugyanaz, mint fent, csak hosszabba az érték, és nem kel mögé az "f" (ELLENŐRIZNI IGAZ-E) 


double m3 = m1 + m2; // megpróbálom a kettőt összeadni, double értéken (EZ NEM VOLT TANANYAG, CSAK TESZ)
Console.WriteLine(m3);



// KASZTOLÁS: TÖRT-EGÉSZ DE-ODA ALAKÍTGATÁSA

int m4 = 13; // ez nem lényeges, csak a bemutatóhoz van. legyen min megmutatni majd

int m5 = (int)m1; // explicit kasztolás. Létrehozom az "m5" változót, ami értéke az 'm1" nem egész szám, de ezzel a módszerrel az lesz (levág)
float m6 = m4; // implicit kasztolás. Létrehozok egy "m6" float típusú változót, és beleteszem az "m4" értékét. Innen: M4 - int, M6-float típus 
// bár a float itt (még) egész szám, de ha elkezdek vele dolgozni, már tud majd nem egész szám lenni. Ha INT formátumban van, ilyet nem tud



// SZÖVEGBŐL IS LEHET SZÁM, CSAK HA NINCS BENNE BETŰ A KÉPERNYŐN, CSAK SZÁMOK SOKASÁGA

string adat00 = "67"; // ez a szövegünk, mivel string volt
int m00 = int.Parse(adat00); // létrehozunk egy "m00" integer típusú változót, belepakoljuk az INT változót ("adat00"), de "parsoljuk" számmá
Console.WriteLine(m00);


// -------------------------------------------------------------------------------


// SZÖVEG

string adat1 = "Helló!"; // ugyanúgy változó, de mivel szöveget vár, azt idézőjellel adju mindíg.
string adat2 = "Csaba vagyok"; // lehet több szó, vagy mondat is benne

string adat3 = "Szeva, " + "Szia, "; // összefűztem a kettő szöveget egy szöveggé
string adat4 = adat3 + adat1 + " " + adat2; // stringek összefűzése, de kellett egy üres (elválasztó) hely, tettem bele egy space-t így " "

Console.WriteLine(adat4); // kiírom az "adat3" változó szöveges értékét. Ha szöveget direktben írnék, kellene a " ", de így nem, mert érti


// BÁRMI SZÖVEGGÉ ALAKÍTHATÓ ÍGY

int egyszám = 48;
string adat5 = egyszám.ToString(); // létrehozom az "adat5-öt" és beletszem az "egyszam" értékét, de közben .ToString()-gel átalakítom szöveggé

string adat6 = adat4 + ", " + adat5; // egybegyúrom a fenti, már összevágott szöveget, egy vesszőt és a koromat
Console.WriteLine(adat6); // kiíratom a fenti, már összevágott szöveget, egy vesszőt és a koromat


// info: azért fontos szöveggé alakítanunk mindent, mert a játék csak szövegeket jelenít meg, számot nem (az is csak szöveg, amit látunk)


// ---------------------------------------------------------------------------------


// LOGIKAI (IGAZ-HAMIS esetekhez) ÉS KISEBB, NAGYOBB, EGYENLŐ....

int m7 = 3, m8 = 7; // megadunk két számot


//igaz - hamis esetek a fenti két számra, alább. Egyben a nagyobb, kisebb és egyéb feltételeket is itt tanuljuk (
bool bol003 = m7 == m8; //false (egyenlő - az egyenlő vizsgálat esetén 2 db "==" mert különben más kódnak értelmezné, mint a változóknál...)
bool bol004 = m7 > m8; // false (nagyobb)
bool bol005 = m7 < m8; // true (kisebb)
bool bol006 = m7 >= m8; // false (nagyobb vagy egyenlő, megcserélve a két jelent nem működik)
bool bol007 = m7 <= m8; // true (kisebb vagy egyenlő, megcserélve a két jelent nem működik)
bool bol008 = m7 != m8; // nem egyenlő. A "!" az ellentét / fordított eset állítására szolgál

bool bol009 = m7 > 3; // false
bool bol010 = m7 >= 3; // true

// mindegyik kiírása + elválasztó jel
Console.WriteLine(bol003 + "|" + bol004 + "|" + bol005 + "|" + bol006 + "|" + bol007 + "|" + bol008 + "|" + bol009 + "|" + bol010); 


// az igaz-hamis mehet szövegre is, ott két eset van.
string adat12 = "Alma", adat13 = "Körte";

bool bol011 = adat12 == adat13; // false (a kettő gyanaz)
bool bol012 = adat12 != adat13; // true (a kettő nem ugyanaz)

Console.WriteLine(bol003 + "|" + bol004); // ezt is kiírjuk, le lehessen ellenőrizni


// ---------------------------------------------------------------------------------

// ÉS/VAGY LEHETŐSÉGEK --> PÉLDÁK (tudsz-e lőni --> tudsz-e duplát ugrani --> kimehetek a levegőre? 

int ammo = 7;
bool HaveAmmo = ammo > 0;
bool HaveWeapon = true;
bool CanShoot = HaveWeapon && HaveAmmo; // az "&&" = ÉS (mindkettőnek teljesülnie kell, különben nem lehetséges (ITT IGAZ)

int airjumpcount = 0;
bool canJumpinnnair = airjumpcount > 0;
bool grounded = true;
bool canjump = grounded || canJumpinnnair; // az "||" = VAGY (ha egyik teljesül, akkor a válasz igen, tudsz duplaugrást (ITT HAMIS)

bool isLegBroken = false;
bool isRaining = true;
bool cantGoOut = isLegBroken|| isRaining; // VAGY állapot, mivel esik, nem tudok kimenni
bool cangoout = !cantGoOut; // vagy bool canGoOut = !(isLegBroken|| isRaining); > itt a "cangoout" állapota a "cantogoout" fordítottja

// figyelni kell, mert ha csak egy karaktert elírsz, vagy nagybetű helyett kisbetűt írsz, már más változót keres a rendszer!!!!



// ---------------------------------------------------------------------------------



// ADAT BEÍRÁSA KÉPERNYŐN

Console.WriteLine("Írj be egy szöveget:"); // kiírjuk, hogy kérünk szöveget
string adat7 = Console.ReadLine(); // letároljuk a szöveget. A "Console.ReadLine();" az, ami majd várja a beírást

Console.WriteLine("Írj be egy számot:"); // kérünk számot
string adat8 = Console.ReadLine(); // letároljuk a szöveget (ilyenkor a szám is egy szöveg, csak számot adj meg)
int m10 = int.Parse(adat8); // ilyenkor jön jól a "parse", hogy bekonvertáljuk a szövegként érkező adatot számmá

// FIGYELEM! Ha alul sárga háromszög warning van, "..null literal..non nullable.. szöveggel azt jelenti: rossz adat bevitel esetén lehet gond
// ez még nem probléma, a piros error a gond az "előrelátható" hibákból. Ha egyben látjuk a "possible null reference argument..." sárha hibát
// az viszont azt jeleti, hogy az esetleges rossz beolvasást tovább használjuk, amikor dolzunk vele (fent ez a "parse")


Console.Write("NÉV: "); // A ".writeline" kiír, és a kurzort egy sorral lejjeb "dobja". A ".write" esetén meg ugyanabba a sorba írhatsz! 
string adat9 = Console.ReadLine();


// ------------------------------------------------------------------------------- 
// -----------------------------KÖVETKEZŐ PONT -----------------------------------
// ------------------------------------------------------------------------------- 


// MATEMATKA SZÁMOLÓS PÉLDA:


Console.WriteLine("Írj be egy számot!");
string adat10 = Console.ReadLine();

Console.WriteLine("Írj be egy másik számot");
string adat11 = Console.ReadLine();

int m11 = int.Parse(adat10); //szövegből szám, mindíg kell, ha számolni akarunk vele
int m12 = int.Parse(adat11); //szövegből szám, mindíg kell, ha számolni akarunk vele

int summa = m11 + m12;
int difference = m11 - m12;
int product = m11 * m12 ;
float quotient = (float) m11 / m12;

Console.WriteLine("Összeg: " + summa);
Console.WriteLine("Különbség: " + difference);
Console.WriteLine("Szorzat: " + product);
Console.WriteLine("Hányados: " + quotient);


// ------------------------------------------------------------------------------- 
// -----------------------------KÖVETKEZŐ PONT -----------------------------------
// ------------------------------------------------------------------------------- 


//VEZÉRLÉSI SZERKEZETEK ( if-else / elseif-...-elseif-else) / while)


int number = 10; // bármilyen számot adhatsz, akár beolvashatsz is, csak ne felejtsd el szövegből számmá alakítan
bool isEven; //Páros-e boolean (igen/nem) változó létrehozás
isEven = number % 2 == 0; // valami akkor páros, ha osztható kettővel

if (isEven) // struktúrája: if (ha) "( )"-között a vizsgálandó elem, majd egy új sorba, amit itt tenni akarunk ha igaz "{ }" mindíg kapcsos!
{
    Console.WriteLine("PÁROS"); // ide sorban egymás alá, beljebb és egymás alatt írva (olvashatóság miatt) minden, amit igen esetén végezzen el
}
else // struktúrája: else, majd egy új sorba, amit itt tenni akarunk ha hamis a fenti állítás "{ }" mindíg kapcsos!
{
    Console.WriteLine("PÁRATLAN"); // ugyanúgy sorban egymás alá, mit csináljon a nem esetén
}
// ez a két utasítás ide tartozik, figyeljünk a közös hazsnálatra. Itt nincs ";" csak a kapcsols zárójelen belüli dolgokra. A "{ }" váltja ki
// egy sorba is írhatnánk az egészet: if (..) { utasítások; utasítások;} de nem olvasható jól. Ha esetén azt történik, ami a"{ }" között van
// ha "elromlik a formázásunk: tartsuk nyomva a CTRL-t, majd egymás után nyomjuk le a K és D gombot, akkor berendezi szép formára



// Persze, lehet ezt (páros-páratlan) máshogy is vizsgálni:

string pairity; // létrehzok egy új változót
if (isEven) // Ha a fenti "isEven" igaz, akkor a "pairity"-be beírom, hogy páros 
{
    pairity = ("PÁROS");
}
else // Ha a fenti "isEven" hamis, akkor a "pairity"-be beírom, hogy páratlan 
{
    pairity = ("PÁRATLAN");
}
Console.WriteLine(pairity); // végül kiírom



// hogyan lehet még egyszerűbben? egy sorban csinálom meg azt, amit fent több sorban.
string pairity2 = isEven ? "PÁROS" : "PÁRATLAN"; //  Ezt nevezzük feltételes operéátornak. 3 bemenete van.



// ie-elseif-else használata: nulla, pozitív, negatív megállapításra

if (number > 0) // ha
{
    Console.WriteLine("POZITÍV");
}
else if (number < 0) // más esetben ha (ebből akár sok is lehet egymás után,ha követjük a szükséges struktúrát, vigyázunk a kapcsols zárójelekre
{
    Console.WriteLine("NEGATÍv");
}
else
{
    Console.WriteLine("NULLA");
}


// ------------------------------------CIKLUS (WHILE)

int m15 = 0;
while (m15 < 10) // while = amíg; amíg nem teljesül egy, a ( )-ben megadott valmai, addig a kapcsols zárójelek utasításait ismételgesse 
{
        Console.WriteLine(m15);
    m15++; // m15 = m15 + 1;  RETTENETESEN FONTOS: a while esetében eljussunk egy olyan pontig, ahol teljesül a feltétel. Különben végtelen a ciklus!
}



// ----------------------------- SWITCH (nem hazsnáljuk, de olvass utána)
// arról szól, hogy egy adott feltétel esetében a feltételre rátalálva CSAK az arra vonatkozó ködrészlet fog megfutni, a többi nem
// hasonlóan kapcsols zárójeles, mint a többi fent, ; hazsnálat is hasonló

Console.WriteLine("Hétfő, kedd, vagy szerda a jobb nap? Add meg számmal (1-3): ");
string adat15 = Console.ReadLine();

int m16 = int.Parse(adat15); //szövegből szám, mindíg kell, ha számolni akarunk vele

switch (m16) // itt adjuk meg a switch-nek a bekért számot, legyen az a paraméter, ami alapján a lenti kód blokkok között keres és futtat
{
    case 1: // első eset
        Console.WriteLine("Hétfő a jobb nap"); // első esetben fusson ez
        break; // nem kötelező, de a break jó, mert ha megvan a case, aminél futnia kell, a többin ne fusson meg (ott már úgysem csinál semmit)

    case 2:
        Console.WriteLine("Kedd a jobb nap"); 
        break;

    case 3:
        Console.WriteLine("Szerda a jobb nap"); 
        break;
}


// ------------------------------------------------------------------------------- 
// -----------------------------KÖVETKEZŐ PONT -----------------------------------
// ------------------------------------------------------------------------------- 


//----------------------- GYAKORLÓ PÉLDÁK


// irjuk ki az elso 10 olyan szamot, ami oszthato 3-mal ( fent sajat. lent 2 megoldas)

// a trükk, hogy megyünk 10 olyan számig, ami 3-mal osztható, de ha úgy csináljuk, hogy pl: 1*3... 2*3... 3*3... 4*3 az a megoldást adja
// mert 1*3 = 3, az első ilyen szám. 2*3 =6, a második ilyen szám, 3*3= a harmadik ilyen szám... stb. gyakorlatilag nem vizsgáljuk, hanem
// ha sorba megyünk 10-ig az biztosan telejsíti ezt a kérést

int m17 = 1; //innen indulunk
while (m17 <= 10) // fusson addíg, amíg kevesebb, vagy egyenő 10-zal (ahány ilyet ki kell íratnuk)
{
    Console.WriteLine(m17 * 3); // írassuk ki az épp aktuális számot
    m17++; // egyel növeljük a számot, hogy a következő "kör"-ben már 2..3..4.. stb legyen majd az érték. HA NEM CSINÁLJUK = végtelen ciklus!
}



// másik megoldás: az első ilyen szám a 3; tudjuk, hogy 10 ilyen szám kel nekünk, vagyis 10*3 a vége, amíg mennünk kell


int m18 = 3; // első szám
while (m18 <= (3* 10)) // amíg a változó értéke nem lesz 3*10 (keresett szám * alkalom, ahányszor futnia kell), addíg fusson újra és újra 
{
    Console.WriteLine(m18); // kiíratom a számot. Azért nem a szám nevelés után, mert akkor az első szám már a 6 lenne
    m18 += 3; // növelem hárommal. Azért a kiíratás után, amit felül már írtunk
}



// ------------------------------- FOR HASZNÁLAT -------------------------------------- 


// harmadik megoldás, FOR-ral - valmennyivel rövidebb


for (int m19 = 1; m19 <= 10; m19++) // megadjuk a kezdő értéket, amíg az kevesebb vagy egyenő 10, fusson a FOR, növeljük eggyel mindan alk.
{
    Console.WriteLine(m19 * 3); // egyszerűen beszorozzuk itt hárommal 
}




// MÁSIK GYAKORLÁS szorzótáblát készítünk, az 1 x 1 --> 1 x 10 -esekre (erre a számtartományra) 


for (int m20 = 1; m20 <=10; m20++)
{
    Console.WriteLine(m20 + " x 1 = " + m20);
}


for (int x = 1; x <= 10; x++)
{
    for (int y = 1; y <= 10; y++)
    {
        Console.WriteLine($"{x} * {y} = {x*y}");
}
}


*/

