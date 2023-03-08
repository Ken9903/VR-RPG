using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 고개를 돌려도 몸체는 여전히 같은 곳을 바라 볼 수 있게하는 스크립트.
// 이 스크립트가 있다면 몸은 카메라를 따라 다니지만 XRRig 기준으로 방향이 고정된다.
public class BodyRIg : MonoBehaviour
{
    
    public Transform xrHeadTrans; // 몸이 머리를 따라 갈 수 있도록 참조.

    private Quaternion quaternion;
    private Vector3 position;
    // Update is called once per frame
    void Update()
    {
        position = xrHeadTrans.transform.position; // 몸이 머리를 따라 갈 수 있도록 참조.
        position.y = xrHeadTrans.position.y - 0.5f; // 몸체는 머리보다 0.5낮은 곳에 위치
        this.transform.position = position;


        // 방향은 0으로 부모인 XRRIg기준으로 설정.
        quaternion = xrHeadTrans.transform.rotation;
        quaternion.x = 0;
        quaternion.z = 0;
        this.transform.rotation = quaternion; 
    }
}
