using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCarrotDrop : MonoBehaviour
{
    private AudioSource audioSource;

    // subscribe to carrotDropped event
    public CarrotFeeder carrotFeeder;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        carrotFeeder.carrotDropped?.AddListener(PlaySound);
    }

    void PlaySound(GameObject _)
    {
        audioSource.Play();
    }

}
