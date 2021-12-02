using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public abstract class State : MonoBehaviour
    {
        public abstract void OnEnter();
        public abstract void FsmUpdate(float a_deltaTime);
        public abstract void FsmFixedUpdate(float a_fixedDeltaTime);
        public abstract void OnExit();
    }
}