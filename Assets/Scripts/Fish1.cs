using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish1 : FishButtons, IClickable
{
    [SerializeField] private int price = 100;
    [SerializeField] private FishManager fm;
    [SerializeField] private FishData fd;
    public override void Activate()
    {
        fd.points += 2;
        fm.displayChange.text = "+2";
    }
    public override void Buy()
    {
        if (fd.points >= price)
        {
            fd.points = fd.points - price;
            fm.displayChange.text = "-100";
            fm.fishNumButton[0].transform.GetComponentInChildren<Text>().enabled = false;
            fd.fishBool[0] = true;
        }
    }

    public void Clicked()
    {
        if (fd.fishBool[0])
        {
            Activate();
        }
    }
}
