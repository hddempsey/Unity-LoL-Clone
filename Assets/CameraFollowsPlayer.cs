using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public enum FollowType
    {
        Rigid,
        Lerp,
        Slerp
    }
    
    public Transform playerTransform;
    public Vector3 offset;
    public float speed = 5f;
    public FollowType followMethod = FollowType.Lerp;

    private Transform cameraTransform;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform;
    }

    private void LateUpdate()
    {
        switch (followMethod)
        {
            case FollowType.Rigid:
                targetPos = playerTransform.position + offset;
                break;
            case FollowType.Lerp:
                targetPos = Vector3.Lerp(cameraTransform.position, playerTransform.position + offset, Time.deltaTime * speed);
                break;
            case FollowType.Slerp:
                targetPos = Vector3.Slerp(cameraTransform.position, playerTransform.position + offset, Time.deltaTime * speed);
                break;
        }
        cameraTransform.position = targetPos;
    }
}
