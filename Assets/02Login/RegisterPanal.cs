using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanal : MonoBehaviour {

    private Button mLoginBtn;
    private Button mRegisterBtn;
    private InputField mUsername;
    private InputField mPassword1;
    private InputField mPassword2;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Register");
        mLoginBtn = transform.Find("SubBtn").GetComponent<Button>();
        mRegisterBtn = transform.Find("RegisterBtn").GetComponent<Button>();
        mUsername = transform.Find("NameInput").GetComponent<InputField>();
        mPassword1 = transform.Find("PwdInput1").GetComponent<InputField>();
        mPassword2 = transform.Find("PwdInput2").GetComponent<InputField>();

        mLoginBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("SubBtn clicked");
            LoginRegisterExample.LoginRegisterMgr.RegisterPanal.gameObject.SetActive(false);
            LoginRegisterExample.LoginRegisterMgr.LoginPanal.gameObject.SetActive(true);
        });

        mRegisterBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("RegisterBtn Clicked");
        });

        mUsername.OnEndEditAsObservable().Subscribe(_ =>
        {
            mPassword1.Select();
        });

        mPassword1.OnEndEditAsObservable().Subscribe(_ =>
        {
            mPassword2.Select();
        });

        mPassword2.OnEndEditAsObservable().Subscribe(_ =>
        {
            mRegisterBtn.Select();
            Debug.Log("RegisterBtn clicked");
        });

    }


}
