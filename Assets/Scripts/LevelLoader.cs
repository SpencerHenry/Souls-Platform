using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(PlayerActionController))]

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public PlayerActionController _playerActionController;
    public float crossFadeTransitionTime = 0f;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(crossFadeTransitionTime);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerActionController _playerActionController = col.GetComponent<PlayerActionController>();
        if(_playerActionController != null) {
            _playerActionController.paralyzed = true;
        }
        
        if(col.gameObject.tag == "Player")
        {
            LoadNextLevel();
        }
    }
}
