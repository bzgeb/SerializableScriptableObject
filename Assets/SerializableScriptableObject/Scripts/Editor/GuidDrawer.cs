using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Guid))]
public class GuidDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var value0 = property.FindPropertyRelative(Guid.VALUE0_FIELDNAME);
        var value1 = property.FindPropertyRelative(Guid.VALUE1_FIELDNAME);
        var value2 = property.FindPropertyRelative(Guid.VALUE2_FIELDNAME);
        var value3 = property.FindPropertyRelative(Guid.VALUE3_FIELDNAME);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        EditorGUI.SelectableLabel(position,
            $"{(uint) value0.intValue:X8} {(uint) value1.intValue:X8} {(uint) value2.intValue:X8} {(uint) value3.intValue:X8}");
        EditorGUI.EndProperty();
    }
}