using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticle : MonoBehaviour
{
    public static PlayerParticle instance;

    #region Variables
    ParticleSystem[] particles;

	#endregion

	private void Awake()
	{
        instance = this;
	}
	void Start()
    {
        particles = new ParticleSystem[transform.childCount];
		for (int i = 0; i < particles.Length; i++)
		{
            particles[i] = transform.GetChild(i).GetComponent<ParticleSystem>();
		}
    }

	public void PlayParticle(int particleIndex)
	{
		if (transform.childCount > particleIndex && particles[particleIndex] != null)
		{
			particles[particleIndex].Play();
		}
		else
		{
			Debug.LogWarning("Out of boundaries or No particle Detected!");
		}
	}
}
