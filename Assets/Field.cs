using UnityEngine;

public class FootballFieldGenerator : MonoBehaviour
{
    public Material lineMaterial;
    public GameObject hashMarkPrefab; // Create a small white cube prefab for hash marks
    public float fieldLength = 109.73f;
    public float fieldWidth = 48.76f;
    public float yardLineSpacing = 4.57f;

    void Start()
    {
        CreateField();
        CreateYardLines();
        CreateHashMarks();
    }

    void CreateField()
    {
        GameObject field = GameObject.CreatePrimitive(PrimitiveType.Plane);
        field.transform.localScale = new Vector3(fieldWidth / 10f, 1, fieldLength / 10f);
        field.GetComponent<Renderer>().material.color = new Color(0f, 0.4f, 0f); // Dark green
        field.name = "Football Field";
    }

    void CreateYardLines()
    {
        for (float z = 0; z <= fieldLength; z += yardLineSpacing)
        {
            GameObject line = new GameObject("YardLine");
            LineRenderer lr = line.AddComponent<LineRenderer>();
            lr.material = lineMaterial;
            lr.positionCount = 2;
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.SetPosition(0, new Vector3(-fieldWidth / 2, 0.01f, z - fieldLength / 2));
            lr.SetPosition(1, new Vector3(fieldWidth / 2, 0.01f, z - fieldLength / 2));
            lr.startColor = lr.endColor = Color.white;
        }
    }

    void CreateHashMarks()
    {
        float[] hashX = {
            -18.29f, // Left NCAA hash from center
            18.29f   // Right NCAA hash from center
        };

        for (float z = yardLineSpacing; z < fieldLength; z += yardLineSpacing)
        {
            foreach (float x in hashX)
            {
                Vector3 pos = new Vector3(x, 0.1f, z - fieldLength / 2);
                Instantiate(hashMarkPrefab, pos, Quaternion.identity);
            }
        }
    }
}
