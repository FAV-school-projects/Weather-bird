using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Bongs : MonoBehaviour
{
    public float cocaine = 4f;
    private float left;
    private bool pablo = false;

    public static List<Bongs> allObstacles = new List<Bongs>();

    private void Awake()
    {
        allObstacles.Add(this);
    }

    private void Start()
    {
        left = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    private void Update()
    {
        transform.position += Vector3.left * cocaine * Time.deltaTime;

        if(transform.position.x < left)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        allObstacles.Remove(this);
    }

    public void Delete()
    {
        foreach (Bongs obstacle in Bongs.allObstacles.ToArray())
        {
            Destroy(obstacle.gameObject);
        }
    }

    public void ThatBolivian()
    {
        pablo = !pablo;

        if (pablo == true)
        {
            cocaine = 6f;
        } else
        {
            cocaine = 4f;
        }
    }
}
