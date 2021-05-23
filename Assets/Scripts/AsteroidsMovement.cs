using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private Vector2 _direction;

    private GameObject _player;

    public float Speed;

    private float _rotationSpeed;
    private float _deviation;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        //�������� �������� ����������
        _rotationSpeed = Random.Range(-25, 25);
        // �������� ���������� ����� ���������
        _deviation = Random.Range(-10, 10);
        // ���������� �������� �� ������
        _direction = _player.transform.position - transform.position;
        // ��������� �������� � ��������� ����������
        _rb.AddForce(new Vector2(_direction.x + _deviation, _direction.y + _deviation) * Speed);
    }


    void Update()
    {
        // ������� ���������
        transform.Rotate(new Vector3(0, 0, _rotationSpeed) * Time.deltaTime);
        // ��������� ��������� �� �������� � ������� ����. ���������� ������, ���� �� ������ �� ������� ����
        CheckPosition();
    }

    public void CheckPosition()
    {
        if (transform.position.x > 18 || transform.position.x < -18)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > 10 || transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
