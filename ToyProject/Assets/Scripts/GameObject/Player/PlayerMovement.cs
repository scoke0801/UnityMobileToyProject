using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1.0f; 
    public float rotateSpeed = 40.0f;

    private Rigidbody playerRigidboy;
    private PlayerInput playerInput;
    private Animator playerAnimator;

    GameScene _currentScene;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidboy = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        _currentScene = (GameScene)Managers.Scene.CurrentScene;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_currentScene && _currentScene.IsGamePaused)
        {
            return;
        }
        Move();
        Rotate();

        playerAnimator.SetFloat("Forward", playerInput.move); 
        //playerAnimator.SetFloat("Turn", playerInput.rotate);
    }

    private void Move()
    {
        Vector3 moveDist = playerInput.move * transform.forward * moveSpeed * Time.fixedDeltaTime; 
        playerRigidboy.MovePosition(playerRigidboy.position + moveDist);
    }

    private void Rotate()
    {
        if( playerInput.move == 0.0f ) { return; }

        float turn = playerInput.rotate * rotateSpeed * Time.fixedDeltaTime;

        playerRigidboy.rotation = playerRigidboy.rotation * Quaternion.Euler(0f, turn, 0f);
    }

    public void Dash()
    {
        Debug.Log("Dash!");
        Vector3 moveDist = transform.forward * moveSpeed * 1.2f;
        playerRigidboy.MovePosition(playerRigidboy.position + moveDist);
    }
}
