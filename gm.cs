using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System;
using System.Linq;
using System.Collections.Generic;

public class gm : MonoBehaviour {
	public Text moneyDisplay;
	public int money = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		//_GM_AdvisorCat AC = gameObject.GetComponent<_GM_AdvisorCat> ();
		//AC.showDialog ();
		//AC.message = "world!";
	}
	// Update is called once per frame

	public void tempEarnMoney (int earn){
		money += earn;
	}

	public void UpdateUI() {
		moneyDisplay.text = money.ToString ();
	}

	void Update () {
	}
}
