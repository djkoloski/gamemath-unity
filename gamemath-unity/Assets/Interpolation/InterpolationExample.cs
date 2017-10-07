using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolationExample : MonoBehaviour
{
	[SerializeField]
	private Vector3 _startingPosition;
	[SerializeField]
	private Vector3 _endingPosition;
	[SerializeField]
	private float _interpolationTime;
	[SerializeField]
	private AnimationCurve _interpolationCurve;

	private float _timer;

	private void Update()
	{
		_timer = (_timer + Time.deltaTime) % _interpolationTime;
		float t = _interpolationCurve.Evaluate(_timer / _interpolationTime);
		transform.localPosition = _startingPosition * (1.0f - t) + _endingPosition * t;
	}
}
