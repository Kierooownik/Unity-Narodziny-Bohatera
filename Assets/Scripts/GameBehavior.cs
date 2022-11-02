using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Stack<string> lootStack = new Stack<string>();
    Queue<string> activePlayers = new Queue<string>();

    public delegate void DebugDelegate(string newText);
    public DebugDelegate debug = Print;
    
    private string _state;
    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    public string labelText = "Zbierz wszystkie przedmioty i zdob�d� wolno��!";
    public int maxItems = 1;
    private bool showWinScreen = false;
    private bool showLossScreen = false;

    void Start()
    {
        Initialize();
        AddToQueue();
        InventoryList<string> inventoryList = new InventoryList<string>();
        inventoryList.SetItem("Eliksir");
        //Debug.Log(inventoryList.item);
    }

    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set { _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                labelText = "Znalaz�e� wszystkie przedmioty!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Przedmiot znaleziony. Jeszcze " + (maxItems - _itemsCollected) + " do ko�ca!";
            }

        }
    }

    private int _playerHP = 2;
    public int HP
    {
        get { return _playerHP; }
        set { 
            _playerHP = value;
            if (_playerHP <= 0)
            {
                labelText = "Czy potrzebujesz kolejnego �ycia?";
                showLossScreen = true;
                Time.timeScale = 0f;
            }    
            else
            {
                labelText = "Oj... To boli.";
            }
        }
    }

   
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Kondycja:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Zebrane przedmioty: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Wygra�e�!"))
            {
                try
                {
                    Utilities.RestartLevel(-1);
                    debug("Restart poziomu zako�czy� si� sukcesem...");
                }
                catch (System.ArgumentException e)
                {
                    Utilities.RestartLevel(0);
                    debug("Powr�t do sceny 0: " + e.ToString());
                }
                finally
                {
                    debug("Restart zosta� obs�u�ony");
                }

            }
        }
        if(showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Przegra�e�! Spr�buj ponownie."))
            {
                Utilities.RestartLevel();
            }
        }
    }
    public void Initialize()
    {
        _state = "Mened�er zainicjowany...";
        
        debug(_state);
        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;


        lootStack.Push("Miecz losu");
        lootStack.Push("Dodatkowe �ycie");
        lootStack.Push("Z�oty klucz");
        lootStack.Push("Skrzydlaty but");
        lootStack.Push("Magiczne szelki");
    }
    public void HandlePlayerJump()
    {
        debug("Gracz wykona� skok");
    }
    
    public void LogWithDelegate(DebugDelegate del)
    {
        del("Delegowanie zadania wy�wietlania komunikatu..");
    }
    
    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();
        Debug.LogFormat("Zebra�e� {0}! Teraz masz szans� na znalezienie {1}!", currentItem, nextItem);
        Debug.LogFormat("Na stosie oczekuje na Ciebie {0} losowych przedmiot�w!", lootStack.Count);

    }
    public void AddToQueue()
    {
        activePlayers.Enqueue("Harrison");
        activePlayers.Enqueue("Alex");
        activePlayers.Enqueue("Haley");
    }
    public void PrintPlayers()
    {
        var firstPlayer = activePlayers.Peek();
        //var firstPlayer = activePlayers.Dequeue();
    }
}
