using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public int count;
    public static Counter instance;
    public Animator transition;

    public float transitionTime = 1f;
    private void Awake()
    {
        instance = this;
    }
    public void Countdown()
    {
        count--;
        if (count == 0)
        {
            SfxManager.instance.Audio.PlayOneShot(SfxManager.instance.sceneLoad);
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {       
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadSameLevel()
    {      
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
