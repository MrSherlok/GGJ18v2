using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        private Vector3 target;
        public Transform target1;
        public Transform target2;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.8f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;
        
        Vector2 heading;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target;
            m_OffsetZ = (transform.position - target).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            if (Joystick.isPl1Dead || !target1.gameObject.activeInHierarchy)
            {
                gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(gameObject.GetComponent<Camera>().fieldOfView, 100, 0.1f);
                if (target != target2.position) {
                    target = new Vector2(Mathf.Lerp(target.x, target2.position.x, 0.1f), Mathf.Lerp(target.y, target2.position.y, 0.1f));
                } else
                {
                    target = target2.position;
                }

            } else
            {
                if (Joystick2.isPl2Dead || !target2.gameObject.activeInHierarchy)
                {
                    gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(gameObject.GetComponent<Camera>().orthographicSize, 3, 0.1f);
                    if (target != target1.position)
                    {
                        target = new Vector2(Mathf.Lerp(target.x, target1.position.x, 0.1f), Mathf.Lerp(target.y, target1.position.y, 0.1f));
                    }
                    else
                    {
                        target = target1.position;
                    }
                } else
                {
                    target = (target2.position + target1.position) / 2;
                    heading = target2.position - target1.position;
                    //Debug.Log(heading.magnitude);
                    if ((heading.magnitude / 2f) >= 2)
                        gameObject.GetComponent<Camera>().orthographicSize = (heading.magnitude / 2f);
                }
            }
            
            
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target;
        }
    }
}
