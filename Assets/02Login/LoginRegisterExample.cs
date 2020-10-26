using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginRegisterExample : MonoBehaviour
{
    public LoginPanal LoginPanal;
    public RegisterPanal RegisterPanal;

    public static LoginRegisterExample LoginRegisterMgr;

    void Awake()
    {
        LoginRegisterMgr = this;
    }
	// Use this for initialization
	void Start () {
        Debug.Log("Mgr");
	    LoginPanal = transform.Find("LoginPanal").GetComponent<LoginPanal>();
	    RegisterPanal = transform.Find("RegisterPanal").GetComponent<RegisterPanal>();

        LoginPanal.gameObject.SetActive(true);
        RegisterPanal.gameObject.SetActive(false);
	}
	
}
