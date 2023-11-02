////using System.Collections;
////using System.Collections.Generic;
////using UnityEditor;
////using UnityEngine;

////[CustomEditor(typeof(Scoring))]
////public class ScoringEditor : Editor
////{
////    public override void OnInspectorGUI()
////    {
////        serializedObject.Update();

////        Scoring component = (Scoring)target;
////        Debug.Log("comp"+component.SelectedOption);
////        // Display a dropdown list for the enum-like variable
////        component.SelectedOption = (Scoring.Color)EditorGUILayout.EnumPopup("Selected Option", component.SelectedOption);
////        serializedObject.ApplyModifiedProperties();
////    }
////}
