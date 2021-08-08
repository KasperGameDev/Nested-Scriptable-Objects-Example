using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DamageType : ScriptableObject
{
    [SerializeField] private ContainerDamageType _myContainer;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public ContainerDamageType MyContainer { get => _myContainer; }
    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }

#if UNITY_EDITOR
    public void Initialise(ContainerDamageType myContainer)
    {
        _myContainer = myContainer;
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Rename to name")]
    private void Rename()
    {
        this.name = _name;
        AssetDatabase.SaveAssets();
        EditorUtility.SetDirty(this);
    }
#endif

#if UNITY_EDITOR
    [ContextMenu("Delete this")]
    private void DeleteThis()
    {
        _myContainer.DamageTypes.Remove(this);
        Undo.DestroyObjectImmediate(this);
        AssetDatabase.SaveAssets();
    }
#endif
}
