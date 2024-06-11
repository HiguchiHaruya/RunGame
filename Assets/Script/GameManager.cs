using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int _score = 0;
    public GameObject EnemyPrefab;
    int poolsize = 10;
    float interval = 1.5f; //スポーン間隔
    private List<GameObject> Enemypool; //オブジェクトプール
    public bool isEnd = false; //ゲームの終了判定
    public Text scoreTxt;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        Enemypool = new List<GameObject>(); //初期化
        for (int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab);
            enemy.SetActive(false);
            Enemypool.Add(enemy);
        }
        StartCoroutine(SpownEnemy());
    }
    private void Update()
    {
        scoreTxt.text = ($"スコア : {_score.ToString()}");
    }
    public void AddScore(int p)
    {
        _score += p;
    }
    int currentPlayerCount = 1;
    public GameObject PlayerPrefab;
    public void SetPlayerCount(int r)
    {
        if (r == 0)
        {
            for (int i = 0; i < currentPlayerCount * 2; ++i)
            {
                Instantiate(PlayerPrefab);
                PlayerPrefab.transform.position =
                    new Vector3(PlayerPrefab.transform.position.x + i, 0, 0);
            }
        }
        else if (r == 1) { }
        else { }
    }
    //-------------Enemy関連------------------
    IEnumerator SpownEnemy()
    {
        while (!isEnd) //ゲーム終了まで回り続ける
        {
            Vector3 pos = new Vector3(Random.Range(6.6f, -6.6f), 1, -95); //ランダムな位置
            GameObject enemy = GetEnemy(); //enemyを取得
            enemy.transform.position = pos; //enemyの位置設定
            yield return new WaitForSeconds(interval); //設定した時間待つ
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
        //非アクティブなやつが無かったらプール拡張
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
