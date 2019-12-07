using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DungeonManager : MonoBehaviour
{

    // 트리거 지우고 GameManger에서 GameState Enum 받아올 예정.
    public bool StateOn = false;

    public GameObject DungeonCanvas;
    public GameObject SlotPrefab;
    public int SlotNumber;

    public Sprite SampleCharImg;
    public Sprite SampleCharImg2;

    private List<Character> CharacterList;
    private List<Image> CharacterImageList;
    private Image DungeonImage;

    private CanvasGroup cg;

    // Start is called before the first frame update
    void Start()
    {
        CharacterList = new List<Character>();
        CharacterImageList = new List<Image>();

        DungeonImage = DungeonCanvas.transform.Find("DungeonPopImage").GetComponent<Image>();
        DungeonImage.enabled = false;
        Transform Grid = DungeonCanvas.transform.Find("BottomPanel/Grid").transform;

        for(int i=0; i<SlotNumber; i++)
        {
            GameObject slot = Instantiate(SlotPrefab);
            slot.name = "Slot" + i;
            slot.transform.SetParent(Grid);

            Image Img = slot.gameObject.GetComponentsInChildren<Image>()[1];
            CharacterImageList.Add(Img);
        }

        cg = DungeonCanvas.GetComponent<CanvasGroup>();
        cg.alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
            RegistChar(new Character("Nun", SampleCharImg));
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            RegistChar(new Character("Baba", SampleCharImg2));
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return");
                
        }

    }

    public void GoToDungeon()
    {
        // 캐릭터들을 통해 이벤트 생성
        //GameManager.Instance.EventManager.CreateEvent(CharacterList);
            

        // 초기화
        CharacterList = new List<Character>();
        CharacterImageList = new List<Image>();
        UpdateUI();
    }

    private void RegistChar(Character Chara)
    {
        if(CharacterList.Count >= 4 || CharacterList.Contains(Chara))
        {
            return;
        }

        CharacterList.Add(Chara);
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < CharacterList.Count; i++)
        {
            if(CharacterList[i] == null)
            {
                CharacterImageList[i].sprite = null;
                CharacterImageList[i].enabled = false;
                continue;
            }

            CharacterImageList[i].sprite = CharacterList[i].Portrait;
            CharacterImageList[i].enabled = true;
        }
    }

    public void DungeonUI(bool onOff, Sprite sprite)
    {

        if (onOff)
        {
            DungeonImage.enabled = true;
            DungeonImage.sprite = sprite;
                
            StateOn = true;
            cg.alpha = 1.0f;
            cg.blocksRaycasts = true;


        }
        else
        {
                
            StateOn = false;
            cg.alpha = 0f;
            cg.blocksRaycasts = false;
        }
    }
}