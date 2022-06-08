using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlySpawnPlanets : MonoBehaviour
{

    public Vector2 Center;
    public Vector2 Size;
    public GameObject[] _planetPrefab;

    public int _planetsSpawned = 20;
    public GameObject _planetParent;

    private void Start()
    {
        Vector2 pos = Center + new Vector2(Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2));


        for (int i = 0; i < _planetsSpawned; i++)
        {

            SpawnPlanets();
        }
        
        
    }

    void SpawnPlanets()
    {
        Vector2 pos = Center + new Vector2(Random.Range(-Size.x / 2, Size.x / 2), Random.Range(-Size.y / 2, Size.y / 2));

        Collider2D CollisionWithPlanet = Physics2D.OverlapCircle(pos, 3);
        
        if(CollisionWithPlanet == false)
        {
            GameObject Planets = Instantiate(_planetPrefab[Random.Range(0, _planetPrefab.Length )], pos, Quaternion.identity);
            Planets.transform.SetParent(_planetParent.transform);
        }

        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(Center, Size);
    }

}