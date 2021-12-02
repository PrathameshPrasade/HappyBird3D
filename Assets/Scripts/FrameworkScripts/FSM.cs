using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public abstract class FSM : MonoBehaviour
    {
        public List<State> m_lstStates = null;
        public State m_startState = null, m_currentState = null, m_previousState = null;

        void Start()
		{
			TransitionTo (m_startState);
		}

        void Update ()
		{
			if (m_currentState != null)
				m_currentState.FsmUpdate(Time.deltaTime);
		}

		void FixedUpdate()
		{
			if (m_currentState != null)
				m_currentState.FsmFixedUpdate(Time.fixedDeltaTime);
		}

        public void TransitionTo(State a_state)
		{
			if (m_lstStates.Contains (a_state)) 
            {
				m_previousState = m_currentState;
				m_currentState = a_state;
				OnStateChange (m_currentState, m_previousState);
			} 
			else 
			{
				Debug.LogError ("FSM :: TransitionTo : Invalid state : " + a_state.name);
			}
		}
        private void OnStateChange(State a_newState, State a_oldState) 
		{
			if (a_oldState != null)
            {
				a_oldState.OnExit ();
            }
			a_newState.OnEnter ();
		}
    }
}