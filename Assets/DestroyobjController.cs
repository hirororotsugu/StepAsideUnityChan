using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyobjController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとデストロイの距離
    private float difference;

    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクト取得
        this.unitychan = GameObject.Find("unitychan");
        //UnityちゃんとDestroyobj(z座標)の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてDestroyobjを移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

    void OnTriggerEnter(Collider other)
    {
        //もしDestroyobjとアイテムが衝突したら破壊
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            //破壊
            Destroy(other.gameObject);
        }
    }
}
