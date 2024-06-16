using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private static List<Transform> children = new List<Transform>();
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
        AddAllHearts();
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
            toBeRemoved.gameObject.SetActive(false);
            children.Remove(toBeRemoved);
        }
    }

    public void AddAllHearts()
    {
        children.Clear();
        foreach (Transform child in transform)
        {
            children.Add(child);
            child.gameObject.SetActive(true);
        }
    }

    public void AddHeart()
    {
        float distance = float.PositiveInfinity;
        Transform toBeAdded = null;

        foreach (Transform child in children)
        {
            if (child.position.x < distance)
            {
                toBeAdded = child;
                distance = child.position.x;
            }
        }

        if (toBeAdded != null)
        {
            toBeAdded.gameObject.SetActive(true);
            children.Add(toBeAdded);
        }
    }

    public bool DeathCheck()
    {
        return children.Count == 0;
    }
}
