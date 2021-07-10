using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    Rigidbody m_Rigidbody;
    AudioSource m_audioSource;
    Animator m_Animator;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        // Approximately: 2���� �÷�Ʈ ���� �����ϸ� ��, �׷��� ������ ������ ��ȯ��
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if(isWalking)
        {
            if(!m_audioSource.isPlaying)
            {
                m_audioSource.Play();
            }
        }
        else
        {
            m_audioSource.Stop();
        }

        //RotateTowards: ó�� �� �Ķ���ʹ� Vector3�� ���� ȸ�� ���� ��ǥ ȸ�� ����
        //�� ��°�� ������ ��ȭ(����: ����)�̰� �� ��°�� ũ���� ��ȭ�Դϴ�.
        Vector3 desireForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        // �ش� �Ķ���� �������� �ٶ󺸴� ȸ���� �����մϴ�.
        m_Rotation = Quaternion.LookRotation(desireForward);
    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
