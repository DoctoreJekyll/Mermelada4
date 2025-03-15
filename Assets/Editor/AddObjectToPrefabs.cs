using System.IO;
using UnityEditor;
using UnityEngine;

public class AddObjectToPrefabs : EditorWindow
{
        private GameObject objectToAdd;
        private string folderPath = "Assets/Prefabs/EveningPrefabs/In";
    
        [MenuItem("Tools/Add Object to Prefabs")]
        public static void ShowWindow()
        {
            GetWindow<AddObjectToPrefabs>("Add Object to Prefabs");
        }
    
        private void OnGUI()
        {
            GUILayout.Label("Añadir Objeto a Prefabs", EditorStyles.boldLabel);
    
            objectToAdd = (GameObject)EditorGUILayout.ObjectField("Objeto a añadir:", objectToAdd, typeof(GameObject), false);
            folderPath = EditorGUILayout.TextField("Carpeta de prefabs:", folderPath);
    
            if (GUILayout.Button("Añadir a todos los Prefabs"))
            {
                AddObjectToAllPrefabs();
            }
        }
    
        private void AddObjectToAllPrefabs()
        {
            if (objectToAdd == null)
            {
                Debug.LogError("⚠️ No has seleccionado un objeto para añadir.");
                return;
            }
    
            string[] prefabPaths = Directory.GetFiles(folderPath, "*.prefab", SearchOption.AllDirectories);
    
            foreach (string path in prefabPaths)
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
    
                if (prefab != null)
                {
                    GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
    
                    if (instance != null)
                    {
                        GameObject newObject = Instantiate(objectToAdd, instance.transform);
                        newObject.name = objectToAdd.name;
    
                        PrefabUtility.ApplyPrefabInstance(instance, InteractionMode.UserAction);
    
                        Debug.Log($"✅ Se añadió {newObject.name} a {prefab.name}");
                    }
                }
            }
    
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
}
