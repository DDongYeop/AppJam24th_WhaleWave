using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [HideInInspector] public bool IsFast = false;
    [HideInInspector] public bool IsStop = false;
    
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple SkillManager is running");
        Instance = this;
    }

    public Fish[] ReturnFish() { return FindObjectsOfType<Fish>(); }
}
