using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    private float _bulletForce = 10f;



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // ������� ���� � ������ ��������
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // ��������� ����
        rb.AddForce(FirePoint.up * _bulletForce, ForceMode2D.Impulse);

    }
}
