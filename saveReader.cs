using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class saveReader : MonoBehaviour
{
    public TMPro.TextMeshProUGUI achieve1;
    public TMPro.TextMeshProUGUI achieve2;
    public TMPro.TextMeshProUGUI achieve3;

    // Update is called once per frame
    public void showAchivements()
    {
        //Path to the text file
        string filePath = @"SavedAchievements.txt";

        try
        {
            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Output each line to the console
                foreach (string line in lines)
                {
                  
                    if (line.Contains("1")) { displayAchievement(achieve1); }
                    
                    if (line.Contains("2")) { displayAchievement(achieve2); }

                    if (line.Contains("3")) { displayAchievement(achieve3); }
                }
            }
            else
            {
                Debug.LogError("File not found: " + filePath);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("An error occurred");
        }
    }

    private void displayAchievement(TMPro.TextMeshProUGUI achievement)
    {
        if (achievement != null)
        {
            achievement.gameObject.SetActive(true);
        }
    }
}
