using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(CreaterWords))]
public class CreaterWordsGUI : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CreaterWords createrWords = (CreaterWords)target;
        if (GUILayout.Button("Instatiate"))
            createrWords.CreateWords();
    }
}
#endif
