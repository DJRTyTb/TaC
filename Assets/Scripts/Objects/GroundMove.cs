using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    //public float miniPart;
    public CameraMove cameraObj;

    void Start()
    {
        //miniPart = transform.localScale.x * (300F / 1455F);
    }

    void Update()
    {
        float cameraX = cameraObj.transform.position.x;

        transform.SetPositionAndRotation(new Vector3(cameraX, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));

        /*if (cameraX / miniPart >= 1 && cameraX > 0 && miniPart > 0)
            transform.SetPositionAndRotation(new Vector3(transform.position.x + miniPart, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        else if(cameraX / miniPart >= 1 && cameraX < 0 && miniPart < 0)
            transform.SetPositionAndRotation(new Vector3(transform.position.x - miniPart, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        else if(cameraX / miniPart <= -1 && cameraX > miniPart)
            transform.SetPositionAndRotation(new Vector3(transform.position.x + miniPart, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        else if (cameraX / miniPart <= -1 && cameraX < miniPart)
            transform.SetPositionAndRotation(new Vector3(transform.position.x - miniPart, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));*/
    }
}
