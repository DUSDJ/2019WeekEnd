using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dungeon : MonoBehaviour, IPointerClickHandler
{
    public Sprite DungeonSprite;
    private DungeonManager DGManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("DD");
        DGManager.DungeonUI(true, DungeonSprite);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 임시, GameManager에서 받아올 예정
        DGManager = FindObjectOfType<DungeonManager>();
        if(DGManager == null)
        {
            GameObject go = new GameObject();
            go.name = "DungeonManager";
            go.AddComponent<DungeonManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}