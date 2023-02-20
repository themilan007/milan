/*


// Létrehozás Unity-ben
// assets - create - c# scipt  --> megnyitja a VS-t

// de ehhez be kell kötni Unity-n belül
// unity work
// edit - preferences - external tools - 	external scipt editor - ms visual studioo
// ha nincs ott:  windows, package manager - Package in projekt helyett unity manager - visual studio editor kell, nem a code editor


// --------------------------- FONTOS, INDULÁS ELŐTT ------------------------------------------
// NEM SZABAD A UNITY SCRIPT NEVE ÉS OSZTÁLY NEVE KÜLÖNBÖZZÖN (KIS-NAGY BETŰRE PONTOSAN KELL)!!

// a kész scriptet el kell menteni (CTRL+S), mielőtt vidsdzslépünk Unity-be, utána a futtatás gomb és megjelenik bent a console fülön
// Create Empty (game object) -csak behúzom rá a scriptet, így kötöm be

// Ha Play módban módosítok, az elveszik!!!! Előbb állítsd majd le.

// -------------------------------------------------------------------------------------------

// ALAPKÓD KIINDULÁSHOZ


using UnityEngine;                                // alap

public class myFirstUnityScript : MonoBehaviour   // alap. "myFirstUnityScript" EGYEZZEN OSZTÁLY és SCRIPT NEVE! Monobehaviour = Unity elem lesz
{                                                 // alap
    void Start()                                  // eredetileg private-t volt. "start" = amikor létrejön a komponens, akkor indul is a script
    {
        Debug.Log("Hello Unity");                 // Ment. Visszalépés után futtat, kiírja a szöveget
        Debug.Log($"Hello I'm {name}");           // Ment, visszalép, futtat. A game object nevét írja ki.
    }
}                                                 // alap



// --------------------------------- VEKTOROKRÓL ---------------------------------------------

// A vektorok mindíg derékszögben, kifelé mutatnak (gömb is)
// mire jók: irányított szakasz (nyil) / egy pontot a térben (helyvektor) / irányt (irány vektor, egység vektor - hossz pont 1) 
// 3D elfordulást / Skálázást (méretezés)

// ------------

// Milyen vektorokról tanultunk:Vector2 --> 2D (X,Y) és Vector3 --> 3D (X, Y, Z)

// ------------

//VEKTOR ÖSSZEADÁS: c = a + b
// Vizuálisan: Az A vektort lemásoljuk a helyén, és képzelezben a b vektoron eltoljuk a b másik végéig (szaggatott vonallal rajzoljuk).
// A B-t lemásoljuk helyben, eltoljuk a másik végéig (képzeletben, szaggatott vonal).
// Ahol eltolás után ezek létrejönnek vonalként, találkoznak egy pontban. A c a nullából eddig a pontig húzódik

// ------------

// VEKTOR KIVONÁS c = a-b 
// (b-ből mutat a felé) gyakorlatilag az a vektor nem nullában levő pontja és b vektor nem nullában levő pontja között a szaggatott vonalat
// ha elcsúsztatjuk a (szaggatott vobalat) b vektor végpontjából a b vektor nulla pontjába, úgy, hogy a vonal ugyanúgy marad, az
// a kivonás után a c vektor

// ------------

// VEKTOR SZORZÁS (van más mód is, de azt nem tárgyaluk) SKALÁRRAL (float érték) c = c * s
// a C vektor hoszabbodik

// ------------

// VEKTOR OSZTÁS SKALÁRRAL c = c / s
// A C vektor rövidül

// ------------

// VEKTOR HOSSZ (ABSZOLÚTÉRTÉK) MEGÁLLAPÍTÁSA 
// vektor be, szám ki -->  hossz megállapítás, minden vektorból össszeáll egy derékszögú háromszög, a2+b2=c2, de Unityben
// leprogramozva, csak lekérdezzük (magnitude)
// Vector2 v = new Vector2(6, 8); 
// float length = v.magnitude;

// ------------

// NORMALIZÁLÁS (hossz 1-re állítás)
// vektor be, vektor ki - normalizálás művelete. Az irány és hossz megvan. Normalizál: irányt megtartja, de hossza 1 lesz.
// valójában a normalizálás a vektor saját hosszának önmagával vaó osztása

// ------------

// KÉT PONTVEKTOR TÁVOLSÁGA
// 2 bemenet vektor, a távlság pedig float (skalár) -- egy kvonás, majd távolság meghat.
// float distance1 = Vector2.Distance(v1, v2); // kiszámítás egyik módon
// float distance2 = (v1 - v2).magnitude; // Távolság kiszámítása más módon



// --------------------------------- A GYAKORLATBAN ---------------------------------------------


using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 pos;                     // ez meg is jelenik a Unity-ben "POS" alpontként (POS (POZÍCIÓ)

     void Start()                                    // induláskor hívja meg, amikor létrejön az objektum play alatt
    {
        Vector2 v2a = new Vector2(1, 4);             // new kulcsszó ha bármit létre akarunk hozni 
        Vector3 v3a = new Vector3(4, 5, 7.54f);      // ami idáig volt, az primitív típus volt, ez összetett típus

        float f1 = v2a.x;                           // pont operátorral nyerjük ki az egyik elemet, mert itt 2 elemet tartalmaz
        float f2 = v3a.z;                           // szintén, csak 3D a vektor

        // tudjuk, h. transformja mindnek van.

        Transform T = transform;                    // új típus. Mindíg nagybetű, ha nem primitív típus
        T.position = v3a;                           // elmozgattuk


     void Update()                                  // minden egyes képfrissítésre hívja meg
        {
          transform.position = new Vector3(1,2,3);  //kép frissítésenként 
        }
    }
}

// -----------------------------------SEBESSÉG---------------------------------------------------

using UnityEngine;
public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 velocity;             // megjelenik Unity-n belül

    void Update()                                  // képkockánként frissít
    {
        Vector3 p = transform.position;            // transofrm-ot csinál a helyzetére
        Vector3 newPos = p + velocity;             // az új pozíció a p-re vonatkozóan a velocity hozzáadásával történik (ezt belül adjuk majd)
        transform.position = newPos;               // a pozíció az új pozíció lesz
    }
}                                                  //ha ezek után beírjuk unityben, hogy y = 0.01, és run, elkezd felfelé menni de ez kis érték


// ----------------------------------------------------------------------------------------------


// a fenti egyszerre teszi meg az utat
// mi van, ha beállítok egy sebességvektort - akkor pont annyi utat tenne meg, ami mindenhol ugyanakkora utat tesz. Nem egyszerr, hanem
// lépésekben, pl. 10 részletben tenné, pl 10 frame/sec ideális lenne (egységnyi) - ez lesz a technikánk, lekérdezzük mennyi idő múlt el
// és az alapján mozgatunk, hogy gyors és laaaú gépeken is hasonlóan kezelje az utat 

using UnityEngine;
public class Mover : MonoBehaviour                          // Mover - script fájl és class neve
{
    [SerializeField] Vector3 velocity;                      // Vector3 Velocity-t létrehozzuk, megjelenik menüként is!

    void Update()
    {
        Vector3 p = transform.position;                     // p egy pozíció transform lesz

        Vector3 newPos = p + (velocity * Time.deltaTime);   // az új pozi a p + (sebesség, ahol a sebesség az idő delta (átlag) értéke
        transform.position = newPos;                        // a transform helyzete másodpercenként legyen a newPos
    }
}
// Unity-ben a velocity 1 mp alatt (ha 1-et állítunk)


// --------------------------------------MOZGATÁS---------------------------------------------------


using UnityEngine;
public class Mover : MonoBehaviour
{
    [SerializeField] Vector3 velocity;

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);            // boolean, felfelé - az input (pl: keyboard) figyeli a gombot, a gomb kód: fel
        bool down = Input.GetKey(KeyCode.DownArrow);        // le 
        bool right = Input.GetKey(KeyCode.RightArrow);      // jobbra
        bool left = Input.GetKey(KeyCode.LeftArrow);        // balra

        // PLUSZ INFO: A GetKey = folyamatos állapotot jelent. A GetKeyDown = éppen le van nyomva a gomb
        // PLUSZ INFO: ha mögé írjuk a gombnak, hogy:  || Input.GeKey(KeyCode-W); kiegészíthető új gomb

        // --- felbővítés 1: egységnyi lépést ugorjon, szépen, egyesével ---
        float y = 0;                                        // null értékről indul
        float x = 0;                                        // null értékről indul

        if (up)                                             // he a bool up történik
            y = 1;                                          // akkor y legyen 1 érték, egységnyi egyet menjen (felfelé pozitív érték)
        else if (down)                                      // ha le
            y = -1;                                         // y = -1

        if (left)                                           // ugyanez jobbra - balra (jobbra pozitív érték)
            x = -1;
        else if (right)
            x = 1;

        Vector3 velocity = new Vector3(x, y, 0);            // A velocity az új vektor fentről vett értéke, Z pedig nulla
                                                            // --- felbővítés 1 vége ---

        // --- felbővítés 2: a velocity legyen a veloity és speed szorzata ---
        velocity *= speed;
        // --- felbővítés 2 vége --- 

        Vector3 p = transform.position;
        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;
    }
}
// ----------------------------------------------------------------------------------------------

// Eddig beállításból jött a "velocity", de nem akarjuk, ezért kivettük a "[SerializeField] Vector3 velocity"-t, helyette speed 
// Plusz nem akarjuk, hogy két gomb lenyoására is egyik működjön, ezért leprogramozzuk, hogy pl fel-le egyszerre NE működjön
// illetve azt akarjuk, hogy csak egységnyit menjenminden irányba, ezért normalizáljuk (1-re állítjuk a mozgást)

using UnityEngine;
public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;                       // ami szerializált field-ek, azok megjelennek az editorban (SPEED)

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

        float y = 0;

        if (up && down)                                     // le fel együttes lenyomásnál ne mozogjon
            y = 0;
        else if (up)
            y = 1;                                          // menj felfelé
        else if (down)
            y = -1;                                         // menj lefelé

        float x = 0;

        if (right && left)                                  // jobbra balra együttes lenyomásnál ne mozogjon
            x = 0;
        else if (left)                                      // menj balra
            x -= 1;
        else if (right)                                     // menj jobbra
            x += 1;
        // de átlóban sokkal gyorsabb, nem egy, ezért normalizálni kell

        Vector3 velocity = new Vector3(x, y, 0);

        velocity.Normalize();                               // a speed előtt, hogy azt ne normalizálja, csak a mozgást
        velocity *= speed;                                  // speed és velocity szorzata a mozgás sebessége

        Vector3 p = transform.position;
        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;
    }
}
// DE EZ ÍGY NEM JÓ! Cseréljük le gyorsan az összes Y-t Z-re, és a Vector3 velocity = new Vector3(x, y, 0);-ben a sorrendet (x, 0, z)-re!!!!
// Ha megtettük, akkor jön rendbe a mozgás a szoftverben!!!

// ----------------------------------------------------------------------------------------------


//EZ EGY ÚJ ÓRAVÉGI TÖRTÉNET:

// Ha a "Mover"-t unityben kikapcsolom az objektumon és ráteszem inkább a kamerára, akkor az mozog.

using UnityEngine;
pubic class LookAt : MonoBehaviour
{
    [serializerField] transform = target; // új beállítás target néven. ha ez megvan, le tudom kérdezni a player pozit, saját pozit, stb.

    void update ()
    {
        vector3 targetPosition = target.position;
        vector3 getPosition = transform.position;

        vector3 dir = transform.rotation quaternion.LookRotation ( dir ); // a kamera mindíg középen tartja --> NEM TUDOM JÓ_E ÍGY
    }
}

*/