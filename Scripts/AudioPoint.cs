using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPoint : MonoBehaviour
{
    private AudioSource audioSource;
    
    // subscribe to fedRabit event
    public CarrotRabbitPairManager carrotRabbitPairManager;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        carrotRabbitPairManager.fedRabbit?.AddListener(PlaySound);
    }

    void PlaySound()
    {
        audioSource.Play();
    }

}
