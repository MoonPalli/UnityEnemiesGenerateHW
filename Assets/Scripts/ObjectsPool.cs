using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _objPool = new List<GameObject>();

    protected void Initialize(GameObject prefab, int count)
    {
        for (int i = 0; i <= count - 1; i++)
        {
            GameObject objToSpawn = Instantiate(prefab, _container.transform);
            objToSpawn.SetActive(false);

            _objPool.Add(objToSpawn);
        }
    }

    protected bool TryGetObject(out GameObject obj)
    {
        obj = _objPool.FirstOrDefault(o => o.activeSelf == false);

        return obj != null;
    }
}