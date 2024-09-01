using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public Transform[] spawnPoint; // 스폰 위치
    public GameObject bear; // 스폰 객체
    public GameObject helicopter;
    public Transform[] helicopterSpawnPos;

    void Start()
    {
        GameManager.Instance.spawnManger = this;   
    }

    // 헬리콥터 랜덤 위치 생성
    public void SpawnHelicopter()
    {
        Transform transform = helicopterSpawnPos[Random.Range(0, helicopterSpawnPos.Length)];
        Instantiate(helicopter, transform.position, Quaternion.identity);
    }

    // 곰 랜덤 위치에 생성
    public void SpawnBear()
    {
        // 스폰 위치를 4 중에 1개를 선택해서 그 위치에 스폰해야함
        Instantiate(bear, spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);
    }
}
