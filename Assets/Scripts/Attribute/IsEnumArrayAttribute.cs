using System;
using UnityEngine;

public class IsEnumArrayAttribute : PropertyAttribute {

	private System.Type m_EnumType;

	public Type EnumType {
		get {
			return m_EnumType;
		}
	}


	public IsEnumArrayAttribute(System.Type enumType) {
		m_EnumType = enumType;
	}
}