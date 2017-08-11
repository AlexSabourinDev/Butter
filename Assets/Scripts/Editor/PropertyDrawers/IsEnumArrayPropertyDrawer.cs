using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(IsEnumArrayAttribute))]
public class IsEnumArrayPropertyDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

		Debug.Assert(property.objectReferenceValue is IEnumTypeProvider);

		EditorGUI.BeginProperty(position, label, property);

		System.Type enumType = ((IEnumTypeProvider)property.objectReferenceValue).EnumType;

		string[] enumNames = System.Enum.GetNames(enumType);
		for(int i = 0; i < property.arraySize; i++) {
			EditorGUILayout.PropertyField(property., new GUIContent(enumNames[i]));
		}

		EditorGUI.EndProperty();

	}
}
