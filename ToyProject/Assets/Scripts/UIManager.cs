using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public enum UIPanelType
    { 
        PANEL_TYPE_MIN,

        PANEL_TYPE_GAME,
        PANEL_TYPE_EFFECT,
        
        PANEL_TYPE_MAX,
    };

    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }
    [SerializeField]
    private GameObject gamePanel;

    [SerializeField]
    private GameObject effectPanel;
     
    private TextMeshProUGUI remainTimeText;
    private TextMeshProUGUI remainMonsterText;
     
    void Awake()
    { 
        remainTimeText = gamePanel.transform.Find("RemainTime").GetComponent<TextMeshProUGUI>();
        remainMonsterText = gamePanel.transform.Find("ReamainMonsterCount").GetComponent<TextMeshProUGUI>();

        EnablePanel(UIPanelType.PANEL_TYPE_GAME);
    }

    public void UpdateGameTime(string text)
    {
        if (remainTimeText == null) { return; }
         
        remainTimeText.text = text;
    }
    public void UpdateRemainMonsterText(string text)
    {
        if (remainMonsterText == null) { return; }

        remainMonsterText.text = text;
    }

    public void EnablePanel(UIPanelType panelType)
    {
        switch (panelType)
        {
            case UIPanelType.PANEL_TYPE_GAME:
                {
                    gamePanel.SetActive(true);
                    effectPanel.SetActive(false);
                }
                break;
            case UIPanelType.PANEL_TYPE_EFFECT:
                {
                    gamePanel.SetActive(false);
                    effectPanel.SetActive(true);
                }
                break;
        }
    }
}