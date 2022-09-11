using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : LivingObject
{
    [SerializeField]
    private AudioClip _dieClip;   // 사망 시 소리
    
    [SerializeField]
    private AudioClip _hitClip;   // 피격 시 소리

    private AudioSource _playerAudioSource;
    private Animator _playerAnimator;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerAudioSource = GetComponent<AudioSource>();
        _playerAnimator = GetComponent<Animator>();

        _playerMovement = GetComponent<PlayerMovement>();

        if (_playerMovement)
        {
            _playerMovement.enabled = true;
        }
    }

    override public void RestoreHP(float addHP)
    {
        base.RestoreHP(addHP);

        // To do...
        // UI 갱신
    }

    override public void OnDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    { 
        if( _isDead ) { return; }

        base.OnDamage(damage, hitPos, hitNormal);

        _playerAudioSource.PlayOneShot(_hitClip);

        // To do...
        // UI 갱신
    }

    public override void Die()
    {
        base.Die();

        _playerAudioSource.PlayOneShot(_dieClip);
        _playerAnimator.SetTrigger("Die");

        _playerMovement.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( _isDead) { return; }

        // To do..
    }
}
