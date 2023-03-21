/*

// -------------------óra előtti fotók alapján a jelenlei UNITY beállítások----------------

// Main Camera:
// Transform : Local pozíciók
// Look at scipt (target: head)

// Directional Light:
// Local transformok, alatta light-en pipa, de nincs lenyitva

// Player:
// Transformok localban
// Mover (script): Speed: 1. Camere Transform: Main Camera (transform), Move in camera space: yes, Angular velocity: 500, 
// ...Health Object: Player (Health Object)
// Capsule Collider: Material: none (Physics materiel), Is Trigger: yes, Radius: 0.5, Height: 3, Direction: Y-Axis, Center: 0, 1, 0
// Health Object (script), Max Health: 100, Current Health: 0
// Rigidbody: nincs lenyitva (de: gravity kikapcs, vagy phsycs kikapcs, talán
// COllector (script): Collected: 0

// Plane:
// Cooking Options: 30, Mesh: Plane, Shader: UVFree/UVFreeSpecular, Lightmap flags: 4, Enable instancing..: no, Double sided: no, 
// ... custom render queue: -1, semmi extra

// GameObject: (az ellenfél, csak nem lett elnevezve)
// Follower (script): Target: Player (transform), Speed: 1, Big Range: 15, Small Range: 10
// Capsule collider: Mat: none, IsTrigger: yes, Radius: 0,5, Height: 4, Direction: Y axis, Center: 0, 1, 0
// Damager (script): Damage: 10, Current Health: 0

// Obstacle: 
// Pap Moveer (script): Pos A_ Position A (transform), Pos B: Position B (transform),  Speed: 0, Start position: 0.552, 
// ... Next target: none (transfrm)
// Sphere Collider: Mat: none, Is Trigger: yes, Raius: 0.5, Center: 0, 0, 0
// Damager (script): Damage: 10, Current Health: 0

// Position A: csak helyzete

// Position B: csak helyzete

// Point Light: 
// LightDimmer (script): Light (point light), C1: zöld, Alpha kb 80% (fehér csík, játékban beállítva) C2: piros, alpha: ~75%, Frequency: 1

// Coin: Local transforms, Capule (mesh Filter), Mesh renderer, Capsule Collider (mindhárom pipa, de nincsenek lenyitva csak a collider)
//  ...IsTrigger: no, Radius: 0,5, Height: 2, Direction: Y axis, Center: 0, 0, 0, Collectable (script), Value: 1, Teleport area:
//  ... (tp area folytatás: Center: 0, 1, 0; Extent: 15, 0, 15)


// -----------------------------------------------------------------------------------------------------------


// ---------------------------- HÁZI MEGOLDÁSA LINKRŐL

// ---------------------------- PÓZ RAJZOLÓ

using System.Drawing;
using System.Numerics;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] float length;  // Egy tengely hossza

    void OnDrawGizmos()
    {
        Vector3 p = transform.position;

        DrawAxis(p, Vector3.right, Color.red);
        DrawAxis(p, Vector3.up, Color.green);
        DrawAxis(p, Vector3.forward, Color.blue);
    }

    void DrawAxis(Vector3 center, Vector3 axis, Color color)
    {
        Vector3 direction = length * transform.TransformDirection(axis);
        Gizmos.color = color;
        Gizmos.DrawLine(center - direction, center + direction);
        Gizmos.DrawSphere(center + direction, 0.1f * length);
    }
}

// VAGY A MÁSIK:

using UnityEngine;

public class PoseMarker : MonoBehaviour
{
    [SerializeField] float length = 0.5f;  // Egy ág hossza

    void OnDrawGizmos()
    {
        Vector3 p = transform.position;              // Középpont (lekérjük a saját pozinkat

        // X tengely
        Gizmos.color = Color.red;                    // Gizmó színe
        Vector3 right = length * transform.right;    // Lokális joobbra irány
        Gizmos.DrawLine(p - right, p + right);       // Vonal rajzolása
        Gizmos.DrawSphere(p + right, length);        // Gömb rajzoása 

        // Y tengely
        Gizmos.color = Color.green;
        Vector3 up = length * transform.up;
        Gizmos.DrawLine(p - up, p + up);
        Gizmos.DrawSphere(p + up, length);

        // Z tengely
        Gizmos.color = Color.blue;
        Vector3 forward = length * transform.forward;
        Gizmos.DrawLine(p - forward, p + forward);
        Gizmos.DrawSphere(p + forward, length);

    }
}


// SULIVERZIO

using UnityEngine;

public class PoseMarker : MonoBehaviour
{
    [SerializeField] float length = 0.5f;  // Egy ág hossza

    void OnDrawGizmos()
    {
        Vector3 p = transform.position;
        Vector3 right = transform.right;
        Vector3 up = transform.up;
        Vector3 forward = transform.forward;

        float r = 0.1f * length;

        Gizmos.Color = Color.red;
        Gizmos.DrawLine(p + right * length), p - right * length)); // vagy  Gizmos.DrawLine(p + right, p - right);
        Gizmos.DrawSphere(p + right, r);


        Gizmos.Color = Color.green;
        Gizmos.DrawLine(p + up, p - up);
        Gizmos.DrawSphere(p + up, r);

        Gizmos.Color = Color.blue;
        Gizmos.DrawLine(p + forward, p - forward);
        Gizmos.DrawSphere(p + forward, r);
    }
}

// jó, pl. ha irányt akarunk változtatni, pls shooting arc
// [SerializeField] vector direction
// Vector3 localV = tansform(x, y, z);
// Vector3 globalV = transform.TransformDirection(direction);
//globalV.Normalize();
// globalV += length;


//--------------------------------------------------------------------------------------

//-----------------------------------SZÍNÁTMENET

using UnityEngine;

public class GradientDrawer : MonoBehaviour
{
    [SerializeField] Vector3 point1, point2;
    [SerializeField] Color color1, color2;
    [SerializeField, Min(2)] int segmentCount = 10;
    
    void OnDrawGizmos()
    {
        float step = 1f / segmentCount;
        for (int i = 0; i < segmentCount; i++)
        {
            float colorRate = (float)i / (segmentCount-1);
            Color color = Color.Lerp(color1, color2, colorRate);
            Vector3 start = Vector3.Lerp(point1, point2, i * step);
            Vector3 end = Vector3.Lerp(point1, point2, (i+1) * step);
            Gizmos.color = color;
            Gizmos.DrawLine(start, end);
        }

    }
}

// ha RGB szyneket adunk meg, akkor és máskor is figyelni kell arra, hogy az alpha (átlátszóság) manuálisan
// beállítandó UNITY-n belül, de ha konrét "SZÖVEGGEL" adom meg, pl: red, blue - akkor annak lesz alapból
// alpha feltekerve, vagyis látszik

//---------------------------------------------------------------------------

// -----------------------------------------KÖVETŐRAKÉTA

using UnityEngine;

public class Rocket : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] float speed = 5;
	[SerializeField] float angularSpeed = 180;
	
	void Update()
	{
		Transform self = transform;
		
		Vector3 targetDirection = target.position - self.position;  // Ebben az irányban van a cél
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection);   // Ahhoz ebbe az irányba akarunk fordulni
		
		// Fordulás:
		float maxAngle = angularSpeed * Time.deltaTime;  // Maximum ekkora szögben fordulhatunk most
		self.rotation = Quaternion.RotateTowards(self.rotation, targetRotation, maxAngle);  // Towards metódus
		
		// Haladás:
		float offset = speed * Time.deltaTime;   // Ennyit lépünk előre
		self.position += self.forward * offset;  // Előre irányba megyünk
	}
}




//-------------------------------------------- Házi vége ----------------------------------------


// ------------------------------ ISKOLAI MUNKA -------------------------------------------------

// ------------------------------------- SZÍNÁTMENET ÚJRA ---------------
using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

Using UnityEngine;

class MainDirectionDrawer : MonoBehaviour
{
    [SerializeField] float length = 1;                                          // hossz
    [SerializeField] Vector3 direction = new Vector3(1, 1, 1);                  // új vektor irány

    void OnDrawGizmos()                                                         // gizmo rajzolás
    {
        Vector3 p = transform.position;                                         // ezzel adjuk meg (olvassuk), hogy MOST hol van
        Vector3 right = transform.right * length;                               // a right vector az a right irányba a transformálása * hossz
        Vector3 up = transform.up * length;                                     // ugyanaz, csak up
        Vector3 forward = transform.forward * length;                           // ugyanaz csak előre

        Vector3 globalV = transform.TransformDirection(direction);              // ha GLOBÁL irányba akarjuk a fentit, akkor azt kb így
        globalV.Normalize();                                                    // majd normalizálnunk kell
        globalV *= length;                                                      // majd beszorozni a hosszal

        float r = 0.1f * length;                                                // ezzel az egy egészet úgymond 10 szakaszra (részre) bontjuk

        Gizmos.color = Color.red;                                               // piros színű gizmo
        Gizmos.DrawLine(p + right, p - right);                                  // vonalat húz mindkét irányba
        Gizmos.DrawSphere(p + right, r);                                        // rajzol egy gömböt a p.right vektorhoz. r sugárral

        Gizmos.color = Color.green;
        Gizmos.DrawLine(p + up, p - up);
        Gizmos.DrawSphere(p + up, r);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(p + forward, p - forward);
        Gizmos.DrawSphere(p + forward, r);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(p + globalV, p - globalV);
        Gizmos.DrawSphere(p + globalV, r);

    }

}

// -------------------------------------------------------------------------------------------------------

// --------------------------------------SZÍNÁTMENET SULI--------------------------------------------
// Amikor a részeket kell számolnunk, interpolálnunk kell (LERP - lineáris interpoláció)

float segment = 1f / segmentCount;                          // a 10 részből álló 0-1ig terjedő skálát osztom, ami 0,1 érték lesz (kódban lent)
                                                            // utána csak a szegmentet kell szoroznunk ahanyadik pontnál vagyunk
                                                            // (segment * (i + 1 )) azért plusz 1
                                                            // mert nulla az első szegmens "azonosítója"

using UnityEngine;

class GradientDrawer : MonoBehaviour
{
    [SerializeField] Vector3 p1 = Vector3.left, p2 = Vector3.right;     // létrehozunk 2 vektort
    [SerializeField] Color c1 = Color.red, c2 = Color.blue;             // létrehozunk 3 színt

    [SerializeField, Min(2)] int segmentCount = 10;                     // 10 részletet adunk meg elsőre a szegmens számnak, változtatható

    void OnDrawGizmos()                                                 // rajzolunk 
    {
        float segment = 1f / segmentCount;                              // 10 részre (akárhány részre) osztjuk

        for (int i = 0; i < segmentCount; i++)                          // lépésenként végigmegyünk a szegmenseken
        {

            float tA = segment * i;                                     // ideiglenes változó, a szegmenst beszorozza i-vel
            float tB = segment * (i + 1);                               // ideiglenes a szegmenst i+1-el szorozza

            Vector3 a = Vector3.Lerp(p1, p2, tA);                       // létrehozás, bontás
            Vector3 b = Vector3.Lerp(p1, p2, tB);

            float tC = (float)i / (segmentCount - 1);                   // az ideiglenes tc értéke az "i" - float-ra konvertálva itt osztva a
                                                                        // szegmensszám -1-el. Azért, mert a szegmensszám 1, de ugye nulláról
                                                                        // kell indulnunk
            Color c = Color.Lerp(c1, c2, tC);                           // LERP színátmenetek

            Gizmos.color = c;                                           // gizmo színe
            Gizmos.DrawLine(a, b);                                      // vektorok (gizmo) vonala
        }
    }

}


// ---------------------------------------------------------------------------------------------------------
// -------------------------------------- KÖVETŐ REPÜLŐ ----------------------------------------------------
// CSAK EGYENESEN MEGY A REPZI ÉS FORDUL HOZZÁ (LIMITÁLT)
// az "angularspeed" a háziban az "angularvelocity" a suli példában

using UnityEngine;

class Rocket : MonoBehaviour
{
    [SerializeField] Transform target;                          // a transform legyen a target
    [SerializeField] float speed = 1;                           // sebesség (átírjuk játékben 3-5 re)
    [SerializeField] float angularVelocity = 360;               // forgulási szög (átírjuk játékban 180-ra)

    void Update()
    {
        if (target == null)                                      // ha nincs cél, akkor ne fusson
            return;

        Vector3 direction = target.position - transform.position;       // az irány a cél poziíciója mínus a mi objektünk jelenlegi pozíciója
        Quaternion targetRotation = Quaternion.LookRotation(direction); // célrotáció arra amerre néz, az meg a direction fentről
        float angle = angularVelocity * Time.deltaTime;                 // a szög a velocity * delta idő
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angle);   //a rotáció a felérotálás, célrotálás, szög

        transform.position += transform.forward * speed * Time.deltaTime;                           //a pozi ae előrefelé * sebesség * deltaidő

    }
}

//------------------------------HÁZI SULIS FELDOLGOZÁS VÉGE


// ----------------------------------- 6. ÓRAI ANYAGOK -------------------------------------------

//Mi kell ahhoz, hogy a tárgyak találkozzanak: OnTriggerEnter - isTrigger - RigidBody
//ha nincs beállítva az isTrigger, akkor ütközni fog (fizika)
// other-rel ütköztünk (minden mással, ain is trigger volt), GetComponenttel kérdeztük le, és ha volt ott sebezhető elem, akkor OK, sebződünk
// DAMAGER kód változtatást javítottam.

// a THIS.GETCOMPONENT helyett lehet csak GETCOMPONENT-et írni, ha megunkat címezzük, kivéve ha át akarjuk adni paraméterként
// vagy paramétert, akkor kell a this.

// -----------------------
// Egyéb GetComponent elemek (a Damager-ben kikommentezve benne van).

//       Rigidbody rb = other.GetComponentInChildren<Rigidbody>();     // először saját magán nézné, utána alatta, de ha megtalált már egyet
// is, akkor azzal tér vissza
//       Rigidbody rb = other.GetComponentInParent<Rigidbody>();       // parent irányba
//       Rigidbody[] rigidbodies = GetComponents<Rigidbody>();             // szépen sorban veszi a tömbökből
//       Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();   // ugyanaz, mint fent, csak tömbből
//       Rigidbody[] rigidbodies = GetComponentsInParent<Rigidbody>();     // ugyanaz, mint fent, csak tömbből

// ------------------------------------------------------------------------------------------------------


//  -----------------------------------------------UI----------------------------------------------------

// Create - UI - Canvas létrehoz elsőre egy Event Systemet, ez csak 1x kell, hogy benn legyen, nem foglalkozunk vele csak Canvas-szal
// UI - Button - TextMeshPro - első fuásnál telepíteni kell. 2 elemből áll, a button és a szöveg. A Button méretét ne csúszkával, hanem
// alatt a számokkal (menü) módosítsjuk, különben szétcsúszik. Igazgatni lehet a képernyőhöz vsizonyítva, pl jobb alul, de az csak annyit
// tesz, hogy utána mozgathatjuk a gombot ide-oda, viszont ahogy változik a képernyő mérete, ő ahhoz fog "idomulni" mindíg
// Kirakja a szöveget valahova a térbe, de ennek ellenére a képernyőre teszi ki gyakorlatilag amikor renderelünk.

//Ha az inspektorban kivesszük a pipát a létrehozott objektum név elől, olyan, mintha nem is lenne benne a játékban.

// Button transform itt "rect" transform, 2d-s téglalapot kezel, többet tud mint a transform.
// NE MARADJ DEBUG-MÓDBAN

// Lockolod bal felül, akkor akárhogy módosul, a gomb marad ahhol van
// Pivot - Van 9 állapot, ne változzon hozzá képest VS. kék nyilak - tudod te álítani
//-----------------
// Csináltunk két szöveget meg egy Restart button-t utóbbit alulra betettük középre fixen



// -------------------- COLLECTORHOZ SZÖVEG  (HÁNY COIN-t GYŰJTÖTTÜNK) ----------------------------

using TMPro;                                                        // kell a szöveghez
using UnityEngine;

class Collector : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;                               // szövegmezőhöz

    int collected = 0;     

    void OnTriggerEnter(Collider other)
    {
        Collectable c = other.GetComponent<Collectable>();

        if (c != null)                                              // csak akkor fut, ha a fenti Collectable-t megtaláltuk a játékban
        {
            collected += c.GetValue();
            Debug.Log(collected);

            uiText.text = "Score " + collected;                     // simán hozzátesszük itt a számolást

            c.Teleport();
        }
    }
}

// ------------------------------- csináljuk picit másképp a collectort -------------------------------

using TMPro;
using UnityEngine;

class Collector : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;


    int collected = 0;

    void Start()
    {
        NewMethod();                                            // startban egyszer meghívjuk a NewMethod-ot
    }

    void OnTriggerEnter(Collider other)
    {
        Collectable c = other.GetComponent<Collectable>();

        if (c != null)
        {
            collected += c.GetValue();
            Debug.Log(collected);

            NewMethod();                                        // onTriggerEnter-en is meghívjuk a NewMethod-ot

            c.Teleport();
        }
    }

    void NewMethod()                                            // ha nem hiányzik a szöveg a játékban, akkor írja ki
    {
        if (uiText != null)
            uiText.text = "Score " + collected;
    }
}


//----------------------------------------------------------------------------------------------------



//------------------------------- HEALTHOBJECT HIBAJAVÍTÁS ÉS SAJÁT KIÍRATÁS--------------------------

//2 hiba is volt benne régről, alul jelölöm

using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField, Min(1)] int maxHealth = 100;
    [SerializeField] TMP_Text uiText;

    public int currentHealth;                                               // ez itt az új

    void Start()
    {
        currentHealth = maxHealth;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void Damage(int damage)
    {
        //  currentHealth -= damage;

        if (currentHealth <= 0) return;                         // javasolt először a nem megyünk tovább ág kezelése, máskor lehet akár
                                                                // 4-5 feltétel, hogy ne is fusson, ha a feltétel jó-rossz  
                                                                // itt nekem == volt (HIBA ITT JAVÍTVA)

        currentHealth = Mathf.Max(currentHealth - damage, 0);   // ezzzel egy sorba bele tudjuk tenni if helyett
                                                                // itt nem volt nálam ott a "- damage" sem (HIBA ITT JAVÍTVA)

        NewMethod2();                                           // itt hívtam a metódust

        if (currentHealth <= 0)
        {


            Debug.Log("Good By!");
        }


        // Debug.Log("Aucs!");
    }



    void NewMethod2()                                           // itt hoztam létre, ha létezik a játékban a dzöveg csak akkor dolgozzon
    {
        if (uiText != null)
            uiText.text = "Health " + currentHealth;
    }
}


//----------------------------- TANÁRI MEGOLDÁS CURRENT HEALTH -------------------------------------------------

using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] Color minColor = Color.red, maxColor = Color.green;            // ez az enyémhez képest új
    [SerializeField] Gradient textColor;                                            // gradiens színe                              

    [SerializeField, Min(1)] int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();                                                                 // frisítse az UI-t
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void Damage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        UpdateUI();                                                                 // frissítse az UI-t

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    void UpdateUI()                                                                 // ha nem nulla, írja ki a HP-t és színezze átmenettel
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;
        
        float t = (float)currentHealth / maxHealth;                                         // ezt csak a 2. körben vettük hozzá

        //uiText.color = Color.Lerp(minColor, maxColor, (float)currentHealth / maxHealth);  // első körben ez volt, kivettük a 2. körben

        uiText.color = textColor.Evaluate(t);                                               // 2. körben ezt vettük hozzá a fenti helyett

    }
}

// Gradient belül lehet állítani plusz pontokat felvenni, a felső pontok az átlátszóság, és lehet presetként kezelni.


// -------------------------------------------------------------------------------------

// -------------------- GameManager sciprt létrehozás ----------------------------------
// GameManager scipt létrehozás - más Unity-n belül a scipt ikonnak a megjelenítése: ha a scriopt nevében a "manager" benne
// = fogaskerékként jelöli. (event System)


using UnityEngine;
using UnityEngine.SceneManagement;                  // ha a scene Managementtel dolgozunk, ez kell

public class GameManager : MonoBehaviour
{
    [SerializeField] string sceneName;              // Scene name változó
    public void RestartGame()
    {

        SceneManager.LoadScene(sceneName);          // ha restart game-t hívunk, akkor a scene manager hívja meg a scene-t
                                                    // (pl: teljes újraindítása a scene-nek így történik

    }
}


// --------------------- csak akkor lássunk restart-ot ha meghalt a karakter (Health Objectre) -------------------------

using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;                                              // ez új
    // [SerializeField] Color minColor = Color.red, maxColor = Color.green;             // ezt kikapcsoltuk
    [SerializeField] Gradient textColor;

    [SerializeField, Min(1)] int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void Damage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);
        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, (float)currentHealth / maxHealth);     // kivettük az előbb, helyette van az evaluate
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());                                                        // ez új: akkor legyen a restartUI aktív
                                                                                                // ha a fenti IsAlive nem igaz
                                                                                                // addíg ne látsszon!
    }
}

//-----------------------------------------------------------------------------------------

// saját tapasztalat: csinlsz egy scriptet, behúzod a gomb alá (vagy panel de gombon dolhoztam ki ott tuti ok), aztán
// fogod és a gombot behúzod az OnClick alá (plusszal felveszed az on click eseményt és oda kell majd behúzni), mert objektumokat kezel
// és ide NEM a scriptet húzod be. Innentől a gombra ható scruiptekben definiált dolgok megjelennek a menüpont alatt és ki lehet
// válasaztani, pl az UpdateUI-t, hogy kattintásnál az hasson.


// a "canvas" - on minél lejjeb van valami, annál fentebb van a képen (sorrendiség)
// lefotóztam a bekötéseket, azt majd itt meg kell nézni és hozzáírni.

// A restart button on Click-re +-al lehetett felvenni a GameManager-t, amit fent léátrehoztunk,
// utána le kellett nyitni az abalkot és a game managert, kiválasztani a restart game-t.

// Aztán csináltunk egy Game Over szöveget, meg egy Panelt, és a panel child-je lett a 
// Game Over és alatta a Restart button (így a képen a restart van legelöl.

// Aztán bementünk a playerbe, majd a Health objectbe, ahol az UI text a Health Text, és alatta 
// a Restart UI -ban a panelt állítjuk be, így lehet elérni, hogy gyakorlatilag a menü ne jelenjen meg,
// amíg nem haltunk meg.

// a peneltn nkikapcsolhatjhuk a képet, hogy csak síne legyen, alpha állítás és nevet is adhatunk mást.

// ----------------------------------
// Új szöveg (fontkészlet hozzáadása, bemegyek a text mesh pro-ba, és hozzárendelem, majd generate font atlas, utána tudod kezelni.
// Window menü alatt (NEM TEXT, HANEM TEXT MESH PRO a sima text már régi, ne azt hazsnáld)


// -------------------------------------------------------------------------


// -------------------------------- COLLECTIONS: ARRAY (TÖMB) és LIST (LISTA) -------------------------------------------
// EZ KELL Az ÉRETTSÉGIHEZ IS!
// UNITY-BEN DOLGOZTUNK RAJTA, DE SIMÁN MEGY UNITY NÉLKÜL (using System-mel is)

using UnityEngine;

public class CollectionsPractice : MonoBehaviour
{

    void OnValidate()
    {
        int[] intArray = new int[10]; // 10 elemszám
                                      //bármilyen tipusra lehetne, szöveg, de akár tömb tömbje is
                                      // index szerint hivatkozhatóak

        intArray[2] = 15;             // beír a 3. pozícióba
        int element = intArray[5];    // kiveszi a 6. pozícióból (itt mindenhol minden nulla, kivéve a kettes, ami 15 mert fent beadtuk neki)
                                      // int m2 = intArray[10];      // szar, mert nincs tizedik, hibát dob (out of range) ERRE FIGYELJ!


        for (int i = 0; i < intArray.length; i++)   // felttöltés 1..2... egészen végig utolsó számig-mal
        {
            intArray[i] = i + 1;
        }


        for (int i = 0; i < intArray.length; i++)       // kiíratom, (Unity nélkül debug.log helyett Console.writeLine (intArray[i]);
        {
            Debug.Log(intArray[i]);
        }
    }
}

// ------------------------------- picit tovább megyünk... --------------------------

using UnityEngine;                                                      // ez csak unity, helyette using System

public class CollectionsPractice : MonoBehaviour                        // csak unity
{
    [SerializeField] int[] intArraySetting;                             // csak unity, pl int array mejelenítve Unity-n belül
    [SerializeField] string[] stringArraySetting;                       // csak unity, string.... 
    [SerializeField] GameObject[] GameObjectArraySetting;               // csak unity, GameObject....

    void OnValidate()
    {
        int[] intArray = new int[10];                                   // 10 int elemszám: a változó: "intArray", az "int[]" mondja hogy array    
        string[] stringArray = { "Alma", "Körte", "Barack" };           // rögtön létre is hozunk 3 stringet, pl így lehet (de int-tel is lehet

                                                                        //bármilyen tipusra lehetne, szöveg, de akár tömb tömbje is
                                                                        // index szerint hivatkozhatóak [0] az első index, azaz első érték


 //------------------------------------ KARAKTER ------------------------------------

        char myFirstChar = '*';                 // karakter létrehozása

        string s = "bármi";                     // sima string

        char[chars] = "Akármi".ToCharArray();   // karakter [karakterek] legyen egyenlő "valamiszöveg" amit kitesz Array-ba (karakterenként)
                                                // TESZTELNI, de lehet ez iibás, lásd következőt!!!
    }
}

//----------------------------------------------

//---------------------------------EZ A JÓ VÉGEGES ANYAG-----------------------------------
// jelölöm, ami új benne

using UnityEngine;
using UnityEngine.UIElements;

class CollectionsPractice : MonoBehaviour
{
    [SerializeField] int[] intArraySetting;
    [SerializeField] string[] stringArraySetting;
    [SerializeField] GameObject[] gameObjectArraySetting;

    void Start()                                                // betettük start-ba onValidate helyett, hogy fusson indításkor
    {

        int a = 67;                                             // új, de cak egy int

        int[] intArray = new int[10]; 
        string[] stringArray = { "Alma", "Körte", "Barack" };

        intArray[2] = 15;

        int element = intArray[5];

        // int e2 = intArray[10];  // ERROR, tudjuk

        
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i + 1;
        }


        for (int i = 0; i < gameObjectArraySetting.Length; i++)     // Game Array-ra alakítottuk át, hogy a GameArray hosszát nézzük (UNITY)
        {
            Debug.Log(gameObjectArraySetting[i].name);              // ki is íratjuk (szintén UNITY)
        }

        char myFirstChar = '*';

        string s = "Bármi";

        char[] chars = s.ToCharArray();                             // lehet ez a jó. Illetve előző is szerintem jó, csak itt mást csinálunk
                                                                    // itt a char alapértelemzettben üres, és feltöltjük az S string betűivel

        string s2 = new string(chars);                              // s2 változó az új string legyen, amit a "chars" elemeiből rakunk össze

        // string s3 = s.Substring(0, s.Length - 1);                // -1el levégjuk az utsó elemet, nulla kezdet, s.hossz mínus egy
        string s3 = s.Substring(s.Length / 2, s.Length / 2);        // ????????????????  KIOKOSHODNI, ez is "-1el levégjuk az utsó elemet"???
        string s4 = s.Replace("á", "a");                            // cserélünk benne

        string s5 = s.Replace(".", "");                             // kicseréljük pontot space-re
        string s6 = s.ToLower();                                    // kisbetűs mind
        string s7 = s.ToUpper();                                    // nagybetűs mind
        bool contains = s.Contains("árm");                          // igen a bool, mert az "árm" benne van a "bármi"-ben
        int indexOf = s.IndexOf("árm");                             // idexét lekéri és kitesi változóba --> // 1 (egyes indexen kezdődik
                                                                    // b = nullás index á = egyes index)

    }
}


//---------------------------------------------------------------------------------------



using System.Collections.Generic;                               // a listáknál ez miníg kell
using UnityEngine;                                              // csak UNITY esetében kell

class CollectionsPractice : MonoBehaviour                       // csak UNITY
{
    [SerializeField] int[] intArraySetting;                     // csak UNITY
    [SerializeField] string[] stringArraySetting;               // csak UNITY
    [SerializeField] GameObject[] gameObjectArraySetting;       // csak UNITY

    [SerializeField] List<string> stringList;                   // csak UNITY      ------> EZ AZ ÚJ? A TÖBBI A RÉGIHEZ TARTOZIK!!!!!!!

    [SerializeField] int[][] arrayOfArraies;                    // NEM MŰKÖDIK
    [SerializeField] int[,] matrix;                             // NEM MŰKÖDIK

    void Start()
    {

        List<int> ints = new List<int>();               // létrehoz egy ints nevű változó listát és új listaként hozza létre (ÍGY KELL)

        for (int i = 0; i < 10; i++)                    // ints elemeit (1..2..3..) listába tesz
        {
            ints.Add(i * i);                            // ints.add-dal adtuk hozzá új elemként
        }

        Debug.Log(ints.Count);                          // kiíratjuk az ints számosságot (unity-n kívül: Console.Writeline(ints.count);


        for (int i = 0; i < ints.Count; i++)            // ??????????????????
        {
            Debug.Log(ints[i]);                         // ??????????????????
        }

        List<string> strings = new List<string> { "Alma", "Körte", "Banán" };       // string lista létrehozás, és már be is töltünk értéket

        bool succes = strings.Remove("Körtét");                                     // false körtét nem Körte! (kis nagybetű számít)
        
        strings.RemoveAt(2);                                                        // 2-es indexen töröl

        strings.Sort();                                                             // sorrendbe rakja

        strings.Insert(1, "1111235436");                                            // beszúrunk egy elemet 1-es indexre (2. érték), szövegként

        string sss = strings[2];                                                    // sz "sss" vegye fel a 2. indexet (3. érték)

        strings.RemoveAt(2);                                                        // majd kivesszük

        strings.Insert(2, sss);                                                     // majd a 2. poziba betesszük ismét 

                                                                                    // változó értéket kap, töröljük a listából, de a vátozót
                                                                                    // nem bántotta semmi, így onnan ugyanazt vissza lehetett
                                                                                    // olvasni a listába

        strings.Clear();                                                            // törlünk minden adatot a listáról.

    }
}


// ---------------------------- UNITY-n belüli -----------------------------------

// GameManager Objektum --> GameManager Script van rákötve

// Canvas (parent)
//      - Score Text
//      - Health Text
//      - Restart Button    --> GameManager Objektum van rákötve, a GameManager.RestartGame van kiválasztva alatta

// EventSystem (automatikusan jön létre, csak kell, nincs vele dolgunk)

// A PLAYER-en:
// ...Mover script mellett a Health Object script van bekötve, ahol az 
//      - UI Text: Health Text bekötve
//      - Restart UI: Game Manager bekötve
//
// ...és a Collector Scipt alatt az
//      - UI Text:  Score Text van bekötve

// ----------------------------- a VÉGÉRE ---------------------------
// a panel kikapcsolt (kiszürkített állapotban van)
// a Canvason ez látszik:
//      - Score Text
//      - Health Text
//      - Panel (kiszürkített, kikapcsolt)
//              -- GameOver (kiszürkített, kikapcsolt)
//              -- Restart Button (kiszürkített, kikapcsolt)
//      - EventSystem
//      - GameManager
//
// A PLAYER-en:
//  Mover scipt konfig: Spped:1, Camera Transform: Main Camera Transform. Move in Camera Space (pipa), Health Object (Player (Health Object)
//... Angular Veolcity: 500
//  Health Object (script) konfig: UI Text: Health Text, Reastart UI: Panel
//  Collector (nincs lenyitva)


// ----------------------------------- 6. ÓRA VÉGE ------------------------------------------------------
*/


