using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ������ ����������
    public GameObject[] Asteroids;
    // ������ ����� ������
    public GameObject[] SpawnPositions;

    //��� ������� ������
    private float _spawnRate = 10f;
    private float _timeToSpawn;
    
    void Start()
    {
        _timeToSpawn = _spawnRate;
        Spawn();
    }

    void Update()
    {
        // ������ ������� ������
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
        // �������� ����� ������
        Vector2 position = SpawnPositions[Random.Range(0, SpawnPositions.Length)].transform.position;
        // ������� ��������
        GameObject asteroid = Instantiate(Asteroids[Random.Range(0, Asteroids.Length)], new Vector2(position.x, position.y), transform.rotation);
    }
}
