using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Assets.ZFrame.Mono {
    public class MonoMgr : Single<MonoMgr> {
        private MonoCtrl controller;

        public MonoMgr ( ) {
            GameObject obj = new GameObject("MonoCtrl");
            controller = obj.AddComponent<MonoCtrl>( );
        }


        public void AddUpdateListener ( Action fun ) {
            controller.AddUpdateListener(fun);
        }

        public void DelUpdateListener ( Action fun ) {
            controller.DelUpdateListener(fun);
        }

        public Coroutine StartCoroutine ( string methodName ) {
            return controller.StartCoroutine(methodName);
        }

        public Coroutine StartCoroutine ( string methodName, [DefaultValue("null")] object value ) {
            return controller.StartCoroutine(methodName);
        }

        public Coroutine StartCoroutine ( IEnumerator routine ) {
            return controller.StartCoroutine(routine);
        }
    }
}