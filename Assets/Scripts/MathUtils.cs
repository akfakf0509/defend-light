using UnityEngine;

static class MathUtils
{
	public static Vector2 RadianToVector2(float radian)
	{
		return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
	}
	public static Vector2 DegreeToVector2(float degree)
	{
		return RadianToVector2(degree * Mathf.Deg2Rad);
	}
	public static float DirectionToDegree(Vector2 direction)
	{
		float angle = Vector2.Angle(Vector2.up, direction);
		angle *= Vector2.Dot(-Vector2.right, direction) > .0f ? 1 : -1;
		return angle;
	}
}