using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public List<Character> HiredCharacters;
    public Sprite dummySprite;

    private HeroScrollViewController svc;

    private void Awake()
    {
        HiredCharacters = new List<Character>();
        svc = FindObjectOfType<HeroScrollViewController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddHero(new Character("NunNun", dummySprite, 10, 1, 10));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            HiredCharacters.RemoveAt(3);
            svc.UpdateUI();
        }
    }

    public bool AddHero(Character chara)
    {
        if (HiredCharacters.Count >= GameManager.Instance.MaxHero)
        {
            Debug.Log("MaxHero");
            return false;
        }

        if(chara.Cost > GameManager.Instance.ResourceManager.Gold)
        {
            Debug.Log("No Money");
            return false;
        }
        else
        {
            GameManager.Instance.ResourceManager.Gold -= chara.Cost;
            /* Gold Effect & Sound => Gold Setter */
        }

        HiredCharacters.Add(chara);

        svc.UpdateUI();

        return true;
    }

}
