using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    Rigidbody rb;
    private Animator animator;
    public static PlayerController PlayerInstance { get; private set; }

    private void Awake()
    {
        if (PlayerInstance == null)
        {
            PlayerInstance = this;
            //DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.speed = 1f;
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(h * moveSpeed, 0, 0);
        Debug.Log($"現在のアニメーションスピード{animator.speed}");
    }
    public void SetAnimationSpeed(float speed)
    {
        animator.speed += speed;
    }
}
