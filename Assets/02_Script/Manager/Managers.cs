using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Main;

namespace Manager
{

    public static class Managers
    {

        public static string GetText(string key)
        {

            return MainManager.textManager.GetText(key);

        }

    }

}
