using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 50f; // �ƶ��ٶ�
    public float turnSpeed = 200f; // ��ת�ٶ�
    private float targetAngle; // Ŀ��Ƕ�

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from this GameObject.");
        }
        targetAngle = transform.eulerAngles.y; // ��ʼ��Ŀ��Ƕ�
    }

    // Update is called once per frame
    void Update()
    {
        // ��ȡ W �� S ��������
        float vertical = Input.GetAxis("Vertical"); // W/S ����ǰ���ͺ���
        Vector3 moveDirection = transform.forward * vertical; // ���ݳ���ǰ�����ƶ�

        // �ƶ�����
        if (moveDirection.magnitude > 0.1f) // ������Ե�����ֵ
        {
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }

        // ������ת
        if (Input.GetKeyDown(KeyCode.A)) // A ��������ת
        {
            targetAngle -= 90f; // ������ת 90 ��
        }
        else if (Input.GetKeyDown(KeyCode.D)) // D ��������ת
        {
            targetAngle += 90f; // ������ת 90 ��
        }

        // ƽ����ת
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
}