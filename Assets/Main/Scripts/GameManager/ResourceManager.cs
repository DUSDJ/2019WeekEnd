using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{

    #region Gold

    private Text GoldText;

    private int gold;
    public int Gold
    {
        set
        {
            if(value < 0)
            {
                /* Gold Minus Event */
                value = 0;
            }

            gold = value;
            GoldText.text = gold.ToString();

        }
        get
        {
            return gold;
        }
    }

    #endregion


    #region House

    private int houseLevel = 1;
    public int HouseLevel
    {
        set
        {
            houseLevel = value;
            /* effect */
        }
        get
        {
            return houseLevel;
        }
    }

    #endregion

    private void Awake()
    {
        GoldText = GameObject.Find("GoldText").GetComponent<Text>();       
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
