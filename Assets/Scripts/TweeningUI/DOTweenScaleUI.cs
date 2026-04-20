using UnityEngine;
using DG.Tweening;

public class DOTweenScaleUI : MonoBehaviour
{
    public Vector3 fromScale, toScale;
    void OnEnable()
    {
        transform.DOScale(toScale, 0.25f).From(fromScale).SetUpdate(true);
    }
}