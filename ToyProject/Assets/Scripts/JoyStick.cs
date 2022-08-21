using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    RectTransform rectJoyStick;
    RectTransform rectLever;

    Transform player;

    float m_fRadius;
    float m_fSpeed = 5.0f;
    float m_fSqr = 0f;

    Vector3 vecMove;

    Vector2 vecNormal;

    public bool touch { get; private set; }
    public float move { get; private set; }
    public float rotate { get; private set; }

    void Start()
    {
        rectJoyStick = transform.Find("JoyStick").GetComponent<RectTransform>();
        rectLever = transform.Find("JoyStick/Lever").GetComponent<RectTransform>();

        player = GameManager.instance.GetPlayerObject().transform;

        // JoystickBackground의 반지름입니다.
        m_fRadius = rectJoyStick.rect.width * 0.5f;

        // 보정
        m_fRadius *= 0.45f;
    }

    void Update()
    {
        if (touch)
        {
           // player.position += vecMove;
        } 
    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2(vecTouch.x - rectJoyStick.position.x, vecTouch.y - rectJoyStick.position.y);
         
        // vec값을 m_fRadius 이상이 되지 않도록 합니다.
        vec = Vector2.ClampMagnitude(vec, m_fRadius);
        rectLever.localPosition = vec;

        // 조이스틱 배경과 조이스틱과의 거리 비율로 이동합니다.
        // float fSqr = (rectJoyStick.position - rectLever.position).sqrMagnitude / (m_fRadius * m_fRadius);
        move = (rectJoyStick.position - rectLever.position).sqrMagnitude / (m_fRadius * m_fRadius); ;
        move *= 10.0f;

        Debug.Log(move);
        // 터치위치 정규화
        Vector2 vecNormal = vec.normalized;

        //vecMove = new Vector3(vecNormal.x * m_fSpeed * Time.deltaTime * fSqr, 0f, vecNormal.y * m_fSpeed * Time.deltaTime * fSqr);
        // player.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg, 0f);

        rotate = Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg;
        rotate /= 360.0f ;
        Debug.Log(rotate);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        touch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        touch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 원래 위치로 되돌립니다.
        rectLever.localPosition = Vector2.zero;
        touch = false;
    }
}