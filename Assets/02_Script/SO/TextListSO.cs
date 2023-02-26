using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TextList")]
public class TextListSO : ScriptableObject
{

    [System.Serializable]
    public class TextList
    {

        public string key;
        [TextArea] public string koreanText;
        [TextArea] public string englishText;

    }

    public List<TextList> textList = new List<TextList>();

}
