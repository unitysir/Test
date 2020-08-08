/****************************************************
--------------------------------
    ----------------------------
    文件名称：ZTools
    作者：邹建
    创建日期：2020年08月03日 09:22:27
    ----------------------------
    ----------------------------
    修改次数：0
    修改人员：
    修改日期：
    ----------------------------
    ----------------------------
    功能描述：工具类
    ----------------------------
--------------------------------
*****************************************************/
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

namespace ZTool {

    /// <summary>
    /// 用于监听摇杆事件
    /// </summary>
    public class ZListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {
        public Action<PointerEventData> onClickDown;
        public Action<PointerEventData> onClickUp;
        public Action<PointerEventData> onDrag;

        #region 实现接口

        public void OnPointerDown ( PointerEventData eventData ) {
            onClickDown?.Invoke(eventData);
        }

        public void OnPointerUp ( PointerEventData eventData ) {
            onClickUp?.Invoke(eventData);
        }

        public void OnDrag ( PointerEventData eventData ) {
            onDrag?.Invoke(eventData);
        }

        #endregion
    } //ZListener_End

    /// <summary>
    /// 一些常用工具类
    /// </summary>
    public class ZTools : Single<ZTools> {
        #region 获取两数之间的随机数

        /// <summary>
        /// 获取两数之间的随机数
        /// </summary>
        /// <param name="min">最小</param>
        /// <param name="max">最大</param>
        /// <returns></returns>
        public static int GetIntRand ( int min, int max ) {
            Random rand = new Random( );
            int val = rand.Next(min, max);
            return val;
        }

        #endregion

        #region 得到组件
        /// <summary>
        /// 获取组件，如果对象上没有该组件，则添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <returns></returns>
        public T GetOrAddComponect<T> ( GameObject go ) where T : Component {
            try {
                T t = go.GetComponent<T>( );
                if ( t == null ) {
                    t = go.AddComponent<T>( );
                }

                return t;
            } catch {
                Debug.LogError("没有找到该组件：" + GetType( ).Name + ".GetOrAddComponect");
                return null;
            }
        }

        #endregion

        #region 摇杆插件

        /// <summary>
        /// 当摇杆按下
        /// </summary>
        /// <param name="go">传入对象</param>
        /// <param name="cb">传入委托</param>
        public void OnClickDown ( GameObject go, Action<PointerEventData> cb ) {
            ZListener listener = GetOrAddComponect<ZListener>(go);
            listener.onClickDown = cb;
        }
        /// <summary>
        /// 摇杆抬起
        /// </summary>
        /// <param name="go"></param>
        /// <param name="cb"></param>
        public void OnClickUp ( GameObject go, Action<PointerEventData> cb ) {
            ZListener listener = GetOrAddComponect<ZListener>(go);
            listener.onClickUp = cb;
        }
        /// <summary>
        /// 拖拽摇杆
        /// </summary>
        /// <param name="go"></param>
        /// <param name="cb"></param>
        public void OnDrag ( GameObject go, Action<PointerEventData> cb ) {
            ZListener listener = GetOrAddComponect<ZListener>(go);
            listener.onDrag = cb;
        }

        #endregion

    }

}