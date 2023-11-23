using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void RunAllClickables()
    {
        IClickable[] clicked = GetComponents<IClickable>();

        foreach (IClickable clickable in clicked)
        {
            clickable.Clicked();
        }
    }
}
