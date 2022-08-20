using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveAixName = "Vertical";
    public string rotateAxisName = "Horizontal";
    public string fireButtonName = "Fire1";
    public string reloadButtonName = "Reload";
    
    public float move { get; private set; }
    public float rotate { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }

    private PlayerShooter playerShooter;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerShooter = GetComponent<PlayerShooter>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxis(moveAixName);
        rotate = Input.GetAxis(rotateAxisName);
        // fire = Input.GetButton(fireButtonName);
        // reload = Input.GetButton(reloadButtonName);
    }

    public void OnButtonClickRightMain()
    {
        playerShooter.Shoot();
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
        playerMovement.Dash();
    }
    public void OnButtonReload()
    {
        playerShooter.ReloadGun();
    }
}
