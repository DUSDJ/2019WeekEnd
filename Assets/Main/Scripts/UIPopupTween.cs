using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIPopupTween : MonoBehaviour
{
  Sequence seq;

  void OnEnable()
  {
    seq.Restart();
    PlayTween();
  }

  public void PlayTween()
  {
    seq = DOTween.Sequence()
    .SetAutoKill(false)
    .OnStart(() =>
    {
      transform.localScale = Vector3.zero;
      //GetComponent<CanvasGroup>().alpha = 1.0f;
    })
    .Append(transform.DOScale(1, 0.3f).SetEase(Ease.InOutBack));
    //.Join(GetComponent<CanvasGroup>().DOFade(1, 0.3f))
    //.SetDelay(0.1f);
  }

  public void ReverseTween()
  {
    seq.Rewind();
  }
}
