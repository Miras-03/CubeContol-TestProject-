using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private Transform sphereParent;

    private const int numberOfSpheres = 20;
    private const float radius = 7f;
    private const float angleStep = 360f / numberOfSpheres;

    private void Start() => CreateSpheres();

    private void CreateSpheres()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            float angle = i * angleStep;
            Vector3 position = GetPositionOnCircle(angle);

            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity, sphereParent);
            sphere.GetComponent<Renderer>().material.mainTexture = LoadRandomTexture();
        }
    }

    private Vector3 GetPositionOnCircle(float angle)
    {
        float xPos = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
        float zPos = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

        return new Vector3(xPos, 1f, zPos);
    }

    private Texture LoadRandomTexture()
    {
        Texture[] textures = Resources.LoadAll<Texture>("Textures");
        return textures[Random.Range(0, textures.Length)];
    }
}
