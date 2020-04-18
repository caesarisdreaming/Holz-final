using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{

    public float bgSpeed;

    public Renderer bgRend;

    // Just scrolling the background
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(0f, bgSpeed * Time.deltaTime);
    }
}
