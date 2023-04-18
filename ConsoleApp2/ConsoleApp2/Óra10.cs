﻿
/*


//------------------------- HÁZI -------------------------------

// ----------------------- BOMB ELSŐ LÉPÉS----------------------------

using UnityEngine;

class Bomb : MonoBehaviour
{
    [SerializeField, Min(0)] float delay = 1;
    [SerializeField] float range = 2;
    [SerializeField] float maxForce = 100;

    void Start()
    {
        Invoke(nameof(Explode), delay);     // először ezt fogja hívni, a többi VOID-ot majd csak később.. (gondolom hacsak nem hívod explicit)
    }

    void Explode()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>(); // getcomponent = csak ahol a kód van, a getcomponents tömb lesz findobjectsoftype - az mindenhol
                                                                  // getcomponentin...  parent vagy child, akkor fel és lefelé keres csak
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

// --------------------------------  BOMB, 2. LÉPÉS ideiglenes, magyarázatokkal ---------------------------


using UnityEngine;

class Bomb : MonoBehaviour
{
    [SerializeField, Min(0)] float delay = 1;
    [SerializeField] float range = 2;
    [SerializeField] float maxForce = 100;

    void Start()
    {
        Invoke(nameof(Explode), delay);
    }

    void Explode()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        Vector3 selfPos = transform.position;

        foreach (Rigidbody rb in allRigidbodies)
        {
            float dist = Vector3.Distance(rb.position, selfPos);
            if (dist >= range)
                continue;
            // csak cikluson belül működik, az adott konkrét vérehajtásból ugrik csak ki, és ciklusokban használható csak az adott végrehajtásból
            // a ciklusból lép ki
            // brerak, az egész ciklus megtörésére hazsnálatos (a tejes ciklusból)
            // return - az egész metódust szakítja meg, nam csak az adott elemet (mindíg a metódusból)

            float forceRate = 1 - ((dist) / range);
            float currentForce = maxForce * forceRate;

            Vector3 dir = (rb.position - selfPos).normalized;
            rb.AddForce(dir, ForceMode.Impulse);
            // tömeg nem számít, egyszeri hatás: ForceMode.VelocityChange
            // tömeg nem számít, folyamatos hatás: ForceMode.Acceleration
            // tömeg számít, egyszeri hatás: ForceMode.Impulse
            // tömeg számít, folyamatos hatás: ForceMode.Force

            //  rb.velocity = dir * currentForce / rb.mass;       // ugyanaz, mint a fenti két sor, csak egyszerűbb
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

// --------------------------- BOMB, 3. lépés - Még Pici Magyarázat ---------------------------------

using UnityEngine;

class Bomb : MonoBehaviour
{
    [SerializeField, Min(0)] float delay = 1;
    [SerializeField] float range = 2;
    [SerializeField] float maxForce = 100;

    void Start()
    {
        Invoke(nameof(Explode), delay);
    }

    void Explode()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        Vector3 selfPos = transform.position;

        foreach (Rigidbody rb in allRigidbodies)
        {
            float dist = Vector3.Distance(rb.position, selfPos);
            if (dist >= range)
                continue;


//            // AZ EGÉSZET A 2. KÖRBEN KIKOMMENTELTE, MERT A LENTI EGY SOR MEGOLDJA
//
//                                                // csak cikluson belül működik, az adott konkrét vérehajtásból ugrik csak ki, és ciklusokban használható csak az adott végrehajtásból
//                                                // a ciklusból lép ki
//                                                // brerak, az egész ciklus megtörésére hazsnálatos (a tejes ciklusból)
//                                                // return - az egész metódust szakítja meg, nam csak az adott elemet (mindíg a metódusból)
//
//            float forceRate = 1 - ((dist) / range);
//            float currentForce = maxForce * forceRate ; 
//
//            Vector3 dir = (rb.position - selfPos).normalized;
//            rb.AddForce(dir, ForceMode.Impulse);        
//                                                // tömeg nem számít, egyszeri hatás: ForceMode.VelocityChange (Dash)
//                                                // tömeg nem számít, folyamatos hatás: ForceMode.Acceleration (Nitro)
//                                                // tömeg számít, egyszeri hatás: ForceMode.Impulse (kő)
//                                                // tömeg számít, folyamatos hatás: ForceMode.Force (Push - tologatás)
//
//                                                //  rb.velocity = dir * currentForce / rb.mass;       
//                                                // ugyanaz, mint a fenti két sor, csak egyszerűbb
//


            rb.AddExplosionForce(maxForce, selfPos, range)

        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

// --------------------------------------------------------------------------------------------
// a földre nem kell rigidbody, a kockákra, amiket legyártunk, kell rigidbody
// a kockák után 3d object, bomb, cylindert használ


//----------------- BOMB VÉGLEGES: TANÁRI ---------------------

using UnityEngine;

class Bomb : MonoBehaviour
{
    [SerializeField, Min(0)] float delay = 1;
    [SerializeField] float range = 2;
    [SerializeField] float maxForce = 100;
    [SerializeField] float upwardModifier = 0.5f;

    void Start()
    {
        Invoke(nameof(Explode), delay);
    }

    void Explode()
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        Vector3 selfPos = transform.position;

        foreach (Rigidbody rb in allRigidbodies)
        {
            float dist = Vector3.Distance(rb.position, selfPos);
            if (dist >= range) continue;

//            float forceRate = 1 - ((dist) / range);
//            float currentForce = maxForce * forceRate;
//
//            Vector3 dir = (rb.position - selfPos).normalized;
//
//            rb.AddForce(dir * currentForce, ForceMode.Impulse);
//            //rb.velocity += dir * currentForce / rb.mass;       // Ugyanaz (ForceMode.Impulse)

            // --------------------------------

            rb.AddExplosionForce(maxForce, selfPos, range, upwardModifier);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}


//----------------MÁSIK HÁZI: PÁLYÁN KÖRKÖRÖS MOZGÁS (PONTTÓL PONTIG)--------------------

using UnityEngine;

public class LongPathMover : MonoBehaviour
{
    [SerializeField] Transform[] points;                                   // lehetne Vector3 is, de könnyebb a Transformokkal dolgozni
    [SerializeField] float speed;

    int currentIndex = 0;                                                  // ami field, és nem publikus, azt általában alulvonássaal kezdik

    void Update()
    {
        if (points.Length == 0) return;

        Vector3 selfPos = transform.position;

        Transform target = points[currentIndex];
        if (target == null)
        // return; kiléphetünk, de minek állítsuk le a játékot
        {
            currentIndex++;
            target = points[currentIndex];
            Debug.LogError("Missing Path Point!")          // így a debug log piros színben jelenik meg, mint error
        }

        if (target == null) return;                        // ha kettő nulla van egymás után, akkor kihagyunk egy update-t, ez biztosítja ezt

    }

}

//-------------------TANÁRI MÁSOLT VERZIÓ - KIINDULÁS ---------------------------------

using UnityEngine;

class LongPathMover : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float speed;

    int currentIndex = 0;

    void Update()
    {
        if (points.Length == 0) return;

        Vector3 selfPos = transform.position;

        Transform target = points[currentIndex];

        if (target == null)
        {
            currentIndex++;
            target = points[currentIndex];
            Debug.LogError("Missing Path Point!");
        }
        if (target == null) return;


    }


}

//--------------TANÁRI VERZIÓ - FOLYTATÁS (ÉS VÉGLEGES IS EGYBEN) -------------

using UnityEngine;

class LongPathMover : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float speed;

    int currentIndex = 0;

    void Update()
    {
        if (points.Length == 0) return;

        if (currentIndex >= points.Length)
            currentIndex = 0;

        Transform target = points[currentIndex];

        if (target == null)
        {
            currentIndex++;
            target = points[currentIndex];
            Debug.LogError("Missing Path Point!");
        }
        if (target == null) return;

        Vector3 selfPos = transform.position;
        Vector3 targetPos = target.position;

        // towards megspórol 10 sornyi kódot
        transform.position = Vector3.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);       // a move towards nem fog túlugrani,
                                                                                                    // pontosan a célhoz érkezik, ezért
                                                                                                    // fontos

        if (transform.position == targetPos)
        {
            currentIndex++;
        }
    }
}

    // az előző dobozokat hazsnálja fel, csinál egy spherer-t, a collidert leveszi, kódot hozzáadja
    // lelcokolja jobb felül az inspactort (lakat), kijelöli az elemeket és hozzáadja (neki 30 elem), ezek között megy majd
    // beállít egy sebességet 10 egység / mp
    // hiba, mert a kockák robbannak és pár leesik, és ez azokat is követi
    // jó lehet arra is, hog egy ellenfél megeszi a karaktereket ha nem érsz gyorsan végig a pályán
    // törölt elemeket, azok innentől NONE-ként vannak ezek a nullák a kódban.
    // lenullázza a tömböt (0 értékkelÍ), előről kezdi
    // (ráhúzza a 7 elemet a "points"-ra
    // ez meg akkra jó, hogy a pályán 
//-------------------------------------------------------------



// -------------- UGYANAZ A KÖVETŐ, DE: kör végén randomizáltjuk az új kört!!!---------------------


using System.Collections.Generic;
using UnityEngine;

class LongPathMover : MonoBehaviour
{
    [SerializeField] List<Transform> points;                // listát a tömbből
    [SerializeField] float speed;

    int currentIndex = 0;

    void Update()
    {
        if (points.Count == 0) return;

        if (currentIndex >= points.Count)
            currentIndex = 0;
        List<Transform> randomlist = new List<Transform>();

        while (points.Count > 0)
        {
            int randomIndex = Random.Range(0, points.Count);
            randomlist.Add(points[randomIndex]);
            points.RemoveAt(randomIndex);

        }
        points = randomlist;

        Transform target = points[currentIndex];

        if (target == null)
        {
            currentIndex++;
            target = points[currentIndex];
            Debug.LogError("Missing Path Point!");
        }
        if (target == null) return;

        Vector3 selfPos = transform.position;
        Vector3 targetPos = target.position;

        // towards megspórol 10 sornyi kódot
        transform.position = Vector3.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);       // a move towards nem fog túlugrani, pontosan a célhoz érkezik, ezért fontos

        if (transform.position == targetPos)
        {
            currentIndex++;
        }
    }
}

// ----------------------- TANÁRI LEMÁSOLT, VÉGLEGES ---------------------


using System.Collections.Generic;
using UnityEngine;

class LongPathMover : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    [SerializeField] float speed;

    int currentIndex = 0;

    void Update()
    {
        if (points.Count == 0) return;

        if (currentIndex >= points.Count)
        {
            currentIndex = 0;
            List<Transform> randomList = new List<Transform>();

            while (points.Count > 0)
            {
                int randomIndex = Random.Range(0, points.Count);
                randomList.Add(points[randomIndex]);
                points.RemoveAt(randomIndex);
            }
            points = randomList;
        }

        Transform target = points[currentIndex];

        if (target == null)
        {
            currentIndex++;
            target = points[currentIndex];
            Debug.LogError("Missing Path Point!");
        }
        if (target == null) return;

        Vector3 selfPos = transform.position;
        Vector3 targetPos = target.position;

        transform.position = Vector3.MoveTowards(selfPos, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            currentIndex++;
        }
    }
}

//------------------------------HÁZI VÉGE------------------------------------------------


// ----------------ÓRAI (BIG RANGE, SMALL RANGE, MAX SPPED HELYETTESÍTÉS -----------------

using UnityEngine;

class AdvencedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] AnimationCurve distanceToSpeedCurve;


    void Update()
    {

        float speed = maxSpeed; // Ezt fogjuk folytatni


        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}

// bekötjük, playerre, 5-re, megnyit a grafikon, amúgy ctrl-lel lehet csak le fel mozgatni, görgővel zoom, shift 
//csak Y tengely, add point, de lehet azt is, hogy a pőonton jobbgomb - flat, vagy auto, vagy amit akarunk
// megpróbáljuk megcsinálni azt, amit eddig kóddal csináltunk, a követésben.
// broken - akkor nam görbe, hanem egyeneseket készít



//-------------------- FOLYTATÁS, TANÁRI VERZIÓ KIMÁSOLVA ------------------------

using UnityEngine;

class AdvencedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] AnimationCurve distanceToSpeedCurve;


    void Update()
    {

        Vector3 p = transform.position;	// ha rövid a változó élattartama akkor rövid, mert később nem kell
        Vector3 t = target.position;

        float distance = Vector3.Distance(p, t);
        float speed = distanceToSpeedCurve.Evaluate(distance) * maxSpeed; // evaluate - mintavételezés egy ponton


        transform.position = Vector3.MoveTowards(p, t, speed * Time.deltaTime);
    }
}

//---------- (nekem így még valamiért nem működik, de lehet szar a scene-m) ----------


//--------------- FOLYTATÁS: PLUSZ HOZZÁADVA: maxdistance (így már nekem is működik) PLUSZ ++ gradient ----------------

using UnityEngine;

class AdvancedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] AnimationCurve distanceToSpeedCurve;
    [SerializeField] Gradient gradient; 			// ez mindíg nulla és egy között van szigorúan


    void Update()
    {

        Vector3 p = transform.position;
        Vector3 t = target.position;

        float distance = Vector3.Distance(p, t);
        float speed = distanceToSpeedCurve.Evaluate(distance / maxDistance) * maxSpeed;


        transform.position = Vector3.MoveTowards(p, t, speed * Time.deltaTime);
    }
}
//---------------------TANÁRI LEMÁSOLVA-------------------------

using UnityEngine;

class AdvencedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] AnimationCurve distanceToSpeedCurve;
    [SerializeField] Gradient gradient;
    [SerializeField] Light light;


    void Update()
    {
        Vector3 p = transform.position;
        Vector3 t = target.position;

        float distance = Vector3.Distance(p, t);

        float x = distance / maxDistance;

        float speed = distanceToSpeedCurve.Evaluate(x) * maxSpeed;
        Color c = gradient.Evaluate(x);                             // visszaad egy másik színt
        light.color = c;

        transform.position = Vector3.MoveTowards(p, t, speed * Time.deltaTime);
    }
}


// Hozzáad egy point light-et. megemeli, növeli az intenzitását, range-t kicsire, távolság mértékeére módosítjuk a fényerőt, színt
// ha közel, piros, ha távol, akkor zöld, stb. köztes: sárga, narancs

//--------------------------------------------------------------------


//---------------------TANÁRI PLUSZ INFOK: ALPHA ÉS RGB IS LEHET--------------------------------------

using UnityEngine;

class AdvencedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] AnimationCurve distanceToSpeedCurve;
    [SerializeField] Gradient gradient;
    [SerializeField] Light light;

    float originalIntansity;
    private void Start()
    {
        originalIntansity = light.intensity;
    }


    void Update()
    {
        Vector3 p = transform.position;
        Vector3 t = target.position;

        float distance = Vector3.Distance(p, t);

        float x = distance / maxDistance;
        float speed = distanceToSpeedCurve.Evaluate(x) * maxSpeed;
        Color c = gradient.Evaluate(x);
        light.color = c;
        light.intensity = c.a * originalIntansity;		// a-alpha, r-red, g-green, b-blue...

        transform.position = Vector3.MoveTowards(p, t, speed * Time.deltaTime);
    }
}

//---------------------------------------------------------------------------


// ---------------------3D JÁTÉKUKNRA SZÜNETBEN ADOTT MAGYARÁZAT -------------------------
// a probléma az, hogy sima vektorral ha neimegyek ridigbody-s beállítással, néha amikor visszapattanok a tárgyról (pl ház)
// akkor valamiért elkezd egy irányba mozogni. Hiába nyomok gombot, akármit csinálok, folytatja a mozgást az adott irányba

// tanár: talán azért, mert vektort hazsnálok rigidbody-val, a vektor csak nyom, meg áll, de a ridigbody ütközésnél visszapattanó
// erő miatt ad velocity-t is a tárgynak, amit semmi nem ötörl el, mert nem velocity-t kezelek, hanem cektort, így itt a gond

// MIMI rigidbody.velocity - érték  vagy addforce - addforce.addposition vagy hasonló, ezzel lehet űrben ellökni
// nem túl jó a transform-ot használni a rigidbody fizika esetén, a visszapattanásnál kap velocity-t, a transform
// meg azt nem írja felül velocity-t pl: 0-ra állítani?



//---------------------------------------------------------------------------


// ---------------------JAVÍTÁSOK: lehet RÉGEBBEN nem JÓL írtam le az advanced followert itt korrigálom!!!! ----------------------

using UnityEngine;

class AdvancedFollower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxDistance;
    [SerializeField] AnimationCurve distanceToSpeedCurve;
    [SerializeField] Gradient gradient;
    [SerializeField] Light light;

    float originalIntansity;
    private void Start()
    {
        originalIntansity = light.intensity;
    }


    void Update()
    {
        Vector3 p = transform.position;
        Vector3 t = target.position;

        float distance = Vector3.Distance(p, t);

        float x = distance / maxDistance;
        float speed = distanceToSpeedCurve.Evaluate(x) * maxSpeed;
        Color c = gradient.Evaluate(x);
        light.color = c;
        light.intensity = c.a * originalIntansity;

        transform.position = Vector3.MoveTowards(p, t, speed * Time.deltaTime);
    }
}


//-------------------------------------------------------------------------------------------------


// ---------------sebez az ellenfél, egy darabig sebezhetetlenné válunk -------------------------------

using System.Collections;
using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    [SerializeField] Gradient textColor;
    [SerializeField] Collider hitBox;

    [SerializeField, Min(0)] float invincibilityFrames = 1;

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
        hitBox.enabled = false;
        Invoke(nameof(EnableHitBox), invincibilityFrames);          // itt invoke-vel várakoztatunk

        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    void EnableHitBox()
    {
        hitBox.enabled = true;
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());

    }
}

// hitbox 3 mps, a playert behúzza a Hit Box-ba, van bekapcsolt rigidbody
// ez így jó, de villogjunk is
// hogyan számolgassunk
// mi lenne, ha egyszerűen lenne egy metódusunk, amit ki és be kapcsolgatunk
// ilyet csak úgy nem tudunk, nem tud update-n belül várni, megállítja az update-t, vagy lehal a program (végtelen ciklus)
// coroutine-vel tudun várni.ű


// ------------------TANÁRI VERZIÓ, INVOKE HELYETT COROUTINE-----------------------------


using System.Collections;
using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    [SerializeField] Gradient textColor;
    [SerializeField] Collider hitBox;
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField, Min(0)] float invincibilityFrames = 1;
    [SerializeField, Min(0)] float flickTime = 0.1f;

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
        hitBox.enabled = false;

        StartCoroutine(InvincibilityCoroutine());           // ezzel hívunk coRoutint


        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    IEnumerator InvincibilityCoroutine()                    // így készül a CoRoutin
    {
        hitBox.enabled = false;
        float startTime = Time.time;
        while (startTime + invincibilityFrames > Time.time)
        {
                                                            // ez itt jó lenne de alul optimalizálta rövidebben a =!... résszel
//            if (meshRenderer.enabled)
//            {
//                meshRenderer.enabled = false;
//            }
//            else
//            {
//                meshRenderer.enabled = true;
//            }


            meshRenderer.enabled = !meshRenderer.enabled;
            yield return new WaitForSeconds(flickTime);     // Coroutinnál kell a yield
        }

        meshRenderer.enabled = true;
        hitBox.enabled = true;
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());

    }
}

// átkötötte a body-t mesh rendererre, de most nem nagyon működik, hiba van..
//---------------------------------VILLOGJUNK AKKOR (ELVILEG FENT AZ IS MEG VAN CSINÁLVA ) ------------------------------


//-------------------- vissza a health objecthez, folytatjuk -----------------------

using System.Collections;
using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    [SerializeField] Gradient textColor;
    [SerializeField] Collider hitBox;
    // [SerializeField] MeshRenderer meshRenderer;

    [SerializeField, Min(0)] float invincibilityFrames = 1;
    [SerializeField, Min(0)] float flickTime = 0.1f;

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

        StartCoroutine(InvincibilityCoroutine());


        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        MeshRenderer[] allMeshRenderer = GetComponentsInChildren<MeshRenderer>();

        hitBox.enabled = false;
        float startTime = Time.time;
        while (startTime + invincibilityFrames > Time.time)
        {
            foreach (MeshRenderer meshRenderer in allMeshRenderer)
                meshRenderer.enabled = !meshRenderer.enabled;

            yield return new WaitForSeconds(flickTime);
        }

        foreach (MeshRenderer meshRenderer in allMeshRenderer)
            meshRenderer.enabled = true;

        hitBox.enabled = true;
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());

    }
}

//-------------------tovább ----------------------------

using System.Collections;
using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    [SerializeField] Gradient textColor;
    [SerializeField] Collider hitBox;
    // [SerializeField] MeshRenderer meshRenderer;

    [SerializeField, Min(0)] float invincibilityFrames = 1;
    [SerializeField, Min(0)] float flickTime = 0.1f;

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

        StartCoroutine(InvincibilityCoroutine());


        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        MeshRenderer[] allMeshRenderer = GetComponentsInChildren<MeshRenderer>();

        hitBox.enabled = false;
        float startTime = Time.time;

        var wait = new WaitForSeconds(flickTime);

        while (startTime + invincibilityFrames > Time.time)
        {
            foreach (MeshRenderer meshRenderer in allMeshRenderer)
                meshRenderer.enabled = !meshRenderer.enabled;

            yield return wait;
        }

        foreach (MeshRenderer meshRenderer in allMeshRenderer)
            meshRenderer.enabled = true;

        hitBox.enabled = true;
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());

    }
}
//------------------tovább, ha nem akarjuk a collidert kikapcsolni-------------------------

using System.Collections;
using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    [SerializeField] Gradient textColor;
    // [SerializeField] Collider hitBox;
    // [SerializeField] MeshRenderer meshRenderer;

    [SerializeField, Min(0)] float invincibilityFrames = 1;
    [SerializeField, Min(0)] float flickTime = 0.1f;

    [SerializeField, Min(1)] int maxHealth = 100;
    int currentHealth;

    bool isInvincible = false;

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
        if (isInvincible) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);

        StartCoroutine(InvincibilityCoroutine());


        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        MeshRenderer[] allMeshRenderer = GetComponentsInChildren<MeshRenderer>();

        isInvincible = true;
        float startTime = Time.time;

        var wait = new WaitForSeconds(flickTime);

        while (startTime + invincibilityFrames > Time.time)
        {
            foreach (MeshRenderer meshRenderer in allMeshRenderer)
                meshRenderer.enabled = !meshRenderer.enabled;

            yield return wait;
        }

        foreach (MeshRenderer meshRenderer in allMeshRenderer)
            meshRenderer.enabled = true;

        isInvincible = false;
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());

    }
}

//--------------------VÉGLEGES, TANÁRTÓL MÁSOLT HEALTH OBJECT--------------------------------

using System.Collections;
using TMPro;
using UnityEngine;

class HealthObject : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    [SerializeField] GameObject restartUI;
    [SerializeField] Gradient textColor;
    // [SerializeField] Collider hitBox;
    // [SerializeField] MeshRenderer meshRenderer;

    [SerializeField, Min(0)] float invincibilityFrames = 1;
    [SerializeField, Min(0)] float flickTime = 0.1f;

    [SerializeField, Min(1)] int maxHealth = 100;
    int currentHealth;

    bool isInvincible = false;

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
        if (isInvincible) return;

        currentHealth = Mathf.Max(currentHealth - damage, 0);

        StartCoroutine(InvincibilityCoroutine());


        UpdateUI();

        if (currentHealth <= 0)
        {
            Debug.Log("Good By!");
        }
    }

    IEnumerator InvincibilityCoroutine()
    {
        MeshRenderer[] allMeshRenderer = GetComponentsInChildren<MeshRenderer>();

        isInvincible = true;
        float startTime = Time.time;

        var wait = new WaitForSeconds(flickTime);

        while (startTime + invincibilityFrames > Time.time)
        {
            foreach (MeshRenderer meshRenderer in allMeshRenderer)
                meshRenderer.enabled = !meshRenderer.enabled;

            yield return wait;
        }

        foreach (MeshRenderer meshRenderer in allMeshRenderer)
            meshRenderer.enabled = true;

        isInvincible = false;
    }

    void UpdateUI()
    {
        if (uiText == null)
            return;

        uiText.text = "HP: " + currentHealth;

        float t = (float)currentHealth / maxHealth;

        // uiText.color = Color.Lerp(minColor, maxColor, t);
        uiText.color = textColor.Evaluate(t);

        restartUI.SetActive(!IsAlive());

    }
}

//----------------------------------------------------------------------------------



//------------- BallisticPath-ot pisztolyhoz, golyónak gravity. Plusz line renderer-t is felvenni -------------------



using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]         // az update fusson le az editorban (executealways)
public class BallisticPath : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float speed = 10;
    [SerializeField, Min(0)] float simulationTime = 1;


    void Update()
    {
        Vector3 position = transform.position;
        Vector3 direction = transform.up;

        Vector3 gravity = Physics.gravity;
        float deltaT = Time.fixedDeltaTime;

        Vector3 velocity = direction * speed;
        float time = 0;

        List<Vector3> points = new List<Vector3>();
        points.Add(position);

        while (time < simulationTime)
        {
            position += velocity * deltaT;
            velocity += gravity * deltaT;

            points.Add(position);

            time += deltaT;
        }

    }
}

//---------------------------------------------TANÁRI KIMÁSOLT ----------------------------------------

using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
class BallisticPath : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float speed = 10;
    [SerializeField, Min(0)] float simulationTime = 1;

    void Update()
    {
        Vector3 position = transform.position;
        Vector3 direction = transform.up;

        Vector3 gravity = Physics.gravity;
        float deltaT = Time.fixedDeltaTime;

        Vector3 velocity = direction * speed;
        float time = 0;

        List<Vector3> points = new List<Vector3>();
        points.Add(position);

        while (time < simulationTime)
        {
            position += velocity * deltaT;
            velocity += gravity * deltaT;

            points.Add(position);


            time += deltaT;
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}

// Line renderer pontba a gun-t be kellett húzni
// így most a fgyverünk mutatja a csíkot lilán, hova fog esni a golyó
// RAYCAST-ot lehetne pzíció blokkolásra hazsnálni, ha eltalál valameddig, addig tart
// maeterialt átállítja defeult sprite rendererre és csinál gradienst neki, hogy jobban nézzen ki


//-------------------------RAYCAST A FEGYVERHEZ (CÉLZÁS, TÁVOLSÁG ÉS ESÉSI SZÖGET MUTAT)------------------------------------

using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
class BallisticPath : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float speed = 10;
    [SerializeField, Min(0)] float simulationTime = 1;

    void Update()
    {
        Vector3 position = transform.position;
        Vector3 startDirection = transform.up;

        Vector3 gravity = Physics.gravity;
        float deltaT = Time.fixedDeltaTime;

        Vector3 velocity = startDirection * speed;
        float time = 0;

        List<Vector3> points = new List<Vector3>();
        points.Add(position);

        while (time < simulationTime)
        {
            Vector3 lastPosition = position;

            position += velocity * deltaT;
            velocity += gravity * deltaT;

            Vector3 dir = position - lastPosition;
            Ray ray = new(lastPosition, dir);

            bool isHit = Physics.Raycast(ray, out RaycastHit hitInfo, dir.magnitude);
            if (isHit)
            {
                points.Add(hitInfo.point);
                break;
            }
            else
            {
                points.Add(position);
            }

            time += deltaT;
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }
}

//-------------------------END OF ÓRA 10----------------------------------------------




*/