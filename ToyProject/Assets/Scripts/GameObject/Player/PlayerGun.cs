﻿using System.Collections;
using UnityEngine;
 
public class PlayerGun : MonoBehaviour
{
    // 총의 상태를 표현하는 데 사용할 타입을 선언
    public enum State
    {
        Ready,      // 발사 준비됨
        Empty,      // 탄알집이 빔
        Reloading   // 재장전 중
    }

    public State state { get; private set; } // 현재 총의 상태

    public Transform fireTransform; // 탄알이 발사될 위치

    public ParticleSystem muzzleFlashEffect; // 총구 화염 효과
    public ParticleSystem shellEjectEffect; // 탄피 배출 효과
     
    private AudioSource gunAudioPlayer; // 총 소리 재생기

    public GunData gunData; // 총의 현재 데이터

    private float fireDistance = 50f; // 사정거리

    public int ammoRemain = 100; // 남은 전체 탄알
    public int curAmmo; // 현재 탄알집에 남아 있는 탄알

    private float lastFireTime; // 총을 마지막으로 발사한 시점

    LineRenderer lineRenderer;

    private void Awake()
    {
        // 사용할 컴포넌트의 참조 가져오기
        gunAudioPlayer = GetComponent<AudioSource>();
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;


    }

    private void OnEnable()
    {
        // 총 상태 초기화
        ammoRemain = gunData.startAmmoRemain;
        curAmmo = gunData.ammoCapacity;

        state = State.Ready;
        lastFireTime = 0;
    }

    // 발사 시도
    public void Fire()
    {
        if(state == State.Ready && Time.time >= lastFireTime + gunData.timeBetFire )
        {
            lastFireTime = Time.time;

            Shot();
        }
        ObjectManager.instance.GetObject(OBJECT_TYPE.OBJ_PROJECTILE);
    }

    // 실제 발사 처리
    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPos = Vector3.zero;

        if (Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance))
        {
            IDamageable target = hit.collider.GetComponent<IDamageable>();
            if (target != null)
            {
                target.OnDamage(gunData.damage, hit.point, hit.normal);
            }
            hitPos = hit.point;
        }
        else 
        {
            hitPos = fireTransform.position + fireTransform.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPos));

        //  Todo 탄창 처리.
        --curAmmo;
        if(curAmmo <= 0)
        {
            state = State.Empty;
        }
    }

    // 발사 이펙트와 소리를 재생하고 탄알 궤적을 그림
    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        muzzleFlashEffect.Play();
        shellEjectEffect.Play();

        lineRenderer.SetPosition(0, fireTransform.position);
        lineRenderer.SetPosition(1, hitPosition);
        lineRenderer.enabled = true;
         
        // 0.05초 동안 잠시 처리를 대기
        yield return new WaitForSeconds(0.05f);
        
        lineRenderer.enabled = false;
    }

    // 재장전 시도
    public bool Reload()
    {
        StartCoroutine(ReloadRoutine());
        return true;
    }

    // 실제 재장전 처리를 진행
    private IEnumerator ReloadRoutine()
    {
        // 현재 상태를 재장전 중 상태로 전환
        state = State.Reloading;

        // 재장전 소요 시간 만큼 처리 쉬기
        yield return new WaitForSeconds(gunData.reloadTime);

        // 총의 현재 상태를 발사 준비된 상태로 변경
        state = State.Ready;

        curAmmo = gunData.ammoCapacity; 
    }
} 