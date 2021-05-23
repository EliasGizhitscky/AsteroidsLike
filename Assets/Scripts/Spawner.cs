using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // массив астероидов
    public GameObject[] Asteroids;
    // массив точек спавна
    public GameObject[] SpawnPositions;

    //Для таймера спавна
    private float _spawnRate = 10f;
    private float _timeToSpawn;
    
    void Start()
    {
        _timeToSpawn = _spawnRate;
        Spawn();
    }

    void Update()
    {
        // Запуск таймера спавна
        if (_timeToSpawn > 0)
        {
            _timeToSpawn -= Time.deltaTime;
        }
        else
        { 
            Spawn();
            _timeToSpawn = _spawnRate;
        }
    }

    void Spawn()
    {
        // Выбираем точку спавна
        Vector2 position = SpawnPositions[Random.Range(0, SpawnPositions.Length)].transform.position;
        // Создаем астероид
        GameObject asteroid = Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], new Vector2(position.x, position.y), transform.rotation);
    }
}
