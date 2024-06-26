using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PachinkoMadness.MainScene
{
    public class GoalManager : MonoBehaviour
    {
        public int numOfObjToMod = 2;
        public static GoalManager instance;
        public void Awake()
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
            SelectAndModifyGoals();
        }
        public void SelectAndModifyGoals()
        {
            // find all objects with the PossibleGoal component
            PossibleGoal[] allObjects = FindObjectsOfType<PossibleGoal>();

            // convert array to list
            List<PossibleGoal> objectList = new List<PossibleGoal>(allObjects);

            // randomly select subset of objects
            List<PossibleGoal> selectedGoals = new List<PossibleGoal>();

            for (int i = 0; i < numOfObjToMod; i++)
            {
                if (objectList.Count == 0) break;

                int randomIndex = Random.Range(0, objectList.Count);
                selectedGoals.Add(objectList[randomIndex]);
                objectList.RemoveAt(randomIndex);
            }

            // modify the selected goals
            foreach (PossibleGoal goal in selectedGoals)
            {
                goal.MakeGoal();
            }

            foreach (PossibleGoal goal in objectList)
            {
                goal.MakeDanger();
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
