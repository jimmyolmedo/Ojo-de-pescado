using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip hoverSound;

    [SerializeField] private Image fill;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;

    [Header("Colores Default")]
    [SerializeField] private Color defaultColorPrimary;
    [SerializeField] private Color defaultColorSecundary;

    [Header("Colores Selección")]
    
    [SerializeField] private Color enterColorPrimary;
    [SerializeField] private Color enterColorSecundary;

    void Awake()
    {
        if(fill != null) fill.color = defaultColorPrimary;
        
        if(icon != null) icon.color = defaultColorSecundary;
        if(text != null) text.color = defaultColorSecundary;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (fill != null) fill.color = enterColorPrimary;

        if (icon != null) icon.color = enterColorSecundary;
        if (text != null) text.color = enterColorSecundary;

        AudioManager.instance.PlayAudio(hoverSound);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(fill != null) fill.color = defaultColorPrimary;
        
        if(icon != null) icon.color = defaultColorSecundary;
        if(text != null) text.color = defaultColorSecundary;
    }

    
}
