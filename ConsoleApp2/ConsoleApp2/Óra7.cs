/*

// PREFERENCES: EXTERNAL EDITOR BEÁLLÍTÁS SZÜKSÉGES LEHET HA HIBÁVAL SZÁLL EL A UNITY!!!!!!!!!!!!!!!!!
// ---------------------------------------------------------------------------------------------------




//  --------------------------------- HÁZI FELADAT MEGOLDÁSA --------------------------------

//---- unity alapcucc alatt írjuk, nem simán VS alatt, így eltérhet

//-----NxN feladat

// Ö ezt start-ba tette UNITY alatt, hogy fusson, tesztelhető legyen
// a sok n-ben a lokális változót használja, ezért tud több helyen is n-t hazsnálni, mert az pl. egy if-en belül "él" csak, kívül nem
// ettől nevezhetjük "lokális"-nak. Ha "SerializeField"-ben van egy int n onnan globális az az n;
// ha a serializefield n-jét akarjuk a kódon belül "debugoltatni", akkor a kiíratás this.n (osztály változója)
// ha statikus int n akkor "class_név_megadása_kell.n" unity-n belül

// ha statikusból csak egyet hozunk létre, és tudjuk, hogy egy lesz belúőle bárhol a kódunk során, akkor ezt hazsnáljuk - ugyanúgy lehet
// egy metódus is statikus, nem csak egy változó
// pl MATF-ben előre megírt statikus függvények vannak.
// 


using System;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Numerics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

WriteFirstNumbers(int n);               // itt pl hívjuk

void WriteFirstNumbers(int n)           // ez a "fő" kódunk. Bárhol lehet hívni így: "WriteFirstNumbers (30);" --> 30 számra fut meg
{
    int found = 0;

    for (int i = 1; found < n; i++)
    {
        int SumOfDigits(int n);

        if (SumOfDigits == n)
        {
            found++;
            Debug.Log(i);   // pl ha itt nem a belső n kell, hanem a serialize (this.n) vagy static (classneve.n)
        }
    }

}


int SumOfDigits(int n);                 // ez itt a segédfüggvény. A számolásban segít
{
    int sum = 0;

    while (n != 0)                      // az n > 0 mínuszra is érvényes, ezért nem azt írtuk be
    {
        int lastDigit = n % 10;
        sum += lastDigit;
        n /= 10,
		}
    return sum;
}


// -------------------------------------------------------------------------------------

// --------------- Mi a statikus és mi nem ----------------------------------
    
    // v.Normalize() akkor ezen csinálom		// nem statikus
    // float distance = Vector2.Distance(v1, v2);	// statikus

// -----------------------------------------

//TANÁRI VERZIÓ KIMÁSOLVA (ugyanaz, mint fent, csak tekergette, magyarázgatott dolgokat

using UnityEngine;

public class NTimesN : MonoBehaviour
{
    [SerializeField] int n;	                // nem része csak bennemaradt

    static int x;		                    // nem része, csak bennemaradt

    void Start()
    {
        WriteFirtsNumbers(n);
    }

    void WriteFirtsNumbers(int n)
    {
        int found = 0;

        Vector2 v1 = new Vector2(2, 4);                 // normalizálást magyarázta, nem része
        Vector2 v2 = new Vector2(2, 4);                 // normalizálást magyarázta, nem része

        v1.Normalize();                                 // normalizálást magyarázta, nem része

        float distance = Vector2.Distance(v1, v2);      // normalizálást magyarázta, nem része


        for (int i = 1; found < n; i++)
        {
            int sumOfDigits = SumOfDigits(i);

            if (sumOfDigits == n)
            {
                found++;
                Debug.Log(i);
            }
        }
    }

    int SumOfDigits(int n)
    {
        int sum = 0;

        while (n != 0)
        {
            int lastDigit = n % 10;
            sum += lastDigit;
            n /= 10;
        }
        return sum;
    }
}

// -----------------------------------------------------------------------

// Köv feladat: HUF-os példa átbeszélése --> Ebből valami újat tanulunk

using UnityEngine;

class NotesAndCoins : MonoBehaviour
{
    [SerializeField] int amount = 10000;	// ami a gámában beírok, 
    [SerializeField] int notesAndCoins;     // azt itt egyből vissza is adja (mert "onvalidate"-ben dologozunk, az onvalidate
                                            // bármilyen változás esetén rögtön validál (erre jó, ez az új info itt)

    void OnValidate()
    {
        notesAndCoins = HowManyNotes(amount);
    }


    readonly int[] notes =			                                // readonly beírás: lockoltam (tömbnél, változónál "const" float pi=3.14f)
        {20000,10000,5000,2000,1000,500,200,100,50,20,10,5,2,1};
                                                                    // (a readonly nem kötelező)

    int HowManyNotes(int num)
    {
        int result = 0;
        for (int i = 0; i < notes.Length; i++)
        {
            int noteValue = notes[i];
            result += num / noteValue;
            num = num % noteValue;
        }

                                                                    // (foreach ciklus is használható for helyett), ezt kijelöléssel,
                                                                    // és "ajánlatkéréssel" lehet megkérni a VS-ben. kiseréli (QUICK ACTIONS)
        return result;
    }
}


// --------------------------------------------------------
// for listából törlés vezélyes - tömb fix elemű, list változtatható hosszú, a kkveszünk, csökken a tömb elemek száma, már 
// pl nem mas index lesz, hanem kette, mert a 3-mast töröltük. Hátulró megyünk végig, ha ki akarunk belőle elemeket venni
// QUICK ACTIONS a felajánlás (reverse)
// for (....notes.length - 1; ..i--)
// Tömb átlaga
//
// -------------------------------------------
// Ugyanaz amit néztünk, csak Foreach-al rövidebben
//...
foreach (float n in array)
	{
    mean += n;
    }

mean /= array.length;
//...

// ---------------------------------------
// TANÁRI KIMÁSOLT VERZIÓ JÖN, UGYANAZ MINT FENT

using UnityEngine;

class MeanOfArray : MonoBehaviour
{
    [SerializeField] float[] floats;
    [SerializeField] float mean;

    void OnValidate()
    {
        mean = Mean(floats);
    }



    float Mean(float[] array)
    {
        float mean = 0;

        foreach (float n in array)
        {
            mean += n;
        }

        mean /= array.Length;

        return mean;
    }

}


//----------------------------END PÉLDA-------------------------------------------------------



// --------------------------- 7. ÓRA ANYAGA ------------------------------


// UNITY_n belül próbáljuk követni, hogy mit csinál, de túl gyors, csak annyi van meg, amit fel tudtam írni

// Csináltunk egy új Scene-t ez 2D játék lesz
// A fényt törölte (object), mert elvileg 2D alatt nem kellenek a fények, nem használjuk
// Ezt követően a skybox-ot akarja átállíttatni velünk, de nem simán, hanem más módon

// Windows - rendering - lighting ---> environment fülön Skybox material  - none. Ezt kell beállítani, de alapból a lightning-et jobbra
// felülre kitette, mint egy új fület. Ezt nem kelle, de...

// A szükséges háttereket nem értük el, mert rossz helyen voltak a gépen. A tanár kint másolta, de én meg kijelöltem Unity-n belül és úgy
// másoltam át, --> Assetekhez bemásoljuka képeket, különben nem ismeri fel őket (ha nincs Asset könyvtár akkor kell) - háttereket

// Textture type - sprite-ra állítva

//  Sprite renderer:  --> sprite-re húz be képet

// Tile Mode - continuous

//  W: 200.H: 40

//  KÉP

// Üres Game Object létrehozás

// spaceship - üreg game objectbe. Fontos, hogy induláskor a háttér "mögött van". ezt lehet kezelni azzal, hogy Z: -0.5 vagy hasonló
// de ebből pl. nálam gond volt, mert egyszercsak a hajkó lefelé menet eltűnt. Kiderült, hogy ez azért van, mert amikor központban van
// a hajó, a kamera központjában is, de ahogy megy pl lefelé, úgy a kamera központja meg középen marad, de ettől a játékos meg már távolabb
// kerül, tehát nem ugyanaz a távolság, és ez okozhat problémát
// SOKKAL JOBB: ha a SORTING ORDER-t használjuk!! a biztodan nem csinál ilyen gubancot

// -----------------------------------------------------------------------------------------------------------------------------


// ----------------------Mozgunk az űrhajóval (lépésenként vesszük, ugyanazt a kódot bővítjuk majd -----------------------------

// -----------ALAPKÓD-------------
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    void Update()
    {
        Vector2 velocity = new Vector2(1, 2);                               // 2D vektorból indulunk ki (2D játék)

        transform.position += (Vector3)(velocity * Time.deltaTime);         // muszáj átkonvertálni, ert itt ez 3D-s vektor pozi
    }
}

// és már mozog is

// -----------PICI VÁLTOZÁSOK: GYORSÍTÁS, GOMBNYOMÁSRA MENJEN-------------

using UnityEngine;

public class Spaceship : MonoBehaviour
{

    [SerializeField] float acceleration = 1;                                // hozzáadjuk a gyorsítást

    Vector2 velocity;                                                       // áttettük osztályváltozóba, nem történik semmi (nem mozogna így)

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))                                  // gombnyomás
        {
            velocity += (Vector2)transform.up * (acceleration * Time.deltaTime);    // nem velocit, hanem accelerationnal szorozzuk
                                                                                    // zárójelbe téve, hogy 4 szorzás helyett 3 legyen
                                                                                    // egyenletes gyorsulás még hozzájön
        }

        transform.position += (Vector3)(velocity * Time.deltaTime);
    }
}

// ha így használjuk és elforgatom, akkor ő más irányba fog menni, mert a saját felfeléje és nem globális felfeléje van
// (amerre néz, arra van a felfelé)

// --------------------------- MÉG PICI KORREKCIÓ, FORGÁS -----------------------------

using UnityEngine;
using UnityEngine.UIElements;

public class Spaceship : MonoBehaviour
{

    [SerializeField] float acceleration = 1;        
    [SerializeField] float angularSpeed = 100;                                          // fokban várja a forgásnál

    Vector2 velocity; 

    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.deltaTime);    
        }

        transform.position += (Vector3)(velocity * Time.deltaTime); 

        float rotate = Input.GetAxis("horizontal");                                     // figyelnio fog a WASD-re (előre megírt cucc)

        transform.Rotate(new Vector3(0, 0, rotate * angularSpeed * Time.deltaTime));    // ez változik
    }
}

// ----------------------------- NEHOGY VALAMI SZAR LEGYEN ITT A TANÁRI KÓD ---------------------------------------

using UnityEngine;

class Spaceship : MonoBehaviour
{
    [SerializeField] float acceleration = 3;
    [SerializeField] float angularSpeed = 200;

    Vector2 velocity;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.deltaTime);
        }

        transform.position += (Vector3)(velocity * Time.deltaTime);

        float rotate = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, 0, rotate * angularSpeed * Time.deltaTime));
    }

}

// ---------------MEGYÜNK TOVÁBB, KÖZEGELLENÁLLÁS (EGYBEN MAX SPEED KORLÁT), ROTÁLÁS KORRIGÁLÁS------------------

using UnityEngine;

class Spaceship : MonoBehaviour
{
    [SerializeField] float acceleration = 3;
    [SerializeField] float angularSpeed = 200;
    [SerializeField] float drag = 1;                             // közegellenállás (ha nem nyomunk gombot, lassuljon)

    Vector2 velocity;

    void Update()
    {
        //gyorsítás
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.deltaTime);
        }

        //közegellenállás (lassítás)
        velocity -= velocity * (drag * Time.deltaTime);


        // mozgás
        transform.position += (Vector3)(velocity * Time.deltaTime);

        
        //forgás
        float rotate = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, 0, -rotate * angularSpeed * Time.deltaTime));    // - rotate, mert fordítve adta a gombokra a hatást
    }

}

// a drag ezzel gyakorlatilag végsebességet is ad, nem tudunk gyorsulni jobban egy idő után, ezáltal van egy maximális sebességünk
// Drag: 0,65, Acceleration: 20. Angular Speed 200 --> TRÜKK: Ha UNITY-n belül állítgatunk, nekünk megfelelő beállításokra, és megvan
// az amit szeretnénk (mindezt a "play" során kell tenni) --> "spaceship" komponensen jobbgomb - copy componenet, majd leállít
// így át tudjuk vinni a "STOP", vagyis szerkesztés módba az összes beállítást, így nem kell mejgeyezni és bepötyögni őket kézzel
// --> leállít majd "paste component values", ezzel lehet átmenteni
// (jobbgomb - copy component, paste component values)


// ---------------------------------TOVÁBB, GYORSASÁG MAXIMALIZÁLÁSA-------------------------------------------

class Spaceship : MonoBehaviour
{
    [SerializeField] float acceleration = 3;
    [SerializeField] float angularSpeed = 200;
    [SerializeField] float drag = 1;          
    [SerializeField] float maxSpeed = 5;

    Vector2 velocity;

    void Update()
    {
        //gyorsítás
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.deltaTime);

            if (velocity.magnitude > maxSpeed)                                      // vektor hossza (magnitude) nagyobb-e mint maximális
                                                                                    // sebesség
            {
                velocity.Normalize();                                              // ha igen, akkor beállítja a maximális sebességet
                                                                                   // lehet nem érzékeljük, mert a közegellenállás is maximalizál
                                                                                   // de ezt lehet hazsnálni, ha túl sok, vagy más értéket
                                                                                   // akarunk szabályzoni
                                                                                   // lehet helyette:
                                                                                   // velocity = velocity.normalized * maxSpeed;
                                                                                   // másik megoldás (ez nem normalizál, hanem lekéri a
                                                                                   // normalizáltat és szorozza egy sorban)
                velocity *= maxSpeed;
            }
        }

        //közegellenállás (lassítás)
        velocity -= velocity * (drag * Time.deltaTime);


        // mozgás
        transform.position += (Vector3)(velocity * Time.deltaTime);


        //forgás
        float rotate = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, 0, -rotate * angularSpeed * Time.deltaTime)); 
    }

}

// -------------------------------------------------------------------------------------------------


// ----------JÖN ALUL :FIXED UPDATE sima UPDATE helyett (fix idő alatt tutira, fizikai szimulációhoz ezt érdemes használni.------------
//  OLVASD el az anyagban ami a fizikai szimulációra vonatkozik


using UnityEngine;

class Spaceship : MonoBehaviour
{
    [SerializeField] float acceleration = 3;
    [SerializeField] float angularSpeed = 200;
    [SerializeField] float drag = 1;
    [SerializeField] float maxSpeed = 5;

    Vector2 velocity;

    void FixedUpdate()                  // ez segít fix időben kezelni mindent, de itt NEM JÓ a "time.DeltaTime"
                                        // a fixed update végképp nagyon erősen figyel rá, hogy minden pontosan időben történjen
                                        // amíg a delta time és update alatt pl: ha üldöz egy medve és egy gépen pont nem kap el
                                        // de az századminilmétereken múlik, úgy lehet, hogy egy sokkal lasabb gépen pont elkap a medve
                                        // ez segít ezt kiküszöbölni, de nem szabad minden esetben hazsnálni
    {
        //gyorsítás
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.fixedDeltaTime);           // FIXED UPDATE ALATT MINDÍG FIXED DELTA TIME!

            if (velocity.magnitude > maxSpeed)                                                  {
                velocity.Normalize();                  
                velocity *= maxSpeed;
            }
        }

        //közegellenállás (lassítás)
        velocity -= velocity * (drag * Time.fixeddeltaTime);                                    // FIXED


        // mozgás
        transform.position += (Vector3)(velocity * Time.fixedDeltaTime);                        // FIXED

        //forgás
        float rotate = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, 0, -rotate * angularSpeed * Time.fixedDeltaTime));      // FIXED
    }

}

// Project settings - time alatt állítható a fix idő, ha nem felel meg a defeult

// ---------------------TOVÁBB: NEM KELL MINDENHOL A FIXED, NEM IS JAVASOLT, CSAK AHOL KELL (LÁSD ALUL)-----------------------

using UnityEngine;

class Spaceship : MonoBehaviour
{
    [SerializeField] float acceleration = 3;
    [SerializeField] float angularSpeed = 200;
    [SerializeField] float drag = 1;           
    [SerializeField] float maxSpeed = 5;

    Vector2 velocity;

    void FixedUpdate()                  
    {
        //gyorsítás
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.fixedDeltaTime);           // FIXED

            if (velocity.magnitude > maxSpeed)                                     
            {
                velocity.Normalize();                    
                velocity *= maxSpeed;
            }
        }

        //közegellenállás (lassítás)
        velocity -= velocity * (drag * Time.fixedDeltaTime);                                    // FIXED

    }
    void Update()
    {
        // mozgás
        transform.position += (Vector3)(velocity * Time.deltaTime);                            // NEM FIXED

        //forgás
        float rotate = Input.GetAxis("Horizontal");

        transform.Rotate(new Vector3(0, 0, -rotate * angularSpeed * Time.deltaTime));          // NEM FIXED
    }

}


// -----------------------------------TOVÁBB: BOOST - tanári vgleges verzió----------------------------------------

using UnityEngine;

class Spaceship : MonoBehaviour
{
    [SerializeField] float acceleration = 1;
    [SerializeField] float angularSpeed = 360;
    [SerializeField] float drag = 1;
    [SerializeField] float maxSpeed = 5;
    [SerializeField] float boostSpeed = 5;                            // BOOST. egyszeri boost (max speed okozhat
                                                                      // problémát, ha benyomjuk pl 2 mp-re. opció
                                                                      // lehet ha ki kapcsoljuk a max spped-et

    Vector2 velocity;

    void FixedUpdate()
    {
        // Gyorsítás
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += (Vector2)transform.up * (acceleration * Time.fixedDeltaTime);

            if (velocity.magnitude > maxSpeed)
            {
                // A
                velocity.Normalize();
                velocity *= maxSpeed;

                // B - másik megoldás amiről már szó volt felül
                // velocity = velocity.normalized * maxSpeed;
            }
        }

        // Lassítás (Közegellenállás)
        velocity -= velocity * (drag * Time.fixedDeltaTime);

    }

    void Update()
    {
        // Dash
        if (Input.GetKeyDown(KeyCode.Space))                                            // space gomb lenyomásával (getkeydown)
        {
            velocity += (Vector2)transform.up * boostSpeed;                             // BOOST hozzáadása
        }

        // Mozgás
        transform.position += (Vector3)(velocity * Time.deltaTime);


        //Forgás
        float rotate = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, 0, -rotate * angularSpeed * Time.deltaTime));
    }

}

//getkeydown pillanatnyi esemény, lassaban történik, ezért nem mindí működik  GETKEYDOWN


//---------------------------------------------------------------------------------------------------------


// -----------------------KAMERA FOLLOW AMI MIMINEK KELL --------------------------

using UnityEngine;

class FollowerCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }


    void Update()
    {
        transform.position = target.position + offset;
    }
}

// ----------------------- csak egy "AREA" után induljon el a kamera (köríven belül nem, csak kívül) --------------------

using UnityEngine;

class FollowerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range;


    Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;    // a legvégén derült ki, hogy szar volt a kód mert ez volt végig benne
                                                                   // amiért nem működött: offset = transform.position - target.position;
                                                                 
    }


    void Update()
    {
        Vector3 offsetedPos = transform.position + offset;

        // float distance = Vector3.Distance(offsetedPosition, target.position);   //ez volt az előzőben, amivel próbálkozott

        Vector3 difference = target.position - offsetedPos;                 // erre cserélte, ez nem volt benne a kódban
        float distance = difference.magnitude;                              // erre cserélte, ez nem volt benne a kódban
        if (distance > range)                                               // erre cserélte, ez nem volt benne a kódban
        {                                                                   // erre cserélte, ez nem volt benne a kódban
            Vector3 dir = difference.normalized;                            // erre cserélte, ez nem volt benne a kódban
            float length = distance - range;                                // erre cserélte, ez nem volt benne a kódban

            transform.position += dir * length;                             // e helyett ez volt. az IF ág sem volt, azon kívül volt ez:
                                                                            // transform.position = target.position + offset;
        }                                                                   // erre cserélte, ez nem volt benne a kódban
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 offsetedPos = transform.position + offset;          // ez új, második körben került bele
        Gizmos.DrawWireSphere(offsetedPos, range);                  // csak akkor kövessük ha a körből kilépett // ez új, előtte más volt
                                                                    // méghozzá ez: Gizmos.DrawWireSphere(target.position, range);
    }
}


//--------------------------------------------------------------------------------------------------

// ---------------------------LEHET OLYAN ELEMET KÉSZÍTENI AMI SEGÉDESZKÖZ-----------------------------------------

// Ha pl. platform játékot akarunk, és nem akarjuk folyamatosan a kézzel méretezett objektumunkhoz kézzel hozzáméretezni
// a collider méretét, ezt (csak és kivéve a 2D játékoknál és csak némely típusra lehet ilyet, de segítség
// alul ezt tanuljuk


// ---------------------BoxColliderAutoSize:-----------------------

using UnityEngine;

[ExecuteAlways]                                                             // ezt a 2. körben adtuk hozzá, hogy MINDÍG megfusson, bármi van
[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]           // ez azt jelenti hogy megköveteli a létezését ezeknek
class BoxColliderAutoResizer : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;                             // létrehozzuk őket
    [SerializeField] SpriteRenderer spriteRenderer;

    void OnValidate()                                                       // bármi módosulásnál fut majd, vedzi az elemeket
    {
        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()                                                           // itt meg ugyanazzá a méretté teszi
    {
        boxCollider.size = spriteRenderer.size;
    }

}

// -------------------ÉS A VÉGLEGES VERZÓ (JÁTÉKON BELÜL MEGSZŰNTETJÜK)------------------------------------------------

using UnityEngine;

[ExecuteAlways]                                                     
[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
class BoxColliderAutoResizer : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] SpriteRenderer spriteRenderer;

    void OnValidate()
    {
        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Start()                // ez új
    {
        if (Application.isPlaying)      // ha fut az alkalmazás....
            Destroy(this);              // semmisítsd meg (ezt) --> megsemmisítés (this = komponens,
                                        // this.gameobject = a játékobjektumot is törli
                                        // Azért, hogy ez játékon kívül létezzen csak, utána kuka
    }

    void Update()
    {
        boxCollider.size = spriteRenderer.size;
    }

}

//------------------------------------------------------------------------------------------------

// ------------------------------ EGY PICI FIZIKA -------------------------------

// create - 2d material - physics material 2d
// rá kell húzni a játékosra, pattogást lehet pl állítani
// ez kb emlékeim szerint ugyanott jött létre, ahol a scriptjeink szoktak UNITY-n belül látszani


// --------------------------------PLATFORM JÁTÉK, UGRÁS ------------------------------------

using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rB;
    [SerializeField] float jumpSpeed;


    void onValidate()
    {
        if (rB == null)
            rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rB.velocity = Vector2.up * jumpSpeed
        }
    }
}

// ------------------------KIBŐVÍTVE GROUNDED ÉS COLLISION (azaz groundeddé válás) ---------------------

using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed; // mivel itt nem adtunk meg értéket, a játékba kell. Vagy itt megadni

    bool grounded = false;

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
            if (grounded)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}

//-----------------------MEGSPÉKELVE DUPLAUGRÁSSAL (AIRJUMP)---------------------------------

using UnityEngine;

class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField, Min(0)] int airJumpCount = 1;

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

*/