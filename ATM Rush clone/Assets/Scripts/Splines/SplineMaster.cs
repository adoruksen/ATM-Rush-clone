using Dreamteck.Splines;
using Dreamteck.Splines.Examples;
using System.Collections.Generic;
using UnityEngine;


public class SplineMaster : MonoBehaviour
{
	[System.NonSerialized] public static SplineMaster instance;

	#region Variables

	[System.NonSerialized] public SplineTracer myTracer;
	[System.NonSerialized] public SplineFollower myFollower;
	double lastPercent;

	#endregion

	private void Awake()
	{
		instance = this;
	}

	void Start()
	{
		myFollower = GetComponent<SplineFollower>();
		myTracer = GetComponent<SplineTracer>();
		myTracer.onNode += OnJunction;
		myTracer.onMotionApplied += OnMotionApplied;
		if (myTracer is SplineFollower)
		{
			SplineFollower follower = (SplineFollower)myTracer;
			follower.onBeginningReached += FollowerOnBeginningReached;
			follower.onEndReached += FollowerOnEndReached;
		}
		myFollower.follow = false;
	}

	private void OnMotionApplied()
	{
		lastPercent = myTracer.result.percent;
	}

	private void FollowerOnBeginningReached(double lastPercent)
	{
		this.lastPercent = lastPercent;
	}

	private void FollowerOnEndReached(double lastPercent)
	{
		this.lastPercent = lastPercent;
	}

	private void OnJunction(List<SplineTracer.NodeConnection> passed)
	{
		Node node = passed[0].node;
		JunctionSwitch junctionSwitch = node.GetComponent<JunctionSwitch>();
		if (junctionSwitch == null) return;
		if (junctionSwitch.bridges.Length == 0) return;

		JunctionSwitch.Bridge bridge;

		//Geçmek istediðimiz bridgenin indexini burada seçiyoruz
		int bridgeIndex = 0;

		bridge = junctionSwitch.bridges[bridgeIndex];
		Node.Connection[] connections = node.GetConnections();

		SwitchSpline(connections[bridge.a], connections[bridge.b]);
	}

	void SwitchSpline(Node.Connection from, Node.Connection to)
	{

		float excessDistance = from.spline.CalculateLength(from.spline.GetPointPercent(from.pointIndex), myTracer.UnclipPercent(lastPercent));
		myTracer.spline = to.spline;
		myTracer.RebuildImmediate();
		double startpercent = myTracer.ClipPercent(to.spline.GetPointPercent(to.pointIndex));
		if (Vector3.Dot(from.spline.Evaluate(from.pointIndex).forward, to.spline.Evaluate(to.pointIndex).forward) < 0f)
		{
			if (myTracer.direction == Spline.Direction.Forward) myTracer.direction = Spline.Direction.Backward;
			else myTracer.direction = Spline.Direction.Forward;
		}
		myTracer.SetPercent(myTracer.Travel(startpercent, excessDistance, myTracer.direction));
	}
}

