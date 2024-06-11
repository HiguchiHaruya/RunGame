using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class GimicMove : MonoBehaviour
{
    public Text cubetxt;
    int movespeed = 45;
    Rigidbody _rb;
    int r = 0;
    void Start()
    {
        r = Random.Range(0, 3);
        _rb = GetComponent<Rigidbody>();
        cubetxt = GetComponent<Text>();
        if (r == 0) { cubetxt.text = "2x".ToString(); }
        if (r == 1) { cubetxt.text = "未定".ToString(); }
        if (r == 2) { cubetxt.text = "未定".ToString(); }
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
            GameManager.Instance.SetPlayerCount(0); //でバック。r忘れずにいれろ
            GimicController.Instance.ReturnGimic(gameObject);
        }
    }
}
