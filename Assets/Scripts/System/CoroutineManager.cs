﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
	const int MAX_COROUTINE = 100;

	public static CoroutineManager instance;
	[SerializeField]
	private bool[] Kbool;
	private Coroutine[] inst;

	public Coroutine[] Inst { get { return inst; } set { inst = value; } }

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of CoroutineController found!");
			return;
		}
		instance = this;
		Initialize_K(MAX_COROUTINE);
	}

	private void Initialize_K(int n)
	{
		Kbool = new bool[n];
		inst = new Coroutine[n];
		for (int i = 0; i < Kbool.Length - 1; i++)
		{
			Kbool[i] = false;
			inst[i] = null;
		}
	}

	public int GetK()
	{
		for (int i = 0; i < Kbool.Length - 1; i++)
		{
			if (!Kbool[i])
			{
				Kbool[i] = true;
				Debug.Log("Get K: " + i);
				return i;
			}
		}
		Debug.LogError("TOO MANY COROUTINE REQUESTS, K OVER BOUND!!");
		return -1;
	}

	public void RevokeK(int i)
	{
		Kbool[i] = false;
		Debug.Log("Revoke K: " + i);
	}
}
