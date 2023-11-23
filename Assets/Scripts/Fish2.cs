using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish2 : FishButtons, IClickable
{
    [SerializeField] private int price = 300;
    [SerializeField] private FishManager fm;
    [SerializeField] private FishData fd;
    public override void Activate()
    {
        fd.points += 3;
        fm.displayChange.text = "+3";
    }
    public override void Buy()
    {
        if (fd.points >= price)
        {
            fd.points = fd.points - price;
            fm.displayChange.text = "-300";
            fm.fishNumButton[1].transform.GetComponentInChildren<Text>().enabled = false;
            fd.fishBool[1] = true;
        }
    }

    public void Clicked()
    {
        if (fd.fishBool[1])
        {
            Activate();
        }
    }
}
