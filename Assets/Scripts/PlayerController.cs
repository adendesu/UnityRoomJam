using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && _animator.GetBool("Jump") == false)
        {
            _animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D) && _animator.GetBool("Jump") == false)
        {
            _animator.SetBool("Run", true);
        }
        else _animator.SetBool("Run", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("Jump", true);
            _animator.SetBool("Run", false);
        }
        else _animator.SetBool("Jump", false);
    }
}
