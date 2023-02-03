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
    //�X�^�[�g�n�_(���g�p)
    private int startPos = 80;
    //�S�[���n�_�i���g�p�j
    private int goalPos = 360;
    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    //�Ō�ɍ�����I�u�W�F�N�g
    public GameObject lastObject;
    //Unity������lastObject�̋���
    private float difference;
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;


    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g�擾
        this.unitychan = GameObject.Find("unitychan");

        //�ǂ̃A�C�e���������_����
        int num = Random.Range(1, 11);
        if(num <= 2)
        {
            //�R�[����x�������Ɉ꒼���ɐ���
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab);
                conePrefab.transform.position = new Vector3(4 * j, conePrefab.transform.position.y, 45);
                lastObject = cone;
            }
        }
        else
        {
            //���[�����ƂɃA�C�e������
            for (int j = -1; j <= 1; j++)
            {
                //�A�C�e���̎�ނ����߂�
                int item = Random.Range(1, 11);
                //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                int offsetZ = Random.Range(-5, 6);
                //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                if(1<=item && item <= 6)
                {
                    //�R�C���𐶐�
                    GameObject coin = Instantiate(coinPrefab);
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, 45 + offsetZ);
                    lastObject = coin;
                }
                else if(7<=item && item <= 9)
                {
                    //�Ԃ𐶐�
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

            //�ǂ̃A�C�e���������_����
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + 55);
                    lastObject = cone;
                }
            }
            else
            {
                //���[�����ƂɃA�C�e������
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�
                    int item = Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u:30%�Ԕz�u:10%�����Ȃ�
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + 55 + offsetZ);
                        lastObject = coin;
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + 55 + offsetZ);
                        lastObject = car;
                    }
                }
            }
        }
    }
}
