using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int _score = 0;
    public GameObject EnemyPrefab;
    int poolsize = 10; 
    float interval = 1.5f; //�X�|�[���Ԋu
    private List<GameObject> Enemypool; //�I�u�W�F�N�g�v�[��
    bool isEnd = false; //�Q�[���̏I������


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        Enemypool = new List<GameObject>(); //������
        for (int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.SetActive(false);
            Enemypool.Add(enemy);
        }
        StartCoroutine(SpownEnemy());
    }
    IEnumerator SpownEnemy()
    {
        while (!isEnd) //�Q�[���I���܂ŉ�葱����
        {
            Vector3 pos = new Vector3(Random.Range(6.6f, -6.6f), 1, -95); //�����_���Ȉʒu
            GameObject enemy = GetEnemy(); //enemy���擾
            enemy.transform.position = pos; //enemy�̈ʒu�ݒ�
            yield return new WaitForSeconds(interval);
        }
    }
    private GameObject GetEnemy()
    {
        foreach (GameObject e in Enemypool)
        {
            if (!e.activeInHierarchy)
            {
                e.gameObject.SetActive(true);
                return e;
            }
        }
        //�v�[���g�� ��A�N�e�B�u�Ȃ������������
        GameObject newEnemy = Instantiate(EnemyPrefab);
        newEnemy.SetActive(true);
        Enemypool.Add(newEnemy);
        return newEnemy;
        // Instantiate(EnemyPrefab, pos, Quaternion.identity);

    }
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
