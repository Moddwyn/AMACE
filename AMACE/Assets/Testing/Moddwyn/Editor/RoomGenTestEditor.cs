using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(RoomGenTest))]
public class RoomGenTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RoomGenTest myScript = (RoomGenTest)target;
        if(GUILayout.Button("Generate Rooms"))
        {
            myScript.Generate();
        }
    }
}