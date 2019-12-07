using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    #region Managers
    private HeroManager heroManager;
    public HeroManager HeroManager
    {
        get
        {
            if (heroManager == null)
            {
                heroManager = GameObject.FindObjectOfType(typeof(HeroManager)) as HeroManager;
                if (!heroManager)
                {
                    GameObject container = new GameObject();
                    container.name = "HeroManager";
                    heroManager = container.AddComponent(typeof(HeroManager)) as HeroManager;
                }
            }

            return heroManager;
        }
    }

    private DungeonUi dungeonUiManager;
    public DungeonUi DungeonUiManager
    {
        get
        {
            if (dungeonUiManager == null)
            {
                dungeonUiManager = GameObject.FindObjectOfType(typeof(DungeonUi)) as DungeonUi;
                if (!dungeonUiManager)
                {
                    GameObject container = new GameObject();
                    container.name = "DungeonUi";
                    dungeonUiManager = container.AddComponent(typeof(DungeonUi)) as DungeonUi;
                }
            }

            return dungeonUiManager;
        }
    }


    private HireManager hireManager;
    public HireManager HireManager
    {
        get
        {
            if (hireManager == null)
            {
                hireManager = GameObject.FindObjectOfType(typeof(HireManager)) as HireManager;
                if (!hireManager)
                {
                    GameObject container = new GameObject();
                    container.name = "HireManager";
                    hireManager = container.AddComponent(typeof(HireManager)) as HireManager;
                }
            }

            return hireManager;
        }
    }

    private ResourceManager resourceManager;
    public ResourceManager ResourceManager
    {
        get
        {
            if (resourceManager == null)
            {
                resourceManager = GameObject.FindObjectOfType(typeof(ResourceManager)) as ResourceManager;
                if (!resourceManager)
                {
                    GameObject container = new GameObject();
                    container.name = "ResourceManager";
                    resourceManager = container.AddComponent(typeof(ResourceManager)) as ResourceManager;
                }
            }

            return resourceManager;
        }
    }

    private House houseManger;
    public House HouseManager
    {
        get
        {
            if (houseManger == null)
            {
                houseManger = GameObject.FindObjectOfType(typeof(House)) as House;
                if (!houseManger)
                {
                    GameObject container = new GameObject();
                    container.name = "HouseManger";
                    houseManger = container.AddComponent(typeof(House)) as House;
                }
            }

            return houseManger;
        }
    }



    private DungeonManager dungeonManager;
    public DungeonManager DungeonManager
    {
        get
        {
            if (dungeonManager == null)
            {
                dungeonManager = GameObject.FindObjectOfType(typeof(DungeonManager)) as DungeonManager;
                if (!dungeonManager)
                {
                    GameObject container = new GameObject();
                    container.name = "DungeonManager";
                    dungeonManager = container.AddComponent(typeof(DungeonManager)) as DungeonManager;
                }
            }

            return dungeonManager;
        }
    }

    #endregion

    #region Variables

    public int MaxHero = 20;
    public GameState GameState = GameState.Title;
    public int StartingGold = 100;
        

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ResourceManager.Gold = 100;


    }

    // Update is called once per frame
    void Update()
    {
        if(GameState == GameState.Pause)
        {
            return;
        }

        if(GameState == GameState.Title)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }

            return;
        }


        if(GameState == GameState.Gaming)
        {



            return;
        }

    }

}
