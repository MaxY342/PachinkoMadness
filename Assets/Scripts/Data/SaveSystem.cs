using UnityEngine;

namespace PachinkoMadness.Data
{
    public static class SaveSystem
    {
        private static string dataKey = "GameData";

        public static void SaveGameData(GameData data)
        {
            string json = JsonUtility.ToJason(data);
            PlayerPrefs.SetString(dataKey, json);
            PlayerPrefs.Save();
        }
        public static GameData LoadGameData()
        {
            if (PlayerPrefs.HasKey(dataKey))
            {
                string json = PlayerPrefs.GetString(dataKey);
                return JsonUtility.FromJason<GameData>(json);
            }
            else
            {
                return new GameData();
            }
        }
        public static void ResetData()
        {
            PlayerPrefs.DeleteKey(dataKey);
            PlayerPrefs.Save();
        }
    }
}