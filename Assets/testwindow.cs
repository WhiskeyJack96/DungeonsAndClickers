using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testwindow : MonoBehaviour {

    public Rect windowRect = new Rect(20, 20, 120, 50);
    void OnGUI() {
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "Quest Description");
    }
    void DoMyWindow(int windowID) {
      	GUI.Label(new Rect(10, 20, 100, 20), "");

        
    }
}
