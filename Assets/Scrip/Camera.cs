using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float start,end;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var playrX = player.transform.position.x;
        var camX = transform.position.x;
        var camY = transform.position.y;
        var camZ = transform.position.z;

        if (playrX > start && playrX < end)
        {
            camX = playrX;
        }

        if (playrX < start)
        {
            camX = start;
        }

        if (playrX > end)
        {
            camX = end;
        }

        transform.position = new Vector3(camX, camY, camZ);

    }
}
