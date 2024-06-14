using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ClonePlayer : MonoBehaviour
{
    float _movespeed = 10;
    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
