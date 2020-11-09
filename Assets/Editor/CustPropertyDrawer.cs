using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer(typeof(ArrayLayout))]
public class CustPropertyDrawer : PropertyDrawer {

	public override void OnGUI(Rect position,SerializedProperty property,GUIContent label){
		EditorGUI.PrefixLabel(position,label);
		Rect newposition = position;
		newposition.y += 20f;
		SerializedProperty data = property.FindPropertyRelative("rows");
        if (data.arraySize != 12)
            data.arraySize = 12;
		//data.rows[0][]
		for(int j=0;j<12;j++){
			SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("row");
			newposition.height = 20f;
			if(row.arraySize != 8)
				row.arraySize = 8;
			newposition.width = position.width/8;
			for(int i=0;i<8;i++){
				EditorGUI.PropertyField(newposition,row.GetArrayElementAtIndex(i),GUIContent.none);
				newposition.x += newposition.width;
			}

			newposition.x = position.x;
			newposition.y += 20f;
		}
	}

	public override float GetPropertyHeight(SerializedProperty property,GUIContent label){
		return 20f * 15;
	}
}
