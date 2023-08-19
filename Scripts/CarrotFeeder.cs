using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CarrotFeeder : MonoBehaviour
{
    public UnityEvent<GameObject> carrotDropped = new UnityEvent<GameObject>();

    [SerializeField] GameObject carrotPrefab;
    [SerializeField] GameObject character;
    [SerializeField] float sendCarrotDistance = 2.0f;
    [SerializeField] int radius;

    public void DropCarrot()
    {
        // Calculate where the instantiated carrot should be dropped 
        Vector3 characterPos = character.transform.position;
        Vector3 carrotPos = characterPos + Camera.main.transform.forward * sendCarrotDistance;  
        Instantiate(carrotPrefab, carrotPos, Quaternion.identity);

        carrotDropped?.Invoke(carrotPrefab);
    }

}
