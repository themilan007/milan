using TMPro;
using UnityEngine;

class Collector : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;


    int collected = 0;

    void Start()
    {
        NewMethod();
    }

    void OnTriggerEnter(Collider other)
    {
        Collectable c = other.GetComponent<Collectable>();

        if (c != null)
        {
            collected += c.GetValue();
            Debug.Log(collected);

            NewMethod();

            c.Teleport();
        }
    }

    void NewMethod()
    {
        if (uiText != null)
            uiText.text = "Score " + collected;
    }
}