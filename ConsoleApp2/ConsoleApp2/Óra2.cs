﻿/*

//ISMÉTLÉS ÉS KIEGÉSZÍTÉS, 1. ÓRA
//-----------------------------------------------------------------------


// int u = feltétel ? 5 : 0; // ha egy feltétel igez, az első, ha nem, akkor a második ( 3 inputja van) ez a "?" és ":" használata
// mint első órán vettük: string pairity2 = isEven ? "PÁROS" : "PÁRATLAN"; //  Ezt nevezzük feltételes operéátornak. 3 bemenete van.



Console.WriteLine(15 + " *");
Console.WriteLine(15.ToString() + " *");
Console.WriteLine($"{15} *");
// ?: operátor - feltételes operátor
// ez kb. mind ugyanaz lesz. A harmadiknál a "$" jel azt jelenti, hoyg vegye a "{}" zárójel közötti számot, vagy matematikai műveletet
// és zárójelen beül matematikai elemként. de megjelenítésben egyből szövegként kezelje. Ilyenkor MINDEN összesen egy "...." sorban van!!!!


//-------------------------------------------------------------------------


// Írj egy olyan programot, ami bekér számokat, és kiszámolja az összes átlagát. Az utolsó nem-szám, amit beírsz, onnan tudja, hogy vége

bool runLoop = true; //megadjuk, hogy a "runLoop" legyen igaz
int summa = 0; // kívül adunk értéket, hogy ne csak belül (ciklusban) létezzen
int numberCount = 0; // szintén

while (runLoop) // amíg igaz...
{
    string line = Console.ReadLine(); // olvass be egy új számot

    bool success = int.TryParse(line, out int number);  //lehetne csak parse, de: tryparse boolean lesz, 2 kimenet, az egyik az out, ha sikeres
                                                        // ha sikeres a "line" parsolása INT-ként, akkor OUT-na tegye be INT numberbe
                                                        // ha nem sikeres tovább lép...
    if (success)  // ha a fenti sikeres volt...
    {
        summa += number; // adja a szummához a number INT értéket.
        numberCount++; // számolja, hány beadott számnál tartunk
    }

    else // ha a fenti nem volt sikeres...
    {
        // runLoop= false; - megadhatjuk ezt is, vagyis több kört nem fog futni a program, megy tovább 
        break;  //vagy ezzel a módszerrel. Ilyenkor nem állítgatunk semmit, megmondju, hogy itt kiléphet a ciklusból
    }
}

float mean = (float)summa / numberCount;                 // mvel akár tizedes is lehet a vége, áttérünk float-ra. ahol az átéag (középérték) az 
                                                         // összeg osztva hányszor futtatott
Console.WriteLine($"az eredmény: {mean}"); // kiírjuk


//-------------------------------------------------------------------------


// Sok olyan "math. ..." előre elkészített elem van, amit mi is leprogramozhatnánk, de megtették helyettünk..
// pl alább:

double pi = Math.PI; // lehetne float pi = (float)Math.PI, mivel a math PI egy double érték, a hosszabb verzió miatt inkább double-t írtunk

const float pi2 = 3.14f; //blokkoljuk a változót, ez a konstans (CONST), innentől nem tudja semmi felülírni, nem tud új értéket kapni!

double sqrt = Math.Sqrt(56); // gyök számítás (négyzetgyők)
double sq = Math.Pow(5, 1 / 6f); // gyök a sokadiknál. Nagyon hasonlít a lenti POW-hot, de az egész szám = az X-ediken, a tört (x/6f) a gyökvonás
double vals = Math.Pow(5, 6); // a vals változó értéke, 5 az n-ediken (itt hatodikon)




//......................................EGYÉB MATEMATIKAI MŰVELETEK.................................


double a = Math.Pow(2, 6); //kettő a hatodikon, azaz 
double aa = Math.Sqrt(9); // kilenc négyzetgyöke, azaz 3

float number1 = 12.544f; // ezt itt a példa miatt adjuk csak meg, más oka nincs

float b = Math.Abs(12.4f); // ABS - abszolút rövidítése (ha a szám negatív, visszaadja a pozitívat) az értéket cserélhetjük
                           // "number1"-re is amit fent megadtunk, mint idáig máshol is, működik (működnek) már létező változóval

float e = Math.Sign(-10); //Előjel függvény (szintén "number1" is lehet, kaphat változót is értékként, ahogy a többi)
Console.WriteLine(e);     // az "e"  azért, mert negatív az előjel, a MATH.SIGN értéke "-1" lesz. Ha plusz lenne, akkor simán "1"


float c = Math.Max(7, 4); // kiadja a nagyobbik értéket
float d = Math.Min(7, 4); // kiadja a kisebbik értéket

double f = Math.Ceiling(45.05); // Plafon - felfelé kerekítés -- 46 lesz
double g = Math.Floor(467.75); // Padló - lefelé kerekítés - 467 lesz
double h = Math.Round(33.6); // Kerekítés (normál kerekítési szabályok)

int k = Math.Clamp(23, 0, 10);  // az első értéket (23) a második kettő (0, 10) közé szorítja be. Mivel a szám csak 0,1,2,3,4,5,6,7,8,9,10
                                // lehet, a 23 így beszorítva 10. float és double is jöhet

int l = Math.Clamp(-20, 0, 10); // 0
int m = Math.Clamp(13, 50, 100); // 50
int n = Math.Clamp(67, 50, 100); // 67 - mert közte van, lehet pontos érték
int o = Math.Clamp(105, 50, 100); // 100



//......................................METÓDUSOK...2- SZAKASZ-.......................................

// metódus a nagy kategória, ezen belül vannak a függvények és az eljárások is. 

// METÓDUS = olyan ködrészlet, ami önmagában végrehajtható, és meghívható a köd más pontjáról!!!
//           ilyenkor nem ,uszáj a meghívást a metódus kódja után írni, hívható akár előtte is, a program bárhol
//           a ködben tudja mit kell tennie, mintha a matódust egyből ismerné. Akárhányszor hívható, ez a jó benne

//           RUTIN (ROUTINE) = olyan metódus, ami nem ad rögtön vissza semmit (nincs visszatérése). A "VOID" jelzi, hogy ez rutin
//           FÜGGVÉNY (FUNCTION) = van egyből adat, azaz van visszatérése


// metódusokat nagy betüvel, a változókat kis betüvel kezdjük, ez a szokás


// ------------------------------------------------




float a1 = Abs(-13.5f); // ugyanaz, mint fent a math, de magunk is leprogramozhatjuk, előbb futtatjuk, mint ahol a függvény van (136-os sor)
float a2 = Siign(-44); // ezt a tanári Siign után írjuk be, hatni fog rá, metóduskonál ez nem számít, lehet előtte vagy mögötte (193-mas sor)
                       // Unity-n belül mindíg metóduson belül fogunk dolgozni


Mymethod(10); // miért van itt? Azt mutatja, hogy a program akár előbb hívja meg, mint ahol a később található rutint megírtuk (209-es sor)
Mymethod(12); // ugyanaz, csak másik számmal, ez utatja, hogy többször meghívható (209-es sor)



// ------------------------------------------------


//viszonylag egyszerű függvény, 1 bemenet, 1 kimenet
// definiáljuk, majd felsoroljuk a függvényben a paramétereket, sorban. Ebben különbözik a már tanult float "x"; és float "x"=1; -től,
// hogy () - zárójelben további bekérendő értéket adunk meg. ez az oka, hogy a program megérti, ez nem csak egxy sima float lesz, vagy 
// érték, vagy matematikai képklet, hogy a VÁLTOZÓN BELÜL kér egy, vagy több másik változót!!!!

float Abs(float num)            // típus, azonosító, paraméterek  ---> jelzem, hogy a float "ABS" függvény lesz, (float típusú paraméterrel)
{                               // törzs, innen jön a függvényben elvégzendő
    if (num < 0)
        num = -num;   //ha num kisabb nullánál akkor az "-" elójeles. Így itt a -num = minusz * minusz érték, aátforgatod pluszba

    return num;              // ez a visszatérés, 
}

// ez is ugyanaz, csak fenti egyszerűbb
float Abs1(float num1)             // típus, azonosító, paraméterek
{                               // törzs
    float result1 = num1;

    if (num1 < 0)
        result1 = -num1;

    return result1;              // ez a visszatérés, 
}


//   ------------------------------------------------


float Max(float a, float b)  // mint fent, függvény, de 2 paraméterrel, a progi tudja, hogy majd egyszer valahol, valaki meg fogja hívni
{

    if (a < b)
    {
        return b;
    }
    else  // az else ág itt simán kihagyható, (else, {, és } törlés  a "return a;" kiírható, majd a függény kapcsols zárójele zárja
    {
        return a;
    }
}



//   ------------------------------------------------
// float e = Math.Sign(-10); //Előjel függvény (szintén változó is lehet) fent vettük, most megírjuk a sajátot

float szign(float elojelecske)         // sajátmegoldás, nem túl jó
{
    if (elojelecske >= 0)
    {
        elojelecske = 1;
        return elojelecske;
    }
    else
    {
        elojelecske = -1;
        return elojelecske;
    }
}


// Tanári megoldás
float Siign(float num5)
{
    if (num5 < 0)
    {
        return -1;
    }
    return 1;
}

// NAGYON FONTOS, hog a függvény minden lehetséges kimenetre legyen visszatérése. Ha kihagyunk valamit, akkor  fordítási hibát ír, nem fut le

//   ------------------------------------------------

// Method (eljárások - mind VOID-ok, rutinok, függvények bármilyen típusok, pl: INT, BOOL....)
// ugye írtuk, hogy itt nincs a végén érték, nem ad vissza eredményt, de ugyanúgy, bármikor hívható. 
// a program a VOID-ból tudja, hogy ez egy érték nélküli "rutin"

void Mymethod(int n) // létrehozzuk egy (int pareméter)-rel
{
    for (int i = 1; i < n; i++) //számoló rész, az int első értéke 1, de amíg n-nél kisebb, fusson körbe-körbe, és növelje a számláló részt
    {
        Console.WriteLine(i); // simán írja ki a számot, de itt is lehet sok egyebet adni a kapcsols zárójelek között
    }

}

*/