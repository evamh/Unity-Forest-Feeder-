using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    // Rotate with Terrain
    private Terrain terrain;
    private float terrainHeight;
    private Vector3 terrainNormal;

    // Start is called before the first frame update
    void Start()
    {
        terrain = FindObjectOfType<Terrain>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate with terrain every frame
        RotateWithTerrain();
    }

    // Rotate the asset to the terrain
    // ChatGPT helped with this 
    private void RotateWithTerrain()
    {
        terrainHeight = terrain.SampleHeight(transform.position);
        terrainNormal = terrain.terrainData.GetInterpolatedNormal((transform.position.x / terrain.terrainData.size.x), 
                                                                    (transform.position.z / terrain.terrainData.size.z));

        transform.rotation = Quaternion.FromToRotation(transform.up, terrainNormal) * transform.rotation;

    }
}
