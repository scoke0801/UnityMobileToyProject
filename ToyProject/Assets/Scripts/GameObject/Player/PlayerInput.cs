using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const string moveAixName = "Vertical";
    public const string rotateAxisName = "Horizontal";
    public const string fireButtonName = "Fire1";
    public const string reloadButtonName = "Reload";
    
    public float Move { get; private set; }
    public float Rotate { get; private set; }
    public bool Fire { get; private set; }
    public bool Reload { get; private set; }

    private PlayerShooter _playerShooter;
    private PlayerMovement _playerMovement;

    public JoyStick _joyStick;

    // Start is called before the first frame update
    void Start()
    {
        _playerShooter = GetComponent<PlayerShooter>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move = Input.GetAxis(moveAixName);
        Rotate = Input.GetAxis(rotateAxisName);

        if (_joyStick && _joyStick.touch)
        {
            Move = _joyStick.move;
            Rotate = _joyStick.rotate;
        } 
    }

    public void OnButtonClickRightMain()
    {
        _playerShooter.Shoot();
    }
    public void OnButtonClickRightSub1()
    {
    }
    public void OnButtonClickRightSub2()
    {
    }
    public void OnButtonClickRightSub3()
    {
    }
    public void OnButtonClickDash()
    {
        _playerMovement.Dash();
    }
    public void OnButtonReload()
    {
        _playerShooter.ReloadGun();
    }
}
