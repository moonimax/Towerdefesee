using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    //����� �� ���� ������ ĭ ����
    public Transform enemyPrefab;

    //������ ��ġ : ������ ��ġ�� �����´�.
    public Transform startPoint;

    //��Ƽ�� Ÿ�̸�
    public float timerWaves = 5.0f;  //���̺� ���� ����
    private float countdown = 5f;  //ī��Ʈ �ٿ� ����

    //���̺� ī����
    private int waveCount = 0;

    //ī��Ʈ �ٿ� UI �ؽ�Ʈ
    public Text countdownText; //using UnityEngine.UI;�� �־�� Text ��� ����

    void Start()
    {
        
    }

    void Update()
    {
        /*
        countdown += Time.deltaTime;
        if(countdown >= timerWaves)
        {
            //���๮
            Debug.Log("���̺� ����");

            countdown = 0f;
        }
        */
        
        //5�� Ÿ�̸�
        if (countdown <= 0)
        {
            //���๮
            StartCoroutine(SpawnWaves());

            countdown = timerWaves;
        }

        countdown -= Time.deltaTime;

        //countdownText UI�� countdown �� ����
       // countdownText.text = Mathf.Round(countdown).ToString();
        //Mathf.Round = ������
        countdownText.text = string.Format("{0:00:00}", countdown);
    }

    IEnumerator SpawnWaves()
    {
        waveCount++;
        PlayerStats.rounds++;
        for (int i = 0; i < waveCount; i++)
        {
            EnemySpawn();
            yield return new WaitForSeconds(0.3f);
        }

        //Debug.Log($"waveCount : {waveCount}");
    }

    private void EnemySpawn()
    {
        Instantiate(enemyPrefab, startPoint.position, Quaternion.identity);
    }
}
