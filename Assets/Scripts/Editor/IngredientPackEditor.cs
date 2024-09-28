using Assets.Scripts.ScriptableObjects.Ingredients;
using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    [CustomEditor(typeof(IngredientPack))]
    public class IngredientPackEditor : UnityEditor.Editor
    {
        private const float spaceBetweenLists = 20;
        private const float spaceBetweenRows = 2;
        private const float dropDownWidth = 160;
        private const float horizontalSpace = 5;
        private const float labelWidth = 50;
        private const float rightShift = 40;

        private ReorderableList list;
        private SerializedProperty ingredientTypesProp;
        private string[] ingredientNames;

        public void OnEnable()
        {
            ingredientTypesProp = serializedObject.FindProperty("ingredientTypes");
            list = new ReorderableList(serializedObject, serializedObject.FindProperty("startPack"), true, true, true, true);

            list.drawHeaderCallback = (Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Start Pack");
            };

            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                if (ingredientNames.Length == 0) return;

                var element = list.serializedProperty.GetArrayElementAtIndex(index);
                var propertyName = element.FindPropertyRelative("name");

                int indexName = Array.IndexOf(ingredientNames, propertyName.stringValue);
                if (indexName < 0) indexName = 0;

                rect.y += spaceBetweenRows;

                indexName = EditorGUI.Popup(new Rect(rect.x, rect.y, dropDownWidth, EditorGUIUtility.singleLineHeight), indexName, ingredientNames);
                propertyName.stringValue = ingredientNames[indexName];

                float labelX = rect.x + dropDownWidth + horizontalSpace;
                EditorGUI.LabelField(new Rect(labelX, rect.y, labelWidth, EditorGUIUtility.singleLineHeight), "Count");

                float countFieldX = labelX + labelWidth + horizontalSpace;

                EditorGUI.PropertyField(new Rect(countFieldX, rect.y, rect.width - countFieldX + rightShift, EditorGUIUtility.singleLineHeight), 
                    element.FindPropertyRelative("count"), GUIContent.none);
            };
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(ingredientTypesProp, true);
            var ingredientPack = serializedObject.targetObject as IngredientPack;
            ingredientNames = ingredientPack.GetAllIngredients();
            EditorGUILayout.Space(spaceBetweenLists);
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();

        }

    }

}

