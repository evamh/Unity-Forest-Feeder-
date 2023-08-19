using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBehaviour : MonoBehaviour
{
    public CarrotFeeder carrotFeeder;

    // Update is called once per frame
    void Update()
    {
        OnClick();
    }

    void OnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            carrotFeeder.DropCarrot();
        }
    }
}
