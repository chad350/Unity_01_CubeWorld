using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌했습니다"); 
        
        Debug.Log("1 : " + gameObject.name);
        Debug.Log("2 : " + collision.gameObject.name);
        
    }
}
