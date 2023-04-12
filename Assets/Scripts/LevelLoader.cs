using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator  transition;    

    public float transitionTime = 1f;
    public bool waitForBoss = false;
    public bool customPositionEnabled = false;
    public Vector3 customRespawnPosition = Vector3.zero;
    public bool customSceneEnabled = false;
    public int customSceneNumber = 0;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    public void Activate()
    {
        if(customPositionEnabled)
        {
            Checkpoints.checkpointSet = true;
            Checkpoints.currCheckPoint = customRespawnPosition;
        }
        else
        {
            Checkpoints.checkpointSet = false;
        }
        if(customSceneEnabled)
        {
            StartCoroutine(LoadLevel(customSceneNumber));
        }
        else
        {
            LoadNextLevel();
        }
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
            if(waitForBoss)
            {
                FirstBossFight boss = FindObjectOfType<FirstBossFight>();
                if(boss != null)
                {
                    return;
                }
            }
            PlayerActionController action = col.GetComponent<PlayerActionController>();
            if(action != null)
            {
                action.Paralyze();
            }
            Activate();
        }
    }
}
