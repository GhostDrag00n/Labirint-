using UnityEngine;
using UnityEngine.UI;

public class Chechers : MonoBehaviour {

    public GameObject[] points;
    public Text finish;
    [HideInInspector]
    public int index = 0;
    private void Start()
    {
        index = 0;
        print(points.Length);
        finish.gameObject.SetActive(false);
            
    }

    private void Update()
    {
        
    }

    public void NextPoint(GameObject hittedPoint)
    {
        print(points[index].name);
        print(index);
        if (index + 1 <points.Length && hittedPoint.name.Equals(points[index].name)) {
            index++;
            print(points[index].name);

        }
        else
            if (index + 1 == points.Length && hittedPoint.name.Equals(points[index].name))
        {
            finish.gameObject.SetActive(true);
        }
    }
}
