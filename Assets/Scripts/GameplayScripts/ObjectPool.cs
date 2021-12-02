using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> m_PooledObjects;
    public GameObject GetPooledObject()
    {
        for(int i=0; i<m_PooledObjects.Count; i++)
        {
            if(!m_PooledObjects[i].activeInHierarchy)
            {
                return m_PooledObjects[i];
            }
        }
        return null;
    }
}
