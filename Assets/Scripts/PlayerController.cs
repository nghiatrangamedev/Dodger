using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    Rigidbody2D _playerRb;

    float _horizontalInput;
    float _speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager._isPlaying)
        {
            PlayerInput();
        }

        else
        {
            _horizontalInput = 0;
        }
        
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void PlayerMovement()
    {
        _playerRb.MovePosition(transform.position + Vector3.right * _speed * _horizontalInput * Time.deltaTime);
    }
}
