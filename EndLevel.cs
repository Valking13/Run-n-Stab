using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class EndLevel : MonoBehaviour
    
{
    public GameObject eventQue;
    public EventQueue eventQueue;
    public Collider2D detectCol;
    // Start is called before the first frame update
    void Start()
    {
        detectCol = GetComponent<Collider2D>();
        eventQueue = eventQue.GetComponent<EventQueue>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogError("collision");
        // for achivemnts gets index for level 
        string achievementID =(SceneManager.GetActiveScene().buildIndex).ToString();
        eventQueue.NotifyAchivementComplete(achievementID);
        StartCoroutine(DelayCoroutine());
        SceneManager.LoadSceneAsync(0);

    }
    IEnumerator DelayCoroutine()
    {
       

        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3f);

        
    }

}