using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GimicController : MonoBehaviour
{
    public static GimicController Instance { get; private set; }
    int interval = 3;
    int poolsize = 5;
    private List<GameObject> GimicPool;
    public GameObject GimicPrefab;
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
        GimicPool = new List<GameObject>();
        for (int i = 0; i < poolsize; i++)
        {
            GameObject enemy = Instantiate(GimicPrefab);
            enemy.SetActive(false);
            GimicPool.Add(enemy);
        }
        StartCoroutine(SpownGimic());
    }
    IEnumerator SpownGimic()
    {
        while (!GameManager.Instance.isEnd) //ゲーム終了まで回り続ける
        {
            Vector3 pos = new Vector3(Random.Range(7.31f, -0.85f), -3.96f, -87.6f); //ランダムな位置
            GameObject enemy = GetGimic(); 
            enemy.transform.position = pos; 
            yield return new WaitForSeconds(interval); //設定した時間待つ
        }
    }
    private GameObject GetGimic()
    {
        foreach (GameObject e in GimicPool)
        {
            if (!e.activeInHierarchy)
            {
                e.gameObject.SetActive(true);
                return e;
            }
        }
        //非アクティブなやつが無かったらプール拡張
        GameObject newGimic = Instantiate(GimicPrefab);
        newGimic.SetActive(true);
        GimicPool.Add(newGimic);
        return newGimic;
    }
    public void ReturnGimic(GameObject Gimic)
    {
        Gimic.SetActive(false);
    }
}
