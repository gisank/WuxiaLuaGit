using UnityEngine;
using System.Collections;

public class UIMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        JLua.Init();
        JLua.RunLua("UIMain", "UIMain");
	}

    public void Login() {
        GameObject AccountGo = this.transform.FindChild("AboutLogin/AccountInputField").gameObject;
        GameObject PassGo = this.transform.FindChild("AboutLogin/PasswordInputField").gameObject;
        object[] r = JLua.CallLuaFunc("Login", (object)AccountGo, (object)PassGo);
        if (!(bool)r[0]) {
            Debug.Log(r[1]);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
