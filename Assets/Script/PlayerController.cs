using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    Rigidbody rb;
    private Animator animator;
    private int currentPlayerCount = 1;
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

    [SerializeField] GameObject PlayerPrefab;
    public void SetPlayerCount(int r)
    {
        if (r == 0)
        {
            for (int i = 0; i < currentPlayerCount * 2; ++i)
            {
                var player = Instantiate(PlayerPrefab, new Vector3(PlayerPrefab.transform.position.x + i, 0, 0)
                     , Quaternion.identity);
                Debug.Log
                    ($"クローン:{player} 位置:{player.transform.position}" +
                    $"スケール:{player.transform.localScale}");
            }
        }
        else if (r == 1) { }
        else { }
    }

}
