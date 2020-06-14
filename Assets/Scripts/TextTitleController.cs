using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextTitleController : MonoBehaviour
{
     private Material titleMaterial;
    [SerializeField] private TMP_FontAsset fontAsset;
    [SerializeField]private Color[] colors;
    
    [SerializeField] private float lerpTime;
    [SerializeField] private float speed = 1f;
    private float timer = 0;
    private float changeColourTime = 2;

    private int nextIndex;
    private int currentIndex;
  

    private void Awake()
    {
        titleMaterial = gameObject.GetComponent<TextMeshProUGUI>().fontSharedMaterial;
    }

    private void Start()
    {
        nextIndex = (currentIndex + 1) % colors.Length;

        titleMaterial.SetColor(ShaderUtilities.ID_GlowColor, colors[0]);

    }


    private void Update()
    {
        GlowHueShift();
    }

    private void GlowHueShift()
    {


        timer += Time.deltaTime;
        if (timer > changeColourTime)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            nextIndex = (currentIndex + 1) % colors.Length;
            timer = 0f;
        }



        Color newColor = Color.Lerp(colors[currentIndex], colors[nextIndex], timer/changeColourTime);

        titleMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color(newColor.r, newColor.g, newColor.b));

        







    }


}
