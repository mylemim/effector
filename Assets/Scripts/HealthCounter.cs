using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthCounter : Counter {

	Text text;

	public override int Value
	{
		get{
			return this.value;
		}
		
		set{
			this.value = value;
			if(text!=null)
				text.text = this.value.ToString();
		}
	}

	// Use this for initialization
	protected void Awake () {
		text = gameObject.GetComponent<Text>();
	}
}
