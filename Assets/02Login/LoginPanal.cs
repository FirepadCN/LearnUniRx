using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanal : MonoBehaviour
{
    private Button mLoginBtn;
    private Button mRegisterBtn;
    private InputField mUsername;
    private InputField mPassword;

	// Use this for initialization
	void Start () {
        Debug.Log("login");
	    mLoginBtn = transform.Find("SubBtn").GetComponent<Button>();
	    mRegisterBtn = transform.Find("RegisterBtn").GetComponent<Button>();
	    mUsername = transform.Find("NameInput").GetComponent<InputField>();
	    mPassword = transform.Find("PwdInput").GetComponent<InputField>();

	    mLoginBtn.OnClickAsObservable().Subscribe(_ =>
	    {
	        Debug.Log("SubBtn clicked");
	    });

	    mRegisterBtn.OnClickAsObservable().Subscribe(_ =>
	    {
	        LoginRegisterExample.LoginRegisterMgr.RegisterPanal.gameObject.SetActive(true);
	        LoginRegisterExample.LoginRegisterMgr.LoginPanal.gameObject.SetActive(false);
        });

	    mUsername.OnEndEditAsObservable().Subscribe(_ =>
	    {
            mPassword.Select();
	    });

	    mPassword.OnEndEditAsObservable().Subscribe(_ =>
	    {
	        mLoginBtn.onClick.Invoke();
	    });
	}

}
