using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float moveSpeed = 30f;

    public float scrollSpeed = 0.5f;

    private float minValue = 10f;
    private float maxValue = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //A키 값 받기 I - 앞으로 이동
        if (Input.GetKey(KeyCode.W) )//|| Input.mousePosition.y > Screen.height - 10)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }

        //A키 값 받기 I - 앞으로 이동
                    

        else if(Input.GetKey(KeyCode.A)) //|| Input.mousePosition.x <  10)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }

        else if(Input.GetKey(KeyCode.D)) //|| Input.mousePosition.x > Screen.width - 10)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }
        
        else if (Input.GetKey(KeyCode.S)) // || Input.mousePosition.y <  10)
        { 
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
        }



        //마우스 휠값을 받아서 축소. 확대 기능을 구현하기
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * Time.deltaTime * scrollSpeed;
       // 최소, 최대값 적용
        pos.y = Mathf.Clamp(pos.y, minValue, maxValue); //min보다 작으면 minValue값을 pos.y에 사용하게 하고
        transform.position = pos;




        
        













        /*
        if (scroll != 0f)
        {
            Debug.Log($"scroll: {scroll}");
        }

        */


    }
}
