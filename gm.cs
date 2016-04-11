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

// how long is a year? Say 120 turns, and each month is 10 turns.

public class _cat {
	string name; // randomized? - need to do an engine on this
	string job; // allocated by player
	string gender; // can be both
	
	int age; // cats live for 12-18, so they'll want to retire around 8
	int timeWorked; // how long they've worked for the hospital so far
	float salaryDaily;
	
	int intelligence; // affects diagnostic abilities
	int gut; // may offer random, miracle decisions - the higher the gut, the 
			// more likely it's true - with high payoff!
	int charisma; // how nice they are to patients, comfort to patience
	int passion; // how passionate they are about their job (might take lower pay?) - if too low they might leave
	
	float wellBeing; // affects performance (how many patients they're handling at the moment, etc)
}

public class _patient {
	string name;
	string gender;
	
	float loveForCat; // 0 - 100%, will affect wellbeing
	string preferredCat;

	float wellBeing; // general wellBeing, will affect health
	float health; // 0 -100%, 0% triggers death, can be discharged whenever, but may come back.
	
	float profileRisk; // 0 - 100%, 0 for normal. Profile risk describes a high-profile character, affects reputation of hospita

	float legendaryDisease; // 0 for none, 0 - 100% for difficulty to cure
	float epidemicDisease; // 0 for none, 0 - 100% for how contagious
	
	
}

public class _donor {
	string name;
	float hospitalLike; // 0 - 100%, how much they like the hospital, will affect chances of donorship
}


public class _hospital {
	float money; // current capital
	float expenses; // calculated off salary, maintenance
	
	float reputation; // reputation will affect patient profile risks (more high profile might come)
	// will affect donor chances etc
	
	float chanceNewPatient; // percentage calc'd from everything else on new patients
	
	List<_patient> patients = new List<_patient>(); // store all patients here
	List<_cat> doctors = new List<_cat>();
	//List<_cat> lawyers = new List<_cat>();
	//List<_cat> accountants = new List<_cat>();
	
	public _building building = new _building();
	
	public class _building {
		//int ambulanceBay; // provide more patients, but would increase risks, more happiness?
		//int emergencyDepartment; // provide more patients, but would increase risks
		//int pharmacy; // reputation, effectiveness?
		//int morgue; // morgue could add learning bonuses, in exchange for expense and more staff?
		//int kitchen; // level affects patient happiness
		//int cafeteria; // needs kitchen
		//int fancyCafe; // happiness, image?
		//int diagnosticMachines; // MRI, cat scans, xrays etc
		
		int size = 0; //levels, essentially
		int currentSpace = 10;
		int[] maxSpace = {10, 15, 20, 25, 30};
		
		
		public patientRoom[] patientRooms = new List<patientRoom>();
		public office[] offices = new List<office>();
		
		public class patientRoom
		{
			public _patient patient;
			public int roomid; // linked to room generic id\
			
			public int level = 0; // level associated with space/maintenance/etc
			private int[] _space = {1, 2, 3, 4, 5}; // amount of space to take up
			private int[] _maintenance = {100, 200, 300, 400, 500}; // daily maintenance
			private int[] _cost = {1000, 2000, 3000, 4000, 5000}; // cost to build/upgrade
			
			public int space{get{return _space[level]}}
			public int maintenance{get{return _maintenance[level]}}
			public int cost{get{return _cost[level]}}
			
		}
		
		public class office
		{
			public _cat cat;
			public int roomid;
			
			public int level = 0; // level associated with space/maintenance/etc
			private int[] _space = {1, 2, 3, 4, 5}; // amount of space to take up
			private int[] _maintenance = {100, 200, 300, 400, 500}; // daily maintenance
			private int[] _cost = {1000, 2000, 3000, 4000, 5000}; // cost to build/upgrade
			
			public int space{get{return _space[level]}}
			public int maintenance{get{return _maintenance[level]}}
			public int cost{get{return _cost[level]}}
		}
	}
	
	
	public float expenseCalculate(){
		// annual to false for daily
 		
		// go through all maintenance stuff
		// go through all staff
		// do tax stuff
		float totalDailySalary = 0;
		
		
		foreach (_cat cat in doctors)
		{
			totalDailySalary += cat.salaryDaily;
		}
		
		foreach (_cat cat in surgeons)
		{
			totalDailySalary += cat.salaryDaily;
		}
		
		foreach (_cat cat in lawyers)
		{
			totalDailySalary += cat.salaryDaily;
		}
		
		foreach (_cat cat in accountants)
		{
			totalDailySalary += cat.salaryDaily;
		}
		
		
		totalDailyExpenses = totalDailySalary; // add maintenance stuff to this later
		
		return totalDailyExpenses;
	}
}

public class _world {
	float tax; // in %, depends on world economy
	float govtFriendly; // how much the government likes your hospital, will affect funding
	
	
}
