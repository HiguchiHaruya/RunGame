using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class GimicMove : MonoBehaviour
{
    [SerializeField] Text cubetxt;
    int movespeed = 45;
    Rigidbody _rb;
    int r = 0;
    void Start()
    {
        r = Random.Range(0, 2);
        Debug.Log(r);
        _rb = GetComponent<Rigidbody>();
        if (r == 0) { cubetxt.text = "2x"; }
        if (r == 1) { cubetxt.text = "2x"; }
        if (r == 2) { cubetxt.text = "2x"; }
    }

    void Update()
    {
        _rb.velocity = new Vector3(0, 0, movespeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            movespeed += 10;
            PlayerController.PlayerInstance.SetPlayerCount(0);
            GimicController.Instance.ReturnGimic(gameObject);
        }
    }
}
