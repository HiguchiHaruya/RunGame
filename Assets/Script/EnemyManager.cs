using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float _moveSpeed = 45;
    Rigidbody rb;
    float _genarateTime = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(0, 0, _moveSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.Instance.ReturnEnemy(gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(1000);
            PlayerController.PlayerInstance.SetAnimationSpeed(0.05f);
            _moveSpeed += 10f;
            Debug.Log($"���݂̓G�̃X�s�[�h{_moveSpeed}");
            var ImplseSorce = GetComponent<CinemachineImpulseSource>();
            ImplseSorce.GenerateImpulse();
            GameManager.Instance.ReturnEnemy(gameObject);
            //�����������琁����уA�j���[�V�����̒ǉ��Ƃ�����������
        }
    }
}
