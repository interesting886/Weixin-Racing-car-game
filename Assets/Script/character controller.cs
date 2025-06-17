using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 50f; // 移动速度
    public float turnSpeed = 200f; // 旋转速度
    private float targetAngle; // 目标角度

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing from this GameObject.");
        }
        targetAngle = transform.eulerAngles.y; // 初始化目标角度
    }

    // Update is called once per frame
    void Update()
    {
        // 获取 W 和 S 键的输入
        float vertical = Input.GetAxis("Vertical"); // W/S 控制前进和后退
        Vector3 moveDirection = transform.forward * vertical; // 根据车的前方向移动

        // 移动车辆
        if (moveDirection.magnitude > 0.1f) // 这里可以调节阈值
        {
            rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
        }

        // 处理旋转
        if (Input.GetKeyDown(KeyCode.A)) // A 键向左旋转
        {
            targetAngle -= 90f; // 向左旋转 90 度
        }
        else if (Input.GetKeyDown(KeyCode.D)) // D 键向右旋转
        {
            targetAngle += 90f; // 向右旋转 90 度
        }

        // 平滑旋转
        float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
}