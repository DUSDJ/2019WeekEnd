using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireSlot : MonoBehaviour
{
    public Character chara;

    public Image Portrait;
    public Text Name;
    public Text Cost;




    // Start is called before the first frame update
    void Start()
    {
        Portrait.sprite = chara.Portrait;
        Name.text = chara.Name;
        Cost.text = chara.Cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
