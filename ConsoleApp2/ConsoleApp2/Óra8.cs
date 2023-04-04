
/*



//CODESHARE-t használunk az adat gyors másolására (online egyből meghjelenik


// ----------------HÁZIK-------------------------------
// ----------------FIBONACCI-------------------------------

using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System;
using UnityEngine;

public class FibonacciClass : MonoBehaviour
{
    [SerializeField, Min(0)] int length = 10;
    [SerializeField] int[] array;

    void OnValidate()
    {
        array = Fibonacci(length);
    }


    int[] Fibonacci(int length)
    {
        int[] array = new int[length];

        if (length > 0)
            array[0] = 0;

        if (length > 1)
            array[1] = 1;

        for (int i = 2; i < length; i++)
        {
            array[i] = array[i - 1] + array[i - 2];
        }

        return array;
    }

}
// ha túl nagy értéket adunk meg, megjelennek mínusz zámok... túlcsordul az INT, ilyenkor LONG lehet helyette
//------------------------------------------------

// Gravitációs Gyorsulás
// Fizikai rendszer nélkül oldjuk meg (no rigidbody, ezért le is vettük a collidert a gömbről)



using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float acceleration = 9.81f;

    Vector3 velocity = Vector3.zero;                 // field kell, hogy legyen, mert meg akarom őrizni az értékét!


    void FixedUpdate()
    {
        velocity += Vector3.down * acceleration * Time.fixedDeltaTime;

        transform.position += velocity * Time.fixedDeltaTime;           // a velocity tartalmazza ár a hosszt is és az irányt is
    }

}

//--------------------------------------------
//Kérésre beletettük a drag-et is, mint gravitációs hatás


using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float acceleration = 9.81f;
    [SerializeField] float drag = 0.2f;               // általában a közegellenállás függ a sebességtől. Minél gyorsabb vagy, annál
                                                      // ...nagyobb a drag, míg ki nem egyenlít

    Vector3 velocity = Vector3.zero;                 // field kell, hogy legyen, mert meg akarom őrizni az értékét!


    void FixedUpdate()
    {
        velocity += Vector3.down * acceleration * Time.fixedDeltaTime;
        velocity -= velocity * (drag * Time.fixedDeltaTime);            // ha drag is kell, beletettük
        transform.position += velocity * Time.fixedDeltaTime;           // a velocity tartalmazza már a hosszt is és az irányt is
    }

}
//---------------------------------------------------

//És a kettőből ez a vége

using UnityEngine;

class Gravity : MonoBehaviour
{
    [SerializeField] float acceleratin = 9.81f;
    [SerializeField] float drag = 0.2f;

    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 p = transform.position;
        if (p.y > 0)
        {
            velocity += Vector3.down * acceleratin * Time.fixedDeltaTime;
            velocity -= velocity * (drag * Time.fixedDeltaTime);
            transform.position += velocity * Time.fixedDeltaTime;
        }
        else
        {
            p.y = 0;
            transform.position = p;
            velocity = Vector3.zero;
        }
    }
}

//---------------------------------------------------

// Flappy Bird az a gravity-t folytatjuk, mert az is kell neki

// update - egy gomb nyomás igaz egy nagyobb intervallumban. Fixed-ben meg lehet 5x is meghívódik.. lassú gépen: egyszer sem
// ezért használjuk update-ben a gomb lenyomást, hogy 1x legyen igaz. Más ha nyomva tartjuk... de a lenyomásnál ezt
// ezért update és nem fixed update




using UnityEngine;

class Gravity : MonoBehaviour
{
    [SerializeField] float acceleratin = 9.81f;
    [SerializeField] float drag = 0.2f;
    [SerializeField] KeyCode jumpButton = KeyCode.Space;
    [SerializeField] float jumpSpeed = 10;

    Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 p = transform.position;
        if (p.y >= 0)
        {
            velocity += Vector3.down * acceleratin * Time.fixedDeltaTime;
            velocity -= velocity * (drag * Time.fixedDeltaTime);

        }
        else
        {
            p.y = 0;
            transform.position = p;
            velocity = Vector3.zero;
        }

        transform.position += velocity * Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            velocity += Vector3.up * jumpSpeed;
        }

    }
}

//---------------------------------------------------------------
// SPACE - t figyeljük: (lehet, hogy ez előző kódra vonatkozik, nem tudom, ide írtam fel.

using System.Collections.Generic;
using UnityEngine;

class LetterCount : MonoBehaviour
{
    [SerializeField] string text = "ABC";

    [SerializeField] int count = 0;

    void OnValidate()
    {
        count = CountLetters(text);
    }


    int CountLetters(string text)
    {
        List<char> characters = new List<char>();   // a list  system.collections.generic-et használj, de feldobathatjuk vele
                                                    // ...ha ráállunk és QUick Actions... ezel lehet gyorsítani, "okosítani"

        foreach (char c in text)
        {
            if (!characters.Contains(c))
            {
                characters.Add(c);
            }
        }

        return characters.Count;                    // bonyolult listás megoldások, Linq -val lehet dolgozni, olvass utána.
                                                    // a LINQ előre megírt, plusz - amit lehet használni
    }

}

//----------------------------------

// ----------------------KÖR RAJZOLÁSA--------------------------

//  Gizmos.DrawLine(points[0], points[Count -1]); /// vagy helyette [^1] - az utóbbi vadiúj feature, a szöveges megoldást (-1) cseréli.

using System.Collections.Generic; 
using UnityEngine;

class CircleDrawer : MonoBehaviour
{
    [SerializeField] Vector2 center;
    [SerializeField] float radius;

    [SerializeField, Min(3)] int segmentCount = 60;

    void OnDrawGizmos()
    {
        List<Vector2> points = GetCirclePoints();
        Gizmos.color = Color.yellow;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector2 point = points[i];
            Vector2 point2 = points[i + 1];

            Gizmos.DrawLine(point, point2);
        }

        Gizmos.DrawLine(points[0], points[^1]);   // nulladik és utolsó elem
    }

    List<Vector2> GetCirclePoints()
    {
        List<Vector2> points = new List<Vector2>();

        float segmentAngle = 360f / segmentCount;

        for (int i = 0; i < segmentCount; i++)
        {
            float angle = i * segmentAngle;
            angle *= Mathf.Deg2Rad;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            Vector2 point = new Vector2(x, y) + center;
            points.Add(point);
        }

        return points;
    }

}

//------------------------------ JAVÍTÁS, FENTI LEHET HIBÁS? ++ PARAM-BAN KAPJA MINDET, hogy külön is kezelhető legyen --------------------------------
// hogy kívülről is el tudjuk érni másik osztályból, akkor public legyen és MATHF-hez hasonlóan kell használni
// akkor PUBLIC STATIC --> kívülről is használható, ITT ALUL VAN


using System.Collections.Generic; 
using UnityEngine;

class CircleDrawer : MonoBehaviour
{
    [SerializeField] Vector2 center;
    [SerializeField] float radius;

    [SerializeField, Min(3)] int segmentCount = 60;

    void OnDrawGizmos()
    {
        List<Vector2> points = GetCirclePoints(center, radius, segmentCount);
        Gizmos.color = Color.yellow;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector2 point = points[i];
            Vector2 point2 = points[i + 1];

            Gizmos.DrawLine(point, point2);
        }

        Gizmos.DrawLine(points[0], points[^1]);   // nulladik és utolsó elem
    }

    // ---------------------------------------------------------------------
    // Másik megoldás listával

    public static List<Vector2> GetCirclePoints(Vector2 center, float radius, int segmentCount)
    {
        List<Vector2> points = new List<Vector2>();

        float segmentAngle = 360f / segmentCount;

        for (int i = 0; i < segmentCount; i++)
        {
            float angle = i * segmentAngle;
            angle *= Mathf.Deg2Rad;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            Vector2 point = new Vector2(x, y) + center;
            points.Add(point);
        }

        return points;
    }

}//---------------------------HÁZI VÉGE-----------------------------------------------------



// ------------------------------ 8. óra tananyag -----------------------------------------

// Kijelölsz egy tartalmat, Quick Actions - Extract, adok neki nevet és STATIC, PUBLIC. Kész. Ezzel kb. bármit átkonvertáljuk VOID-dá
// Kijelölsz egy szót, CTRL+RR átnevezés

// UNITY ELŐKÉSZÜLÉS
// NEW - LINE RENDERER kell UNITY-ben.

// Positions - size, elemek száma, alul meg véáltoztatom a pozikat, és látható a játékban
// vastagság
// Kód ablakban új material, shadert adunk hozzá (Sprite shader, default nekünk most elég)
// Materials lelapoz, beledobjuk a cuccost (Materialt)


// -------------------Line renderert és a circle drawert összehozzuk, a line rederer lesz majd a kör, nem a gizmo ------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

class CircleDrawer : MonoBehaviour
{
    [SerializeField] Vector2 center;
    [SerializeField] float radius;

    [SerializeField, Min(3)] int segmentCount = 60;

//       void OnDrawGizmos()
//       {
//           DrawCircleGizmo(center, radius, segmentCount);       // menetközben kivette ahogy fejlődött a kód
//       }

    void OnValidate()
    {
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
            return;

        List<Vector2> points = GetCirclePoints(center, radius, segmentCount);
        lineRenderer.positionCount = points.Count;

        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i]);
        }
    }

//       public static void DrawCircleGizmo(Vector2 center, float radius, int segmentCount)        // nem kell a gizmo, helyette line renderer
//       {
//           List<Vector2> points = GetCirclePoints(center, radius, segmentCount);
//           Gizmos.color = Color.yellow;
//
//           for (int i = 0; i < points.Count - 1; i++)
//           {
//               Vector2 point = points[i];
//               Vector2 point2 = points[i + 1];
//
//               Gizmos.DrawLine(point, point2);
//           }
//
//           Gizmos.DrawLine(points[0], points[^1]);   // nulladik és utulsó elem
//       }

   
    public static List<Vector2> GetCirclePoints(Vector2 center, float radius, int segmentCount)
    {
        List<Vector2> points = new List<Vector2>();

        float segmentAngle = 360f / segmentCount;

        for (int i = 0; i < segmentCount; i++)
        {
            float angle = i * segmentAngle;
            angle *= Mathf.Deg2Rad;

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            Vector2 point = new Vector2(x, y) + center;
            points.Add(point);
        }

        return points;
    }

}

// -----------------------------------------------------------------------------------------



// ------------------------RAYCASTING (Sugárvetés)----------------------------------

using UnityEngine;

public class CursorExploder : MonoBehaviour
{

    void OnDrawGizmos()
    {
        Vector3 cursorScreenPos = Input.mousePosition;                          // Pixel

        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(cursorScreenPos);                    // 2 db pontot és az irányt mutatja (vektor)

        bool ishit = Physics.Raycast(ray, out RaycastHit hit);                 // olvass utána Unity dokumentációban

        if (ishit)
        {
            Vector3 p = hit.point;
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(p, 0.5f);
        }

        //Debug.Log
    }

}
// ez annyit csinál, hogy létrehoz egy sugarat ahol a kurzor jár kirajzolja a gizmo-t

// ----------------------------- folytatás ---------------------------------

// most jön a robbanás nemsokára, legyenminden update-ben és ne gizmoval, ++cékereszttel
// Így szar, mert ha megállunk egy helyben, a golyó felénk jön (mert rajta maradt a sphere-n a collider, MINDEN collidert le)

using UnityEngine;

class CursorExploder : MonoBehaviour
{
    [SerializeField] GameObject cursor3D;

    void Update()
    {
        Vector3 cursorScreenPos = Input.mousePosition;                      // Pixel

        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(cursorScreenPos);

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);

        if (isHit)
        {
            cursor3D.transform.position = hit.point;
            // Gizmos.color = Color.red;
            // Gizmos.DrawSphere(p, 0.5f);
            //CircleDrawer.DrawCircleGizmo(p, 0.5f, 10);
        }
    }

}

// a játékban vagy egy CursorExploder üres objekt, ezen a script, alatta egy sphere 
// ahhoz létrehozva Cursor material és ráhúzva
// A CursorExploder-en van egy Cursor 3d mező, abba húzzuk be a sphere-t
// collidereket levenni...

// ------------ folytatás (egyrészt hibás is volt valószínű, meg tovább is mentünk, alul a tanári, jó verzió -------------

using UnityEngine;

class CursorExploder : MonoBehaviour
{
    [SerializeField] GameObject cursor3D;
    [SerializeField] float range = 10;
    [SerializeField] float maxForce = 100;

    void Update()
    {
        Vector3 cursorScreenPos = Input.mousePosition;              // Pixel

        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(cursorScreenPos);

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);

        if (isHit)
        {
            cursor3D.transform.position = hit.point;

            // Gizmos.color = Color.red;                            // ezt mind kivettük végül
            // Gizmos.DrawSphere(p, 0.5f);
            //CircleDrawer.DrawCircleGizmo(p, 0.5f, 10);
            // cursor3D.SetActive(true);                            // ez is jó lenne párban a másik ilyen kommenttel alul

            if (Input.GetMouseButtonDown(0))                        // 0-bal egér gomb, 1-jobb egér gomb, most bal egérgombra figyelünk
            {
                Explode(hit.point);
            }
            //cursor3D.SetActive(true);                             // ez is jó lenne párban a másik ilyen kommenttel felül. ALső van helyette
        }

        cursor3D.SetActive(isHit);                                  // de végül ez lett
    }

    void Explode(Vector3 position)
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in allRigidbodies)
        {
            Push(rb, position);
        }
    }

    void Push(Rigidbody rb, Vector3 position)
    {
        float distance = Vector3.Distance(position, rb.position);

        if (distance >= range) return;

        float force = (1 - (distance / range)) * maxForce;
        Vector3 direction = (rb.position - position).normalized;  // ha A-ból megyünk B-be, akkor B-A a számolás - az irány miatt

        Vector3 explosionForce = force * direction;

        rb.velocity += explosionForce;
    }
}



// ------------------------- PARTICLE SYSTEMS, BOX RIGIDBODYVAL RAJTA, ÍGY SOKSZOROZZUK, ÉPÍTÜNK VALAMIT ---------------------------
// Sok dobozból vár, majd szét fogjuk rombolni

//  UNITY
//  Particle System (és pár ehhez kapcsolódó beállítás majd a robbantáshoz)
//  Materials - Sprite és Deafault beállítás
//  Render Mode: mesh
//  Meshes: Sphere
//  Start Lifetimer - random between two constants
//  Shape alatt cuccok
//  Size over lifetime bakapcs (nagymenü)
//  Size görbe

//  Start Color első menü lenyit, random between two colors
//  Color over lifetime
//  Első menü start size, lenyit, random 2 color

//  Element - Burst, hogy egyszerre lője ki 100-at

//  túl egységes, start speed is mozogjon 2 érték között

//  lejjebb, gravity modifier - 2 érték között, legyen 2 vagy 10

// ---------------------------------------------------------------------------------



// ------------------------------- ANGRY BIRDS-FÉLE "DOBOZOK" SZÉTÜTÉSÉHEZ, ROBBANÁSÁHOZ ------------------------- 
// a kiindulás az előző kód....

using UnityEngine;

class CursorExploder : MonoBehaviour
{
    [SerializeField] new ParticleSystem particleSystem;
    [SerializeField] GameObject cursor3D;
    [SerializeField] float range = 10;
    [SerializeField] float maxForce = 100;

    void Update()
    {
        Vector3 cursorScreenPos = Input.mousePosition;                  // Pixel

        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(cursorScreenPos);

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);

        if (isHit)
        {
            cursor3D.transform.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                Explode(hit.point);
            }
        }

        cursor3D.SetActive(isHit);
    }

    void Explode(Vector3 position)
    {
        particleSystem.Play();

        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidbodies)
        {
            Push(rb, position);
        }
    }

    void Push(Rigidbody rb, Vector3 position)
    {
        float distance = Vector3.Distance(position, rb.position);

        if (distance >= range) return;

        float force = (1 - (distance / range)) * maxForce;
        Vector3 direction = (rb.position - position).normalized;

        Vector3 explosionForce = force * direction;

        rb.velocity += explosionForce;
    }
}

// loopingot is kikapcsolta
// meg ne kövesse a szülő objektumot, akkor a simulation space nem lokális, hanem world lesz.

// play on awake kikapcs, hogy indításnál ne játssza le.

// -------------------- folytatás -------------------------------


using UnityEngine;

class CursorExploder : MonoBehaviour
{
    [SerializeField] new ParticleSystem particleSystem;
    [SerializeField] GameObject cursor3D;
    [SerializeField] float range = 10;
    [SerializeField] float maxForce = 100;

    void Update()
    {
        Vector3 cursorScreenPos = Input.mousePosition;  // Pixel

        Camera camera = Camera.main;
        Ray ray = camera.ScreenPointToRay(cursorScreenPos);

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);

        if (isHit)
        {
            cursor3D.transform.position = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                Explode(hit.point);
            }
        }

        // cursor3D.SetActive(isHit);
        cursor3D.GetComponent<MeshRenderer>().enabled = isHit;
    }

    void Explode(Vector3 position)
    {
        particleSystem.Play();

        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody rb in allRigidbodies)
        {
            Push(rb, position);
        }
    }

    void Push(Rigidbody rb, Vector3 position)
    {
        float distance = Vector3.Distance(position, rb.position);

        if (distance >= range) return;

        float force = (1 - (distance / range)) * maxForce;
        Vector3 direction = (rb.position - position).normalized;

        Vector3 explosionForce = force * direction;

        rb.velocity += explosionForce;
    }
}

// particle system-et is be kellett kötni, meg volt egy köztes kód ami még "béna" volt, nincs értelme leírni, csak ezt

//-------------------------------- 8. óra vége


*/