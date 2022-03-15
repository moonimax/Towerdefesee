using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] enemyWave; //= new GameObject[5];

    int enemyCounting;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextEnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator NextEnemySpawn()
    {
        //���̺� ����
        for (int i = 0; i < enemyWave.Length; i++)
        {
            enemyWave[i] = Instantiate(enemy);

            yield return new WaitForSecondsRealtime(0.5f);

            StartCoroutine(EnemySpawn(i));

            yield return new WaitForSecondsRealtime(5.0f);
        }
    }

    IEnumerator EnemySpawn(int x)
    {
        //���̺� �� ���� �߰� �� ���� ����
        for (int j = 0; j < x; j++)
        {
            Instantiate(enemy, new Vector3(0, 1.5f, 0), Quaternion.identity);

            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
