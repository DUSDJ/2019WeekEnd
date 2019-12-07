using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIPopupTween : MonoBehaviour
{
  Sequence seq;

  void OnEnable()
  {
    transform.localScale = Vector3.zero;
    seq.Restart();
    OpenTween();
  }

  public void OpenTween()
  {
    seq = DOTween.Sequence()
    .SetAutoKill(false)
    .Append(transform.DOScale(1, 0.3f).SetEase(Ease.InOutBack));
  }

  public void CloseTween()
  {
    seq.OnRewind(() => gameObject.SetActive(false)).PlayBackwards();
  }
}
