using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleController : MonoBehaviour
{
    public static ObstracleController Instance = null;
    public ObjectPool m_ObstacleObjectPool;
    public float LastObstracleZpos = 25.0f;
    public float ObstracleZoffset = 10.0f;
    public float ObstracleYoffset = 4.0f;
    void Awake()
    {
        Instance = this;
    }
    public void PlaceNextObstracle()
    {
        LastObstracleZpos += ObstracleZoffset;
        GameObject l_NextObstracle =  m_ObstacleObjectPool.GetPooledObject();
        l_NextObstracle.transform.localPosition = new Vector3(l_NextObstracle.transform.localPosition.x,
                                                            Random.Range(-ObstracleYoffset,ObstracleYoffset),
                                                            LastObstracleZpos);
        
        l_NextObstracle.SetActive(true);
    }

}
