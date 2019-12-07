//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;

//public class HouseSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
//{
//    private Image coverImage;
//    private float coveredAlpha = 120 / 255.0f;

//    public enum HouseMenu
//    {
//        Hire,
//        Recreation,
//        Reinforce,
//    }
//    public HouseMenu menuType;

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        Action();
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        Color c = coverImage.color;
//        c.a = 0f;

//        coverImage.color = c;
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        Color c = coverImage.color;
//        c.a = coveredAlpha;

//        coverImage.color = c;
//    }

//    void Action()
//    {
//        switch (menuType)
//        {
//            case HouseMenu.Hire:
//                GameManager.Instance.HouseManager.HireMenu(true);
//                break;


//            case HouseMenu.Recreation:
//                break;


//            case HouseMenu.Reinforce:
//                break;


//            default:
//                break;
//        }

        
//    }


//    // Start is called before the first frame update
//    void Start()
//    {
//        coverImage = GetComponent<Image>();
//        coverImage.color = new Color(coverImage.color.r, coverImage.color.g, coverImage.color.b, coveredAlpha);

//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
