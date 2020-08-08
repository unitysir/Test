using Assets.ZFrame.Mono;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace Assets.ZFrame.InputMgr {
    public class InputMgr : Single<InputMgr> {
        private bool isStart = false;
        private List<KeyCode> keyCodeLst;

        public InputMgr ( ) {
            keyCodeLst = new List<KeyCode>( );
            MonoMgr.Instance.AddUpdateListener(MyUpdate);
        }

        public void AddKeyCode(KeyCode key ) {
            keyCodeLst.Add(key);
        }

        public void StartOrEndCheck ( bool isOpen ) {
            isStart = isOpen;
        }

        //检测按键抬起或者按下
        private void CheckKeyCode (KeyCode key ) {
            if ( Input.GetKeyDown(key) ) {
                EventCenter.Instance.EventTrigger("按键按下",key);
            }

            if ( Input.GetKeyUp(key) ) {
                EventCenter.Instance.EventTrigger( "按键抬起",key);
            }

            if ( Input.GetKey(key) ) {
                EventCenter.Instance.EventTrigger("按下未抬起", key);
            }

        }

        private void MyUpdate ( ) {
            if ( !isStart )
                return;
            foreach ( var key in keyCodeLst ) {
                CheckKeyCode(key);
            }
            //CheckKeyCode(KeyCode.W);
            //CheckKeyCode(KeyCode.S);
            //CheckKeyCode(KeyCode.A);
            //CheckKeyCode(KeyCode.D);
            //CheckKeyCode(KeyCode.Q);
            //CheckKeyCode(KeyCode.Space);
        }
    }
}