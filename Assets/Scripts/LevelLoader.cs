using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator  transition;    

    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        Checkpoints.checkpointSet = false;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    public void Reload()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            LoadNextLevel();
        }
    }
}
