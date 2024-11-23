using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance { get; private set; }
    
    [SerializeField] private GameObject arrowPrefab;
    
    private Queue<GameObject> arrowPool = new Queue<GameObject>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public GameObject GetArrow()
    {
        if (arrowPool.Count > 0)
        {
            GameObject arrow = arrowPool.Dequeue();
            arrow.SetActive(true);
            return arrow;
        }
        else
        {
            GameObject newArrow = Instantiate(arrowPrefab,transform);
            return newArrow;
        }
    }
    
    public void ReturnArrow(GameObject arrow)
    {
        arrow.SetActive(false);
        arrowPool.Enqueue(arrow);
    }
    
    public void ShootArrow(Transform shootingPosition, Collider2D target, int damage)
    {
        GameObject arrow = GetArrow();
        arrow.transform.position = shootingPosition.position;
        arrow.GetComponent<Arrow>().ShootArrow(shootingPosition, target, damage);
    }
}
