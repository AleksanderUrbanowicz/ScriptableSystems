using UnityEngine;
using System.Collections;
using ScriptableSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int cash;
    public BuildSystemMonoBehaviour buildSystemMonoBehaviour;
    public DataSystemMonoBehaviour dataSystemMonoBehaviour;
    public RaycastExecutor raycastExecutor;
    public SpawnerHelper spawnerHelper;
    public GameSettings settings;
    public Text infoText;
    [SerializeField]
    public static GameSettings s;
    public static GameManager instance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else
        {
            
        }
        if (GameManager.s == null)
        {
            GameManager.s = settings;
        }
    }

    private void Start()
    {
        InitializeBuildSystem();
        InitializeDataSystem();
    }

    void Update()
    {
        if (infoText != null)
        {

            infoText.text =cash.ToString();
        }
    }

    private void InitializeBuildSystem()
    {
        if (s.scriptableBuildSystem!=null && s.scriptableBuildSystem.initializeOnStart)
        {
            GameObject systemGO = new GameObject();
            systemGO.transform.parent = this.transform;
            s.scriptableBuildSystem.Initialize(systemGO);

        }

    }
    private void InitializeDataSystem()
    {
        if (s.scriptableDataSystem != null && s.scriptableDataSystem.initializeOnStart)
        {
            GameObject systemGO = new GameObject();
            systemGO.transform.parent = this.transform;
            s.scriptableDataSystem.Initialize(systemGO);

        }

    }
}