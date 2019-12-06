using UnityEngine;
using UnityEngine.UI;   // UI와 관련된 스크립트 작업을 위해서 추가해 주어야 한다.
using System.Collections;

[RequireComponent(typeof(ScrollRect))]
public class ScrollViewFixContentSize : MonoBehaviour
{
    // 스크롤 뷰와 관련된 수정을 하기 위해 가지고 있는 변수
    public ScrollRect scrollRect;
    [SerializeField] private RectTransform viewPort;
    public RectTransform contentRoot;

    public float contentHeight;
    public float contentHeightSpace;
    public float contentHeightFirstSpace;

    public float contentWidth;
    
    // Use this for initialization
    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();    // 게임 오브젝트가 가지고 있는 ScrollRect를 가져온다.
        viewPort = scrollRect.viewport;
        contentRoot = scrollRect.content;

        //content = transform.Find("Content").gameObject;

        SetContentSize();
    }

    void SetContentSize()
    {
        // scrollRect.content를 통해서 Hierachy 뷰에서 봤던 Viewport 밑의 Content 게임 오브젝트에 접근할 수 있다.
        // 그리고 sizeDelta 값을 통해서 Content의 높이와 넓이를 수정할 수 있다.
        scrollRect.content.sizeDelta = new Vector2(0, contentHeightFirstSpace + (contentHeight + contentHeightSpace) * contentRoot.childCount);
    }
}