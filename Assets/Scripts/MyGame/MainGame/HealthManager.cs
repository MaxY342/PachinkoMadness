using System.Collections.Generic;
using UnityEngine;
using MyGame;

namespace MyGame.MainGame
{
    public class HealthManager : MonoBehaviour
    {
        private static List<Transform> children = new List<Transform>();

        private Transform healthManagerTransform;
        private int initialHeartCount;
        public GameObject heartPreFab;
        public static HealthManager instance;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            
            GameObject healthManagerObject = GameObject.Find("HealthManager");

            if (healthManagerObject != null)
            {
                healthManagerTransform = healthManagerObject.transform;
            }
            else
            {
                Debug.LogError("Unable to find HeathManager gameObject.");
            }

            LoadGameData();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void RemoveHeart()
        {
            float distance = float.NegativeInfinity;
            Transform toBeRemoved = null;

            foreach (Transform child in children)
            {
                if (child.position.x > distance)
                {
                    toBeRemoved = child;
                    distance = child.position.x;
                }
            }

            if (toBeRemoved != null)
            {
                Destroy(toBeRemoved.gameObject);
                children.Remove(toBeRemoved);
            }
        }

        public void InitializeHearts()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            children.Clear();

            for (int i = 0; i < initialHeartCount; i++)
            {
                Vector2 position = new Vector2(transform.position.x + i * 10, transform.position.y);
                GameObject heart = Instantiate(heartPreFab, position, Quaternion.identity);
                heart.transform.SetParent(healthManagerTransform, true);
                children.Add(heart.transform);
            }
        }

        public void RecoverHeart()
        {
            if (children.Count < initialHeartCount)
            {
                Vector2 position = new Vector2(transform.position.x + children.Count * 10, transform.position.y);
                GameObject heart = Instantiate(heartPreFab, position, Quaternion.identity);
                heart.transform.SetParent(healthManagerTransform, true);
                children.Add(heart.transform);
            }
        }

        public void AddHeart()
        {
            GameData gameData = SaveSystem.LoadGameData();
            gameData.heartCount++
            SaveSystem.SaveGameData(gameData);
        }

        public bool DeathCheck()
        {
            return children.Count == 0;
        }

        private void LoadGameData()
        {
            GameData gameData = SaveSystem.LoadGameData();
            initialHeartCount = gameData.heartCount;
            InitializeHearts();
        }
    }
}