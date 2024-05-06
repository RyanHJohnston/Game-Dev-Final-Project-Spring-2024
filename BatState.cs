using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatState : MonoBehaviour
{
    [SerializeField] public AudioSource batAudioSource;
    [SerializeField] public AudioClip batSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        batAudioSource.clip = batSoundEffect;
        batAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
