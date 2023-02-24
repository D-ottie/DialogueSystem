using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_verticalInput;
    public float m_horizontalInput;
    public float m_speed = 10;
    void Update()
    {
        m_verticalInput = Input.GetAxis("Vertical");
        m_horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(m_horizontalInput*m_speed, m_verticalInput * m_speed, 0);

    }
}
