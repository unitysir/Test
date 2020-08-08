using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        Monster monster1 = new Monster("怪物1");
        monster1.Dead( );

        Monster monster2 = new Monster("海怪");
        monster2.Dead( );

    }

}
