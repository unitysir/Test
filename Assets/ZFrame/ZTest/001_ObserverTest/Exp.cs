using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake ( )
    {
        EventCenter.Instance.AddEventListener("MonsterDead", GetExp);

    }
    public void GetExp ( ) {
        Debug.Log("获得经验");
    }

}
