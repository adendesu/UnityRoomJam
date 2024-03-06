using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerMonoBehaviour
{

    [SerializeField] float speed;

    public static bool canPlay = true;
    // Start is called before the first frame update

    public override void PlayerMoveControll()
    {
        base.PlayerMoveControll();

        if (canPlay)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                if (playerAnimator.GetBool("Jump") == false && Input.GetKey(KeyCode.Space) != true)
                {
                    playerAnimator.SetBool("Run", true);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                if (playerAnimator.GetBool("Jump") == false && Input.GetKey(KeyCode.Space) != true)
                {
                    playerAnimator.SetBool("Run", true);
                }
            }
            else if (Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.D) != true) playerAnimator.SetBool("Run", false);

            if (Input.GetKeyDown(KeyCode.Space) && JumpCounter.JumpCount == 1)
            {
                JumpCounter.canJump = false;
                playerAnimator.SetBool("Run", false);
                playerRigidbody.AddForce(new Vector3(0, 300, 0), ForceMode2D.Force);
                playerAnimator.SetBool("Jump", true);
                JumpCounter.JumpCount = 0;
            }
            else if (JumpCounter.canJump == true) playerAnimator.SetBool("Jump", false);

            
        }
    }
}
