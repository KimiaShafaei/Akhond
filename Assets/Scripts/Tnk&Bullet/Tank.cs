using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{
    public float fireRate = 3.0f; 
    
        private GameObject projectilePrefab; 

    public Vector3 customSpawnPosition = new Vector3(0f, 1f, 5f); 

    
    void Awake()
    {
        projectilePrefab = Resources.Load<GameObject>("Bullet"); 
        
        if (projectilePrefab == null)
        {
            Debug.LogError("FATAL ERROR: Could not load Prefab from Resources. Check the file name and 'Resources' folder structure!");
        }
    }

    void Start()
    {
        StartCoroutine(AutoFireRoutine());
    }

    IEnumerator AutoFireRoutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(fireRate);
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null)
        {
            Instantiate(projectilePrefab, customSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab is still NULL, even after trying to load from Resources.");
        }
    }
}
