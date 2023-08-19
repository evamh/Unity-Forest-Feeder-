using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialCommunication : MonoBehaviour
{
    private string received;
    private SerialPort port;
    [SerializeField] int timeout = 1; 
    [SerializeField] string portValue;
    [SerializeField] CarrotFeeder carrotFeeder;

    // Start is called before the first frame update
    void Start()
    {
        port = new SerialPort(portValue, 9600);
        port.DtrEnable = true;
        port.RtsEnable = true;
        port.ReadTimeout = timeout;

        try
        {
            port.Open();
            Debug.Log("port opened");

        } catch (System.Exception e) {
            Debug.LogError("Failed to open port" + e);
        }

        StartCoroutine(ReadSerialData());
    }

    void OnDestroy()
    {
        if(port != null && port.IsOpen)
        {
            port.Close();
            Debug.Log("Port closed");
        }
    }

    IEnumerator ReadSerialData()
    {
        while(true)
        {
            try
            {
                if(port.IsOpen)
                {
                    received = port.ReadLine();
                    Debug.Log("received: " + received);  

                    if(received == "a")
                    {
                        carrotFeeder.DropCarrot();
                    }
                }
            } catch (System.Exception e)
            { 
                Debug.LogWarning("Exception occured in ReadSerialData(): " + e);
            }

            port.ReadTimeout = timeout;     

            yield return new WaitForSeconds(0.1f);    
        } 
    }


}