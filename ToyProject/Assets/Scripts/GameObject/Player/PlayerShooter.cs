using System.Collections;
using UnityEngine; 

public class PlayerShooter : MonoBehaviour
{
    public Transform gunPivot;

    public Transform leftHandPos;
    public Transform rightHandPos;

    private PlayerInput playerInput;
    private Animator playerAnimator;

    public PlayerGun gun;

    // Use this for initialization
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>(); 
    }
      
    private void OnAnimatorIK(int layerIndex)
    {
        // IK .. 역 운동학
        gunPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        // IK를 사용하여 왼손의 위치와 회전을 왼쪽 손잡이에 맞춤
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPos.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandPos.rotation);

        // IK를 사용하여 오른손의 위치와 회전을 오른쪽 손잡이에 맞춤
        playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

        playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, leftHandPos.position);
        playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, leftHandPos.rotation);

    }
     
    public void ReloadGun()
    {
        Debug.Log("Reload!");   
        playerAnimator.SetTrigger("Reload");

        gun.Reload();
    }

    public void Shoot()
    {
        Debug.Log("Shoot!");
        playerAnimator.SetTrigger("Shoot");

        gun.Fire();
    }
} 