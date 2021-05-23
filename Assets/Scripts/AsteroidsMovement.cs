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
        //Скорость вращения астероидов
        _rotationSpeed = Random.Range(-25, 25);
        // Значение отклонения курса астероида
        _deviation = Random.Range(-10, 10);
        // Направляем астероид на игрока
        _direction = _player.transform.position - transform.position;
        // Запускаем астероид и добавляем отклонение
        _rb.AddForce(new Vector2(_direction.x + _deviation, _direction.y + _deviation) * Speed);
    }


    void Update()
    {
        // Вращаем астероиды
        transform.Rotate(new Vector3(0, 0, _rotationSpeed) * Time.deltaTime);
        // Проверяем находится ли астероид в игровой зоне. Уничтожаем объект, если он улетел за пределы игры
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
