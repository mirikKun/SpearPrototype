using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] private LineRenderer path;
    [SerializeField] private Transform target;
    [SerializeField] private Gradient gradient;

    private const float Height = 0.01f;

    private float _currentWidth;
    // Start is called before the first frame update
    void Start()
    {
        _currentWidth = path.startWidth;
        SetPathPosition();
    }

    private void SetPathPosition()
    {
        Vector3 transformPos = transform.position;
        Vector3 targetPos = target.position;
        path.SetPosition(0,new Vector3(transformPos.x,Height,transformPos.z));
        path.SetPosition(1,new Vector3(targetPos.x,Height,targetPos.z));
    }
    // Update is called once per frame
    public void PathSetup(float sizeScale)
    {
        path.startWidth = _currentWidth * sizeScale;
        path.endWidth = _currentWidth * sizeScale;
    }
}
