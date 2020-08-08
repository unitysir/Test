using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster {
    private string name;
    public Monster(string name ) {
        this.name = name;
        
    }
    public void Dead ( ) {
        EventCenter.Instance.EventTrigger("MonsterDead");
        Debug.Log(name + " 被玩家干掉了！");
    }
}
