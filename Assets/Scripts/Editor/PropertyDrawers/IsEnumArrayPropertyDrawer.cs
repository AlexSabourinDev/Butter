using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(IsEnumArrayAttribute))]
public class IsEnumArrayPropertyDrawer : PropertyDrawer {

	const float STEP_SIZE = 15.0f;
	const int INDENT_AMOUNT = 1;

	private bool m_ShouldFoldout = false;

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

		const string ARRAY_NAME = "m_Array";

		if (property == null) {
			return;
		}

		// Assure that the foldout rect doesnt overlap the item rects
		Rect foldoutRect = position;
		foldoutRect.height = STEP_SIZE;

		m_ShouldFoldout = EditorGUI.Foldout(foldoutRect, m_ShouldFoldout, label);

		if(m_ShouldFoldout) {

			EditorGUI.indentLevel += INDENT_AMOUNT;

			position.y += STEP_SIZE;

			IsEnumArrayAttribute enumArrayAttrib = attribute as IsEnumArrayAttribute;
			System.Type enumType = enumArrayAttrib.EnumType;

			SerializedProperty enumArray = property.FindPropertyRelative(ARRAY_NAME);
			Debug.Assert(enumArray.isArray);

			string[] enumNames = System.Enum.GetNames(enumType);
			for (int i = 0; i < enumArray.arraySize; i++) {

				EditorGUI.BeginProperty(position, label, property);

				EditorGUI.PropertyField(position, enumArray.GetArrayElementAtIndex(i), new GUIContent(enumNames[i]), true);
				position.y += STEP_SIZE;

				EditorGUI.EndProperty();
			}

			EditorGUI.indentLevel -= INDENT_AMOUNT;
		}

	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {

		IsEnumArrayAttribute enumArrayAttrib = attribute as IsEnumArrayAttribute;
		System.Type enumType = enumArrayAttrib.EnumType;

		float height = STEP_SIZE;

		if(m_ShouldFoldout) {

			height += System.Enum.GetNames(enumType).Length * STEP_SIZE;

			// Remove a step size because we only want to add length - 1
			height -= STEP_SIZE;
		}

		return height;
	}
}
