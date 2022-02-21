using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    End_Trigger E1;
    End_Trigger_2 E2;
    
    public GameObject completeLevelUI;
    void Start()
    {
        E1 = FindObjectOfType<End_Trigger>();
        E2 = FindObjectOfType<End_Trigger_2>();
        completeLevelUI.SetActive(false);
    }
    void FixedUpdate()
    {
        if(E1.End1 == true && E2.End2 == true)
        {
            E1.End1 = false;
            E2.End2 = false;
            CompleteLevel();
            StartCoroutine(LoadNextComplete());
        }   
    }
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart",restartDelay);
        }
    }

    // Update is called once per frame
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadNextComplete()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(1.0f);
    }
}
