using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float speed;
    private Vector3 targetPosition;


    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            targetPosition.Set(target.transform.position.x, 3, target.transform.position.z - 4.5f);
            transform.position = targetPosition;
            //this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
