using System;
using System.Collections.Generic;

public static class CollectionUtilities {

	public static List<int> FindAllIndex<Type>(List<Type> list, Predicate<Type> predicate) {

		List<int> indexList = new List<int>();
		for(int i = 0; i < list.Count; i++) {
			if(predicate(list[i])) {
				indexList.Add(i);
			}
		}

		return indexList;
	}

	public static void SetAll<Type>(List<Type> list, Type value) {

		for (int i = 0; i < list.Count; i++) {
			list[i] = value;
		}
	}
}

