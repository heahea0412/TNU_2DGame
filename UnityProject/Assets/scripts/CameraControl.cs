﻿using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("跟隨目標")]
    public Transform target;
    [Header("跟隨速度"), Range(0f, 100f)]
    public float speed = 1.5f;

    private void Track()
    {

        float limitY = Mathf.Clamp(target.position.y, -0.3f, 3f); 
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);

        //攝影機.座標=三維向量.插值
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.3f * speed * Time.deltaTime);
    }
    private void LateUpdate()
    {
        Track();
    }

}