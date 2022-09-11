using System.Collections;
using UnityEngine; 

public class PlayerShooter : MonoBehaviour
{
    public Transform _gunPivot;

    public Transform _leftHandPos;
    public Transform _rightHandPos;

    private PlayerInput _playerInput;
    private Animator _playerAnimator;

    public PlayerGun _gun;

    // Use this for initialization
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<Animator>(); 
    }
      
    private void OnAnimatorIK(int layerIndex)
    {
        // IK .. 역 운동학
        _gunPivot.position = _playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

        // IK를 사용하여 왼손의 위치와 회전을 왼쪽 손잡이에 맞춤
        _playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        _playerAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);

        _playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandPos.position);
        _playerAnimator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandPos.rotation);

        // IK를 사용하여 오른손의 위치와 회전을 오른쪽 손잡이에 맞춤
        _playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        _playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

        _playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, _leftHandPos.position);
        _playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, _leftHandPos.rotation);

    }
     
    public void ReloadGun()
    { 
        _playerAnimator.SetTrigger("Reload");

        _gun.Reload();
    }

    public void Shoot()
    { 
        _playerAnimator.SetTrigger("Shoot");

        _gun.Fire();
    }
} 