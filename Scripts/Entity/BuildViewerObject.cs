using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BuildViewerObject : MonoBehaviour
{
    private MeshRenderer MeshRenderer;
    public bool childCheck = true;

    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        MeshRenderer.material.color = Color.green;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Resource"))
        {
            if (childCheck == false)
            {
                foreach (Transform transform in transform)
                {
                    transform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                }
            }
            MeshRenderer.material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Resource"))
        {
            if (childCheck == false)
            {
                foreach (Transform transform in transform)
                {
                    transform.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
                }
            }
            MeshRenderer.material.color = Color.green;
        }
    }
}
