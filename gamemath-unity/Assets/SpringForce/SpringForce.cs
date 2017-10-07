using UnityEngine;

public static class SpringForce
{
	public static Vector3 Calculate(Vector3 position, Vector3 velocity, Vector3 target, float springConstant, float dampingRatio)
	{
		float criticalDamping = 2.0f * Mathf.Sqrt(springConstant);
		float damping = dampingRatio * criticalDamping;
		Vector3 toTarget = target - position;
		return springConstant * toTarget - damping * velocity;
	}
}
 