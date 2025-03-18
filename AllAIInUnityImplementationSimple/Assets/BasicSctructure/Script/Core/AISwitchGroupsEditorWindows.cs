using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

// This script must be placed in an "Editor" folder in your Assets directory.
public class AISwitchGroupsEditor : EditorWindow
{
    private string targetAIName = "AI"; // Default name to search for.
    private GameObject selectedAI;
    private List<GameObject> aiObjects = new List<GameObject>();
    private int selectedAIIndex = -1;

    [MenuItem("Tools/AI/Switch AI Groups")]
    public static void ShowWindow()
    {
        GetWindow<AISwitchGroupsEditor>("AI Switcher");
    }

    private void OnEnable()
    {
        // Find all GameObjects with the "AI" tag when the window is enabled.
        FindAIObjects();
    }

    private void OnGUI()
    {
        GUILayout.Label("AI Group Switcher", EditorStyles.boldLabel);

        // Display the list of AI objects.
        if (aiObjects.Count > 0)
        {
            string[] aiNames = aiObjects.Select(ai => ai.name).ToArray();
            selectedAIIndex = EditorGUILayout.Popup("Select AI:", selectedAIIndex, aiNames);

            if (selectedAIIndex >= 0 && selectedAIIndex < aiObjects.Count)
            {
                selectedAI = aiObjects[selectedAIIndex];
                
            }
            else
            {
                selectedAI = null;
            }
        }
        else
        {
            GUILayout.Label("No AI objects found with the 'AI' tag.");
        }

        if (GUILayout.Button("Activate Selected AI"))
        {
            ActivateSelectedAI();
        }

        if (selectedAI != null)
        {
            EditorGUILayout.ObjectField("Selected AI:", selectedAI, typeof(GameObject), true);
        }
       
    }

    private void FindAIObjects()
    {
        // Find all GameObjects with the "AI" tag.
        aiObjects.Clear();
        aiObjects.AddRange(GameObject.FindGameObjectsWithTag("AI"));

        if (aiObjects.Count > 0)
        {
            // Sort the list by name
            aiObjects = aiObjects.OrderBy(ai => ai.name).ToList();
            selectedAIIndex = 0;
            selectedAI = aiObjects[0];
        }
        else
        {
            selectedAIIndex = -1;
            selectedAI = null;
        }
    }

    private void ActivateSelectedAI()
    {
        if (selectedAI == null)
        {
            Debug.LogWarning("No AI selected.");
            return;
        }

        // Deactivate all AI objects.
        foreach (GameObject aiObject in aiObjects)
        {
            aiObject.SetActive(false);
        }

        // Activate the selected AI object.
        selectedAI.SetActive(true);
    }
}
