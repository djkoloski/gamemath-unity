using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpringForceExample : MonoBehaviour
{
	[SerializeField]
	private float _springConstant;
	[SerializeField]
	private float _dampingRatio;
	[SerializeField]
	private Transform _target;

	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	private void Update()
	{
		_rigidbody.AddForce(
			SpringForce.Calculate(
				_rigidbody.position,
				_rigidbody.velocity,
				_target.position,
				_springConstant,
				_dampingRatio));

		transform.rotation = Quaternion.AngleAxis(
			Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg,
			Vector3.forward);
	}
}
