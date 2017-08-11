using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(AsInterfaceAttribute))]
public class AsInterfacePropertyDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

		AsInterfaceAttribute attrib = attribute as AsInterfaceAttribute;


		EditorGUI.BeginProperty(position, label, property);
		property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, attrib.InterfaceType, true);
		EditorGUI.EndProperty();

	}
}
