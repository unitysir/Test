using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake ( )
    {
        EventCenter.Instance.AddEventListener("MonsterDead", GetCoin);

    }
    public void GetCoin ( ) {
        Debug.Log("获得金币");
    }
}
