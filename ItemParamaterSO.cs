using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class ItemParamaterSO : ScriptableObject
    {
        [field: SerializeField] public string ParameterName { get; private set; }
    }
}