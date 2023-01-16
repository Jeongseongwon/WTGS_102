#define Graph_And_Chart_PRO
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ChartAndGraph;

public class StreamingGraph : MonoBehaviour
{
    public GraphChart Graph;
    public int TotalPoints = 5;
    float lastTime = 0f;
    float lastX = 0f;

    public float min=0;
    public float max=1;

    public GameObject text_box;

    private float Num_value;

    void Start()
    {
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        float x = 3f * TotalPoints;
        Graph.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
        //Graph.DataSource.ClearCategory("Player 2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector

        //for (int i = 0; i < TotalPoints; i++)  //처음에 몇개 생성되는 부분
        //{
        //    Graph.DataSource.AddPointToCategory("Player 1", System.DateTime.Now - System.TimeSpan.FromSeconds(x), Random.value * 20f + 10f); // each time we call AddPointToCategory 
        //    //Graph.DataSource.AddPointToCategory("Player 2", System.DateTime.Now  - System.TimeSpan.FromSeconds(x), Random.value * 10f); // each time we call AddPointToCategory 
        //    x -= Random.value * 3f;
        //    lastX = x;
        //}

        Graph.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
    }

    void Update()
    {
        float time = Time.time;
        if (lastTime + 1f < time)   //생성되는 시간 조절 부분
        {
            Num_value = Random.Range(min, max) * 20f;
            lastTime = time;
            lastX += Random.value * 3f;
//            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
            Graph.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, Num_value, 1f); // each time we call AddPointToCategory 
            //Graph.DataSource.AddPointToCategoryRealtime("Player 2", System.DateTime.Now, Random.value * 10f, 1f); // each time we call AddPointToCategory
            text_box.GetComponent<Text>().text = Num_value.ToString("F1");
        }

    }
}
