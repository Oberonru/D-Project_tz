using System;
using UnityEngine;

namespace Infrastructure.SO
{
    public class ScriptableObjectIdentity : ScriptableObject
    {
        public string ID => _guid;
        private string _guid = Guid.NewGuid().ToString();
    }
}