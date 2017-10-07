using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalMovementExample : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField]
	private float _acceleration;
	[SerializeField]
	private float _maxAcceleration;
	[SerializeField]
	private float _maxVelocity;
	[SerializeField]
	private float _timeToReach;

	[Header("Target")]
	[SerializeField]
	private Transform _target;

	private Rigidbody2D _rigidbody2d;

	private void Awake()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		_rigidbody2d.AddForce(
			NaturalMovement.ApproachPositionForce(
			_target.position,
			_rigidbody2d.position,
			_rigidbody2d.velocity,
			_acceleration,
			_maxAcceleration,
			_maxVelocity,
			_timeToReach));

		transform.rotation = Quaternion.AngleAxis(
			Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg,
			Vector3.forward);
	}
	private void FixedUpdate()
	{
		_rigidbody2d.velocity = NaturalMovement.CapVelocity(_rigidbody2d.velocity, _maxVelocity);
	}
}
