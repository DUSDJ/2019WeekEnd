//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class HeroScrollViewController : MonoBehaviour
//{
//    public ScrollRect scrollView;

//    public GameObject contentOriginPrefab;
//    public RectTransform contentPivot;

//    public HeroSlot[] HeroArray;

//    public class HeroSlot
//    {
//        public GameObject gameObject;
//        public Image Portrait;
//        public Text Name;
//        public Text Stress;
//        public Text Level;

//        public HeroSlot(GameObject go, Image portrait, Text name, Text stress, Text level)
//        {
//            gameObject = go;
//            Portrait = portrait;
//            Name = name;
//            Stress = stress;
//            Level = level;
//        }

//        public void InitSlot()
//        {
//            Portrait.sprite = null;
//            Portrait.enabled = false;
//            Name.text = "";
//            Name.enabled = false;
//            Stress.text = "";
//            Stress.enabled = false;
//            Level.text = "";
//            Level.enabled = false;
//        }

//        public void SetSlot(Sprite sprite, string name, int stress, int level)
//        {
//            Portrait.enabled = true;
//            Portrait.sprite = sprite;
//            Name.enabled = true;
//            Name.text = name;
//            Stress.enabled = true;
//            Stress.text = stress.ToString();
//            Level.enabled = true;
//            Level.text = level.ToString();
            
//        }
//    }

//    public void Awake()
//    {
//        HeroArray = new HeroSlot[GameManager.Instance.MaxHero];

//        contentOriginPrefab = Resources.Load<GameObject>("Prefabs/HeroSlot");

//        scrollView.inertia = false;
//        for (int ix = 0; ix < HeroArray.Length; ix++)
//        {
//            GameObject content = Instantiate(contentOriginPrefab, contentPivot);

//            Image portrait = content.GetComponentsInChildren<Image>()[1];
//            Text name = content.GetComponentsInChildren<Text>()[0];
//            Text stress = content.GetComponentsInChildren<Text>()[1];
//            Text level = content.GetComponentsInChildren<Text>()[2];
            
//            HeroArray[ix] = new HeroSlot(content, portrait, name, stress, level);
//            HeroArray[ix].InitSlot();
//        }
//        scrollView.inertia = true;

//    }

//    public void UpdateUI()
//    {
//        List<ICharacter> hc = GameManager.Instance.HeroManager.HiredCharacters;
//        for (int i = 0; i < HeroArray.Length; i++)
//        {
//            if(i >= hc.Count)
//            {
//                HeroArray[i].InitSlot();
//                continue;
//            }

//            HeroArray[i].gameObject.SetActive(true);
//            HeroArray[i].SetSlot(hc[i].Portrait, hc[i].GetName(), hc[i].Stress, hc[i].GetLevel());
//        }
//    }

//    public void Show()
//    {

//    }


//}
