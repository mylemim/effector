﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : Counter {

	Text text;

	public override int Value
	{
		get{
			return this.value;
		}
		
		set{
			this.value = value;
			text.text = this.value.ToString ("D7");
		}
	}

	// Use this for initialization
	protected override void Start () {
		text = gameObject.GetComponent<Text>();
		this.Value = 0;
	}
}
