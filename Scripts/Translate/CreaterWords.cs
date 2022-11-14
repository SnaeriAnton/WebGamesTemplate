
#if UNITY_EDITOR
using Lean.Localization;
using Lean.Localization.Editor;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
public class CreaterWords : MonoBehaviour
{
    [SerializeField] private string[] _words;
    [SerializeField] private TMP_Text[] _texts;

    private string languageCodeEN = "en";
    private string languageCodeRU = "ru";
    private string languageCodeTR = "tr";
    private string _newWord = " ";

    private Transform[] _names = { };

    public void CreateWords()
    {
        if (_words.Length == 0)
            return;

        _names = GetComponentsInChildren<Transform>();

        foreach (var word in _words)
        {

            if (CheckWordInScene(word) == false)
                continue;

            var newObject = new GameObject();
            newObject.transform.name = word;
            newObject.transform.SetParent(transform);
            var lean = newObject.AddComponent<LeanPhrase>();

            lean.AddEntry("English", word);

            Translate(languageCodeRU, word);
            lean.AddEntry("Russian", _newWord);

            Translate(languageCodeTR, word);
            lean.AddEntry("Turkish", _newWord);

        }
        AddComponent();
    }

    private bool CheckWordInScene(string word)
    {
        foreach (var name in _names)
        {
            if (name.name == word)
                return false;
        }

        return true;
    }

    private void AddComponent()
    {
        foreach (var text in _texts)
        {
            if (text.TryGetComponent(out LeanLocalizedTextMeshProUGUI _) == false)
                text.gameObject.AddComponent<LeanLocalizedTextMeshProUGUI>();
        }
    }

    private void Translate(string languageCodeTranslate, string word) => LeanPhrase_Editor.TryAutoTranslate(languageCodeEN, languageCodeTranslate, word, ref _newWord);
}
#endif