using UnityEngine;

namespace Project.Scripts.Controller.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    public class KinematicFollowTarget : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        
        [SerializeField] private Transform _target;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_target.position);
        }
    }
}
