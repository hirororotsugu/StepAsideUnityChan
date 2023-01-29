using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyobjController : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;
    //Unity�����ƃf�X�g���C�̋���
    private float difference;

    //car
    public GameObject carPrefab;
    //coin
    public GameObject coinPrefab;
    //corn
    public GameObject conePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g�擾
        this.unitychan = GameObject.Find("unitychan");
        //Unity�����ƃJ�����̈ʒu(z���W)�̍������߂�
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Unity�����̈ʒu�ɍ��킹�ăJ�����̈ʒu���ړ�
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }

    void OnTriggerEnter(Collider other)
    {
        //����Destroyobj�ƃA�C�e�����Փ˂�����j��
        if(other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag" || other.gameObject.tag == "CoinTag")
        {
            Debug.Log("destroy");
            //�j��
            Destroy(other.gameObject);
        }
    }
}
