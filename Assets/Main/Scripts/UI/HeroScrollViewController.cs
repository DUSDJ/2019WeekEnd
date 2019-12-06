using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScrollViewController : MonoBehaviour
{
    public ScrollRect scrollView;

    public GameObject contentOriginPrefab;
    public RectTransform contentPivot;

    public int heroMaxCount = 20;

    public void Awake()
    {
        contentOriginPrefab = Resources.Load<GameObject>("Prefabs/Hero SCV Prefab");

        scrollView.inertia = false;
        for (int ix = 0; ix < heroMaxCount; ix++)
        {
            GameObject content = Instantiate(contentOriginPrefab, contentPivot);
        }
        scrollView.inertia = true;
    }

    public void Show()
    {

    }


}
