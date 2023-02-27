using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.Main
{

    public class MainManager : MonoBehaviour
    {

        private static TextManager m_TextManager;

        public static TextManager textManager { get { Setting(); return m_TextManager; } }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Setting()
        {

            if(m_TextManager == null)
            {

                m_TextManager = new TextManager();

            }

        }

    }


}