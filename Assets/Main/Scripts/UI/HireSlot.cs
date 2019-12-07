//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class HireSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
//{
//    public ICharacter chara;

//    public Image Portrait;
//    public Text Name;
//    public Text Cost;

//    public GameObject HighLight;

//    // Start is called before the first frame update
//    void Start()
//    {
//        HighLight.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    public void Init()
//    {
//        if(chara == null)
//        {
//            Portrait.sprite = null;
//            Portrait.enabled = false;
//            Name.text = "";
//            Name.enabled = false;
//            Cost.text = "";
//            Cost.enabled = false;
//            return;
//        }
//        Portrait.enabled = true;
//        Portrait.sprite = chara.Portrait;
//        Name.enabled = true;
//        Name.text = chara.GetName();
//        Cost.enabled = true;
//        Cost.text = chara.Cost.ToString();
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        if (GameManager.Instance.HireManager.isClicked != null)
//        {
//            return;
//        }

//        if(GameManager.Instance.HireManager.SelectedSlot == null)
//        {
//            GameManager.Instance.HireManager.SelectedSlot = GetComponent<HireSlot>();
//            HighLight.SetActive(true);
//        }
//        else
//        {
//            GameManager.Instance.HireManager.SelectedSlot.HighLight.SetActive(false);
//            GameManager.Instance.HireManager.SelectedSlot = GetComponent<HireSlot>();
//            HighLight.SetActive(true);
//        }

//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        if (GameManager.Instance.HireManager.isClicked != null)
//        {
//            return;
//        }
//        if (GameManager.Instance.HireManager.SelectedSlot == null)
//        {
//            HighLight.SetActive(false);
//        }
//    }

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        if(GameManager.Instance.HireManager.SelectedSlot == GetComponent<HireSlot>()
//            && GameManager.Instance.HireManager.isClicked == GetComponent<HireSlot>())
//        {
//            GameManager.Instance.HireManager.SelectedSlot = null;
//            GameManager.Instance.HireManager.isClicked = null;
//            HighLight.SetActive(false);
//            return;

//        }

//        if (GameManager.Instance.HireManager.isClicked != null && GameManager.Instance.HireManager.isClicked != GetComponent<HireSlot>())
//        {
//            GameManager.Instance.HireManager.isClicked.HighLight.SetActive(false);
        
//        }

//        if(GameManager.Instance.HireManager.SelectedSlot != GetComponent<HireSlot>())
//        {
//            GameManager.Instance.HireManager.SelectedSlot.HighLight.SetActive(false);

//        }

//        HighLight.SetActive(true);
//        GameManager.Instance.HireManager.SelectedSlot = GetComponent<HireSlot>();        
//        GameManager.Instance.HireManager.isClicked = GetComponent<HireSlot>();
    
//    }
//}
