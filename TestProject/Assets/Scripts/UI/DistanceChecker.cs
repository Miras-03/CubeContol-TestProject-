using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private Transform redCube;
    [SerializeField] private Transform greenCube;

    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private GameObject spheres;

    private float distance;

    private void Start() => StartCoroutine(UpdateIndicator());

    private IEnumerator UpdateIndicator()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            CalculateDistance();
            IndicateDistance();
            ShowCubes();

            CheckOrLoadScene();
        }
    }

    private void IndicateDistance() => distanceText.text = $"Distance: {(int)distance} meters";

    private float CalculateDistance() => distance = Vector3.Distance(redCube.position, greenCube.position);

    private void ShowCubes() => spheres.SetActive(distance < 2f);

    private void CheckOrLoadScene()
    {
        if (distance < 1f)
            SceneManager.LoadScene(1);
    }
}