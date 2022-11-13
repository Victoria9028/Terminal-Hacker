using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    string[] level1Passwords = { "smith", "jones", "williams", "taylor", "brown", "davies" };
    string[] level2Passwords = { "coventry", "demontfort", "oxford", "glasgow", "warwickshire", "leeds" };
    string[] level3Passwords = { "currency", "creditlimit", "collateral", "statement", "prepayment", "guarantor" };
    
    //Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start() {
        ShowMainMenu();
    }

    private void Update() {
        int index = Random.Range(0, level1Passwords.Length);
        print(index);
    }

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello and welcome to Terminal Hacker");
        Terminal.WriteLine("Who would you like to hack into?");
        Terminal.WriteLine("Press 1 for your neighbour's Wi-Fi");
        Terminal.WriteLine("Press 2 for your local University");
        Terminal.WriteLine("Press 3 for an international bank");
        Terminal.WriteLine("Please enter your selection: ");
    }

    void OnUserInput(string input) {

        if (input == "menu") {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber) {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "666") { // easter egg
            Terminal.WriteLine("Please make a selection Lucifer.");
        }
        else {
            Terminal.WriteLine("Invalid selection. Please try again.");
        }
    }

    void StartGame() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level) {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level selection");
                break;
        }
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input) {

        if (input == password) {
            DisplayWinScreen();
        }
        else {
            Terminal.WriteLine("Sorry, wrong password!");
        }
    }

    void DisplayWinScreen() {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward() {
        switch (level) {
            case 1:
                Terminal.WriteLine("WELL DONE!");
                Terminal.WriteLine("Here is your neighbour's hard drive...");
                Terminal.WriteLine(@"
     ________
    /       //
   /       // 
  /       //
 /_______//
(_______(/
"               );
                break;
            case 2:
                Terminal.WriteLine("WELL DONE!");
                Terminal.WriteLine("Here is your universities bank details...");
                Terminal.WriteLine(@"
 _____________________
|  __              )))|
| |__|                |
| 4353 3647 0738 7363 |
| V-05/18   E-05/22   |
| 625262  67686474    |
|_____________________|
"               );
                break;
            case 3:
                Terminal.WriteLine("WELL DONE!");
                Terminal.WriteLine("Here is your banks customer account details...");
                Terminal.WriteLine(@"
 ___________________
| Customer Accounts |
|                   |
| ac/holder: S.Smith|
| ac/number: 6753827|
| password: freedom1|
| balance: £7823327 |
|                   |
|___<1/186718762>___|
");
                break;
        }
    }
}
