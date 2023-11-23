using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using System;

public interface IClickable
{
    void Clicked();
}

[Serializable]
public class FishData
{
    public int points;
    public bool[] fishBool = { false, false, false };


    public FishData()
    {
        points = 0;
        fishBool = new bool[]{ false, false, false};
    }
    public FishData(int points)
    {
        this.points = points;
        fishBool = new bool[] { false, false, false };
    }
    public FishData(int points, bool[] fish)
    {

        this.points = points;
        fishBool = fish;
    }


}

public class FishManager : MonoBehaviour
{
    private FishData fishData;

    [SerializeField] private string path;
    public Text pointDisplay;
    public Text displayChange;
    //public int points;
    //public bool[] fishBool = { false, false, false };
    public List<GameObject> fishNumButton;

    void Write(string content)
    {
        StreamWriter fileWriter = new StreamWriter(path, false);
        fileWriter.WriteLine(content);
        fileWriter.Close();
    }
    private void Read()
    {
        StreamReader fileReader = new StreamReader(path);
        string line = fileReader.ReadToEnd();
        string[] data = line.Split('|');
        pointDisplay.text = "Points: " + data[0];
        int points = int.Parse(data[0]);
        fishData = new FishData(points,new bool[] { bool.Parse(data[1]) , bool.Parse(data[2]) , bool.Parse(data[3]) });

        if (fishData.fishBool[0] == true)
        {
            fishNumButton[0].transform.GetComponentInChildren<Text>().enabled = false;
        }
        if (fishData.fishBool[1] == true)
        {
            fishNumButton[1].transform.GetComponentInChildren<Text>().enabled = false;
        }
        if (fishData.fishBool[2] == true)
        {
            fishNumButton[2].transform.GetComponentInChildren<Text>().enabled = false;
        }

        fileReader.Close();
    }
    private void Start()
    {
        Read();
    }
    private void Awake()
    {
        //fishData = new FishData();
        path = Application.dataPath + "/SavingStuff.txt";
        if (!File.Exists(path))
        {
            Write("0|False|False|False");
        }
        //Write("0|False|False|False");
    }
    public void ClickPoint()
    {
        fishData.points++;
        pointDisplay.text = "Points: " + fishData.points.ToString();
        displayChange.text = "+1";
        Write(fishData.points + "|" + fishData.fishBool[0] + "|" + fishData.fishBool[1] + "|" + fishData.fishBool[2]);
    }

    public void Fish1Click()
    {
        if (fishData.fishBool[0] == false)
        {
            if (fishData.points >= 100)
            {
                fishData.points = fishData.points - 100;
                displayChange.text = "-100";
                fishNumButton[0].transform.GetComponentInChildren<Text>().enabled = false;
                fishData.fishBool[0] = true;
            }
        }
        else
        {
            fishData.points += 2;
            displayChange.text = "+2";
        }
        pointDisplay.text = "Points: " + fishData.points.ToString();
        Write(fishData.points + "|" + fishData.fishBool[0] + "|" + fishData.fishBool[1] + "|" + fishData.fishBool[2]);
    }
    public void Fish2Click()
    {
        if (fishData.fishBool[1] == false)
        {
            if (fishData.points >= 300)
            {
                fishData.points = fishData.points - 300;
                displayChange.text = "-300";
                fishNumButton[1].transform.GetComponentInChildren<Text>().enabled = false;
                fishData.fishBool[1] = true;
            }
        }
        else
        {
            fishData.points += 3;
            displayChange.text = "+3";
        }
        pointDisplay.text = "Points: " + fishData.points.ToString();
        Write(fishData.points + "|" + fishData.fishBool[0] + "|" + fishData.fishBool[1] + "|" + fishData.fishBool[2]);
    }
    public void Fish3Click()
    {
        if (fishData.fishBool[2] == false)
        {
            if (fishData.points >= 750)
            {
                fishData.points = fishData.points - 750;
                displayChange.text = "-750";
                fishNumButton[2].transform.GetComponentInChildren<Text>().enabled = false;
                fishData.fishBool[2] = true;
            }
        }
        else
        {
            fishData.points += 5;
            displayChange.text = "+5";
        }
        pointDisplay.text = "Points: " + fishData.points.ToString();
        Write(fishData.points + "|" + fishData.fishBool[0] + "|" + fishData.fishBool[1] + "|" + fishData.fishBool[2]);
    }
}
