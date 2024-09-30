using Assets.Scripts.ScriptableObjects.Ingredients;
using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(IngredientsList))]
    public class IngredientsListEditor : PropertyDrawer
    {
        private const float spaceBetweenRows = 2;
        private const float dropDownWidth = 160;
        private const float horizontalSpace = 5;
        private const float labelWidth = 50;

        private ReorderableList list;
        private SerializedProperty typesProp;
        private string[] ingredientNames;
        bool wasInsert = false;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (list == null)
            {
                Init(property);
            }

            if (list != null)
            {
                list.DoLayoutList();
            }
        }

        public void Init(SerializedProperty property)
        {
            typesProp = property.FindPropertyRelative("types");
            UpdateIngredientNames();
            list = new ReorderableList(property.serializedObject, property.FindPropertyRelative("items"), true, true, true, true);
            list.drawHeaderCallback = (Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Items");
            };

            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                if (ingredientNames == null || ingredientNames.Length == 0)
                {
                    UpdateIngredientNames();
                    if (ingredientNames == null || ingredientNames.Length == 0) return;
                }

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

                EditorGUI.PropertyField(new Rect(countFieldX, rect.y, rect.width - countFieldX, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("count"), GUIContent.none);
            };

        }

        private void UpdateIngredientNames()
        {
            if (typesProp != null && typesProp.boxedValue != null)
            {
                var types = typesProp.boxedValue as IngredientTypeSet;
                if (types != null)
                {
                    ingredientNames = types.GetAllIngredients();
                }
            }
        }
    }
}

