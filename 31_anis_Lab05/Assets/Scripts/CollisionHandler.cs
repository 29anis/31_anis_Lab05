using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public int pointsToAdd = 1; 

    private int totalPoints = 0; 
    public Text pointsText; 

    
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Collectible"))
        {
            
            totalPoints += pointsToAdd;

            
            UpdateUI();

            
            Destroy(collision.gameObject);

            if (totalPoints>=4)
            {
                SceneManager.LoadScene("GameWin");
            }
        }
        if (collision.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    
    private void UpdateUI()
    {
        // Check if pointsText is assigned
        if (pointsText != null)
        {
            // Update the UI text with total points
            pointsText.text = "Points: " + totalPoints.ToString();
        }
        else
        {
            Debug.LogWarning("UI Text component not assigned!");
        }
    }
}


