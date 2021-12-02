using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird Instance = null;
    public Rigidbody m_BirdRB;
    bool m_Tapped = false;
    public float m_ForwardMovementSpeed = 0.05f;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        switch(UIManager.Instance.m_CurrentDifficulty)
        {
            case Difficulty.Easy:
                m_ForwardMovementSpeed = 0.03f;
            break;
            case Difficulty.Medium:
                m_ForwardMovementSpeed = 0.05f;
            break;
            case Difficulty.Hard:
                m_ForwardMovementSpeed = 0.1f;
            break;
        }
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                m_Tapped = true;
            }
        }
        if (Input.GetKeyDown("space"))
        {
            m_Tapped = true;
        }
    }

    void FixedUpdate()
    {
        m_BirdRB.MovePosition(transform.position + Vector3.forward * m_ForwardMovementSpeed);
        if(m_Tapped)
        {
            m_Tapped = false;
            m_BirdRB.AddRelativeForce (Vector3.up * 150);
        }
    }
}
