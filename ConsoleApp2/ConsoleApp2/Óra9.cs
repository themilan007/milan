// IOS Builder for Windows (asset) - IOS játék MAC nélkül
// ----------------------------------------------------------------------------

//-------------------------------------HÁZI-----------------------------------
//------------------------------ LASER POINTER ------------------------------

using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] Transform[] points;            // lehetne tömb is, vagy lista, így nem kell gameobect.transform.position,
                                                    // hanem elég lesz a transform.position

    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.up;

        Ray ray = new Ray(origin, direction);           // így is lehet

        //Ray ray = new Ray();                          // vagy így és utólag töltjük fel a köv 2 sorral
        //ray.origin = origin;
        //ray.direction = direction;

        Physics.Raycast(ray, out RaycastHit hit);
    }
}

// létrehoz egy cylinder-t, leveleszi róla a collidert, majd behűzza a scriptet.
// Objektumon belül létrehoz spehere-t és létrehoz jópárat, aztán egyesével beveszi az element-be manuálian 
// VAGY: kijelöli mind a 10 al-objektumot, eltűnik a cucc (inspector) --> jobbra fent lockolja az inspectort (ahogy van), és úgy jelöli ki és húzza be, így mindengyik helyre kerül
// aztán lockot feloldja --> ezeket fogja majd kirajzolgati
// Windows - General - lehet újabb inspectort is behúzni, egyik lockolva, a másik pl. nem

//------------------folytatjuk---------------

using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] Transform[] points;            // lehetne tömb is, vagy lista, így nem kell gameobect.transform.position, hanem elég lesz a transform.position

    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.up;

        Ray ray = new Ray(origin, direction);                           // így is lehet

        //Ray ray = new Ray();                                          // vagy így és utólag töljük fel a köv 2 sorral
        //ray.origin = origin;
        //ray.direction = direction;

        // Physics.Raycast(ray, out RaycastHit hit);                    // ezt a 2. körben vette kim, a fentit az elsőben

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);          // sztem ez került be helyette (2 köri kidobás)

        if (isHit)                                                      // csak akkor ha van is találat
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                float t = i / (points.Length - 1f);                     // az egy után azért tett f-et, hogy float maradjon ha int osztva floattal vagy fordítva van
                point.position = Vector3.Lerp(origin, hit.point, t);
            }
        }
    }
}

// ilyenkor nem történik semmi, mert UP --> ha elforgatom Unityben, és végre eltalál valamit elkezd működni, de villog.
// Azért, mert a collidereket nem vettük le a Sphere-kről még, csak a cylinderrről (ami a parent)

//------------------folytatjuk---------------

using UnityEngine;

public class LaserPointer : MonoBehaviour
{

    [SerializeField] Transform[] points;            // lehetne tömb is, vagy lista, így nem kell gameobect.transform.position, hanem elég lesz a transform.position

    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.up;

        Ray ray = new Ray(origin, direction);                           // így is lehet

        //Ray ray = new Ray();                                          // vagy így és utólag töljük fel a köv 2 sorral
        //ray.origin = origin;
        //ray.direction = direction;

        // Physics.Raycast(ray, out RaycastHit hit);                    // ezt a 2. körben vette kim, a fentit az elsőben

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);          // sztem ez került be helyette (2 köri kidobás)

        if (isHit)                                                      // csak akkor ha van is találat
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                float t = i / (points.Length - 1f);                     // az egy után azért tett f-et, hogy float maradjon ha int osztva floattal vagy fordítva van
                point.position = Vector3.Lerp(origin, hit.point, t);
            }

        }

        //       else                                                   // így is lehet,e hogy kitesszük a képről
        //        {
        //        }

        foreach (Transform point in points)                            // de így csináljuk meg
        {
            point.gameObject.SetActive(isHit);
        }


    }
}

// ------------------------TANÁRI VERZIÓ (a fenti is jó!)-----------------------------

using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    [SerializeField] Transform[] points;

    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.up;

        Ray ray = new Ray(origin, direction);

        // ray.origin = origin;
        // ray.direction = direction;

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);

        if (isHit)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                float t = i / (points.Length - 1f);
                point.position = Vector3.Lerp(origin, hit.point, t);
            }
        }

        foreach (Transform point in points)
        {
            point.gameObject.SetActive(isHit);
        }
    }

}

//--------------------------------------------------------------------------------

// ----------------- GRAVITÁCIÓS MÓDOSÍTÓK ------------------------

// létrehoz egy gömböt, rajta hagyja a collidert, átlátszó: m,esh rendere kikapcs. Eltűnik. Ha átlátszó kell, akkor
// létrehoz materialt (Transparent) névvel, ráhúzza a game objectre (gömb)
// standard material, renderernél transparent kiválaszt, alpha lehúzza és piros lesz pl.átlátszóan piros
// meg lehet nézni a háziban megadott megoldást, most máshogy oldjuk meg. (ott rákeres minden rigidbody-ra és megnézi
// a távolságot tőlünk. Most triggerrel oldjuk meg.
// utóbbit bármilyen colliderrel tudjuk használni, az a lényege, hogy legyen beállítva
// létrehozza a scriptet és hozzárendeli a gömbhöz

//----------------------------------------------------------------

using System.Collections.Generic;                               // ez kell, különben hiba van
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [SerializeField] Vector3 gravity;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Add(rb);


        //if (other.GetComponent<Rigidbody>() != null)          // ez a csúnyábbb kódismétléses
        //rigidbodies.Add(other.GetComponent<Rigidbody>());
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Remove(rb);
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in rigidbodies)                        // nem lehet tömb, mert az fix, ezért lista
        {
            rb.velocity += gravity * Time.fixedDeltaTime;
        }

    }
}
---------------------ez a tanári.kb ugyanez-----------------------------

using System.Collections.Generic;
using UnityEngine;

class GravityModifier : MonoBehaviour
{
    List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [SerializeField] Vector3 gravity;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Add(rb);
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Remove(rb);
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.velocity += gravity * Time.fixedDeltaTime;
        }
    }
}

// RIGIDBODY collision detection átállítva continuous-ra , Y-t módosítja 20-ra pl
// ilyenkor simán létrehoz egy újat, és X módosítva 20 ra --> 100 esetén már kilövi

//-----------------------------Tovább nézzük--------------------------------------------------------------

// rigidbodyknak van tömege --> 1 es érték. Lehet osztani ezzel az értékkel, ha nagyobb a tömege, annál
// lassaban gyorsul, vagy annál nagyobb erő kell neki a gyorsuláshoz
// nézzük ezt

using System.Collections.Generic;
using UnityEngine;

class GravityModifier : MonoBehaviour
{
    List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [SerializeField] Vector3 gravity;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Add(rb);
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Remove(rb);
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.velocity += gravity * Time.fixedDeltaTime / rb.mass;         // tömegggel osztok, utána a tömeget módosítom az objektumainkon.
        }
    }
}

//-------------------------RB ADDFORCE MAGYARÁZAT A PÉLDÁN TÚL--------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

class GravityModifier : MonoBehaviour
{
    List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [SerializeField] Vector3 gravity;

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Add(rb);
    }

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
            rigidbodies.Remove(rb);
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.velocity += gravity * Time.fixedDeltaTime / rb.mass;     // tömegggel osztok, utána a tömeget módosítom az objektumainkon. (fix erő. Ha nincs a /rb.mass akkor fix gyorsítás

            rb.AddForce(gravity, ForceMode.Acceleration);               // TÖMEG NEM SZÁMÍT         // azért nem szerti, mert elverszi a megértést, miért kell pl. fixed delta time // FOLYTONOS
            rb.AddForce(gravity, ForceMode.Force);                      // TöMEG SZÁMÍT                                                                                             // FOLYTONOS

            rb.AddForce(-gravity, ForceMode.VelocityChange);            // TÖMEG NEM SZÁMÍT                                                                                         // EGYSZERI
            rb.AddForce(-gravity, ForceMode.Impulse);                   // TÖMEG SZÁMÍT                                                                                             // EGYSZERI
        }
    }
}

// Mértékegységek: 
// time.deltatime = mp
// a hossz az egység,mi találjuk ki
// tömeg, szintén mértékegység, mi találjuk ki
// minden más kb ebből származik le 


//-------------------VISSZALÉPÜNK AZ EREDETI KÓDRA A FENTI CSAK TANULÁS MIATT VOLT--------------------


// méret alapján tömeg számítás (pl űrhajók)
// üres objektum, ráteszi a kódot

//------------------------------------


using UnityEngine;

public class AutoSetup : MonoBehaviour
{

    [SerializeField] float density = 1.0f;
    void Start()
    {
        // var a = 1;                                                       // értékből tudja a var, hogy mi a, itt egy int

        // BoxCollider[] boxes = FindObjectOfType<BoxCollider>()            //
        var boxes = FindObjectOfType<BoxCollider>();                        //                                                    

        foreach (BoxCollider box in boxes)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 = transform.localScale;

                float volume = boxes.size.x * boxes.size.y * boxes.size.z;

                rb.mass = volume * density;
            }
        }
    }
}

//----------------------FENTI NEM JÓ? TANÁRI ALÁBB--------------------------

using UnityEngine;

public class AutoSetup : MonoBehaviour
{
    [SerializeField] float density = 1.0f;

    void Start()
    {
        var boxes = FindObjectsOfType<BoxCollider>();

        foreach (BoxCollider box in boxes)
        {
            Rigidbody rb = box.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 scale = box.transform.lossyScale;

                float volume =
                    box.size.x * box.size.y * box.size.z *
                    scale.x * scale.y * scale.z;

                // Debug.Log(scale);

                rb.mass = volume * density;
            }
        }
    }
}

// fejlesztésnél minden objektumhoz script és onvalidate-ben futtatná, optimálisabb, nem egyben mindre...



//----------------------PLATFORMER ÚJRA-------------------------

using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed = 6;
    [SerializeField, Min(0)] int airJumpCount = 1;
    [SerializeField] float movementSpeed;

    bool grounded;
    int airJumpBudget;

    void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))                // getkeydown miatt egyszeri mozgás miatt, folyamatos mozgást nem ide tesszük
        {
            if (grounded || airJumpBudget > 0)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;

                if (!grounded)
                    airJumpBudget--;
            }
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");          // getaxis - tengelyt kérek le, ezek beállíthatóak az Iput Managerben,
                                                        // de alapból is van vagy 18 másik, sajátot is létre tudsz hozni

        vector
        if (x != 0) { }                                 // X jobbra 1, balra -1, 0 nem mozgunk
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        airJumpBudget = airJumpCount;

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}



// ----------------- tanári a jó alul, de talán mégsem, mert hibát talált, eggyel alább a jó --------------------------------

using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField, Min(0)] int airJumpCount = 1;
    [SerializeField] float movementSpeed;

    bool grounded;
    int airJumpBudget;

    void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded || airJumpBudget > 0)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;

                if (!grounded)
                    airJumpBudget--;
            }
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 velocity = rb.velocity;
        velocity.x = x * movementSpeed;
        rb.velocity = velocity;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        airJumpBudget = airJumpCount;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}

// nem működött a mozgás, mert movement speed-re nem állított semmit. 5-ön már megy
// lassan áll meg, meg indul el, ha a gravity-t feltolom 1000-re akkor pilanatnyi a mozgás, amúgy kb 1/3 mp a sabességhez
// EDIT - PROJECT SETTINGS-ben

// projects - 2d physics-ben -20 akkor dupla akkora lesz a gravitáció, játékon belül (sima physics = 3d, 2d nincs hatás
// vagy magunk: fizikában gravity scale = 0
//-------------------TANÁRI--------------------------------------

using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField, Min(0)] int airJumpCount = 1;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector2 gravity = new Vector2(0, -9.81f);

    bool grounded;
    int airJumpBudget;

    void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded || airJumpBudget > 0)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;

                if (!grounded)
                    airJumpBudget--;
            }
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        Vector2 velocity = rb.velocity;
        velocity.x = x * movementSpeed;
        rb.velocity = velocity;

        rb.velocity += gravity * Time.fixedDeltaTime;                         // ez lett a saját gravitáció  - azért += mert fent negatív
                                                                              // a gravitáció megadott iránya

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        airJumpBudget = airJumpCount;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}

// jump speed-et is fel kell tenni 100-ra, jump speed 15

//-----------------------------------------------------------------------------------------

//[serializefield] Bool RunUpdate
//if (!runUpdate) runupdate kikapcs
//
//de nem biztos,. hogy kell, mert mindenmonobehavious scripetet tud tiltani.
//Minden eseménymetódust...

//----------------------------------------3D GAME-----------------------------------------------------------------
// Coin Duplikálások
// ha a Hierarchy-ban rákeresek a coin-ra, szűr rá, és akkor átállitom
// t:autorotator (típusra tudok rákeresni)
// ugyanez működik a projects fülön is, pl: t:scene és bedobja mind (nem elég csak elkezdeni, a teljes nevet kell magadni
// legyen SABLON azaz PRefab. Létrehozok egy prefab könyvtárat és behúzom a coin-t a prefab könyvtárba, ahol az eredeti
// coin adataival dolgozik
// prefab coin a könyvtában duplakatt, mindenfélét megadok neki, hol jelenjen meg, mekkora legyen, és kész
// utána kihúzom a scene-be
// ha a prefabon módosítok, minden scene-ben módosul
// kilépés a prefab-búl a Hierarchy - Coin felett vissza gomb
// kódból is betehetjük ahová csak akarjuk
// belépni ha eg példányon a scene-n belül lépek be a prefab melletti jobb nyilra. Amit módosítok, ugyanúgy mninden módosul
// OVERRIDES csak a prefab Inspectorban van, akkor ha valamit módosítottunk egyetlen prefab példányon külön (és nem belül)
// scene-n belüli módosítást vagy úgy hagyjuk - (szándékos), vagy revert, visszaállítjuk. Vagy apply amit átvezetünk.
// ha módosítom az értékét és jobbegérgomb a szövegen, nem a módosítható dobozon, akkor lehet "apply to prefab"
// lehet egy prefabon pl. child game objectet létrehozni, amit a Hierarchy jelez is majd, hogy "plusz", és ezt is rá lehet
// húzni a prefab alapra.
// VARIÁNS:
// prefab Inspector-aban bármely tárgyra, majd "SELECT", megtalálja a prefabot.
// NEW - Prefab Variant, ha rajta állunk
// Mesh renderer material --> én rosszul, magát a matertilat akartam buherálni, de az nem jó
// csinált egy kalapot egynek, majd csinál belőle prefabot, törli a scene-ből, de prefabként ott van
// általában egy prefab nem szeencsés, ha nagyon elnyomott (scale)
// csinál egy sima coin másolatot, azt átnevezi Coin Visual-ra, beteszi a szülő alá, csak a szülőn van script
// törli az értékeket 1,1,1re és ezen dolgozik
// a kalap sajna nem lett sikeres.
// Coin - másolás - child. Eredeti coin-on kikapcsolunk mindent, visszaállítjuk 1,1,1-re, majd a child-en mindent beállítunk
// arra, ami a volt 1, 0.2, 1, és vissza is kapcsolunk mindent, így aa visual adja amit kell, ésss a létrehozandó
// objektumok már normálisan jönnek létre, nem összenyomva


//--------------------

using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] KeyCode shootkey = KeyCode.Space;
    [SerializeField] Gameobject projectilePrototype;


    void Update()
    {
        if (Input.GetKeyDown(shootkey))
        {
            // shoot
            GameObject newBullet = Instantiate(projectilePrototype);           // másolatot csinálunk
        }
    }
}

//--------------------------------

using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] GameObject projectilePrototype;
    [SerializeField] float projectileSpeed = 10;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            // Shoot
            GameObject newBullet = Instantiate(projectilePrototype);
            newBullet.transform.position = shooter.position;
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            rb.velocity = transform.up * projectileSpeed;
        }
    }
}

// bullet - add rigidbody.

//-------------------- tanári -----------------------

using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] GameObject projectilePrototype;
    [SerializeField] float projectileSpopeed = 10;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            // Shoot
            GameObject newBullet = Instantiate(projectilePrototype);
            newBullet.transform.position = transform.position;
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            rb.velocity = transform.up * projectileSpopeed;
        }
    }
}
// nem mindegy, hogy a szülő zöldje (up) milyen irányba mutat és egyezik-e a golyó UP-jával
// ha nem megy, az is lehet, hogy belegabalyodik rigidbody-ba, ha nem vetted le a pisztolyról
// vagy a kézről, vagy másról

// minden komponensen, amit menetközben hozunk létre, annak a startja létrehozáskor meg is fut,
// nem az elején mindennek. akkor
// ha nem kell a lövedék, prefabot, majd a gun-nak a prefab-ot kötöm be.
// prefabon kikapcsolom a gravity-t (0) akkor megy a végtelenségbe, de nem szűnik meg


//-------------HOGYAN SEMMISÍTSÜK MEG------------------------------

using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float distanceFromCreation;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if (currentDistance > distanceFromCreation)
        {
            Destroy(gameObject);                                    // ha csak a komponenst akarjuk, akor this. ...,
                                                                    // így meg a teljes game objectet semmisítjük meg 
        }
    }
}

// prefab-ra duplakatt, megnyitva, a script-et oda is rá tudjuk tenni. Ezt csináltuk most, és továbbra is ezt hazsnáljuk

//--------------AKKOR IS SEMMISÍTSÜK MEG HA IDŐ MÚLT EL----------------------------------------

using UnityEngine;

class AutoDestroy : MonoBehaviour
{
    [SerializeField] float destroyDistance = 100;
    [SerializeField] float destroyTime = 100;

    Vector3 startPos;
    float startTime;

    void Start()
    {
        startPos = transform.position;
        //        startTime = Time.time;                                //e helyett más

        //        Destroy(gameObject destroyTime);						// ezt még később kivette

    }

    private void Update()
    {
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if (currentDistance > destroyDistance)
        {
            Destroy(gameObject);
        }

        //        float age = Time.time - startTime;			// ezek helyett más
        //        if (age > destroyTime)
        //        {
        //            Destroy(gameObject);
        //        }
    }

    private void OnDestroy()
    {

    }
}


// ------------------- a tanári ami jó --------------------

using UnityEngine;

class AutoDestroy : MonoBehaviour
{
    [SerializeField] float destroyDistance = 100;
    [SerializeField] float destroyTime = 100;

    Vector3 startPos;
    // float startTime;

    void Start()
    {
        startPos = transform.position;
        // startTime = Time.time;

        // Destroy(gameObject, destroyTime);
        DestroySelf();
    }

    private void Update()
    {
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if (currentDistance > destroyDistance)
        {
            DestroySelf();
        }

        /*
        float age = Time.time - startTime;
        if (age > destroyTime) 
        {
            Destroy(gameObject);
        }
        */
    }

    void DestroySelf()
    {
        // ...
        Destroy(gameObject);
    }
}

//------------------rohanunk mint állat ez sem lesz jó----------------------

using UnityEngine;

class AutoDestroy : MonoBehaviour
{
    [SerializeField] float destroyDistance = 100;
    [SerializeField] float destroyTime = 100;

    Vector3 startPos;
    // float startTime;

    void Start()
    {
        startPos = transform.position;
        // startTime = Time.time;

        // Destroy(gameObject, destroyTime);
        DestroySelf();
    }

    private void Update()
    {
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if (currentDistance > destroyDistance)
        {
            DestroySelf();

            Invoke("DestroySelf", destroyTime)          // ezt nem szereti, mert ha átnevezi, akkor itt a string-ben megmarad
        }

        /*
        float age = Time.time - startTime;
        if (age > destroyTime) 
        {
            Destroy(gameObject);
        }
        */
    }

    void DestroySelf()
    {
        // ...
        Destroy(gameObject);
    }
}

//-----------------TANÁRI, VÉGLEGES------------------------

using UnityEngine;

class AutoDestroy : MonoBehaviour
{
    [SerializeField] float destroyDistance = 100;
    [SerializeField] float destroyTime = 100;

    Vector3 startPos;
    // float startTime;

    void Start()
    {
        startPos = transform.position;
        // startTime = Time.time;

        // Destroy(gameObject, destroyTime);   // Késleltetve

        Invoke(nameof(DestroySelf), destroyTime);
    }

    private void Update()
    {
        float currentDistance = Vector3.Distance(startPos, transform.position);
        if (currentDistance > destroyDistance)
        {
            DestroySelf();
        }

        /*
        float age = Time.time - startTime;
        if (age > destroyTime) 
        {
            Destroy(gameObject);
        }
        */
    }

    void DestroySelf()
    {
        // ...
        Destroy(gameObject);
    }
}

//----------------------------9. ÓRA VÉGE-----------------------------------





