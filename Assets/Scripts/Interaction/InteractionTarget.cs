﻿using UnityEngine;
using System.Collections;

public class InteractionTarget : MonoBehaviour,IEventListener {

	GameObject popup = null;

	// Use this for initialization
	void Awake () {
		EventManager.AddListener(this, "HeroInteractEvent");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public virtual void beginInteraction () {

		this.popup = PopupManager.getInstance().showPopupFromGameObject("testPopup",this.gameObject, new Vector3(0,0.75f,0));
	}

	public virtual void stopInteraction () {

	}


	public virtual void heroInteracted() {
		this.interactionSatisfied();
	}


	void interactionSatisfied () {
		if (this.popup != null){
			GameObject.Destroy(this.popup);
			this.popup = PopupManager.getInstance().showPopupFromGameObject("thankYou",this.gameObject, new Vector3(0,0.75f,0));
			StartCoroutine(hideThankYou());
		}
	}
	
	IEnumerator hideThankYou() {
		yield return new WaitForSeconds(1f);
		GameObject.Destroy(this.popup);
		this.popup = null;
	}


	bool IEventListener.HandleEvent(IEvent evt) {
		switch (evt.GetName()) {
		case "HeroInteractEvent":
			this.heroInteracted();
			break;
		}        
		return false;
	}

}
