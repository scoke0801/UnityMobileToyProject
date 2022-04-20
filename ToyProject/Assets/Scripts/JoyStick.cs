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

    bool bTouch = false;


    void Start()
    {
        rectJoyStick = transform.Find("JoyStick").GetComponent<RectTransform>();
        rectLever = transform.Find("JoyStick/Lever").GetComponent<RectTransform>();

        player = GameManager.instance.GetPlayer().transform;

        // JoystickBackground�� �������Դϴ�.
        m_fRadius = rectJoyStick.rect.width * 0.5f;
    }

    void Update()
    {
        if (bTouch)
        {
           // player.position += vecMove;
        }

    }

    void OnTouch(Vector2 vecTouch)
    {
        Vector2 vec = new Vector2(vecTouch.x - rectJoyStick.position.x, vecTouch.y - rectJoyStick.position.y);
         
        // vec���� m_fRadius �̻��� ���� �ʵ��� �մϴ�.
        vec = Vector2.ClampMagnitude(vec, m_fRadius);
        rectLever.localPosition = vec;

        // ���̽�ƽ ���� ���̽�ƽ���� �Ÿ� ������ �̵��մϴ�.
        float fSqr = (rectJoyStick.position - rectLever.position).sqrMagnitude / (m_fRadius * m_fRadius);

        // ��ġ��ġ ����ȭ
        Vector2 vecNormal = vec.normalized;

        vecMove = new Vector3(vecNormal.x * m_fSpeed * Time.deltaTime * fSqr, 0f, vecNormal.y * m_fSpeed * Time.deltaTime * fSqr);
        player.eulerAngles = new Vector3(0f, Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg, 0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        bTouch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnTouch(eventData.position);
        bTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // ���� ��ġ�� �ǵ����ϴ�.
        rectLever.localPosition = Vector2.zero;
        bTouch = false;
    }
}