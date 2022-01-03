using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RunnerSpecs", menuName = "ScriptableObjects/RunnerSpec", order = 1)]
public class RunnerSpecs : ScriptableObject
{
	[Header("Evolution Runner Specs")]
	public bool isEvolveRunner;
	public bool isOneSided;
	[Header("One Sided Evolution Specs")]
	public string[] oneSidedEvolutionNames = { "KID", "TEEN", "ADULT", "MONSTER" };
	public float[] oneSidedEvolveLimits = { 0.25f, 0.5f, 0.75f, 1f };
	public Color[] oneSidedEvolveColors = {new Color(0.95f, 0.7f, 0.4f),new Color(0.55f,0.9f,0.25f), new Color(0.4f,0.85f,0.25f), new Color(0.3f,0.7f,0.2f)};
	[Header("Double Sided Evolution Specs")]
	public string[] doubleSidedEvolutionNames = { "EVIL MONSTER", "EVIL ADULT", "EVIL TEEN", "KID", "TEEN", "ADULT", "MONSTER" };
	public float[] doubleSidedEvolveLimits = { 0, 0.15f, 0.3f, 0.45f, 0.55f, 0.7f, 0.85f, 1 };
	public Color[] doubleSidedEvolveColors = {new Color(0.7f,0.1f,0.15f), new Color(0.9f,0.15f,0.2f), new Color(0.95f, 0.25f,0)
			, new Color(0.95f, 0.7f, 0.4f), new Color(0.55f, 0.9f, 0.25f), new Color(0.4f, 0.85f, 0.25f),new Color(0.3f, 0.7f, 0.2f)};

	[Header("Others")]
	public bool isRacingRunner;
	public bool isJustRunner;
}
