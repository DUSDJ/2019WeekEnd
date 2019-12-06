using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Main.Scripts
{
    public class GameManager : MonoBehaviour
    {

        #region SingleTon
        /* SingleTon */
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
                    if (!instance)
                    {
                        GameObject container = new GameObject();
                        container.name = "GameManager";
                        instance = container.AddComponent(typeof(GameManager)) as GameManager;
                    }
                }

                return instance;
            }
        }

        #endregion

        #region Managers
        private DungeonManager dungeonManager;
        public DungeonManager DungeonManager
        {
            get
            {
                if (dungeonManager == null)
                {
                    dungeonManager = GameObject.FindObjectOfType(typeof(DungeonManager)) as DungeonManager;
                    if (!instance)
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

        public GameState GameState;

        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
