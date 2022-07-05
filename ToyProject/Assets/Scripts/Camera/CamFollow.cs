using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public enum State
    {
        Idle, Ready, Tracking
    }



    private Transform target;

    public float smoothTime = 0.2f;

    private Vector3 lastMovingVelocity;
    private Vector3 targetPosition;

    private Camera cam;
    private float targetZoomSize = 5.0f;

    private const float roundReadyZoomSize = 14.5f;
    private const float roundShotZoomSize = 5f;
    private const float trackingZoomSize = 10.0f;

    private float lastZoomSpeed;

    [SerializeField]private Vector3 offset;
    private State state
    {
        set
        {
            // property...
            // 바깥에서 봤을 때는 변수처럼 사용
            // 내부적으로는 기능을 끼워넣음
            switch (value)
            {
                case State.Idle:
                    targetZoomSize = roundReadyZoomSize;
                    break;
                case State.Ready:
                    targetZoomSize = roundShotZoomSize;
                    break;
                case State.Tracking:
                    targetZoomSize = trackingZoomSize;
                    break;
            }
        }
    }
    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        state = State.Idle;
        //offset = transform.position;
    }

    private void Move()
    {
        targetPosition = target.transform.position;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition,
            ref lastMovingVelocity, smoothTime);

        transform.position = targetPosition + offset;
    }

    private void Zoom()
    {
        float smoothZoomSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoomSize,
            ref lastZoomSpeed, smoothTime);

        cam.orthographicSize = smoothZoomSize;
    }

    public void Reset()
    {
        state = State.Idle;
    }

    public void SetTarget(Transform newTarget, State newState)
    {
        target = newTarget;
        state = newState;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (target != null)
        {
            Move();
            Zoom();
        }
    }


}

