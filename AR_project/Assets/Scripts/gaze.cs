using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class gaze : MonoBehaviour
{
    List<infoBehave> infos = new List<infoBehave>();
    void Start()
    {
        infos = FindObjectsOfType<infoBehave>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward, out RaycastHit hit))
        {
            GameObject pre = hit.collider.gameObject;
            if (pre.CompareTag("boat"))
            {
                OpenInfo(pre.GetComponent<infoBehave>());
            }
            else
            {
               foreach (infoBehave info in infos)
                {
                    info.CloseInfo();
                }
            }
        }
    }

    void OpenInfo(infoBehave dInfo)
    {
        foreach (infoBehave info in infos)
        {
            if(info == dInfo)
            {
                info.OpenInfo();
            }
            else
            {
                info.CloseInfo();
            }
        }
    }
}
