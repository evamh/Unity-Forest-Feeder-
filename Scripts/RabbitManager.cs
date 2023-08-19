using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RabbitManager : MonoBehaviour
{
    private GameObject targetCarrot;
    private bool hasEaten;
    public int radiusToCheck = 5;

    void Start() 
    {
        hasEaten = false;
    }

    public bool GetHasEaten()
    {
        return hasEaten;
    }

    public void Feed(GameObject carrot)
    {
        targetCarrot = carrot;
        hasEaten = true;
    }
}
