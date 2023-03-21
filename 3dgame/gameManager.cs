using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] string sceneName;
 public void restartGame()
    {

        SceneManager.LoadScene(sceneName);

    }



}
