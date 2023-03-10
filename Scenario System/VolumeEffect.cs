using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeEffect : MonoBehaviour
{
    public Volume volume;

    Vignette vignette;
    DepthOfField depthOfField;

    IEnumerator BlinkEffect_forWakeUp() //일어날 때 눈을 천천히 깜빡이는 연출
    {
        
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.active = true;
            depthOfField.focusDistance.value = 0.5f;
        }
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value = 1;  // 눈 감고 시작
            yield return new WaitForSeconds(1);
        }
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            if (volume.profile.TryGet<DepthOfField>(out depthOfField))
            {
                while (vignette.intensity.value > 0.4f)
                {
                    vignette.intensity.value -= 0.005f;
                    depthOfField.focusDistance.value += 0.005f;
                    yield return new WaitForSeconds(0.005f);
                }

                while (vignette.intensity.value < 1)
                {
                    vignette.intensity.value += 0.005f;
                    depthOfField.focusDistance.value -= 0.005f;
                    yield return new WaitForSeconds(0.005f);
                }
                yield return new WaitForSeconds(1);
                while (vignette.intensity.value > 0f)
                {
                    if (volume.profile.TryGet<DepthOfField>(out depthOfField))
                    {

                        depthOfField.focusDistance.value += 0.01f;

                        vignette.intensity.value -= 0.01f;
                        yield return new WaitForSeconds(0.01f);


                    }
                    if (volume.profile.TryGet<DepthOfField>(out depthOfField))
                    {
                        depthOfField.active = false;
                    }
                }
            }
        }
     
    }

    IEnumerator BlinkEffect_forWakeDown() //기절,잠을 잘 때의 눈을 천천히 감는 연출
    {
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.focusDistance.value = 5;
            depthOfField.active = true;
            if (volume.profile.TryGet<Vignette>(out vignette))
            {
                vignette.intensity.value = 0;  // 눈 뜨고 시작
                while (vignette.intensity.value < 1)
                {
                    vignette.intensity.value += 0.01f;
                    depthOfField.focusDistance.value -= 0.05f;
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(1);

                while (vignette.intensity.value > 0.4f)
                {
                    vignette.intensity.value -= 0.01f;
                    depthOfField.focusDistance.value += 0.05f;
                    yield return new WaitForSeconds(0.01f);
                }

                while (vignette.intensity.value < 1)
                {
                    vignette.intensity.value += 0.01f;
                    depthOfField.focusDistance.value -= 0.05f;
                    yield return new WaitForSeconds(0.01f);
                }

            }
        }
    }

    IEnumerator SceneCloserDepthOfField() //점점 흐릿해지기
    {
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.focusDistance.value = 5;
            depthOfField.active = true;

            while(depthOfField.focusDistance.value > 0.2) //어느정도 최대치.
            {
                depthOfField.focusDistance.value -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    IEnumerator SceneOpenerDepthOfField() //점점 또렷해지기
    {
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.focusDistance.value = 0.2f;
            depthOfField.active = true;

            while (depthOfField.focusDistance.value < 5) 
            {
                depthOfField.focusDistance.value += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            depthOfField.active = false;
        }
    }


    //실제 실행 함수 부
    public void playWakeUp()
    {
        StartCoroutine(BlinkEffect_forWakeUp());
    }
    public void playWakeDown()
    {
        StartCoroutine(BlinkEffect_forWakeDown());
    }
    public void blurEye()
    {
        StartCoroutine(SceneCloserDepthOfField()); 
    }
    public void notblurEye()
    {
        StopCoroutine(SceneOpenerDepthOfField());
    }
}
