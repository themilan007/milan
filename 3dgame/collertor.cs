using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collertor : MonoBehaviour
{
    [SerializeField] TMP_Text uiText;
    int collected = 1;

     void Start()
    {
        uiText.text = "score" + collected;
    }

    public void OnTriggerEnter(Collider other)
    {
        coinCount c = other.GetComponent<coinCount>();

        if (c != null)
        {
            collected += c.GetValue();
            Debug.Log(collected);

            if (uiText != null) 
            uiText.text="score" + collected;
            c.Teleport();
        }
    }
}