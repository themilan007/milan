
/*


// -------------------------- 5. �RA -------------------------------

// El�zm�nyek �s egy kis plusz

// vector3 p = transform.position  (localScale), quaternion..rotation --> lok�lis vagy glob�lis m�dos�t�sokat hajtunk v�gre
// vector3 p2 = transform.localPosition (losyScale) local...

// transform.position = center;  ---> k�z�pre tessz�k a transform hely�t (pivot point)

//--------
// [serializefield] gamoboject2 transform...   --> serialize-ben l�trej�tt elem
// ... gameobject2.transform....               --> k�db�l �gy lehet h�vni

// -----------------------
// LESZ MAJD K�S�BB: referencia, egyik script odasz�l a m�siknak -- majd tanuljuk

//-----------------
// mesh filter - oda h�zod a mesh-t (serialize)

// mesh renderer - fontos (serialize).. - mater�l hat�rozta meg, milyen legyen a felsz�ne


// --------------

// 3d = mesh, 2d = sprite

//----------------

// 0,3 float - unity -- nem tudja kettes sz�mrendszerben, a float �s double vmi nagyon k�zelit ad vissza, vagyis 0.3333333.. a bouble
// sokkal t�bb 3333... at tud ki�rni, t�rolni, ez�rt ha nagyon prec�z valami kell, az double lesz

// ---------------------------------------------------------


// -------------------------- 2D -------------------------------

// UNITY: �j scene, 2 d create empty, sprite rendere, sprite
// berakja, de nem l�tjuk be kell poz�cion�lni a kamer�t, hogy a kamera ter�ben legyen benne a 2D objektum
// perspekt�v, ortografikus kamera, 45 fokos sz�g f�gg. v�zszint (izometrikus)
// v�g�sik, el�ls�, h�tuls� v�g�s�k t�rb�l ezt v�gjuk ki. Ez kb. a kamera mit l�t, t�l-ig
//-----------------

// Sprite

// ahhoz, hogy hazsn�ljuk, minimum kell el�tte a package Manager -- ut�na 2d sprite (install)
// ugyanitt van pl. a sprite anim�ci�hoz a rigging �s mozgat�s is (bone elemek. A sprite-hez csontszer� elemeket rendel�nk, kb: fej, nyak,
// gerinc, jobb felkar, jobba alkar, esetlej jobb k�zfel, ugyanez a bal k�zn�l is, illetve l�bakn�l is (comb, s�pcsont, l�bfej). Ez az�rt
// izgalmas, mert ha ezeket a csontokat elmozgatjuk (pl: l�p a karakter), 0 k�pkock�n �ll, 30 k�pkock�n l�p, azt�n 60-n�l m�sik l�bbal l�p
// a szoftver a k�ztes l�p�seket kisz�molja, megcsin�lja, �gy lehet UNITY-n bel�l mozgatni pl egy ember karaktert
// --------------------


// Pixels per unit (a k�pen mag�n h�ny pixel legyen 1 egys�g  )  -- be�ll�thatjuk hogy a t�rgy egy unit-os legyen (nem csinlunk ilyet mert
// pici lenne, de ha elk�pzelj�k, akor a r�csszerkezetben 1 kock�nyi, vagyis 1 unit l�ptet�ssel m�r a r�csszerkezeten is eggyel od�bb lenne

// sprite sheet - megtekinthet�, ha bet�lt�tt�k a sprite-ot (sprite editor a men�ben

// -----------------------

// Sprite Editor most m�r el�rhet� ha UNITY-ben telep�tett�k a fent le�rtakat

// -------------

// Pivot point nem a k�zep�n van, figyelni kell r�. Ne�nk kell majd be�ll�tani, hol legyen a t�rgyunk "k�zepe" (forg�spont)
// Sprite �s m�s k�pek, Unity f�jlok eset�ben fontos: mindennek van egy meta file is (mindennek van, a hangoknak is). Meta- extra info benne
//Ha m�solunk k�nyvt�rb�l k�nyvt�rba, akkor a meta file-t is m�solni kell Ha Unity bel�l csin�lod a m�sol�st, az viszi. Ha kint m�solsz, �gyelj

// Automatikusan fel lehet darabolni (slice, automatic slice) - revert vagy apply. A Sprite drabol�sa j�l j�het

// Sprite nagyon fontos be�l�t�s: "DRAW Mode" simple, slice, tiled - akkor lehet tiling-et csin�lni, ha tiled-be �ll�tod, sz�pen ism�tli mag�t
// pl ha l�tr�t hozol l�tre, vagy "f�ldet" 2D m�dban, nem kell egyes�vel elhelyezni a t�rgyadat, sokszor, 1 t�rgy is el�g

// Sprite editorn�l, hogy ez egy full rack? ha ezt be�ll�ottuk, akkor lehet csermp�zni. -- ERRE MAJD R� KELL J�NNI, MIT AKART A TAN�R MONDANI
// ---------------------------

// 2d k�pekn�l is van mormal map - f�nyvisszaver�s, tud reag�lni f�nyekre. Ha van normal MAP-unk

//---------------------------

// Sprite renderer vs Sprite renderer - sprite-n�l mind�g egyik sprite vagy el�r�bb, vagy h�tr�bb, itt nincs �tfed�s (f�lig el�l, f�lig h�tul
// 3d eset�n lehet �tfed�s
// Ha mindkett�t null�ba tessz�k, akkor nem tudjuk megmondani, melyik lesz el�l, m�lys�g v�toztat�s kell, a g�p d�nti el ugyanazon a poz�ci�n

// Sorting LAyer, sorrendet ad a spriteoknak.

// kb a 2D-r�l a tan�r ennyit akart elmondani, v�gign�zt�k a men� egy r�sz�t, a t�bbit majd ki kell tal�lni

//--------------------------------



// --------------------------------------- A F�NY "DIMMEL�SE" (GYENGE-ER�S) --------------------------------------

// Light

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;                   // Men�ben megjelen�tjuk a "Light" v�ltoz�t aminek egy eleme a light
 // [SerializeField] Color c1, c2;                  // Men�ben a sz�n, aminek k�t eleme a c1 �s c2. Ezzel "csak" l�trehozom

    [SerializeField] Color c1 = Color.white;        // k�l�n-k�l�n is l�trehozhat�, ezzel egyb�l sz�nt is tudok naki adni
    [SerializeField] Color c2 = Color.white;

    void Update()
    {
        
    }
}

//------------
// UNITYBEN BEL�L: Ha itt l�trej�n �s �ll�tom a sz�neket, alatta van egy cs�k. ami feh�r, az alpha csatorn�t fel kell h�zni, mert az az
// �tl�tsz�s�g ami alapb�l nulla. Az is lehet, ha "gyenge" a f�ny, hogy �ll�tani kell rajta

//---------------------

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
    [SerializeField, Range(0,1) ] float dim = 0; // plusz ezzel a sorral azt csin�ltuk, hogy cs�szkak�nt hozom l�tre. MIND�G 0-1 k�z�tti �rt�k!
 

    	void OnValidate()               // ezzel oldjuk meeg, hogy b�rmilyen v�ltoz�sn�l unity-n bel�l is egyb�l l�ssuk a v�ltoztat�st
    {                                   // azaz r�gt�n jelen�tse is meg minden "validate" eset�ben. En�lk�l nem friss�ti be elvileg
        Update();
    }

    void Update()
    {
        light.color= Color.Lerp(c1, c2, dim); // fent csak a "k�zi" �ll�t�st hoztuk l�tre, a "LERP" seg�ts�g�vel a f�ny �tmenet�t �ll�tjuk be
    }
}

// -------------------

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
//  [SerializeField, Range(0, 1)] float dim = 0         // kidobtuk ezt a sort. Nem k�zzel akarjuk kezelni, hanem "sim�tva" menjen oda-vissza
                                                        // a sz�n, ebben a r�szben ezt tanultuk (sz�nusz f�ggv�nyt hazsn�lunk)
    void OnValidate()   
    {
        Update();
    }

    void Update()
    {
        float t = Time.time;                            // lek�rdezz�k mennyi id� m�lt el a j�t�k kezdete �ta
        float sin = Mathf.Sin(t);                       // a sz�nusz v�ltoz�nak a Mathf-b�l a szinuszt haszn�ljuk (t v�ltoz� �rt�kkel)           
        light.color = Color.Lerp(c1, c2, sin);          // LERP annyit v�ltozik, hogy az ut�ls� DIM �rt�k helyett a SIN v�ltoz�t (�rt�ket) adjuk
                                                        // Mivel a sz�nus 1 �s -1 k�z�tt m�szk�l ezt �t kell konvert�lnunk
        sin += 1;                                       // ezzel a -1 b�l pl nulla lesz, -0,5 -b�l 1,5... �s �gy tov�bb
        sin = sin / 2;                                  //ezzel meg elosztjuk kett�vel. �gy az �rt�k biztosan nem megy 1 f�l�
                                                        // �gy tudjuk biztos�tani, hogy nulla �s egy k�z�tt legyen mind�g az �rt�k
    }
}

// ---------------------------------------

using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
    [SerializeField] float frequency = 1;           // legyen sebess�ges is, milyen gyorsan �r �t egyik sz�nb�l a m�sikba �s vissza

    void OnValidate()   
    {
        Update();
    }

    void Update()
    {
        float t = Time.time;   
        t *= frequency;                             // az el�z�ekben lek�rdezett, j�t�kben eltelt id�t szorozzuk a frekvenci�val
        t *= Mathf.PI * 2;                          // azzal kell szorozni, ami a teljes sz�less�g (sk�la), 2*PI radi�n, mert fokkban kell

        float sin = Mathf.Sin(t);
        sin += 1;                                   // ezeket �temelt�k a LERP el�, �gy m�k�dik j�l
        sin /= 2;

        light.color = Color.Lerp(c1, c2, sin); 

    }
}

// -------------------------------------------------------------------------------------


// ----------------------------------- COLLIDER, TRIGGER HASZN�LATA ---------------------------------------------

// UNITY: collidereket levessz�k az enemy-r�l, gyerek objectn�l, j�t�kosr�l is. A l�nyeg, hogy felesleges ennyi, hacsak pl. nem sebz�st
// akarn�l n�zni, k�l�n pl: headshot, akkor kell k�l�n, de egyszer�bb j�t�kokn�l az "eg�sz"-re n�zz�k
// visszatessz�k ahova kell, de �sszesen 1 collidert tesz�nk egy j�t�k elemre (itt: j�t�kos, ellenf�l, akad�ly)
// ha nem collidert (�tk�z�st) n�z�nk, hanem csak �ssze�r, az trigger ("ISTrigger" bekapcsol�sa a j�t�k elemekn�l)
// mindh�rmon be�ll�tottuk "IsTrigger"-re
// csin�ltunk egy "damager" �s egy "HealthObject"-et (script) unity-n bel�l

using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;       // a "serialize"-n bel�l megadtuk a minimum lehets�ges �rt�ket (1), a "maxHealth"
                                                        // v�ltoz�nak meg 100-at, hogy mi lehet a meximum, �s azt be is �ll�tottuk 100-ra
    int currentHealth;                                  // l�trehoztuk a jelenlegi �letet
}
//- - - - - - - - - - - - 

using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;                   // a s�r�l�s �rt�k�t 10-re �ll�tottuk

    void OnTriggerEnter(Collider other)                 // "OnTriggerEnter" �j. Sok ilyen param�tere van m�g. 2d-s v�g� = 2d j�t�kban !
    {                                                   // Azt mondtuk, hogy a collider, amire majd r�tessz�k figyelje a parm�terben
                                                        // megadott v�ltoz�t. Az "other" azt jelenti, hogy mindeegyiket figyelje (minden m�s)

        GameObject go = other.gameObject;               // b�rmilyen komponenst�pust�l elk�rj�k a game objectj�t (other).
                                                        // Semmi akad�lya, hogy l�thatatlan fal legyen, vagy �ts�t�lni valami megrajzolton. 
        Debug.Log(go.name);                             // ezt a "go"-t csak a debug ablakban val� ki�rat�sra csin�ltuk, am�gy nem fog kelleni
    }
}

// amikor a 2 collider tal�lkozik, ellen�rzi a scipteket, megn�zi a SW minek kell t�rt�nnie.
// Az OnTriggerEnter - most �rkeztek, �pp tal�lkoztak , OnTriggerExit - kil�pett, OnTriggerStay - ciklikusan fog h�v�dni, j�n az �zi hogy benne
// van egyik am�sikban, am�g ez nem v�ltozik meg

// Enemy, obstacle -- damagert r�juk, magunkra meg a health-et tessz�k fel.


// ----------------------  BESZ�RT INFORM�CI�: HIBAKEZEL�S A K�DBAN, UNITY-BEN ----------------------------------

// Ha a k�dban legjobb (NEM LEG BAL OLDAL?) oldalon adunk k�dba cehckpointot �s ut�na attach to unity, akkor ott meg�ll, unityben mutatja
// ha olyan helyen adtunk "break"-et / figyel�st, ahol nem t�rt�nik m�g semmi, ilyenkor a script leragadthat, Unity meg sem ny�lik meret nem
// ott tart.

// UNITY-n bel�l is van debug m�d, akkor ha bekapcsoljuk, l�tjuk pl az am�gy l�thatatlan �rt�ket, ahogy a sebz�s t�rt�nik, megy le az �let)

// Ha menetk�zben �tkattintok pl Projekt Asset-ekr�l, Consolee-re, �s nem kattintok a scene-be, akkor play ut�n pl. a karakterem nem megy.
// Bele kell MINDYG kattintani.

// --------------------------------------------------------------------------------------------------------------


// -------------------------------------- COLLIDER - FOLYTAT�S --------------------------------------------------

// UNITY: Legal�bb egy elemre tegy�k r� a rigidbody-t, innen tudja, hogy van valami "akci�", �s azt is mondjuk meg neki, hogy "IS kinematic"
// /teh�t kinematikus fizik�t haszn�lunk) 


using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;     // startn�l max health-hal indulunk
    }

    public void Damage(int damage)    // ha nem �rjuk ki a private-t, akkor az a default, a "public" jelenti, hogy m�shonnan is el�rhet�.
    {                                 // a PUBLIC mondja meg, hogy a script nem csak �nmag�ban dolgozik, scriptek k�z�tt �gy tudunk �tadni
                                      // az INT.DAMAGE ponttal volt �rva, de nem biztos, hogy �gy kell, kijav�tottam, de ha nem m�k�dik,
                                      // majd �rjuk vissza
        currentHealth -= damage;      // levessz�k a s�r�l�st 

        if (currentHealth<100)        // itt az if ut�n nem volt z�r�jel, �gy nem tudom, mi �s szerpelt-e egy�ltal�n valami a tan�rn�l
            Debug.Log("Auch");        // ha van s�r�l�s, a console �rja ki, hogy Auch
    }
}

// - - - - - - - - - - - - -

using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;

    void OnTriggerEnter(Collider other)  
    {
        GameObject go = other.gameObject;                   // go - mint gameobject v�ltoz�

        HealthObject ho = go.GetComponent<HealthObject>(); // ho - mint healthobject v�ltoz�. Kacsacs�r = �J. Ez is z�r�jel, sp�ci, mezei
                                                           // met�dus. Nincs param�tere, csak param�terszer�s�ge, nem lehet b�rhol haszn�lni,
                                                           // csak aki kezeli, ez itt a a kacsacs�rben az OZT�LYN�V a m�sik UNITY scriptb�l
                                                           // Ez generikus f�ggv�ny (olvass ut�na ha akarsz)

        if(ho != null)                                     // null egy �rt�k
        {
            ho.damage(damage);                             // UNITY SCRIPT M�K�D�S: ha itt r�nyomok az F12.re, akkor innen oda ugrik a m�sik
                                                           // k�dra, ahol haszn�lom (ha nyitva van t�bb k�d is
        }                                                  // ha a helath object nem nulla, akkor a health object s�r�l�se a damage-vel egyenl�
    }
}

// -------------------------------------


// --------- Health, legyen v�ge, aikor elfogy az �let ---------

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

        if (currentHealth <= 0)                             // ha a jelenlegi �let kisebb, vagy nulla, akkor �rja ki azt, hogy v�ge
        {                                                   // ennyi a plusz
            Debug.Log("Good By!");
        }
        // Debug.Log("Aucs!");                              // ezt kikuk�zzuk, m�r nem figyelj�k
    }
}

//- - - - - - - - - - - - - -

// A damagerben enn�l a l�p�sn�l nem v�ltoztattunk semmit

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


// ---------- folytassuk: az �let�nknek nem lenne szabad nulla al� mennie, �s egyszer �rja ki, hogy good bye.

using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    public int currentHealth;                           // ez itt az �j- Publikusan haszn�ljuk a k�vetkez�kben majd a currentHealth-et

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int damage)
    {
       //  currentHealth -= damage;

        if (currentHealth == 0) return;                 // PROGRAOZ�SN�L JAVSOLT: el�sz�r a "nem megy�nk tov�bb" minden lehets�ges esetre.
                                                        // Ak�r lehet 4-5 ilyen fel�tel, hogy ne is fusson, ha a felt�tel nem �gy teljes�l

        currentHealth = Mathf.Max(currentHealth, 0);    // ezzel egy sorba bele tudjuk tenni if �g haszn�lat helyett. Azt j�tsszuk el, hogy
                                                        // a maimumot keress�k a jelenlegi �let �s a nulla k�z�tt. Ez azt eredm�nyezi, hogy
                                                        // mind�g a jerlenlegi �let lesz a max, b�rmennyi is az, de null�ig tud csak lemenni

        if (currentHealth <= 0)
        { 
            Debug.Log("Good By!");
        }
    }
}

// A DAMAGER NEM V�LTOZOTT, NEM �ROM �JRA LE

// -----------------


// ---------------------------CSAK AKKOR MOZOGHATUNK HA VAN �LET�NK. HA NINCS �LLUNK MEG --------------------------

// ez el�tt tett�k publikuss� a "public int currentHealth-ot (a fenti HealthObject scriptben)
// Most a Mover-en kell dolgoznunk a folytat�sban

using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;                       // sebess�g
    [SerializeField] Transform cameraTransform;             // kamera transform be�ll�t�sa
    [SerializeField] bool moveInCameraSpace = true;         // a kamera ter�ben mozogjon
    [SerializeField] float angularVelocity = 100;           // fordul�si mozg�s/sebess�ghez
    [SerializeField] HealthObject healthObject;             // ez az �j- Eredetileg HealthObject = healthObject-et �rtam, deszerintem az rossz
                                                            // �gy. Ha m�gsem, akkor vissza kell majd jav�tani arra, de a progi hib�t adott.

        private void OnValidate()                                       // ha private nem kellene ki�rni, lehet, hogy ez is public? nem hiszem 
    {                                                                   // val�sz�n�bb, hogy csak nem kell a "private" el�
        if (healthObject == null)
        HealthObject healthObject = GetComponent<healthObject>();       // ha nulla, akkor a HealthObject v�ltoz�ja (healtObject) kapja meg a 
    }                                                                   // healthObject komponenst. Gondolom itt azt biztos�tjuk, hogy biztos
                                                                        // legyen neki mefelel� �rt�ke, amikor ind�tjuk el�sz�r �s m�g nincs
    void Update()
    {
        if (healthObject.currentHealth <= 0) return;                    // ez a kiv�telkezel�s. Ha �let kisabb vagy nagyobb, mint nulla, akkor
                                                                        // kil�p, vagyis ez megkad�lyozza, hogy al�bb az ir�ny�t�st tudjuk
                                                                        // haszn�lni. Kb kikapcsoltuk is ezzel
       

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

        Vector3 rightDir = moveInCameraSpace ? cameraTransform.right : Vector3.right;           // ir�ny a kamera space alapj�n. Ha igen, akkor
        Vector3 forwardDir = moveInCameraSpace ? cameraTransform.forward : Vector3.forward;     // kamera transform ter�ben, ha nem, akkor a
                                                                                                // vektor ter�ben t�rt�nik
        Vector3 velocity = rightDir * x + forwardDir * z;
        velocity.y = 0;                                                                         // a fenti 2 sor defini�lja az X, Y, Z-t

        velocity.Normalize(); // a speed el�tt, hogy azt ne normaliz�lja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;


        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If n�lk�l mind�g visszafordul.
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
    int currentHealth;                                                      // felvessz�k a currentHealth-et, ennyi v�ltozik

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

    bool IsAlive()                                          // ez v�ltozott, felvett�k, vizsg�ljuk, hogy a karakter �l-e
    {                                                       // ez v�ltozott
        return currentHealth > 0;                           // ez v�ltozott: return, jelenlegi �letem nagyobb mint 0
    }                                                       // ez v�ltozott

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
        //  if (healthObject.currentHealth <= 0) return;                    // ezt kidobjuk, az eddigi feladatok, l�p�sek miatt m�r nem kell
        if (healthObject.IsAlive()) return;                                 // mostant�l ezt figyelj�k


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

        velocity.Normalize(); // a speed el�tt, hogy azt ne normaliz�lja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;

        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If n�lk�l mind�g visszafordul.
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}

//----------------------------------------------------------------
// ---------elvileg itt m�r nem mozog ha elfogy az �let.----------
// ---------------------------------------------------------------

//-------------------------------------------------------------------------------------------------------



// -------------------- TOV�BB KORRIG�LUNK: ha be van �ll�tva health object, akkor is alive, egy�bk�nt mind�g mozgunk -----------------------

using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5; 
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace = true;
    [SerializeField] float angularVelocity = 100;
    [SerializeField] HealthObject healthObject;                             // HO = hO: egyenl�s�g hiba volt, ki

        private void OnValidate()
    {
        if (healthObject == null)
            HealthObject healthObject = GetComponent<healthObject>();
    }

    void Update()
    {
        //  if (healthObject.currentHealth <= 0) return;            // ezt m�r el�bb kidobtuk, az eddigi feladatok, l�p�sek miatt nem kell

        if (healthObject != null)                                    // EZ �J: csak akkor fusson az IsAlive IF, ha a healthObject nem nulla 
        {                                                           // EZ �J: 
            if (healthObject.IsAlive())                             // EZ �J: Mostant�l is ezt figyelj�k, de egy m�sik IF-be be�gyazva
                return;                                             // EZ �J: 
        }                                                           // EZ �J: 

        //  if (HealthObject != null && !healthObject.IsAlive())    // EZ �J: a fenti vizsg�lat pontosan ugyanez, csak m�shogy. V�laszthat�.
        //     return;                                              // EZ �J:


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

        velocity.Normalize(); // a speed el�tt, hogy azt ne normaliz�lja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;


        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If n�lk�l mind�g visszafordul.
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}

// ---------------------------------

// HEALTH OBJECT HIBA VOLT JAV�TVA ITT - most ez vagy az el�z�re vonatkozik az "=" probl�m�ra vagy nem tudom, mivel az el�z� HealthObject
// scripthez k�pest NULLA a v�ltoz�s.

using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;

    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public bool IsAlive()                                   // ez v�ltozott m�g eggyel ez el�tt: felvett�k, vizsg�ljuk, hogy a karakter �l-e
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

// MOVER IS JAV�TVA (health object = jel kuka, volt egy neg�l�si probl�ma is 


using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5; 
    [SerializeField] Transform cameraTransform;
    [SerializeField] bool moveInCameraSpace = true;
    [SerializeField] float angularVelocity = 100;
    [SerializeField] HealthObject healthObject;                 // egyenl� jel ki

    private void OnValidate()
    {
        if (healthObject == null)
            healthObject = GetComponent<HealthObject>();        // a szar verzi�: HealthObject healthObject = GetComponent<healthObject>();
    }

    void Update()
    {
        if (healthObject != null)
        {
            if (!healthObject.IsAlive())                        // hiba volt. Az eg�szet neg�lni kell ahhoz, hogy ne alive, hanem "dead" legyen
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

        velocity.Normalize(); // a speed el�tt, hogy azt ne normaliz�lja

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);
        transform.position = newPos;

        if (velocity != Vector3.zero) // ugyanaz, mintha a velocity vektor nem egyezik meg a 0, 0, 0 vektorral. If n�lk�l mind�g visszafordul.
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}

//------------------------------------------------------------------------------------------------------



// ----------------------- FELVEHET� ITEM-EK (COIN) ------------------------

// Coin felv�tel
// FONTOS A K�DOL�SHOZ: NE a playerben oldunk meg mindent, a j�t�k �gy nem modul�ris, csak arra az egy dologra val�k, neh�z �jra hazsnos�tani
// MELL�K SZ�L: VISUAL STUDIO: CTRL, SHIFT S minden f�jlt ment
// Minden game componensnek 1 tag-ja legyen, de sok minden m�s is lehet, TAG-eket felejts�k el, Unity c�g sem szereti de m�r belerakt�k...

using UnityEngine;

public class Collector : MonoBehaviour                              // Ez  ascript a gy�jt�shez kell
{
    [SerializeField] int collected = 0;                             // sz�mol�, n�zi, mennyi �rm�t gy�jt�tt�nk
    // int currentHealth;                                           // ez vagy benne maradt v�letlen�l, vagy majd kell. V�gig nem hazsn�ljuk

    void OnTriggerEnter(Collider other)                             // itt is van trigger objektum, onEnter, �s minden m�s Collidert figyeljen     
    {
        Collectable c = other.GetComponent<Collectable>();          // a "c" v�ltoz� �rt�ke az other (�sszes) komponensb�l csak a "Collectable"
                                                                    // Class-t n�zze. Ezzel azt is megoldjuk, nehogy "begy�jts�n" m�st
        collected++;                                                // egyszer�en n�velj�k az �rt�k�t eggyel "�tk�z�skor"
    }
}

// - - - - - - - - - - - - - - -

using UnityEngine;

public class Collectable : MonoBehaviour                            // Ez a script a gy�jthet� cuccok miatt kell
{
    [SerializeField] int value = 1;                                 // �rt�k integer legyen 1 (1 pontot �r a coin)

    public int GetValue() { return value; }                         // publikus �rt�k: int GetValue()  =>  return value;
                                                                    // ilyet is szoktak, ami egyszer�en egy �rt�k eset�n azt az �rt�ket
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

        if (c != null)                                              // miut�n fent m�r publikusnak tett�k a COllectible alatt a "GetValue()"-t
            collected += c.GetValue();                              // itt a "collected++" helyett - de csak ha a "C" nem egyenl� null�val
        Debug.Log(collected);                                       // felhazsn�ljuk a coin �rt�k�t, �s ideiglenesen debug-gal ki is �ratjuk
    }                                                               // EZ AZ �J R�SZ ITT FENT
}

// -------------

// ----------------- Teleport�lni fogjuk az �rm�t, hogy felv�tel ut�n �j hlyen jelenljen meg ----------------

// tan�r�

using UnityEngine;

class Collectable : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] Bounds teleportArea;                                    // �j elem

    public int GetValue() => value;                                         // EZ HELYETT: public int GetValue() { return value; } 

    public void Teleport()                                                  // teleport
    {
        float x = Random.Range(teleportArea.min.x, teleportArea.max.x);     // X koordin�ta. a "random.range" -t haszn�ljuk r�, a
        float y = Random.Range(teleportArea.min.y, teleportArea.max.y);     // "teleportarea.min.x" �s "...max.x" (X, Y �s Z-re) 
        float z = Random.Range(teleportArea.min.z, teleportArea.max.z);

        transform.position = new Vector3(x, y, z);                          // l�trehozunk egy �j vektort
    }

    void OnDrawGizmos()                                                     // Gizmo megrajzol�s
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(teleportArea.center, teleportArea.size);        // a teleport area k�zpontj�t �s m�ret�t defini�ljuk

    }
}


// FONTOS: A "RANDOM" l�tezik a "USING system"-ben is (ez az, amit �ltal�ban az els� p�r �r�n UNITY n�lk�l haszn�ltunk) illetve a
// using UnityEngine-ben is van, de ez m�r felparam�terezett, �s m�shogy m�k�dik. Figyelni kell, hogy a k�dban nehogy pl. belekeveredjen
// egy system, vagy valami m�s, mert az hib�t dobhat 

 // --------------------- 5. �RA V�GE -----------------------



