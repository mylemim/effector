using UnityEngine;
using System.Collections;

public class PlayerHealth : Health {

	public override void Die(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
