using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void _Restart()
    {
        SceneManager.LoadScene(0);
    }
}
