using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 确保引入 TextMeshPro 命名空间
using UnityEngine.UI; // 引入 UI 命名空间

public class carcontroller : MonoBehaviour
{
    private Rigidbody rb;
    public float movespeed = 100f;
    public TextMeshProUGUI textMeshPro; // 使用 TextMeshProUGUI
    public Image oilImage; // 用于显示油量状态的图片
    public Sprite normalOilSprite; // 正常油量的图片
    public Sprite lowOilSprite; // 油量低的图片
    public Sprite emptyOilSprite;
    public float oil = 100;
    public int decreasespeed = 1;
    public int increasespeed = 10;
    public float minX;
    public float maxX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        oilImage.sprite = normalOilSprite; // 初始化时设置正常油量图片
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontal, 0f, 0f);
        moveDirection = transform.TransformDirection(moveDirection);
        if (horizontal != 0f)
        {
            rb.MovePosition(transform.position + moveDirection * movespeed * Time.deltaTime);
        }

        if (oil > 0)
        {
            oil -= Time.deltaTime * decreasespeed;
            textMeshPro.text = $"剩余金币: {oil:.}";
        }

        if (oil <= 0)
        {
            textMeshPro.text = "没有剩余的金币了！";
        }

        // 切换油量图片
        if (oil < 30 && oil >0)
        {
            oilImage.sprite = lowOilSprite; // 切换到油量低的图片
        }
        else if(oil <= 0)
        {
            oilImage.sprite = emptyOilSprite;
        }
        else
        {
            oilImage.sprite = normalOilSprite; // 切换回正常油量的图片
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));

            if (transform.position.x >= minX && transform.position.x <= maxX)
            {
                transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
                if (transform.position.x > maxX)
                {
                    transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < minX)
                {
                    transform.position = new Vector3(minX, transform.position.y, transform.position.z);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("oil"))
        {
            oil += increasespeed;
        }
    }
}
