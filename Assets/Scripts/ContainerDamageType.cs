using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Container Damage Type", menuName = "stata/ContainerDamageType")]
public class ContainerDamageType : ScriptableObject
{
    [SerializeField] private List<DamageType> _damageTypes = new List<DamageType>();

    public List<DamageType> DamageTypes { get => _damageTypes; set => _damageTypes = value; }


#if UNITY_EDITOR
    [ContextMenu("Make New")]
    private void MakeNewDamageType()
    {
        DamageType damageType = ScriptableObject.CreateInstance<DamageType>();
        damageType.name = "New Damage Type";
        damageType.Initialise(this);
        _damageTypes.Add(damageType);

        AssetDatabase.AddObjectToAsset(damageType, this);
        AssetDatabase.SaveAssets();

        EditorUtility.SetDirty(this);
        EditorUtility.SetDirty(damageType);
    }

#endif

#if UNITY_EDITOR
    [ContextMenu("Delete all")]
    private void DeleteAll()
    {
        for (int i = _damageTypes.Count; i-- > 0;)
        {
            DamageType tmp = _damageTypes[i];

            _damageTypes.Remove(tmp);
            Undo.DestroyObjectImmediate(tmp);
        }
        AssetDatabase.SaveAssets();
    }

#endif
}
