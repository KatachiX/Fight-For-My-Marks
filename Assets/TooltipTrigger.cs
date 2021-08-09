using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Multiline()]
    public string content;
    public string header;

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(DelayShow());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        TooltipSystem.Hide();
    }

    IEnumerator DelayShow()
    {
        yield return new WaitForSeconds(1f);
        TooltipSystem.Show(content, header);
    }
}
