using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class NewBehaviourScript : MonoBehaviour {
	string macpath = "";
	string winpath = "";
	string[] maccodes;
	string[] wincodes;
	// Use this for initialization
	void Start () {
		maccodes = Directory.GetFiles (macpath, "*.cs", SearchOption.AllDirectories);
		wincodes = Directory.GetFiles (winpath, "*.cs", SearchOption.AllDirectories);
		for (int i = 0; i < maccodes.Length; i++) {
			string[] s = File.ReadAllLines (maccodes[i]);
			string[] s2 = File.ReadAllLines (wincodes[i]);
			for (int m = 0; m < s.Length; m++) {
				if (s [m].Equals(s2 [m])) {
				
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
