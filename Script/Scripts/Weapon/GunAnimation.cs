using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    SpriteRenderer sr;
    GunRotation gr;
    private float gunRotation;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gr = GetComponentInParent<GunRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gr.left == true)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }

    }
}
