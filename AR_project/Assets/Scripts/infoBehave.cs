using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoBehave : MonoBehaviour
{
    const float speed = 6f;
    [SerializeField]
    Transform SectionInfo;
    Vector3 currentScale = Vector3.zero;

    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, currentScale,Time.deltaTime*speed);    
    }

    public void OpenInfo()
    {
        currentScale = Vector3.one;
    }

    public void CloseInfo()
    {
        currentScale = Vector3.zero;
    }
}
