using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalMovementPlatformingExample : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField]
	private float _acceleration;
	[SerializeField]
	private float _maxAcceleration;
	[SerializeField]
	private float _maxVelocity;

	[Header("Jumping")]
	[SerializeField]
	private float _groundedDistance;
	[SerializeField]
	private float _jumpVelocity;
	[SerializeField]
	private float _jumpCooldown;

	private Rigidbody2D _rigidbody2d;
	private float _jumpTimer;

	private void Awake()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		_rigidbody2d.AddForce(
			NaturalMovement.MatchVelocityForce(
				new Vector3(
					Input.GetAxis("Horizontal"),
					0.0f,
					0.0f) * _maxVelocity,
				new Vector2(_rigidbody2d.velocity.x, 0.0f),
				_acceleration,
				_maxAcceleration));

		// Jumping
		if (_jumpTimer > 0.0f)
		{
			_jumpTimer = Mathf.Max(0.0f, _jumpTimer - Time.deltaTime);
		}

		if (
			Input.GetAxis("Vertical") > 0.0f &&
			Physics2D.Raycast(transform.position, Vector2.down, _groundedDistance).collider != null &&
			_jumpTimer <= 0.0f)
		{
			_rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _jumpVelocity);
			_jumpTimer = _jumpCooldown;
		}
	}
	private void FixedUpdate()
	{
		_rigidbody2d.velocity = new Vector2(
			NaturalMovement.CapVelocity(new Vector2(_rigidbody2d.velocity.x, 0.0f), _maxVelocity).x,
			_rigidbody2d.velocity.y);
	}
}