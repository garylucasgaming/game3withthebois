using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    private Material material;
    [SerializeField] private float backgroundScrollSpeed = 0.5f;
    private Vector2 offset;

    private void Awake()
    {
        material = gameObject.GetComponent<Renderer>().material;
    }

    private void Start()
    {
        offset = new Vector2(0f, backgroundScrollSpeed);
    }


    void Update()
    {
        if (material.mainTextureOffset.y == 1f) { material.mainTextureOffset = Vector2.zero; }
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
