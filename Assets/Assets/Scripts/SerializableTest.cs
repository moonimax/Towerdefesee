using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableTest : MonoBehaviour
{
    public int number;
    [HideInInspector]
    public int hiddenNumber = 10;
    private int count;
    [SerializeField]
    
    public string newname = "ȫ�浿";
    public static string description = "menu def";
}
