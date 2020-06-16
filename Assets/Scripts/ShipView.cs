using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[RequireComponent(typeof(SpriteRenderer))]
class ShipView : MonoBehaviour
{
    [SerializeField] private Sprite shipSprite;
    private Animator animator;
    [SerializeField] private Sprite deadSprite;
    [SerializeField] private AudioClip gunSound;
    [SerializeField] private AudioClip deathSound;
    private ShipModel shipModel;
    private SpriteRenderer SR;
    private AudioSource GunAudioSource;
    private AudioSource DeathAudioSource;
    public AudioMixer AM;
    public bool isPlaying = false;
   



    private void Awake()
    {

       // AM = Resources.Load("MainMixer") as AudioMixer;
        SR = gameObject.GetComponent<SpriteRenderer>();
        SetSprite(shipSprite);
        shipModel = gameObject.GetComponent<ShipModel>();
        
    }

    private void Start()
    {
        GunAudioSource = gameObject.AddComponent<AudioSource>();
        DeathAudioSource = gameObject.AddComponent<AudioSource>();

        GunAudioSource.outputAudioMixerGroup = AM.FindMatchingGroups("Guns")[0];
        GunAudioSource.clip = shipModel.gun.sound;
        GunAudioSource.volume = .5f;
        GunAudioSource.playOnAwake = false;

        DeathAudioSource.outputAudioMixerGroup = AM.FindMatchingGroups("Explosions")[0];
        DeathAudioSource.clip = deathSound;
        DeathAudioSource.volume = .10f;
        DeathAudioSource.playOnAwake = false;
    }

    public void SetSprite(Sprite newSprite)
    {
        SR.sprite = newSprite;
    }

   

    public void OnFire()
    {
        GunAudioSource.pitch = UnityEngine.Random.Range(.5f, 1.5f);
        GunAudioSource.Play();
    }

    public void OnDeath()
    {


        GunAudioSource.Stop();
        DeathAudioSource.Stop();
        SetSprite(deadSprite);
        DeathAudioSource.pitch = UnityEngine.Random.Range(.5f, 1.5f);
        DeathAudioSource.Play();
        

        //var soundTest = new GameObject();
        //var newAudio = soundTest.AddComponent<AudioSource>();
        //newAudio.PlayOneShot(deathSound);
        //Destroy(soundTest, deathSound.length);


        Destroy(gameObject, deathSound.length - 1f);
        
       

    }

 


}

