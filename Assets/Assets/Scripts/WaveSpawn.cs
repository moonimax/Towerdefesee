using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawn : MonoBehaviour
{
    //사용할 적 몬스터 프리팹 칸 설정
    public Transform enemyPrefab;

    //시작점 위치 : 스폰할 위치를 가져온다.
    public Transform startPoint;

    //웨티브 타이머
    public float timerWaves = 5.0f;  //웨이브 간격 설정
    private float countdown = 5f;  //카운트 다운 설정

    //웨이브 카운팅
    private int waveCount = 0;

    //카운트 다운 UI 텍스트
    public Text countdownText; //using UnityEngine.UI;가 있어야 Text 사용 가능

    void Start()
    {
        
    }

    void Update()
    {
        /*
        countdown += Time.deltaTime;
        if(countdown >= timerWaves)
        {
            //실행문
            Debug.Log("웨이브 스폰");

            countdown = 0f;
        }
        */
        
        //5초 타이머
        if (countdown <= 0)
        {
            //실행문
            StartCoroutine(SpawnWaves());

            countdown = timerWaves;
        }

        countdown -= Time.deltaTime;

        //countdownText UI에 countdown 값 대입
       // countdownText.text = Mathf.Round(countdown).ToString();
        //Mathf.Round = 정수형
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
