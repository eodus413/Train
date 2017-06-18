using UnityEngine;
using Entity;

namespace Camera2D
{
    public class CameraController : MonoBehaviour
    {
        //멤버 데이터
        [Header("Moving Datas")]

        [SerializeField] float dampTime = 0.15f;        //카메라의 보간 속도
        [Space(3)]
        [SerializeField] float maxX = 8f;               //카메라의 WorldSpace 좌표 최대값
        [SerializeField] float minX = -8f;              //카메라의 WorldSpace 좌표 최소값

        [Header("Targeting Datas")]

        [SerializeField] Transform target;              //현재 타겟
        [SerializeField] Vector3 targetPoint;           //타겟의 현재 화면 좌표값
        [SerializeField] Camera currentCamera;

        private Vector3 velocity = Vector3.zero;        
        
        //이벤트함수
        public void Start()
        {
            currentCamera = Camera.main;
            SetTarget(EntityManager.player);
        }

        void Update()
        {
            if (target == null) return;
            targetPoint = currentCamera.WorldToViewportPoint(target.position);      //타겟의 현재 화면 좌표값을 저장

            Vector3 delta = target.position - currentCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, targetPoint.z)); //(new Vector3(0.5, 0.5, point.z));

            Vector3 destination = transform.position + delta;

            Vector3 vec = transform.position;

            vec = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

            //카메라의 이동 구역을 벗어났는지 체크
            if (vec.x > maxX) vec.x = maxX;
            else if (vec.x < minX) vec.x = minX;

            transform.position = vec;
        }

        //인터페이스
        public void SetTarget(Transform newTarget)
        {
            if (newTarget == null) return;  //예외처리
            target = newTarget;
        }
    }
}

