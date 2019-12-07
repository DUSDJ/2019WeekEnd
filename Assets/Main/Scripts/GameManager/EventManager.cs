using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager : MonoBehaviour
{
    public List<EventPopUp> EventList;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddEvent()
    {
        EventList.Add(new EventPopUp());

        /* Event UI Update */
    }
    public void AddEvent(EventPopUp eventPopup)
    {
        EventList.Add(eventPopup);

        /* Event UI Update */
    }


    public void CreateEvent(List<Character> characters)
    {

        foreach (var c in characters)
        {

            foreach (var quirk in c.resume.QuirkList)
            {
                    
            }
                


        }

    }
}