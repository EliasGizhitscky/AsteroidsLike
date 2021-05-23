using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Уничтожаем астероид, если он коснулся пули и начисляем очки
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ScoreManager.Score += 5;
            Destroy(gameObject);
        }
    }
}
