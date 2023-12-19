using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigidbody;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (_animator.GetBool("Jump") == false && Input.GetKey(KeyCode.Space) != true)
            {
                _animator.SetBool("Run", true);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (_animator.GetBool("Jump") == false && Input.GetKey(KeyCode.Space) != true)
            {
                _animator.SetBool("Run", true);
            }
        }
        else if(Input.GetKey(KeyCode.A)!= true && Input.GetKey(KeyCode.D)!= true) _animator.SetBool("Run", false);

        if (Input.GetKeyDown(KeyCode.Space) && JumpCounter.JumpCount==1)
        {
            JumpCounter.canJump = false;
            _animator.SetBool("Run", false);
            _rigidbody.AddForce(new Vector3(0, 300, 0), ForceMode2D.Force);
            _animator.SetBool("Jump", true);
            JumpCounter.JumpCount = 0;
        }
        else if(JumpCounter.canJump == true) _animator.SetBool("Jump", false);
    }
}
