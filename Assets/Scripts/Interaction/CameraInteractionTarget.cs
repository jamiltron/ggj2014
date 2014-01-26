﻿using UnityEngine;
using System.Collections;

public class CameraInteractionTarget : InteractionTarget {

	public override void beginInteraction (string id) {
		
		EventManager.TriggerEvent(new LevelStart());
	}
	
	public override void stopInteraction (string id) {
		EventManager.TriggerEvent(new Segway());
	}
	
	
	public override void heroInteracted() {
	}
}
