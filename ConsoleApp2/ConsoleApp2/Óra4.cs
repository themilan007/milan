/*

// -------------------------- 4. ÓRA -------------------------------

// -------------- LookAt ---------------  
// Kamera beállítás hogy kövesse amre ráállítjuk. Ha a játékosunkra, akkor a fő Unity objektumra tesszük, nem bitos, hogy jó
// pl. ha a fejre tesszük, akkor ha közel van hozzánk, akkor is megmutatja a karaktert, nem vágja le a "fejet"

using UnityEngine;
public class LookAt : MonoBehaviour
    {
    [SerializeField] Transform target;                             // Transofrm menüponton dolgozunk

    void Update()
    {
        Vector3 targetPosition = target.position;
        Vector3 selfPosition = transform.position;

        Vector3 dir = targetPosition - selfPosition;

        if (dir != Vector3.zero)                                    // dir - direction jelentése van           
            transform.rotation = Quaternion.LookRotation(dir);      // quaternion = leképezi Unityben a "jó" 3D mozgást, elég sokat tud

    }
}

// ----------------------------------------------------------------------------


// ---------- PRÍMSZÁM HÁZI MEGOLDÁSA UNITA ALATT -----------------

using UnityEngine;

public class WritePrimes : MonoBehaviour
{
    [SerializeField] int num = 10;                              // létrehoz egy menüpontot, és kezdő értéket is ad neki


    void Start()                                                // start-nál írja ki a prímeket
    {
        WriteNPrimes(num);                          
    }

 
    void WriteNPrimes(int count)                                // void RUTIN prímkiírás: nem ad eredményt, csak annyiszor fut, ahányszor kell
    {
        int found = 0;                                          // hányat talál; kezdetben nulla
        int i = 2;                                              // 2 alatt nem keresünk, az 1 nem tartozik bele

        while (found != count)                                  // addíg fusson, amíg a "found" nem lesz egyenlő a "count"-tal
        {
            if (IsPrime(i))                                     // ha "i" prím:
            {
                found++;                                        // found +1
                Debug.Log(i);                                   // írja ki Debug ablakba (WriteLine helyett Unity ide ír) 
            }
        }

 // ide kerülne a második szakasz, de nem biztos, hogy tökéletesen írtam át. FÜGGVÉNY, van eredmény, ez adja meg, hogy prím, vagy sem
        bool IsPrime(int z)             
        {
            if (z < 2)                                          // 2 alatt nincs prímszám, ezért kettő alatt "return"-nal kilépünk
                return false;

            float negyzetgyok = Mathf.Sqrt(z);                  // z négyzetgyöke, felette felesleges osztót keresni, (float)-tal átalakítom
                                                                // Mathf = Foat átalakítás, ez is Unity cucc, enélkül = (float) lenne előtte 
            for (int k = 2; k <= negyzetgyok; k++)              // fusson k alkalommal, kettőnél kezdjen, "négyzetgyok" alkalommal 
            {
                if (z % k == 0)                                 // ha osztásnál nincs törtrész, akkor osztható, return-nal "hamis"-t ad, nem prím
                    return false;


            }
            return true;                                        // ha végig ér minden lehetséges számon, akkor return "true", azza prím
        }
    }
}

// ---------------------------------------------------------------------


// ----------------- MOVER: KAMERA NEM ILLESZKEDIK, PROBLEMAS A MOZGAS A KAMERAN NEZVE ---------------------
// Van GLOBÁLIS beállítás és LOKÁLIS
// le tudjuk kérni egy transform fő irányát

using UnityEngine;

public class Mover : MonoBehaviour
{
    // [SerializeField] Vector3 velocity;                           //kikommenteztük mert nem beállításból jön, hanem programozzuk
    [SerializeField] float speed = 5;                               // ami szerializált field-ek, azok megjelennek az editorban
    [SerializeField] Transform cameraTransform;
    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);                    // itt éppen le van nyomva (GetKeyDown), de itt folyamatosat jelent
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

// hogyan csinálunk vektorból egységnyit itt?

        float z = 0;

        if (up && down)                                             // ha mindkettő le van nyomva akkor legyen nulla, ne mozogjon
            z = 0;
        else if (up)
            z = -1;
        else if (down)
            z = 1;


        float x = 0;

        if (right && left)                                          // ha mindkettő le van nyomva akkor legyen nulla, ne mozogjon
            z = 0;
        else if (left)
            x += 1;
        else if (right)
            x -= 1; 

 // de átlóban sokkal gyorsabb, nem egy, ezért majd normalizálni kell

        Vector3 rightDir = Vector3.right;                           // azt mondjuk, hogy a jobbra dir (direction) legyen jobb irány
        Vector3 forwardDir = Vector3.forward;                       // azt mondjuk, hogy az előre dir (direction) legyen előre irány
                                                                    // "GLOBÁLIS" kezeléshez megmondjuk neki mi merre legyen minden esetben
                                                                    // a kameránál is

        // Vector3.velocity = new (x, 0, z);                        // ezt kikommenteztük, innentől nem ezzel oldjuk meg (globális eset)
        Vector3 velocity = rightDir * x + forwardDir * z;           // mozgás legyen a jobbirány * x + előre irány * z

        velocity.Normalize();                                       // a speed előtt, hogy azt ne normalizálja

        velocity *= speed;                                          // a mozgásnál legyen mozgás * sebesség a velocity

        Vector3 p = transform.position;                             // létrehozunk egy "p"-t ami tárolja a transzform pozíciót (jelenlegi)

        Vector3 newPos = p + (velocity * Time.deltaTime);           // newPos(új pozi) = régi + (normalizált velocity * Deltaidő (minden eszköz)        transform.position = newPos;
        transform.position = newPos;                                // új pozíció létrehozás

        if (velocity != Vector3.zero)                               // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral.
                                                                    // ez az "If" nélkül mindíg visszafordulna. (orra)

            transform.rotation = Quaternion.LookRotation(velocity); // arra nézzen orral előre, amerre mész.
                                                                    // Ezért az orrot a kék nyil irányában kellett létrehozni.Z tengely elejére
                                                                    // mutasson az orr

    }
}
    //ha ezek után beírjuk, hogy y = 0.01, és run, elkezd felfelé menni -- SZERINTEM EZ NEM LESZ, MERT NEM "MENÜ"-BŐL KEZELTÜK

// ---------------------------------------------------------------------


// ----------------- MOVER: KAMERA NEM ILLESZKEDIK, A FENTI KóDON CSAK PICIT TEKERÜNK ---------------------
// amit itt módosítunk, az a komplikáltabb megoldás, de azért érdekes, mert ez az "általánosan hazsnált" megoldás a szakmában
// előállítja az iráy vektorunkat
// ha kikapcsoljuk a kamera döntését, az kell
//
// NEM MÁSOLTAM LE A TELJES KÓDOT, csak azokat, amit változtattunk!!!!!!!!!!!!!!!!!! EZ A SOR ELŐTT MINDEN UGYANAZ:


// de átlóban sokkal gyorsabb, nem egy, ezért majd normalizálni kell

        // Vector3 rightDir = Vector3.right;                        // EZT itt kiiktattuk
        // Vector3 forwardDir = Vector3.forward;                    // EZT itt kiiktattuk
        Vector3 rightDir = cameraTransform.right;                   // ez van helyette
        Vector3 forwardDir = cameraTransform.forward;               // ez van helyette

        // Vector3.velocity = new (x, 0, z);                        // ezt már régebben kikommenteztük
        Vector3 velocity = rightDir * x + forwardDir * z;           // mozgás legyen a jobbirány * x + előre irány * z (maradt az előző kódból)
        velocity.y = 0;                                             // ÚJ ELEM - mivel y-ban nem mozgatunk, adjunk neki nullát

        velocity.Normalize();                                       // a speed előtt, hogy azt ne normalizálja  (maradt az előző kódból)

        velocity *= speed;                                          // a mozgásnál legyen mozgás * sebesség a velocity (maradt az előző kódból)

        Vector3 p = transform.position;                             // létrehozunk egy "p"-t ami tárolja a transzform pozíciót (maradt...)

        Vector3 newPos = p + (velocity * Time.deltaTime);           // newPos(új pozi) = régi + (normalizált velocity * Deltaidő (minden eszköz)        transform.position = newPos;
        transform.position = newPos;                                // ÚJ ELEM - a poziíció legyen új pozíció  

        if (velocity != Vector3.zero)                               // (maradt a régi kódból)
             transform.rotation = Quaternion.LookRotation(velocity); // arra nézzen orral előre, amerre mész. (maradt a régi kódból)
    }
}

// mover-ben a camera transform be main camera-ra rakom. Azért ment rosszul ellentétes gombokkal, mert ez nem voolt jó 
// ---------------------------------------------------------------------



// ----------------- KIEGÉSZÍTŐ SZÖVEGEK UNITY-HEZ AMIT KÖZBEN BESZÉLTÜNK ---------------------
// orr, z (kék tengely), előre mutasson
// Majd ha fizikázunk, akkor egy objektum colliderét le fogjuk venni (ugyanazon objektum több eleme érintkezik azért
// A szoftverben megmutatta, hy csinálunk egy karaktert, akkor hgyan lehet a túl sok érintkező pontot megszöntetni)
// Ha jobb kód elemzőt akarunk, mint a beépített AI, akkor Github CoPilot. Első hónap ingyenes, utána fizetős, de kb. nem tanulsz meg fejleszt.

// ---------------------------------------------------------------------


// ----------------- FOLLOWER KÉSZÍTÉS ÉS PROGRAMOZÁS (KÖVETÉS) ---------------------
// kövessen csak x és z tengelyen
// először csak vízsintes irányban menjen. Ha nulla lesz a különbség akkor fel v. le, és y irányba megy


using UnityEngine;
public class follower : MonoBehaviour
{
    [SerializeField] Transform target;                          //transform menu (létezik, csak használjuk)
    [SerializeField] float speed;                               // speed menü

    void Update()
    {
        Vector3 selfPosition = transform.position;                              // saját pozi
        Vector3 targetPosition = target.position;                               // a játékos pozija

        Vector3 direction = targetPosition - selfPosition;                      // az iránya a cél (játékos) pozi - saját pozi 
        direction.Normalize();

        Vector3 velocity = direction * speed;                                   // irány * sebesség a velocity

        transform.position = transform.position + velocity * Time.deltaTime;    // a pozi legyen velocity / delta idő
    }
}

// ---------------------------------------------------------------------


// ----------------- FOLLOWER REMEGÉS HA UGYNAZON A PONTON VAN AHOL MI ---------------------
// Azért remeg, mert 1 egységnyiket lép, de ha az utolsó lépésben kisebb a távolság, ő egységnyi egyt lép, tehát picivel távolabb lesz, mint mi
// aztán megint lép egyet, ami miatt megint picivel távolabb van, mint mi. Ezt látjuk remegésnek, mert nem pont annyit lép, amennyit kell
// alul a javítása

using UnityEngine;
public class follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void Update()
    {
        Vector3 selfPosition = transform.position;
        Vector3 targetPosition = target.position;
        
//      Vector3 direction = targetPosition - selfPosition;                    // kikommentezzük, nem kell
//      direction.Normalize();                                                // kikommentezzük, nem kell
//
//      Vector3 velocity= direction * speed;                                  // kikommentezzük, nem kell
//
//      transform.position = transform.position + velocity * Time.deltaTime;  // kikommentezzük, nem kell

        transform.position = Vector3.MoveTowards(selfPosition, targetPosition, speed * Time.deltaTime);  // MoveTowards (saját hely. cél hely,
                                                                                                         // sebesség paraméterek
                                                                                                         // csak addig megy, ahol álunk a végén
    }
}

/ ---------------------------------------------------------------------


// ----------------- PLUSZ MÉG: A FOLLOWER FORDULJON MINDÍG FELÉNK  ---------------------
using UnityEngine;
public class follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    void Update()
    {
        Vector3 selfPosition = transform.position;
        Vector3 targetPosition = target.position;

        Vector3 direction = targetPosition - selfPosition;              // a direction mondja meg, merre nézzen (cél pozi - saját pozi)
     
        transform.position = Vector3.MoveTowards(selfPosition, targetPosition, speed * Time.deltaTime);

        
        if (direction != Vector3.zero)                                  // nem nulla a vektor, amerre néz, mert ezt nem tudja kezelni
            transform.rotation = Quaternion.LookRotation(direction);    // rotál abba az irányba, nem csak "átugrik"
        // quaternion olyan elem UNITY alatt ami jól leír a 3d-s térben egy elfordulást. Jó funkciói vannak
    }
}
/ ---------------------------------------------------------------------



// -----------------  A JÁTÉKOS (MOVER) MOZGÁSA NAGYON DARABOS, KORRIGÁLJUK SIMÍTOTTABBRA  ---------------------


using UnityEngine;
using UnityEngine.Tilemaps;     // NEM TUDOM, HOGY EZ KELLETT VAGY CSAK MAGÁTÓL RAKTA BE A KÓD, DE MAJD TESZTELNI KELL!!!! VAGY MEGKÉRDEZNI...
public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace = true;                     // A mozgást a kamera terében kell kezelni (true)
    [SerializeField] float angularVelocity = 100;                       // milyen sebessége legyen a szög fordulásának
    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow); 
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        
        float z = 0;

        if (up && down)
            z = 0;
        else if (up)
            z = 1;
        else if (down)
            z = -1;


        float x = 0;

        if (right && left)
            z = 0;
        else if (left)
            x -= 1;
        else if (right)
            x += 1;

        Vector3 rightDir = moveInCameraSpace ? cameraTransform.right : Vector3.right;
        Vector3 forwardDir = moveInCameraSpace ? cameraTransform.forward : Vector3.forward;

        Vector3 velocity = rightDir * x + forwardDir * z;
        velocity.y = 0;

        velocity.Normalize();
        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;

        // if (velocity != Vector3.zero)                            // ezt nem kell kivenni a régebbi kódunkból, de egyben magtartjuk a 2 sort
        //  transform.rotation = Quaternion.LookRotation(velocity); // kiveszük, mással helyettesítjük hogy arra nézzen, amerre megyünk

        if (velocity != Vector3.zero) // if nélkül visszafordulna + most simítunk is
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);   // rotáció helyett cél rotáció lesz
            Quaternion currentRotation = transform.rotation;                 // a jelenlegi rotáció a transform.rotáció lesz (kiindulási kép)
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
                                                                             // a forgás transform a felé fordulás a 3 db. értékkel (jelen
                                                                             // forgás, cél forgá, szög sebesség * delta idő lesz a vége
        }
    }
 
    // ---------------------------------------------------------------------


// -----------------  AKADÁLY KÉSZÍTÉS A PÁLYÁRA (PAPMOVER NÁLAM A NEVE), MEG A GIZMO-K  ---------------------
// legyártottunk unity-ben egy üres objektumot, ahhoz gyerekként hozzáadtunk egy cylinder-t, ahhoz egy mélységben picire lapított kockát,
// illetve még egy ugyanilyen kockát duplikáltunk, és elforgattuk, hogy olyan legyen, mintha hatszög (6 ágú csillag) lenne
// ez lett az akadályunk
// GIZMO is kell hozzá - a gizmo olyan objektum (pontocska), ami csak a tervezőben jelenik meg, a játékben, kamerán nem látszik már

using UnityEngine;
public class papMover : MonoBehaviour
{
    [SerializeField] Transform posA, posB;       // a Transform menüpontban két pos-t hozunk létre (A, B)
    [SerializeField] float speed;


    // ---EZT CSAK A 2. LÉPÉSBEN ÍRTUK BELE A KÓDBA, ELŐRÖR NEM VOLT BENNE---
    void OnValidate()                           //ezt is csak fejlWsztésre tudjuk hasZnálni, automatizáció, ami lfut az editorban
    {
        transform.position = (posA.position + posB.position) / 2; //  Majd meg kell kérdezni Csbit, mire való, ez felezi a hosszat??????
    }
    // --- EZ A MÁSODIK KÖRBEN BEÍRT KÓD VÉGE ---

    void OnDrawGizmos()                                         // VOID rutin ami eredményt nem ad vissza (egyik rutin sem)
    {
        if (posA == null) return;                               // ha egyik nincs meg, nem rajzolunk semmit, kilépünk, ezzel "védjük" (no hiba)
        if (posB == null) return;                               // szintén

        Gizmos.color = Color.red;                               // legyenek pirosak (alapszín szöveggel is megadható

        Gizmos.DrawSphere(posA.position, 0.1f);                 // a Gizmó legyen sphere (gömb), és az A pozíciója 0.1f)
        Gizmos.DrawSphere(posB.position, 0.1f);                 // a Gizmó legyen sphere (gömb), és a B pozíciója 0.1f)
        Gizmos.DrawLine(posA.position, posB.position);          // a Gizmók között húzzunk egy vonalat
    }
}

// ---------------------------------------------------------------------


// -----------------  AKADÁLY KÉSZÍTÉS, 3. LÉPÉS. MENÜ CSÚSZKA, SZÍNEK KÜLÖN-KÜLÖN KEZELÉSE, LERP HASZNÁLAT  ---------------------


using Unity.VisualScripting;                                // EZ NEM BIZTOS, HOGY KELL A KÓDBA, LEHET CSAK A GÉP ADTA HOZZÁ. MAJD TESZTELNI..
using UnityEngine;
public class papMover : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] float speed;
    [SerializeField, Range(0, 1)] float startPosition = 0.5f;           // range csúszkát ad a menübe


    void OnValidate()                                                   // ezt is csak fejelsztésre, automatizáció, ami lfut az editorban
    {
        transform.position = Vector3.Lerp(posA.position, posB.position, startPosition); //  Lerp - linear interpolation (extrapolation).
        // ezzel rátettem egy csúszkára a 2 db gizmo közé a vonalra, hogy hol legyen az akadály (összekötöttem az akadályt a csúszkával is
    }

    void OnDrawGizmos()
    {
        if (posA == null) return;
        if (posB == null) return;

        // színek felvétele
        Color c1 = Color.red;
        Color c2 = new Color(0, 0, 1); // RGB

        Gizmos.color = Color.Lerp(c1, c2, startPosition); // ezzel a kéát szín között tudunk "váltani". Ahogy húzzuk az objektumot a csúszkán
                                                          // úgy változik a csúszka színe a két szín között. a LERP erre (is) jó.

        Gizmos.DrawSphere(posA.position, 0.1f);
        Gizmos.DrawSphere(posB.position, 0.1f);
        Gizmos.DrawLine(posA.position, posB.position);
    }
}

// ---------------------------------------------------------------------


// -----------------  AKADÁLY MOZGATÁSA  ---------------------

using Unity.VisualScripting;                    // NEM BIZTOS, HOGY KELL
using UnityEditor.Experimental.GraphView;       // NEM BIZTOS, HOGY KELL
using UnityEngine;
public class papMover : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] float speed;
    [SerializeField, Range(0, 1)] float startPosition = 0.5f;


    void Update()
    {
        Vector3 direction = posA.position - posB.position;                          // mozgás iránya
        direction.Normalize();              
        
        Vector3 velocity = direction * speed;                                       // irány előállítása
                                                                                    // irányt reprezentáló vektor és hosszból lehet sebesség
                                                                                    // vektort készíteni
        transform.position += Time.deltaTime * velocity;                            // egyenletes mozgáshoz
    }


    void OnValidate()
    {
        transform.position = Vector3.Lerp(posA.position, posB.position, startPosition);
    }

    void OnDrawGizmos()
    {
        if (posA == null) return;
        if (posB == null) return;

        Color c1 = Color.red;
        Color c2 = new Color(0, 0, 1);

        Gizmos.color = Color.Lerp(c1, c2, startPosition);

        Gizmos.DrawSphere(posA.position, 0.1f);
        Gizmos.DrawSphere(posB.position, 0.1f);
        Gizmos.DrawLine(posA.position, posB.position);
    }
}

// ---------------------------------------------------------------------


// -----------------  AKADÁLY MOZGATÁSA - LEHET AZT, HOGY CSAK EGY CÉLIG MENJEN  ---------------------


using Unity.VisualScripting;                    // NEM BIZTOS, HOGY KELL
using UnityEditor.Experimental.GraphView;       // NEM BIZTOS, HOGY KELL
using UnityEngine;
public class papMover : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] float speed;
    [SerializeField, Range(0, 1)] float startPosition = 0.5f;

    void Update()
    {
        Vector3 targetPosition = posA.position;                 // legyen a cél pozíció a posA

        Vector3 nextPosition = Vector3.MoveTowards(transform.position, targetPosition, speed = Time.deltaTime); // a pontból az ektuális célig
                                                                                                                // megyünk csak
        transform.position = nextPosition;                      // a transzform pozíció legyen a kövtkező pozi

        if (nextPosition == targetPosition)                     // ha a következő pozi a cél pozíció (odaértünk)
        {
            targetPosition = posB.position;                     // az új cél pozíció legyen a B pozi
        }

        Vector3 direction = posA.position - posB.position;      // innen már benne volt a régio kódokban is
        direction.Normalize();
   
        Vector3 velocity = direction * speed;
        transform.position += Time.deltaTime * velocity;  
    }
    // ha így hagyjuk, akkor az update a cikluson belül fut le, ezért nem áll majd meg a nextPosition elenére sem.
    // Valami majd kell kívül - egy változó, ami megmarad! A következő kódban majd kezeljük ezt is!

    void OnValidate() 
    {
        transform.position = Vector3.Lerp(posA.position, posB.position, startPosition); 
    }

    void OnDrawGizmos()
    {
        if (posA == null) return; 
        if (posB == null) return;

        Color c1 = Color.red;
        Color c2 = new Color(0, 0, 1);

        Gizmos.color = Color.Lerp(c1, c2, startPosition);

        Gizmos.DrawSphere(posA.position, 0.1f);
        Gizmos.DrawSphere(posB.position, 0.1f);
        Gizmos.DrawLine(posA.position, posB.position);
    }
}

// ---------------------------------------------------------------------


// -----------------  AKADÁLY MOZGATÁSA - VÁLTOZÓ MEGŐRZÉS (ELŐZŐBEN JELEZTÜK), IDE-ODA MOZGATÁS  ---------------------

using UnityEngine;
public class papMover : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] float speed;
    [SerializeField, Range(0, 1)] float startPosition = 0.5f;

    Transform nextTarget; // ez egy "filed" (filled?) változó, amíg az itt él, az megmarad folymatosan, így tudjuk kezelni, hogy ne csak
                          // belül legyen futáskor, hanem előtte, kívül is  kezelni tudjuk.
    void Start()
    {
        nextTarget = posA;              // induláskor megadjuk a célt, ami a posA
    }

    void Update()
    {
        Vector3 targetPosition = nextTarget.position;

        Vector3 nextPosition = Vector3.MoveTowards(transform.position, targetPosition, speed = Time.deltaTime); // csak célig megyünk (pontosan)
        transform.position = nextPosition;

        if (nextPosition == targetPosition)                                                                     // ha elértünk a célig
        {
            if (nextTarget == posA)                                                                             // ha még célként posA van
                                                                                                                // beállítva
                nextTarget = posB;                                                                              // adjuk meg célnak a posB-t
            else
            {
                nextTarget = posA;                                                                              // különben legyen posA a cél
            }

        }

//        Vector3 direction = posA.position - posB.position;            // EZT KIVETTÜK, ELIVEL MÁR nEM KELL (de miért? nem kell normalize?)
//        direction.Normalize();                                        // EZT KIVETTÜK, ELIVEL MÁR nEM KELL
//                                                                      // EZT KIVETTÜK, ELIVEL MÁR nEM KELL
//        Vector3 velocity = direction * speed;                         // EZT KIVETTÜK, ELIVEL MÁR nEM KELL
//                                                                      // EZT KIVETTÜK, ELIVEL MÁR nEM KELL
//        transform.position += Time.deltaTime * velocity;              // EZT KIVETTÜK, ELIVEL MÁR nEM KELL
    }
   

    void OnValidate() 
    {
        transform.position = Vector3.Lerp(posA.position, posB.position, startPosition);
    }

    void OnDrawGizmos()
    {
        if (posA == null) return;
        if (posB == null) return;

        Color c1 = Color.red;
        Color c2 = new Color(0, 0, 1);

        Gizmos.color = Color.Lerp(c1, c2, startPosition);

        Gizmos.DrawSphere(posA.position, 0.1f);
        Gizmos.DrawSphere(posB.position, 0.1f);
        Gizmos.DrawLine(posA.position, posB.position);
    }
}

// ---------------------------------------------------------------------


// -----------------  AKADÁLY FORGATÁSA  ---------------------
// ez az "alap" forgatás

Using UnityEngine;

public class autoRotator : MonoBehaviour
{
    [SerializeField] float angularVelocity = 360;   // 1 másodperc alatt 360 fokot forduljon

    void Update()
    {
        Vector3 eiler = new Vector3(0, angularVelocity, 0);  // eiler legyen ez az érték
        eiler *= Time.deltaTime;                             // eiler = eiler * delta idő
        transform.Rotate(eiler);                             // rotálás
    }

}

// ---------------------------------------------------------------------


// -----------------  AKADÁLY FORGATÁSA - KOMBINÁLJUK PICIT ---------------------

using UnityEngine;

public class autoRotator : MonoBehaviour
{
    [SerializeField] float angularVelocity = 360;   // a szög 360 fok
    [SerializeField] Vector3 axis = Vector3.up;     // a Vector3 szöge = vector3 fel
    [SerializeField] Space rotationSpace;           // a hazsnált tér a rotation tere legyen

    void Update()
    {
        Vector3 eiler = new Vector3(0, angularVelocity, 0);
        eiler *= Time.deltaTime;
        // transform.Rotate(eiler, Space.World);   // self, vagy world lehet
        // transform.Rotate(eiler, rotationSpace); // szerintem ezeket váltottuk ki, hogy a "menüben" lehetten kettintgatni (serialize-vel)
        transform.Rotate(axis, angularVelocity * Time.deltaTime, rotationSpace); // így definiálva tekergethetjük menüből
    }
    private void OnDrawGizmos()
    {
        Vector3 center = transform.position;        // a vektor3 központja legyen a transzform helye (a központi pont legyen a "forgástengely"?

        Vector3 dir;                                                    // az irány
        //   Vector3 dir = axis.normalized;                             // lehetne normalizált szög, de mégsem ezt hazsnáljuk

        if (rotationSpace == Space.World)                               // ha a world a tér, amiben forgatunk0
        {
            dir = axis.normalized;                                      // akkor legyen ez
        }
        else
        {
            dir = transform.TransformDirection(axis).normalized;        // egyébként meg ez.

        }

        Vector3 a = center + dir * 2;  
        Vector3 b = center + dir * 2;
        
        // Vector3 b = center - axis;
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(a, b);
    }

}

// ---------------------------------------------------------------------



// -----------------  FOLLOWER: BIZONYOS RANGE-N KÍVÜL NE KÖVESSEN ---------------------

using UnityEditor.Experimental.GraphView;                               // EZ SZERINTEM NEM KELL
using UnityEngine;

public class follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float range = 10;                                          // hatókör 

    void Update()
    {
        Vector3 selfPosition = transform.position;                              // saját pozi
        Vector3 targetPosition = target.position;                               // cél pozi

        float distance = Vector3.Distance(selfPosition, targetPosition);        // távolság kiszámítása

        if (distance <= range)                                                  // ha a távolság kisebb vagy egyenő hatókör

//            Vector3 direction = targetPosition - selfPosition;
//            
//            direction.Normalize();
//
//            Vector3 velocity= direction * speed;
//
//            transform.position = transform.position + velocity * Time.deltaTime;

            transform.position = Vector3.MoveTowards(selfPosition, targetPosition, speed * Time.deltaTime); // menjen a karakter után

//        // nem nulla a vektor, mert ezt nem tudja
//        // if (direction != Vector3.zero)
//        // transform.rotation = Quaternion.LookRotation(direction);
//        // quaternion olyan dolgo ami jól leír a 3d-s térben egy elfordulást

    }
}

// ---------------------------------------------------------------------



// -----------------  FOLLOWER: NAGYOBB TÁVOLSÁGNÁL LASABBAN, KISEBBNÉL GYORSABBAN KÖVESSEN ---------------------
// ILLETVE GIZMOKÉNT RAJZOLJA KI A KÉK KÖRÖKET, HOGY UNITÍBEN LÁTSZÓDJON

using UnityEditor.Experimental.GraphView;                               // EZ SZERINTEM NEM KELL
using UnityEngine;

public class follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float bigRange = 15;
    [SerializeField] float smallRange = 10;

    void Update()
    {
        Vector3 selfPosition = transform.position;
        Vector3 targetPosition = target.position;

        float distance = Vector3.Distance(selfPosition, targetPosition);

        if (distance <= bigRange)                                                   // ha kisebb vagy egyenlő BigRange-vel
        {
            float t = Mathf.InverseLerp(bigRange, smallRange, distance);            // Inverz LERP nagytól a kicsi felé
            float actualSpeed = Mathf.Lerp(0, speed, t);                            // az aktuális sebesség Math Float. Lerp 0-tól sebességig 

            transform.position = Vector3.MoveTowards(selfPosition, targetPosition, actualSpeed * Time.deltaTime);   //Move towards
        }
    }

    private void OnDrawGizmosSelected()                             // kiválasztott gizmo rajzolása
    {
        Gizmos.color = Color.blue;                                  // legyen kék
        Gizmos.DrawWireSphere(transform.position, smallRange);      // smallRange megrajzolás
        Gizmos.DrawWireSphere(transform.position, bigRange);        //bigRange megrajzolás
    }
}

*/
// ----------------------------- 4. ÓRA VÉGE -----------------------------