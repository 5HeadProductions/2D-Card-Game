using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;

//WE WANT a button to play that changes when you generate it
public class MainMenuEditor : EditorWindow
{
    GameObject menuCanvas;
    string nameOfButton;
    string buttonDisplayContent;
    Vector3 playButtonPosition;


    [MenuItem("Tools/MainMenuWindowEditor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(MainMenuEditor));

        
    }

    private void OnGUI()
    {
        GUILayout.Label("Menu Editor");

        menuCanvas = EditorGUILayout.ObjectField("Menu to edit", menuCanvas, typeof(GameObject), false) as GameObject;
        nameOfButton = EditorGUILayout.TextField("Name of button to change position", nameOfButton);
        buttonDisplayContent = EditorGUILayout.TextField("Text Displayed on the button", buttonDisplayContent);
        playButtonPosition = EditorGUILayout.Vector3Field("Play Button position", playButtonPosition);
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Apply Changes"))
        {
            ApplyChanges();
        }
    }

    private void ApplyChanges()
    {
        GameObject.Find(nameOfButton).GetComponent<RectTransform>().localPosition = playButtonPosition;
        GameObject.Find(nameOfButton).GetComponentInChildren<TextMeshProUGUI>().text = buttonDisplayContent;
    }
}
