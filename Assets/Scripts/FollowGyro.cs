using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyro : MonoBehaviour
{
    [SerializeField]
    private Quaternion baseRoation = new Quaternion(0, 0, 1, 0);

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
    }

    private void Update()
    {
        transform.rotation = GyroManager.Instance.GetGyroRotation() * baseRoation; 
    }
}
