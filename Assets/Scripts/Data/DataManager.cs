using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] UserData userData;

    void Start()
    {
        userData.Load();
    }

    void OnApplicationQuit()
    {
        userData.Save();
    }
}