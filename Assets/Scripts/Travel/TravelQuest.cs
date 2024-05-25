using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TravelQuest : MonoBehaviour
{
    public int Distance;
    public GameObject TextPrefab;
    private Transform canvas;
    private TravelScriptableObject quest;
    private List<TravelLine> lines;
    private Dictionary<int, List<TravelLine>> lineTracks;
    private float runTime;
    private int currentIndex;
    private int linesCompleted;
    private int currentTrack = 1;

    public void Parse(char c)
    {
        if (lineTracks[currentTrack].Count > 0)
        {
            TravelLine line = lineTracks[currentTrack][0];
            if (line.IsActive())
            {
                line.Parse(c);
                if (line.IsLineComplete())
                {
                    linesCompleted++;
                    lineTracks[currentTrack].Remove(line);
                }
            }
        }
    }

    public bool IsQuestComplete()
    {
        if(linesCompleted >= quest.TravelLines.Count)
        {
            return true;
        }
        return false;
    }

    private void Awake()
    {
        lines = new List<TravelLine>();
        lineTracks = new Dictionary<int, List<TravelLine>>();
        lineTracks.Add(1, new List<TravelLine>());
        lineTracks.Add(2, new List<TravelLine>());
        lineTracks.Add(3, new List<TravelLine>());
        lineTracks.Add(4, new List<TravelLine>());
        currentIndex = 0;
        linesCompleted = 0;
    }

    public void Setup(TravelScriptableObject travel, Transform canvas)
    {
        this.canvas = canvas;
        quest = travel;
        for(int counter = 0; counter < 5; counter++)
        {
            GameObject temp = Instantiate(TextPrefab, canvas);
            if(!temp.TryGetComponent(out TravelLine line))
            {
                Debug.LogError("Could not find TravelLine component.");
                return;
            }
            lines.Add(line);
        }
    }

    private void Start()
    {
        runTime = 0f;
        currentIndex = 0;
    }

    private void Update()
    {
        runTime += Time.deltaTime;
        if(currentIndex < quest.TravelLines.Count)
        {
            TravelLineData data = quest.TravelLines[currentIndex];
            if(data.SpawnTime < runTime)
            {
                foreach(TravelLine line in lines)
                {
                    if(!line.IsActive())
                    {
                        line.Init(data);
                        lineTracks[data.Track].Add(line);
                        currentIndex++;
                        break;
                    }
                }
            }
        }
    }

    public void CleanUp()
    {
        foreach(TravelLine line in lines)
        {
            Destroy(line.gameObject);
        }
    }

    public void KeyPress(KeyCode key)
    {
        if (key == KeyCode.UpArrow)
        {
            if (currentTrack > 1)
            {
                currentTrack--;
            }
            TravelManager.instance.OutputBox.text = $"Track {currentTrack}";
        }
        else if (key == KeyCode.DownArrow)
        {
            if (currentTrack < 4)
            {
                currentTrack++;
            }
            TravelManager.instance.OutputBox.text = $"Track {currentTrack}";
        }
    }
}