using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ ������ ��ü�� ������ ���� ���� �ٶ� �� �� �ְ��ϴ� ��ũ��Ʈ.
// �� ��ũ��Ʈ�� �ִٸ� ���� ī�޶� ���� �ٴ����� XRRig �������� ������ �����ȴ�.
public class BodyRIg : MonoBehaviour
{
    
    public Transform xrHeadTrans; // ���� �Ӹ��� ���� �� �� �ֵ��� ����.

    private Quaternion quaternion;
    private Vector3 position;
    // Update is called once per frame
    void Update()
    {
        position = xrHeadTrans.transform.position; // ���� �Ӹ��� ���� �� �� �ֵ��� ����.
        position.y = xrHeadTrans.position.y - 0.5f; // ��ü�� �Ӹ����� 0.5���� ���� ��ġ
        this.transform.position = position;


        // ������ 0���� �θ��� XRRIg�������� ����.
        quaternion = xrHeadTrans.transform.rotation;
        quaternion.x = 0;
        quaternion.z = 0;
        this.transform.rotation = quaternion; 
    }
}