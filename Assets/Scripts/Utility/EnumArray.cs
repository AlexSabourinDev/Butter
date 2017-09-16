
using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[Serializable]
public class EnumArray<KeyType, Type> where KeyType : struct, IConvertible {

	[SerializeField]
	private Type[] m_Array = new Type[System.Enum.GetValues(typeof(KeyType)).Cast<int>().Max()];

	public int Length {
		get {
			return m_Array.Length;
		}
	}

	public Type[] ToArray() {
		return m_Array;
	}

	public System.Type EnumType {
		get {
			return typeof(KeyType);
		}
	}

	public Type this[int index] {
		get {
			return m_Array[index];
		}
		set {
			m_Array[index] = value;
		}
	}

	public Type this[KeyType index] {
		get {
			return m_Array[index.ToInt32(null)];
		}
		set {
			m_Array[index.ToInt32(null)] = value;
		}
	}

	public EnumArray() { }

	public EnumArray(Type defaultValue) {
		for(int i = 0; i < Length; i++) {
			m_Array[i] = defaultValue;
		}
	}

	public System.Object GetElement(int index) {

		return this[index];
	}
}
