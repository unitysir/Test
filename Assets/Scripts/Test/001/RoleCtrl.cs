/****************************************************
--------------------------------
    ----------------------------
    文件名称：RoleCtrl
    作者：邹建
    创建日期：2020年08月02日 15:39:49
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：角色控制  手机端设置 40  Pc端设置 80
    ----------------------------
--------------------------------
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleCtrl : MonoBehaviour {
    private GameObject roleAniObj;
    private Animation roleAni;
    private CharacterController playerCtrl;
    private bool isMove = false;
    public float moveSpeed;

    private Vector2 dir = Vector2.zero;
    public Vector2 Dir {
        get => dir;
        set {
            if ( value == Vector2.zero ) {
                isMove = false;
            } else {
                isMove = true;
            }

            dir = value;
        }
    }

    private void Start ( ) {
        roleAniObj = transform.GetChild(0).gameObject;
        roleAni = roleAniObj.GetComponent<Animation>( );
        playerCtrl = GetComponent<CharacterController>( );

        EasyTouch.SetDir(dir => {
            SetMoveDir(dir);
        });

        EasyTouch.UnDir(dir => {
            SetMoveDir(dir);
        });
    }

    private void Update ( ) {

        CameraCtrl.Instance.OnGround(playerCtrl, transform);

        //SetCam( );

        if ( isMove ) {
            SetDir( );
            SetMove( );
            roleAni.CrossFade("Run");
        } else {
            roleAni.CrossFade("Stand");
        }

        if ( Input.GetKeyUp(KeyCode.Q) ) {
            roleAni.Play("Attack_01");
        }

        if ( Input.GetKeyUp(KeyCode.W) ) {
            roleAni.Play("Attack_02");
        }

    }

    /// <summary>
    /// 设置移动时的方向
    /// </summary>
    /// <param name="dir"></param>
    private void SetMoveDir ( Vector2 dir ) {
        Dir = dir;
    }

    /// <summary>
    /// 设置移动
    /// </summary>
    private void SetMove ( ) {
        playerCtrl.Move(transform.forward * Time.deltaTime * moveSpeed);
    }

    /// <summary>
    /// 设置方向
    /// </summary>
    private void SetDir ( ) {
        float angle = Vector2.SignedAngle(Dir, new Vector2(0, 1));
        Debug.Log(angle);
        transform.localEulerAngles = new Vector3(0, angle, 0);
    }
}
