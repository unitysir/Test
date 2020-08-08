using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventCenter.Instance.AddEventListener("MonsterDead", GetOther);
    }

    public void GetOther ( ) {
        Debug.Log("获得其他");
    }

}
