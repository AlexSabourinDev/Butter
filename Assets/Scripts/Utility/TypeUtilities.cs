using UnityEngine;

public static class TypeUtilities {

	public static Type Cast<Type>(object target) {

		Debug.Assert(target is Type);
		return (Type)target;
	}
}