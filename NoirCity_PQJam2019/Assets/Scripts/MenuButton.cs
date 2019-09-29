using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color NormalColor;
    public Color HighlightColor;

    public Text TheText;

    private void Start()
    {
        TheText.color = NormalColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        /*theText.color = Color.gray;*/ //Or however you do your color
        TheText.color = HighlightColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //theText.color = Color.white; //Or however you do your color
        TheText.color = NormalColor;
    }
}