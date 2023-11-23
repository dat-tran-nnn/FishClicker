using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish3 : FishButtons, IClickable
{
    [SerializeField] private int price = 750;
    [SerializeField] private FishManager fm;
    [SerializeField] private FishData fd;
    public override void Activate()
    {
        fd.points += 5;
        fm.displayChange.text = "+5";
    }
    public override void Buy()
    {
        if (fd.points >= price)
        {
            fd.points = fd.points - price;
            fm.displayChange.text = "-750";
            fm.fishNumButton[2].transform.GetComponentInChildren<Text>().enabled = false;
            fd.fishBool[2] = true;
        }
    }

    public void Clicked()
    {
        if (fd.fishBool[2])
        {
            Activate();
        }
    }
}
