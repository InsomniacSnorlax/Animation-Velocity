using UnityEngine;
using UnityEngine.AI;

namespace Snorlax.Prototype.Animation
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class VelocityAnimation : MonoBehaviour
    {
        private Animator anim;
        private NavMeshAgent agent;
        private Camera mainCamera;

        private Vector3 clickPosition;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            mainCamera = Camera.main;
        }

        private void Update()
        {
            CameraClick();

            float speed = agent.velocity.magnitude;
            anim.SetFloat("Speed", speed);
            anim.SetFloat("Angle", CalculateAngle(transform.forward, agent.velocity));
        }

        private void CameraClick()
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 CurrentMousePosition = Input.mousePosition;

                Ray ray = mainCamera.ScreenPointToRay(CurrentMousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    clickPosition = hit.point;
                    agent.SetDestination(clickPosition);
                }
            }
        }

        public static float CalculateAngle(Vector3 from, Vector3 to)
        {
            return Quaternion.FromToRotation(to, from).eulerAngles.y;
        }

#if UNITY_EDITOR

        [SerializeField]
        private bool canRotate;
        private void OnValidate()
        {
            if (!agent)
            {
                return;
            }

            if (canRotate)
            {
                agent.angularSpeed = 360f;
            }
            else
            {
                agent.angularSpeed = 0f;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, clickPosition);
        }

#endif
    }
}