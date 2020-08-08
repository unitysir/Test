using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.ZFrame.Mono {
    public class MonoCtrl : MonoBehaviour {
        private Action action;
        public void AddUpdateListener ( Action fun ) {
            action += fun;
        }

        public void DelUpdateListener ( Action fun ) {
            action -= fun;
        }

        private void Start ( ) {
            DontDestroyOnLoad(this);
        }

        private void Update ( ) {
            action?.Invoke( );
        }
    }
}