using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demager : MonoBehaviour
{
    [SerializeField] int dam = 10;

     void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
       // Debug.Log(go.name);

        healt ho = go.GetComponent<healt>();

        if (ho != null)
        {
            ho.Damage(dam);

        }
    }
}
