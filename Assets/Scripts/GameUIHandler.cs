using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIHandler : MonoBehaviour
{
    public Player player;
    public UIDocument UIDoc;
    private Label m_HealthLabel;
    private VisualElement m_HealthBarMask;

    void Start()
    {
        player.OnHealthChange += HealthChanged;
        m_HealthLabel = UIDoc.rootVisualElement.Q<Label>("HealthLabel");
        m_HealthBarMask = UIDoc.rootVisualElement.Q<VisualElement>("HealthBarMask");
        HealthChanged();
    }

    void HealthChanged()
    {
        m_HealthLabel.text = $"{player.currentHp}/{player.maxHp}";
        float healthRatio = (float)player.currentHp / player.maxHp;

        //바에 맨 끝에서 맨 끝까지 건드는 영역이 8부터 88까지기에 이를 0%부터 100%까지로 취급하여 계산.
        float healthPercent = Mathf.Lerp(8, 88, healthRatio);
        m_HealthBarMask.style.width = Length.Percent(healthPercent);
    }
}
