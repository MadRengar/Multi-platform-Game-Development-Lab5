using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationPlants : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 1.0f;
    public Vector2 spawnRangeX = new Vector2(-8f, 8f);
    public float spawnY = 10f;
    public float spawnZ = 0f;
    public Transform generationPosition;
    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    // Update is called once per frame
    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            // �������X���λ��
            float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);

            // ������ʯ
            Vector3 spawnPosition = new Vector3(randomX, spawnY, spawnZ);
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

            // �ȴ�ָ����ʱ������������
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
