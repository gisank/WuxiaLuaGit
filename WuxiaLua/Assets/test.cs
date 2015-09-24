using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public GameObject GoTest;
	// Use this for initialization
	void Start () {
        JLua.Init();
        JLua.RunLua("UIMain", "UIMain");
        object[] r = JLua.CallLuaFunc("newImage", GoTest);
        Debug.Log(r[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
