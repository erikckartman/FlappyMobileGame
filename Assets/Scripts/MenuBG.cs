using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBG : MonoBehaviour
{
    public Renderer spriteRenderer;
    void Update()
    {
        float offset = Time.time * 0.05f;
        spriteRenderer.material.mainTextureOffset = new Vector2(-offset, 0);
    }
}
