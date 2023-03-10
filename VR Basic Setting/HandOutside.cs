using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;


//손이 벽을 뚫어서 맵 밖으로 이동이 가능한 현상을 막기위한 스크립트
public class HandOutside : MonoBehaviour
{
    public Transform handPos;  //현재 손의 위치
    int layerMask;

    public XRRayInteractor interactor; //이동을 담당하는 컨트롤러의 레이 인터렉터
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("NotPermitted"); // 검출할 레이어(이동 불가 지역 ex.벽)
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //XR Rig의 중간, 즉 몸체부터 Raycast를 손에 위치에다 쏨.
        //만약 몸체부터 손으로의 RayCast에 이동불가 레이어가 검출이 된다면 그 것은 손이 벽을 뚫은 것과 같은 상황임
        //그런 상황이 생기면 인터렉터를 false로 바꾸고 이동을 불가하게함.
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
