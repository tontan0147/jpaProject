using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loandintro : MonoBehaviour
{
   
    public string nextSceneName;

    void Start()
    {
        // Start the coroutine when the script is initialized
        StartCoroutine(TransitionCoroutine());
    }

    IEnumerator TransitionCoroutine()
    {

        // Wait for the animation to complete
        yield return new WaitForSeconds(3.0f);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

}
