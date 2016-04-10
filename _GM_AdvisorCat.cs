using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class _GM_AdvisorCat : MonoBehaviour {
	public Text acd_textbox;
	public GameObject dialogWindow;
	public _currentDialog currentDialog = new _currentDialog();
	public _masterDialog masterDialog = new _masterDialog();

	public void Start () {
		//currentDialog.n = 0;
		hideDialog();
		//currentDialog.lines = masterDialog._masterDialogDict["intro"];
	}

	public void nextLine(){
		if (currentDialog.n >= currentDialog.lines.Count-1) {
			hideDialog ();
		} else {
			currentDialog.n++;
			acd_textbox.text = currentDialog.lines [currentDialog.n];
		}
	}
		
	public void showDialog(string nameOfLines){
		currentDialog.n = 0;
		currentDialog.lines = masterDialog._masterDialogDict [nameOfLines]; //find dialog inputted and set current dialog
		acd_textbox.text = currentDialog.lines[currentDialog.n]; //show lines in current dialog

		dialogWindow.SetActive (true);
	}

	public void hideDialog(){
		dialogWindow.SetActive (false);
	}
}

public class _currentDialog {
	public List<string> lines = new List<string>();
	public int n = 0;
}

public class _masterDialog {
	public int n = 0;
	public Dictionary<string, List<string>> _masterDialogDict = new Dictionary<string, List<string>>();

	public _masterDialog () {
		_masterDialogDict.Add ("intro", new List<string>()
			{
				"Hello! I am your advisor cat.",
				"This is your cat hospital.",
				"No, no, no, not a hospital FOR cats",
				"It's a hospital run BY cats."
			}
		);

		_masterDialogDict.Add ("test2", new List<string>()
			{
				"Hey!",
				"I want to suck your blood!",
				"--Dick!"
			}
		);

	}
}