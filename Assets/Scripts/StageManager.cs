using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    void Start()
    {
        // 적을 코드 생성!!

        // 만들고 싶은 대상을 -> 프리팹 -> 저장
        // Resources 폴더 안에 저장

        // 1. 리소스 로드
        // Resources 폴더 -> 메모리 올려야하니다.
        Object enemy = Resources.Load("CubeEnemy");

        // 2. 불러온 리소스를 실제로 생성
        // Instantiate(enemy);

        // Instantiate(오브젝트, 위치, 회전);
        // Instantiate(enemy, new Vector3(2, 0, -2), Quaternion.identity);

        for (int i = 0; i < 10; i++)
        {
            float randomX = Random.Range(-10, 10.0f);
            float randomZ = Random.Range(-10, 10.0f);

            Instantiate(enemy, new Vector3(randomX, 0, randomZ), Quaternion.identity);        
        }        
    }
}
