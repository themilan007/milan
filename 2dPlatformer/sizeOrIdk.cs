using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
    public class sizeOrIdk : MonoBehaviour
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

     void Start()
    {
        if(Application.isPlaying)
        Destroy(this);

    }
    void Update()
    {
        boxCollider.size = spriteRenderer.size;
    }

}
