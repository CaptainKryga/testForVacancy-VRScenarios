using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Controller.Physics
{
	[RequireComponent(typeof(Rigidbody))]
	// Rotate towards from target
	public class KinematicRotateTheTarget : MonoBehaviour
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
			_rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, _target.transform.rotation, _speed));
		}
	}
}
