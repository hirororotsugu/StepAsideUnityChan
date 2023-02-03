using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{


    //car
    public GameObject carPrefab;
    //coin
    public GameObject coinPrefab;
    //corn
    public GameObject conePrefab;
    //スタート地点(未使用)
    private int startPos = 80;
    //ゴール地点（未使用）
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //最後に作ったオブジェクト
    public GameObject lastObject;
    //UnityちゃんとlastObjectの距離
    private float difference;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;


    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクト取得
        this.unitychan = GameObject.Find("unitychan");

        //どのアイテムかランダムに
        int num = Random.Range(1, 11);
        if(num <= 2)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                conePrefab.transform.position = new Vector3(4 * j, conePrefab.transform.position.y, 45);
                lastObject = cone;
            }
        }
        else
        {
            //レーンごとにアイテム生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置:30%車配置:10%何もなし
                if(1<=item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, 45 + offsetZ);
                    lastObject = coin;
                }
                else if(7<=item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab);
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, 45 + offsetZ);
                    lastObject = car;
                }
            }               
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastObject != null)
        {
           this.difference = lastObject.transform.position.z - unitychan.transform.position.z;
        }

        if (this.difference <= 40 && unitychan.transform.position.z <= 300 )
        {
            Debug.Log(this.difference = lastObject.transform.position.z - unitychan.transform.position.z);
            Debug.Log(unitychan.transform.position.z);

            //どのアイテムかランダムに
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + 55);
                    lastObject = cone;
                }
            }
            else
            {
                //レーンごとにアイテム生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + 55 + offsetZ);
                        lastObject = coin;
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + 55 + offsetZ);
                        lastObject = car;
                    }
                }
            }
        }
    }
}
