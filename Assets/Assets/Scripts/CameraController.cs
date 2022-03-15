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
        //AŰ �� �ޱ� I - ������ �̵�
        if (Input.GetKey(KeyCode.W) )//|| Input.mousePosition.y > Screen.height - 10)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }

        //AŰ �� �ޱ� I - ������ �̵�
                    

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



        //���콺 �ٰ��� �޾Ƽ� ���. Ȯ�� ����� �����ϱ�
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * Time.deltaTime * scrollSpeed;
       // �ּ�, �ִ밪 ����
        pos.y = Mathf.Clamp(pos.y, minValue, maxValue); //min���� ������ minValue���� pos.y�� ����ϰ� �ϰ�
        transform.position = pos;




        
        













        /*
        if (scroll != 0f)
        {
            Debug.Log($"scroll: {scroll}");
        }

        */


    }
}
