using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public Gun gunScriptable;
    public AudioSource gunSound;
    

    // Start is called before the first frame update
    void Start()
    {
        if(gunScriptable != null)
        {
            gunSound.volume = gunScriptable.sound;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {

            gunSound.Play();
        }
    }




}
