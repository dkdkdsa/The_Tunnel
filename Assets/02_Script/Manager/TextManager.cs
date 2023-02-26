using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LanguageState
{

    English,
    Korean,

}

namespace Manager.Main
{

    public class TextManager
    {

        private List<TextListSO.TextList> textList;
        private LanguageState state = LanguageState.English;

        public void SetLanguageState(LanguageState state)
        {

            this.state = state;

        }

        public string GetText(string key)
        {

            var textValue = textList.Find(x => x.key == key);

            if (state == LanguageState.English) return textValue.englishText;
            else if (state == LanguageState.Korean) return textValue.koreanText;
            else return "Null";

        }

        public TextManager()
        {

            var loadList = Resources.Load<TextListSO>("SO/TextList");
            textList = loadList.textList;

        }

    }

}