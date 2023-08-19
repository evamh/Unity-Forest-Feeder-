using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarrotRabbitPairManager : MonoBehaviour
{
    public CarrotFeeder carrotFeeder;
    [SerializeField] GameObject character;
    [SerializeField] int radiusToCheck = 5;

    public UnityEvent fedRabbit = new UnityEvent();

    void Start()
    {
        carrotFeeder.carrotDropped?.AddListener(FindNearestRabbit);
    }

    // return first rabbit collision that hasn't been fed 
    void FindNearestRabbit(GameObject carrot)
    {
        Collider[] collisions = Physics.OverlapSphere(character.transform.position, radiusToCheck);
        foreach(Collider collision in collisions)
        {
            GameObject potentialRabbit = collision.gameObject;
            if(potentialRabbit.tag == "Rabbit")
            {
                RabbitManager manager = potentialRabbit.GetComponent<RabbitManager>();

                if(!manager.GetHasEaten())
                {
                    manager.Feed(carrot);
                    fedRabbit?.Invoke();
                    break;
                }
            }
        }
    }
}
