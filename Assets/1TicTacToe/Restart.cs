using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] Player _player;
    public void _Restart()
    {
        _player._ResetAllValues();
    }
}
