using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;

namespace PlayFabControl
{
    public class PlayfabManager : MonoBehaviour
    {
        [SerializeField] GameObject signUpTab, logInTab, startPanel, HUD;
        public InputField username, userEmail, userPassword, userEmailLogin, userPasswordLogin; 
        public Text errorSignUp, errorLogin;
        string encryptedPassword;

        public void SwithchSignUpTab()
        {
            signUpTab.SetActive(true);
            logInTab.SetActive(false);
            errorSignUp.text = "";
            errorLogin.text = "";
        }

        public void SwitchLoginTab()
        {
            signUpTab.SetActive(false);
            logInTab.SetActive(true);
            errorSignUp.text = "";
            errorLogin.text = "";
        }

        string Encrypt(string pass)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach(byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        public void SignUp()
        {
            var registerRequest = new RegisterPlayFabUserRequest{
                Email = userEmail.text,
                Password = Encrypt(userPassword.text),
                Username = username.text
            };
            
            errorSignUp.text = "Loading...";
            PlayFabClientAPI.RegisterPlayFabUser(registerRequest, RegisterSuccess, RegisterError);
        }

        public void RegisterSuccess(RegisterPlayFabUserResult result)
        {
            errorSignUp.text = "";
            errorLogin.text = "";
            StartGame();
        }

        public void RegisterError(PlayFabError error)
        {
            errorSignUp.text = "Account has been registered"; 
        }


        public void LogIn()
        {
            var request = new LoginWithEmailAddressRequest{
                Email = userEmailLogin.text,
                Password = Encrypt(userPasswordLogin.text),
            };
            PlayFabClientAPI.LoginWithEmailAddress(request, LoginSuccess, LoginError);
        }
            public void LoginSuccess(LoginResult result)
        {
            errorSignUp.text = "";
            errorLogin.text = "";
            StartGame();
        }

        public void LoginError(PlayFabError error)
        {
            errorLogin.text = "Account or password is wrong or not registered";
        }

        void StartGame()
        {
            startPanel.SetActive(false);
            HUD.SetActive(true);
        }

        void Start()
        {
            startPanel.SetActive(true);
            signUpTab.SetActive(true);
            logInTab.SetActive(false);
            HUD.SetActive(false);
        }


    }
}