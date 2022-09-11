using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1.0f;

    [SerializeField]
    private float _rotateSpeed = 40.0f;

    private Rigidbody _playerRigidboy;
    private PlayerInput _playerInput;
    private Animator _playerAnimator; 

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRigidboy = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Rotate();

        _playerAnimator.SetFloat("Forward", _playerInput.Move); 
        //playerAnimator.SetFloat("Turn", playerInput.rotate);
    }

    private void Move()
    {
        Vector3 moveDist = _playerInput.Move * transform.forward * _moveSpeed * Time.fixedDeltaTime; 
        _playerRigidboy.MovePosition(_playerRigidboy.position + moveDist);
    }

    private void Rotate()
    {
        if( _playerInput.Move == 0.0f ) { return; }

        float turn = _playerInput.Rotate * _rotateSpeed * Time.fixedDeltaTime;

        _playerRigidboy.rotation = _playerRigidboy.rotation * Quaternion.Euler(0f, turn, 0f);
    }

    public void Dash()
    { 
        Vector3 moveDist = transform.forward * _moveSpeed * 1.2f;
        _playerRigidboy.MovePosition(_playerRigidboy.position + moveDist);
    }
}
