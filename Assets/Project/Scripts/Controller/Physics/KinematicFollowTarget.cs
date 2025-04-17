using UnityEngine;

namespace Project.Scripts.Controller.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    // Kinematic movement towards the target
    public class KinematicFollowTarget : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(Vector3.Lerp(transform.position, _target.transform.position, _speed));
        }
    }
}
