using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FD.AI.Tree
{

    public enum FAED_TreeNodeType
    {

        Root,
        Sequence,
        Tree,
        If,

    }

    [System.Serializable]
    public class FAED_TreeNodeData
    {

        public string GUID;
        public string text;
        public Vector2 pos;
        public FAED_TreeNodeType type;
        public List<string> ports;
        public List<string> inputPorts;

    }

    [System.Serializable]
    public class FAED_TreeNodeLinkData
    {

        public string baseGUID;
        public string portName;
        public string targetGUID;

    }

}
