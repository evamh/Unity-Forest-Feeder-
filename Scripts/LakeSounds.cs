using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeSounds : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int startPlayingRadius = 50;
    public AudioSource lakeAudio;

    [SerializeField] float min = 0.0f;
    [SerializeField] float max = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        lakeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    // ChatGPT helped with this
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        float distance = Vector3.Distance(playerPosition, transform.position);
        float normalized = distance / startPlayingRadius;

        // increase volume as you get closer 
        float volume = Mathf.InverseLerp(max, min, normalized);
        lakeAudio.volume = volume;
    }
}
