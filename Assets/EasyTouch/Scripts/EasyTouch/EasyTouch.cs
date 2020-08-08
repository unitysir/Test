/****************************************************
--------------------------------
    ----------------------------
    文件名称：EasyTouch
    作者：邹建
    创建日期：2020年08月03日 09:21:29
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：简易摇杆插件
    ----------------------------
--------------------------------
*****************************************************/
using System;
using ZTool;
using UnityEngine;
using UnityEngine.UI;

public class EasyTouch : MonoBehaviour {

    private float pointDis;

    private Image imgTouch;
    private Image imgDirBg;
    private Image imgDirPoint;

    /// <summary>
    /// 设置对象方向
    /// </summary>
    private static Action<Vector2> setDir;
    /// <summary>
    /// 清除方向
    /// </summary>
    private static Action<Vector2> unDir;

    /// <summary>
    /// 控制摇杆移动范围
    /// </summary>
    [SerializeField]
    private int ScreenOPDis;
    /// <summary>
    /// 画布的标准高度
    /// </summary>
    [SerializeField]
    private int canvasHeight;
   
    private Vector2 startPos = Vector2.zero; //起始位置
    private Vector2 defaultPos = Vector2.zero; //默认位置

    private void Awake ( ) {
        imgTouch = GameObject.FindWithTag("ImgTouch").GetComponent<Image>( );
        imgDirBg = GameObject.FindWithTag("ImgDirBg").GetComponent<Image>( );
        imgDirPoint = GameObject.FindWithTag("ImgDirPoint").GetComponent<Image>( );
    }

    private void Start ( ) {
        //实际屏幕的高度 * 1.0 / 画布的标准高度 * 标准的长度
        pointDis = Screen.height * 1.0f / canvasHeight * ScreenOPDis;

        defaultPos = imgDirBg.transform.localPosition;

        imgDirPoint.gameObject.SetActive(false);
        RegisterTouchEvts( );

    }

    /// <summary>
    /// 注册虚拟摇杆事件
    /// </summary>
    public void RegisterTouchEvts () {
        GameObject obj = imgTouch.gameObject;
        ZTools.Instance.OnClickDown(obj, evt => {
            startPos = evt.position;
            imgDirPoint.gameObject.SetActive(true);
            imgDirBg.transform.position = startPos;
        });

        ZTools.Instance.OnClickUp(obj, evt => {
            imgDirBg.transform.localPosition = defaultPos;
            imgDirPoint.gameObject.SetActive(false);
            imgDirPoint.transform.localPosition = Vector2.zero;
            //TODO 抬起角色方向归零，视具体情况修改
            unDir?.Invoke(Vector2.zero);
        });

        ZTools.Instance.OnDrag(obj, evt => {
            Vector2 dir = evt.position - startPos;
            float len = dir.magnitude;

            // 将
            if ( len > pointDis ) {
                Vector2 clamDir = Vector2.ClampMagnitude(dir, pointDis);
                imgDirPoint.transform.position = startPos + clamDir;
            } else {
                imgDirPoint.transform.position = evt.position;
            }

            //TODO 方向传递：通过 dir.normalized 设置摇杆方向
            setDir?.Invoke(dir.normalized);
        });
    }//RegisterTouchEvts_End

    #region 供外部访问 API
    /// <summary>
    /// 设置物体方向
    /// </summary>
    /// <param name="cb">物体方向</param>
    public static void SetDir ( Action<Vector2> cb) {
        setDir = cb;
    }
    /// <summary>
    /// 清除物体方向
    /// </summary>
    /// <param name="cb">物体方向</param>
    public static void UnDir(Action<Vector2> cb ) {
        unDir = cb;
    }
    #endregion

} //EasyTouch_End