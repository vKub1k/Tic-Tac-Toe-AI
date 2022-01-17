using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Animator _anim;

    public void _Open()
    {
        _anim.SetBool("isOpen", true);
    }
    public void _Close()
    {
        _anim.SetBool("isOpen", false);
    }
}
