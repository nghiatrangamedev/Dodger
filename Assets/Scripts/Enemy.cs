using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager _gameManager;

    float _addPoint = 5;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _gameManager.GameOver();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PointArea")
        {
            _gameManager.AddScore(_addPoint);
            Destroy(gameObject);
        }
    }
}
