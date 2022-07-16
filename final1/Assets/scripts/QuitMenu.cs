using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game Off");
        Application.Quit();
        SceneManager.LoadScene("GameOff");
    }

    
}
