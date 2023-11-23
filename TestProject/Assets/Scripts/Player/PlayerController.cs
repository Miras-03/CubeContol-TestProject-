using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform redCube;
    [SerializeField] private Transform greenCube;

    private ICommand redCommand;
    private ICommand greenCommand;

    private const int speed = 5;

    private void Start()
    {
        redCommand = new MoveRedCommand();
        greenCommand = new MoveGreenCommand();
    }

    private void FixedUpdate()
    {
        MovePlayer(redCube, "RedHorizontal", "RedVertical", redCommand);
        MovePlayer(greenCube, "GreenHorizontal", "GreenVertical", greenCommand);
    }

    private void MovePlayer(Transform cubeTransform, string horizontalAxis, string verticalAxis, ICommand command)
    {
        float horizontalInput = Input.GetAxis(horizontalAxis) * speed * Time.fixedDeltaTime;
        float verticalInput = Input.GetAxis(verticalAxis) * speed * Time.fixedDeltaTime;

        command.Execute(cubeTransform, horizontalInput, verticalInput);
    }
}