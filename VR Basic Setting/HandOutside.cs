using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


//���� ���� �վ �� ������ �̵��� ������ ������ �������� ��ũ��Ʈ
public class HandOutside : MonoBehaviour
{
    public Transform handPos;  //���� ���� ��ġ
    int layerMask;

    public XRRayInteractor interactor; //�̵��� ����ϴ� ��Ʈ�ѷ��� ���� ���ͷ���
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("NotPermitted"); // ������ ���̾�(�̵� �Ұ� ���� ex.��)
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //XR Rig�� �߰�, �� ��ü���� Raycast�� �տ� ��ġ���� ��.
        //���� ��ü���� �������� RayCast�� �̵��Ұ� ���̾ ������ �ȴٸ� �� ���� ���� ���� ���� �Ͱ� ���� ��Ȳ��
        //�׷� ��Ȳ�� ����� ���ͷ��͸� false�� �ٲٰ� �̵��� �Ұ��ϰ���.
        if(Physics.Raycast(transform.position, handPos.position - transform.position, Vector3.Distance(this.transform.position, handPos.position), layerMask))
        {
            interactor.enabled = false;
        }
        else
        {
            interactor.enabled = true;
        }
    }
}