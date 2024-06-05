using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Rigidbody rb;
    float _genarateTime = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 20);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.ReturnEnemy(gameObject);
        }
    }
}
