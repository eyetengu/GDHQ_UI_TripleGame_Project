using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class NinjaItemManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _outfits;
    [SerializeField] private Sprite[] _weapons;
    [SerializeField] private Sprite[] _tools;
    

    public Sprite GetOutfit()
    {
        return _outfits[Random.Range(0, _outfits.Length)];
    }

    public Sprite GetTool()
    {
        return _tools[Random.Range(0, _tools.Length)];
    }

    public Sprite GetWeapon()
    {
        return _weapons[Random.Range(0, _weapons.Length)];
    }
}
