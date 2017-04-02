﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera2D
{
    public class CameraController : MonoBehaviour
    {
        public float dampTime = 0.15f;
        private Vector3 velocity = Vector3.zero;
        public Transform target;
        public Camera currentCamera;
        void Start()
        {
            currentCamera = Camera.main;
            target = Entity.EntityData.player.transform;
        }
        void Update()
        {
            Vector3 point = currentCamera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - currentCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}

