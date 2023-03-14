
/*


// -------------------------- 5. ÓRA -------------------------------

// Elõzmények és egy kis plusz

// vector3 p = transform.position  (localScale), quaternion..rotation --> lokális vagy globális módosításokat hajtunk végre
// vector3 p2 = transform.localPosition (losyScale) local...

// transform.position = center;  ---> középre tesszük a transform helyét (pivot point)

//--------
// [serializefield] gamoboject2 transform...   --> serialize-ben létrejött elem
// ... gameobject2.transform....               --> kódból így lehet hívni

// -----------------------
// LESZ MAJD KÉSÕBB: referencia, egyik script odaszól a másiknak -- majd tanuljuk

//-----------------
// mesh filter - oda húzod a mesh-t (serialize)

// mesh renderer - fontos (serialize).. - materál határozta meg, milyen legyen a felszíne


// --------------

// 3d = mesh, 2d = sprite

//----------------

// 0,3 float - unity -- nem tudja kettes számrendszerben, a float és double vmi nagyon közelit ad vissza, vagyis 0.3333333.. a bouble
// sokkal több 3333... at tud kiírni, tárolni, ezért ha nagyon precíz valami kell, az double lesz

// ---------------------------------------------------------


// -------------------------- 2D -------------------------------

// UNITY: új scene, 2 d create empty, sprite rendere, sprite
// berakja, de nem látjuk be kell pozícionálni a kamerát, hogy a kamera terében legyen benne a 2D objektum
// perspektív, ortografikus kamera, 45 fokos szög fúgg. vízszint (izometrikus)
// vágósik, elülsõ, hátulsó vágósík térbõl ezt vágjuk ki. Ez kb. a kamera mit lát, tól-ig
//-----------------

// Sprite

// ahhoz, hogy hazsnáljuk, minimum kell elõtte a package Manager -- utána 2d sprite (install)
// ugyanitt van pl. a sprite animációhoz a rigging és mozgatás is (bone elemek. A sprite-hez csontszerû elemeket rendelünk, kb: fej, nyak,
// gerinc, jobb felkar, jobba alkar, esetlej jobb kézfel, ugyanez a bal kéznél is, illetve lábaknál is (comb, sípcsont, lábfej). Ez azért
// izgalmas, mert ha ezeket a csontokat elmozgatjuk (pl: lép a karakter), 0 képkockán áll, 30 képkockán lép, aztán 60-nál másik lábbal lép
// a szoftver a köztes lépéseket kiszámolja, megcsinálja, így lehet UNITY-n belül mozgatni pl egy ember karaktert
// --------------------


// Pixels per unit (a képen magán hány pixel legyen 1 egység  )  -- beállíthatjuk hogy a tárgy egy unit-os legyen (nem csinlunk ilyet mert
// pici lenne, de ha elképzeljök, akor a rácsszerkezetben 1 kockányi, vagyis 1 unit léptetéssel már a rácsszerkezeten is eggyel odébb lenne

// sprite sheet - megtekinthetõ, ha betöltöttük a sprite-ot (sprite editor a menüben

// -----------------------

// Sprite Editor most már elérhetõ ha UNITY-ben telepítettük a fent leírtakat

// -------------

// Pivot point nem a közepén van, figyelni kell rá. Neünk kell majd beállítani, hol legyen a tárgyunk "közepe" (forgáspont)
// Sprite és más képek, Unity fájlok esetében fontos: mindennek van egy meta file is (mindennek van, a hangoknak is). Meta- extra info benne
//Ha másolunk könyvtárból könyvtárba, akkor a meta file-t is másolni kell Ha Unity belül csinálod a másolást, az viszi. Ha kint másolsz, ügyelj

// Automatikusan fel lehet darabolni (slice, automatic slice) - revert vagy apply. A Sprite drabolása jól jöhet

// Sprite nagyon fontos beálítás: "DRAW Mode" simple, slice, tiled - akkor lehet tiling-et csinálni, ha tiled-be állítod, szépen ismétli magát
// pl ha létrát hozol létre, vagy "földet" 2D módban, nem kell egyesével elhelyezni a tárgyadat, sokszor, 1 tárgy is elég

// Sprite editornál, hogy ez egy full rack? ha ezt beállíottuk, akkor lehet csermpézni. -- ERRE MAJD RÁ KELL JÖNNI, MIT AKART A TANÁR MONDANI
// ---------------------------

// 2d képeknél is van mormal map - fényvisszaverés, tud reagálni fényekre. Ha van normal MAP-unk

//---------------------------

// Sprite renderer vs Sprite renderer - sprite-nél mindíg egyik sprite vagy elõrébb, vagy hétrébb, itt nincs átfedés (félig elül, félig hátul
// 3d esetén lehet átfedés
// Ha mindkettõt nullába tesszük, akkor nem tudjuk megmondani, melyik lesz elõl, málység vátoztatás kell, a gép dönti el ugyanazon a pozíción

// Sorting LAyer, sorrendet ad a spriteoknak.

// kb a 2D-rõl a tanár ennyit akart elmondani, végignéztük a menü egy részét, a többit majd ki kell találni

//--------------------------------



// --------------------------------------- A FÉNY "DIMMELÉSE" (GYENGE-ERÕS) --------------------------------------

// Light

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;                   // Menüben megjelenítjuk a "Light" változót aminek egy eleme a light
 // [SerializeField] Color c1, c2;                  // Menüben a szín, aminek két eleme a c1 és c2. Ezzel "csak" létrehozom

    [SerializeField] Color c1 = Color.white;        // külön-külön is létrehozható, ezzel egybõl színt is tudok naki adni
    [SerializeField] Color c2 = Color.white;

    void Update()
    {
        
    }
}

//------------
// UNITYBEN BELÜL: Ha itt létrejön és állítom a színeket, alatta van egy csík. ami fehér, az alpha csatornát fel kell húzni, mert az az
// átlátszóság ami alapból nulla. Az is lehet, ha "gyenge" a fény, hogy állítani kell rajta

//---------------------

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
    [SerializeField, Range(0,1) ] float dim = 0; // plusz ezzel a sorral azt csináltuk, hogy csúszkaként hozom létre. MINDÍG 0-1 közütti érték!
 

    	void OnValidate()               // ezzel oldjuk meeg, hogy bármilyen változásnál unity-n belül is egybõl lássuk a változtatást
    {                                   // azaz rögtön jelenítse is meg minden "validate" esetében. Enélkül nem frissíti be elvileg
        Update();
    }

    void Update()
    {
        light.color= Color.Lerp(c1, c2, dim); // fent csak a "kézi" állítást hoztuk létre, a "LERP" segítségével a fény átmenetét állítjuk be
    }
}

// -------------------

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
//  [SerializeField, Range(0, 1)] float dim = 0         // kidobtuk ezt a sort. Nem kézzel akarjuk kezelni, hanem "simítva" menjen oda-vissza
                                                        // a szín, ebben a részben ezt tanultuk (színusz függvényt hazsnálunk)
    void OnValidate()   
    {
        Update();
    }

    void Update()
    {
        float t = Time.time;                            // lekérdezzük mennyi idõ múlt el a játék kezdete óta
        float sin = Mathf.Sin(t);                       // a színusz változõnak a Mathf-bõl a szinuszt használjuk (t változó értékkel)           
        light.color = Color.Lerp(c1, c2, sin);          // LERP annyit változik, hogy az utólsó DIM érték helyett a SIN változót (értéket) adjuk
                                                        // Mivel a színus 1 és -1 között mászkál ezt át kell konvertálnunk
        sin += 1;                                       // ezzel a -1 bõl pl nulla lesz, -0,5 -bõl 1,5... és így tovább
        sin = sin / 2;                                  //ezzel meg elosztjuk kettõvel. Így az érték biztosan nem megy 1 fölé
                                                        // így tudjuk biztosítani, hogy nulla és egy között legyen mindíg az érték
    }
}

// ---------------------------------------

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
    [SerializeField] float frequency = 1;           // legyen sebességes is, milyen gyorsan ér át egyik színbõl a másikba és vissza

    void OnValidate()   
    {
        Update();
    }

    void Update()
    {
        float t = Time.time;   
        t *= frequency;                             // az elõzõekben lekérdezett, játékben eltelt idõt szorozzuk a frekvenciával
        t *= Mathf.PI * 2;                          // azzal kell szorozni, ami a teljes szélesség (skála), 2*PI radián, mert fokkban kell

        float sin = Mathf.Sin(t);
        sin += 1;                                   // ezeket átemeltük a LERP elé, így mûködik jól
        sin /= 2;

        light.color = Color.Lerp(c1, c2, sin); 

    }
}

// -------------------------------------------------------------------------------------


// ----------------------------------- COLLIDER, TRIGGER HASZNÁLATA ---------------------------------------------

// UNITY: collidereket levesszük az enemy-rõl, gyerek objectnél, játékosról is. A lényeg, hogy felesleges ennyi, hacsak pl. nem sebzést
// akarnál nézni, külön pl: headshot, akkor kell külön, de egyszerûbb játékoknál az "egész"-re nézzük
// visszatesszük ahova kell, de összesen 1 collidert teszünk egy játék elemre (itt: játékos, ellenfél, akadály)
// ha nem collidert (ütközést) nézünk, hanem csak összeér, az trigger ("ISTrigger" bekapcsolása a játék elemeknél)
// mindhármon beállítottuk "IsTrigger"-re
// csináltunk egy "damager" és egy "HealthObject"-et (script) unity-n belül

using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;       // a "serialize"-n belül megadtuk a minimum lehetséges értéket (1), a "maxHealth"
                                                        // változónak meg 100-at, hogy mi lehet a meximum, és azt be is állítottuk 100-ra
    int currentHealth;                                  // létrehoztuk a jelenlegi életet
}
//- - - - - - - - - - - - 

using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;                   // a sérülés értékét 10-re állítottuk

    void OnTriggerEnter(Collider other)                 // "OnTriggerEnter" új. Sok ilyen paramétere van még. 2d-s végû = 2d játékban !
    {                                                   // Azt mondtuk, hogy a collider, amire majd rátesszük figyelje a parméterben
                                                        // megadott változót. Az "other" azt jelenti, hogy mindeegyiket figyelje (minden más)

        GameObject go = other.gameObject;               // bármilyen komponenstípustól elkérjük a game objectjét (other).
                                                        // Semmi akadálya, hogy láthatatlan fal legyen, vagy átsétálni valami megrajzolton. 
        Debug.Log(go.name);                             // ezt a "go"-t csak a debug ablakban való kiíratásra csináltuk, amúgy nem fog kelleni
    }
}

// amikor a 2 collider találkozik, ellenõrzi a scipteket, megnézi a SW minek kell történnie.
// Az OnTriggerEnter - most érkeztek, épp találkoztak , OnTriggerExit - kilépett, OnTriggerStay - ciklikusan fog hívódni, jön az üzi hogy benne
// van egyik amásikban, amíg ez nem változik meg

// Enemy, obstacle -- damagert rájuk, magunkra meg a health-et tesszük fel.


// ----------------------  BESZÚRT INFORMÁCIÓ: HIBAKEZELÉS A KÓDBAN, UNITY-BEN ----------------------------------

// Ha a kódban legjobb (NEM LEG BAL OLDAL?) oldalon adunk kódba cehckpointot és utána attach to unity, akkor ott megáll, unityben mutatja
// ha olyan helyen adtunk "break"-et / figyelést, ahol nem történik még semmi, ilyenkor a script leragadthat, Unity meg sem nyílik meret nem
// ott tart.

// UNITY-n belül is van debug mód, akkor ha bekapcsoljuk, látjuk pl az amúgy láthatatlan értéket, ahogy a sebzés történik, megy le az élet)

// Ha menetközben átkattintok pl Projekt Asset-ekrõl, Consolee-re, és nem kattintok a scene-be, akkor play után pl. a karakterem nem megy.
// Bele kell MINDYG kattintani.

// --------------------------------------------------------------------------------------------------------------


// -------------------------------------- COLLIDER - FOLYTATÁS --------------------------------------------------

// UNITY: Legalább egy elemre tegyük rá a rigidbody-t, innen tudja, hogy van valami "akció", és azt is mondjuk meg neki, hogy "IS kinematic"
// /tehát kinematikus fizikát használunk) 


using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;     // startnál max health-hal indulunk
    }

    public void Damage(int damage)    // ha nem írjuk ki a private-t, akkor az a default, a "public" jelenti, hogy máshonnan is elérhetõ.
    {                                 // a PUBLIC mondja meg, hogy a script nem csak önmagában dolgozik, scriptek között így tudunk átadni
                                      // az INT.DAMAGE ponttal volt írva, de nem biztos, hogy úgy kell, kijavítottam, de ha nem mûködik,
                                      // majd írjuk vissza
        currentHealth -= damage;      // levesszük a sérülést 

        if (currentHealth<100)        // itt az if után nem volt zárójel, így nem tudom, mi és szerpelt-e egyáltalán valami a tanárnál
            Debug.Log("Auch");        // ha van sérülés, a console írja ki, hogy Auch
    }
}

// - - - - - - - - - - - - -

using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;

    void OnTriggerEnter(Collider other)  
    {
        GameObject go = other.gameObject;                   // go - mint gameobject változó

        HealthObject ho = go.GetComponent<HealthObject>(); // ho - mint healthobject változó. Kacsacsõr = ÚJ. Ez is zárójel, spéci, mezei
                                                           // metódus. Nincs paramétere, csak paraméterszerûsége, nem lehet bárhol használni,
                                                           // csak aki kezeli, ez itt a a kacsacsõrben az OZTÁLYNÉV a másik UNITY scriptbõl
                                                           // Ez generikus függvény (olvass utána ha akarsz)

        if(ho != null)                                     // null egy érték
        {
            ho.damage(damage);                             // UNITY SCRIPT MÛKÖDÉS: ha itt rányomok az F12.re, akkor innen oda ugrik a másik
                                                           // kódra, ahol használom (ha nyitva van több kód is
        }                                                  // ha a helath object nem nulla, akkor a health object sérülése a damage-vel egyenlõ
    }
}

// -------------------------------------


// --------- Health, legyen vége, aikor elfogy az élet ---------

using UnityEngine;
class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)                             // ha a jelenlegi élet kisebb, vagy nulla, akkor írja ki azt, hogy vége
        {                                                   // ennyi a plusz
            Debug.Log("Good By!");
        }
        // Debug.Log("Aucs!");                              // ezt kikukázzuk, már nem figyeljük
    }
}

//- - - - - - - - - - - - - -

// A damagerben ennél a lépésnél nem változtattunk semmit

using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        // Debug.Log(go.name);

        HealthObject ho = go.GetComponent<HealthObject>();

        if (ho != null)
        {
            ho.Damage(damage);
        }
    }
}

//--------------------------------


// ---------- folytassuk: az életünknek nem lenne szabad nulla alá mennie, és egyszer írja ki, hogy good bye.

using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    public int currentHealth;                           // ez itt az új- Publikusan hasznéljuk a következõkben majd a currentHealth-et

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
       //  currentHealth -= damage;

        if (currentHealth == 0) return;                 // PROGRAOZÁSNÁL JAVSOLT: elõször a "nem megyünk tovább" minden lehetséges esetre.
                                                        // Akár lehet 4-5 ilyen felétel, hogy ne is fusson, ha a feltétel nem úgy teljesül

        currentHealth = Mathf.Max(currentHealth, 0);    // ezzel egy sorba bele tudjuk tenni if ág használat helyett. Azt játsszuk el, hogy
                                                        // a maimumot keressük a jelenlegi élet és a nulla között. Ez azt eredményezi, hogy
                                                        // mindíg a jerlenlegi élet lesz a max, bármennyi is az, de nulláig tud csak lemenni

        if (currentHealth <= 0)
        { 
            Debug.Log("Good By!");
        }
    }
}

// A DAMAGER NEM VÁLTOZOTT, NEM ÍROM ÚJRA LE

// -----------------


// ---------------------------CSAK AKKOR MOZOGHATUNK HA VAN ÉLETÜNK. HA NINCS ÁLLUNK MEG --------------------------

// ez elõtt tettük publikussá a "public int currentHealth-ot (a fenti HealthObject scriptben)
// Most a Mover-en kell dolgoznunk a folytatásban

using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;                       // sebesség
    [SerializeField] Transform cameraTransform;             // kamera transform beállítása
    [SerializeField] bool moveInCameraSpace = true;         // a kamera terében mozogjon
    [SerializeField] float angularVelocity = 100;           // fordulási mozgás/sebességhez
    [SerializeField] HealthObject healthObject;             // ez az új- Eredetileg HealthObject = healthObject-et írtam, deszerintem az rossz
                                                            // úgy. Ha mégsem, akkor vissza kell majd javítani arra, de a progi hibát adott.

        private void OnValidate()                                       // ha private nem kellene kiírni, lehet, hogy ez is public? nem hiszem 
    {                                                                   // valószínûbb, hogy csak nem kell a "private" elé
        if (healthObject == null)
        HealthObject healthObject = GetComponent<healthObject>();       // ha nulla, akkor a HealthObject változója (healtObject) kapja meg a 
    }                                                                   // healthObject komponenst. Gondolom itt azt biztosítjuk, hogy biztos
                                                                        // legyen neki mefelelõ értéke, amikor indítjuk elõször és még nincs
    void Update()
    {
        if (healthObject.currentHealth <= 0) return;                    // ez a kivételkezelés. Ha élet kisabb vagy nagyobb, mint nulla, akkor
                                                                        // kilép, vagyis ez megkadályozza, hogy alább az irányítást tudjuk
                                                                        // használni. Kb kikapcsoltuk is ezzel
       

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

        Vector3 rightDir = moveInCameraSpace ? cameraTransform.right : Vector3.right;           // irány a kamera space alapján. Ha igen, akkor
        Vector3 forwardDir = moveInCameraSpace ? cameraTransform.forward : Vector3.forward;     // kamera transform terében, ha nem, akkor a
                                                                                                // vektor terében történik
        Vector3 velocity = rightDir * x + forwardDir * z;
        velocity.y = 0;                                                                         // a fenti 2 sor definiálja az X, Y, Z-t

        velocity.Normalize(); // a speed elõtt, hogy azt ne normalizálja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;


        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If nélkül mindíg visszafordul.
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}


// -------------------------------------------

// Damager meg(3ik) -?

using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;
    int currentHealth;                                                      // felvesszük a currentHealth-et, ennyi változik

    void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;

        HealthObject ho = go.GetComponent<HealthObject>();

        if (ho != null)
        {
            ho.Damage(damage);
        }
    }
}

// -------------------------- 

using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    bool IsAlive()                                          // ez változott, felvettük, vizsgáljuk, hogy a karakter él-e
    {                                                       // ez változott
        return currentHealth > 0;                           // ez változott: return, jelenlegi életem nagyobb mint 0
    }                                                       // ez változott

    public void Damage(int damage)
    {
        //  currentHealth -= damage;

        if (currentHealth == 0) return; 

        currentHealth = Mathf.Max(currentHealth, 0); 

        if (currentHealth <= 0)
        {


            Debug.Log("Good By!");
        }
    }
}


//----------------------------

using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5; 
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace = true;
    [SerializeField] float angularVelocity = 100;
    [SerializeField] HealthObject healthObject;

        private void OnValidate()
    {
        if (healthObject == null)
            HealthObject healthObject = GetComponent<healthObject>();
    }

    void Update()
    {
        //  if (healthObject.currentHealth <= 0) return;                    // ezt kidobjuk, az eddigi feladatok, lépések miatt már nem kell
        if (healthObject.IsAlive()) return;                                 // mostantól ezt figyeljük


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

        velocity.Normalize(); // a speed elõtt, hogy azt ne normalizálja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;

        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If nélkül mindíg visszafordul.
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}

//----------------------------------------------------------------
// ---------elvileg itt már nem mozog ha elfogy az élet.----------
// ---------------------------------------------------------------

//-------------------------------------------------------------------------------------------------------



// -------------------- TOVÁBB KORRIGÁLUNK: ha be van állítva health object, akkor is alive, egyébként mindíg mozgunk -----------------------

using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5; 
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace = true;
    [SerializeField] float angularVelocity = 100;
    [SerializeField] HealthObject healthObject;                             // HO = hO: egyenlõség hiba volt, ki

        private void OnValidate()
    {
        if (healthObject == null)
            HealthObject healthObject = GetComponent<healthObject>();
    }

    void Update()
    {
        //  if (healthObject.currentHealth <= 0) return;            // ezt már elõbb kidobtuk, az eddigi feladatok, lépések miatt nem kell

        if (healthObject != null)                                    // EZ ÚJ: csak akkor fusson az IsAlive IF, ha a healthObject nem nulla 
        {                                                           // EZ ÚJ: 
            if (healthObject.IsAlive())                             // EZ ÚJ: Mostantól is ezt figyeljük, de egy másik IF-be beágyazva
                return;                                             // EZ ÚJ: 
        }                                                           // EZ ÚJ: 

        //  if (HealthObject != null && !healthObject.IsAlive())    // EZ ÚJ: a fenti vizsgálat pontosan ugyanez, csak máshogy. Választható.
        //     return;                                              // EZ ÚJ:


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

        velocity.Normalize(); // a speed elõtt, hogy azt ne normalizálja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;


        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If nélkül mindíg visszafordul.
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}

// ---------------------------------

// HEALTH OBJECT HIBA VOLT JAVÍTVA ITT - most ez vagy az elõzõre vonatkozik az "=" problémára vagy nem tudom, mivel az elõzõ HealthObject
// scripthez képest NULLA a változás.

using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public bool IsAlive()                                   // ez változott még eggyel ez elõtt: felvettük, vizsgáljuk, hogy a karakter él-e
    {
        return currentHealth > 0;
    }

    public void Damage(int damage)
    {
        //  currentHealth -= damage;

        if (currentHealth == 0) return; 

        currentHealth = Mathf.Max(currentHealth, 0); 

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }
}

// -----------------------------------

// MOVER IS JAVÍTVA (health object = jel kuka, volt egy negálási probléma is 


using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5; 
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace = true;
    [SerializeField] float angularVelocity = 100;
    [SerializeField] HealthObject healthObject;                 // egyenlõ jel ki

    private void OnValidate()
    {
        if (healthObject == null)
            healthObject = GetComponent<HealthObject>();        // a szar verzió: HealthObject healthObject = GetComponent<healthObject>();
    }

    void Update()
    {
        if (healthObject != null)
        {
            if (!healthObject.IsAlive())                        // hiba volt. Az egészet negálni kell ahhoz, hogy ne alive, hanem "dead" legyen
                return;
        }

        //  if (HealthObject != null && !healthObject.IsAlive())                  // a fenti pontosan ugyanez
        //     return;

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

        velocity.Normalize(); // a speed elõtt, hogy azt ne normalizálja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;

        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If nélkül mindíg visszafordul.
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}

//------------------------------------------------------------------------------------------------------



// ----------------------- FELVEHETÕ ITEM-EK (COIN) ------------------------

// Coin felvétel
// FONTOS A KÓDOLÁSHOZ: NE a playerben oldunk meg mindent, a játék úgy nem moduláris, csak arra az egy dologra valók, nehéz újra hazsnosítani
// MELLÉK SZÁL: VISUAL STUDIO: CTRL, SHIFT S minden fájlt ment
// Minden game componensnek 1 tag-ja legyen, de sok minden más is lehet, TAG-eket felejtsük el, Unity cég sem szereti de már belerakták...

using UnityEngine;

public class Collector : MonoBehaviour                              // Ez  ascript a gyûjtéshez kell
{
    [SerializeField] int collected = 0;                             // számoló, nézi, mennyi érmét gyûjtöttünk
    // int currentHealth;                                           // ez vagy benne maradt véletlenül, vagy majd kell. Végig nem hazsnáljuk

    void OnTriggerEnter(Collider other)                             // itt is van trigger objektum, onEnter, és minden más Collidert figyeljen     
    {
        Collectable c = other.GetComponent<Collectable>();          // a "c" változó értéke az other (összes) komponensbõl csak a "Collectable"
                                                                    // Class-t nézze. Ezzel azt is megoldjuk, nehogy "begyûjtsön" mást
        collected++;                                                // egyszerûen növeljük az értékét eggyel "ütközéskor"
    }
}

// - - - - - - - - - - - - - - -

using UnityEngine;

public class Collectable : MonoBehaviour                            // Ez a script a gyûjthetõ cuccok miatt kell
{
    [SerializeField] int value = 1;                                 // érték integer legyen 1 (1 pontot ér a coin)

    public int GetValue() { return value; }                         // publikus érték: int GetValue()  =>  return value;
                                                                    // ilyet is szoktak, ami egyszerüen egy érték esetén azt az értéket
                                                                    // adja vissza                
}

// -----------

using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] int collected = 0;
    // int currentHealth;

    void OnTriggerEnter(Collider other)
    {
        Collectable c = other.GetComponent<Collectable>();

        if (c != null)                                              // miután fent már publikusnak tettük a COllectible alatt a "GetValue()"-t
            collected += c.GetValue();                              // itt a "collected++" helyett - de csak ha a "C" nem egyenlõ nullával
        Debug.Log(collected);                                       // felhazsnáljuk a coin értékét, és ideiglenesen debug-gal ki is íratjuk
    }                                                               // EZ AZ ÚJ RÉSZ ITT FENT
}

// -------------

// ----------------- Teleportálni fogjuk az érmét, hogy felvétel után új hlyen jelenljen meg ----------------

// tanáré

using UnityEngine;

class Collectable : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] Bounds teleportArea;                                    // új elem

    public int GetValue() => value;                                         // EZ HELYETT: public int GetValue() { return value; } 

    public void Teleport()                                                  // teleport
    {
        float x = Random.Range(teleportArea.min.x, teleportArea.max.x);     // X koordináta. a "random.range" -t használjuk rá, a
        float y = Random.Range(teleportArea.min.y, teleportArea.max.y);     // "teleportarea.min.x" és "...max.x" (X, Y és Z-re) 
        float z = Random.Range(teleportArea.min.z, teleportArea.max.z);

        transform.position = new Vector3(x, y, z);                          // létrehozunk egy új vektort
    }

    void OnDrawGizmos()                                                     // Gizmo megrajzolás
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(teleportArea.center, teleportArea.size);        // a teleport area központját és méretét definiáljuk

    }
}


// FONTOS: A "RANDOM" létezik a "USING system"-ben is (ez az, amit általában az elsõ pár órán UNITY nélkül használtunk) illetve a
// using UnityEngine-ben is van, de ez már felparaméterezett, és máshogy mûködik. Figyelni kell, hogy a kódban nehogy pl. belekeveredjen
// egy system, vagy valami más, mert az hibát dobhat 

 // --------------------- 5. ÓRA VÉGE -----------------------



