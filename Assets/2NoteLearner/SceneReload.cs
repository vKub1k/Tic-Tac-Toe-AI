using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour
{
    // Start is called before the first frame update
    public void _ReloadSceen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void _LoadSceen(int index)
    {
        SceneManager.LoadScene(index);
    }
}
