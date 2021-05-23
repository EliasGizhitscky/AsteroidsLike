using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    // Скорость поворота корабля
    private float _rotationSpeed = 100f;
    private float _moveSpeed = 5f;
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _rotationSpeed = 100;
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            //Связываем скорость поворота и его направление
            float rotate = Input.GetAxis("Horizontal") * (-_rotationSpeed * Time.deltaTime);
            //Текущий поворот
            float currentRotation = gameObject.transform.rotation.eulerAngles.z;
            //Добавляем к текущему повороту новое направление 
            Quaternion rotation = Quaternion.Euler(0, 0, currentRotation + rotate);
            //Присваиваем
            gameObject.transform.rotation = rotation;
        }
        if (Input.GetAxis("Vertical")  > 0) 
        {
           transform.position += transform.up * Time.deltaTime * _moveSpeed * Input.GetAxis("Vertical");
        }
    }
}
