using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;

public class GraphSample : MonoBehaviour
{
    // Start is called before the first frame update

    public GraphChart chart;
    void Start()
    {
        chart.DataSource.AddPointToCategory("Player 1", 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
