using DG.Tweening;
using UnityEngine;

public class DOTweenMoveUI : MonoBehaviour
{
    public float time;
    public Vector3 offset;
    private Vector3 originAnchorPos;
    private bool isInit = false;
    void OnEnable()
    {
        var rectt = transform as RectTransform;
        if (isInit == false)
        {
            originAnchorPos = rectt.anchoredPosition;
            isInit = true;
        }
        rectt.DOAnchorPos(originAnchorPos, time).From(originAnchorPos + offset);
    }
}