using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ȷ������ TextMeshPro �����ռ�
using UnityEngine.UI; // ���� UI �����ռ�

public class carcontroller : MonoBehaviour
{
    private Rigidbody rb;
    public float movespeed = 100f;
    public TextMeshProUGUI textMeshPro; // ʹ�� TextMeshProUGUI
    public Image oilImage; // ������ʾ����״̬��ͼƬ
    public Sprite normalOilSprite; // ����������ͼƬ
    public Sprite lowOilSprite; // �����͵�ͼƬ
    public Sprite emptyOilSprite;
    public float oil = 100;
    public int decreasespeed = 1;
    public int increasespeed = 10;
    public float minX;
    public float maxX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        oilImage.sprite = normalOilSprite; // ��ʼ��ʱ������������ͼƬ
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
            textMeshPro.text = $"ʣ����: {oil:.}";
        }

        if (oil <= 0)
        {
            textMeshPro.text = "û��ʣ��Ľ���ˣ�";
        }

        // �л�����ͼƬ
        if (oil < 30 && oil >0)
        {
            oilImage.sprite = lowOilSprite; // �л��������͵�ͼƬ
        }
        else if(oil <= 0)
        {
            oilImage.sprite = emptyOilSprite;
        }
        else
        {
            oilImage.sprite = normalOilSprite; // �л�������������ͼƬ
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
