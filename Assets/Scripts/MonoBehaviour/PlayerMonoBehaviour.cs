using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonoBehaviour : MonoBehaviour
{
   public GameObject player { private set;  get; }
   public Rigidbody2D playerRigidbody { private set;get; }
   public Animator playerAnimator { private set; get; }
   public Transform playerTransform { private set; get; }
   public CapsuleCollider2D playerCapsuleCollider2D { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerGetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveControll();
    }

    void LateUpdate()
    {
        
    }

    public virtual void PlayerGetInfo()
    {
        player = gameObject;
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
        playerTransform = player.transform;
        playerCapsuleCollider2D = player.GetComponent<CapsuleCollider2D>();
    }
    public virtual void PlayerMoveControll() { }
   
}
