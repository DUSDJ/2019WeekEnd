using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public SpriteRenderer[] imgs;
    Color c;

    public TextMeshProUGUI tmp;
    public TextMeshProUGUI tmp2;
    public Material[] tmpMat;
    public Material[] tmpMat2;
    public Animator[] anim;


    public bool trigger = false;



    // Start is called before the first frame update
    void Start()
    {
        tmpMat = tmp.fontMaterials;
        tmpMat2 = tmp2.fontMaterials;
        

        for (int i = imgs.Length-1; i > 0; i--)
        {
            c = imgs[i].color;
            Color tc = c;
            tc.a = 0;
            imgs[i].color = tc;
        }


        
        StartCoroutine(Shader());
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger && Input.anyKeyDown)
        {
            SceneManager.LoadScene(1);
        }
    }


    IEnumerator Cor()
    {
        float t = 0;
        int n = 1;

        while (true)
        {
            if (n >= 5)
            {
                break;
            }

            t += Time.deltaTime;

            if (t > 0.2f)
            {
                imgs[n].DOColor(c, 0.3f);
                n += 1;
                t = 0;
            }

            yield return null;
        }

        

        t = 0;
        n = 4;
        Color tc = c;
        tc.a = 0;

        foreach (var item in anim)
        {
            item.SetTrigger("stop");
            item.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            if (n < 0)
            {
                imgs[0].DOColor(c, 0.2f);
                break;
                
            }

            t += Time.deltaTime;

            if (t > 0.15f)
            {
                imgs[n].DOColor(tc, 0.2f);
                n -= 1;
                t = 0;
            }

            yield return null;
        }

        StartCoroutine(Press());
        trigger = true;
        yield return null;
    }


    IEnumerator Shader()
    {
        float t = 0;
        float h = 3;
        while (t <= h)
        {
            t += Time.deltaTime;
            tmpMat[0].SetFloat("_FaceDilate", Mathf.Lerp(-0.35f, 0.05f, t/h));
            tmpMat[0].SetFloat("_OutlineSoftness", Mathf.Lerp(0, 0.6f, t / h));
            yield return null;
        }

        StartCoroutine(Cor());
        yield return null;
    }

    IEnumerator Press()
    {
        while (true)
        {
            float t = 0;
            float h = 2;
            while (t <= h)
            {
                t += Time.deltaTime;
                tmpMat2[0].SetFloat("_FaceDilate", Mathf.Lerp(-0.35f, 0.05f, t / h));
                tmpMat2[0].SetFloat("_OutlineSoftness", Mathf.Lerp(0, 0.6f, t / h));
                yield return null;
            }



            yield return new WaitForSeconds(1.0f);
        }

    }
}
