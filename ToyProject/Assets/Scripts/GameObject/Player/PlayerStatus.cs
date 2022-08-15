using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : LivingObject
{
    public AudioClip dieClip;   // 사망 시 소리
    public AudioClip hitClip;   // 피격 시 소리

    private AudioSource playerAudioSource;
    private Animator playerAnimator;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerAudioSource = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();

        playerMovement = GetComponent<PlayerMovement>();

        if (playerMovement)
        {
            playerMovement.enabled = true;
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
        if( isDead ) { return; }

        base.OnDamage(damage, hitPos, hitNormal);

        playerAudioSource.PlayOneShot(hitClip);

        // To do...
        // UI 갱신
    }

    public override void Die()
    {
        base.Die();

        playerAudioSource.PlayOneShot(dieClip);
        playerAnimator.SetTrigger("Die");

        playerMovement.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if( isDead) { return; }

        // To do..
    }
}
