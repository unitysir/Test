using Assets.ZFrame.InputMgr;
using Assets.ZFrame.Mono;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleManCtrl : MonoBehaviour {

    private GameObject roleAniObj;
    private Animator roleAni;
    private AnimatorStateInfo aniInfo;
    private CharacterController playerCtrl;
    private bool isMove = false;
    public float moveSpeed;

    public Button btnPhyAttack;
    public Button btnSkill1;
    public Button btnSkill2;
    public Button btnJumpSkill;

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

    void Start ( ) {
        roleAniObj = transform.GetChild(0).gameObject;
        roleAni = roleAniObj.GetComponent<Animator>( );
        playerCtrl = GetComponent<CharacterController>( );

        CameraCtrl.Instance.Init(transform, -5f, 25f);


        EasyTouch.SetDir(d => {
            Dir = d;
        });

        EasyTouch.UnDir(d => {
            Dir = d;
        });

        MonoMgr.Instance.AddUpdateListener(OnUpdate);


    }

    private void BtnEvent ( ) {
        btnPhyAttack.onClick.AddListener(( ) => {
            roleAni.SetInteger("Attack", 1);
        });

        btnSkill1.onClick.AddListener(( ) => {
            roleAni.SetInteger("Attack", 2);

        });

        btnSkill2.onClick.AddListener(( ) => {
            roleAni.SetInteger("Attack", 3);

        });

        btnJumpSkill.onClick.AddListener(( ) => {
            roleAni.SetInteger("Attack", 4);

        });
        SetState( );
    }

    private void OnUpdate ( ) {
        IsMove( );
        OnGround( );
        BtnEvent( );
    }

    private void SetState ( ) {
        aniInfo = roleAni.GetCurrentAnimatorStateInfo(0);

        if ( aniInfo.normalizedTime >= 1f ) {
            roleAni.SetInteger("Attack", 0);
        }
    }

    /// <summary>
    /// 角色着地
    /// </summary>
    private void OnGround ( ) {
        CameraCtrl.Instance.OnGround(playerCtrl, transform);
    }

    /// <summary>
    /// 角色是否移动
    /// </summary>
    private void IsMove ( ) {
        if ( isMove ) {
            SetDir( );
            SetMove( );
            CameraCtrl.Instance.AutoFollow(transform);
            roleAni.SetBool("IsMove", true);
        } else {
            roleAni.SetBool("IsMove", false);
        }
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
