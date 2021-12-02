using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform m_Target;
    public Transform m_CameraTF;
    private Vector3 m_Velocity = Vector3.zero;
    private Vector3 m_Offset, m_CameraTargetPosition;
    public float m_SmoothFactor = 0.3f;
    
    private void Start()
    {
        m_Offset = m_CameraTF.position - m_Target.position;
    }
 
    private void LateUpdate()
    {
        m_CameraTargetPosition = m_Target.position + m_Offset;
        m_CameraTF.position = Vector3.SmoothDamp(transform.position, m_CameraTargetPosition, ref m_Velocity, m_SmoothFactor);
        transform.LookAt(m_Target);
    }
}
