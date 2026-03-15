using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public enum Position
{
    left,
    down,
    right,
    up
}

public class KeySpawner : MonoBehaviour
{
    public PlayerInput playerInput;
    [SerializeField] private GameObject key;
    [SerializeField] private Transform leftPosition;
    [SerializeField] private Transform downPosition;
    [SerializeField] private Transform rightPosition;
    [SerializeField] private Transform upPosition;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Level4Script level4Script;

    public void GenerateKey()
    {
        var random = new Random();

        var randomPosition = (Position)Enum.GetValues(typeof(Position))
            .GetValue(random.Next(Enum.GetValues(typeof(Position)).Length));

        var playerEvent = playerInput.actions["Any Key"];
        var keyI = Instantiate(key);
        var script = keyI.GetComponent<ArrowScript>();
        script.position = randomPosition;
        playerEvent.performed += script.OnKeyDown;
        script.onSuccess.AddListener(level4Script.OnSuccess);
        script.onFail.AddListener(level4Script.OnFail);

        switch (randomPosition)
        {
            case Position.left:
                keyI.transform.position = leftPosition.position;
                keyI.transform.rotation = leftPosition.rotation;
                break;
            case Position.right:
                keyI.transform.position = rightPosition.position;
                keyI.transform.rotation = rightPosition.rotation;
                break;
            case Position.down:
                keyI.transform.position = downPosition.position;
                keyI.transform.rotation = downPosition.rotation;
                break;
            case Position.up:
                keyI.transform.position = upPosition.position;
                keyI.transform.rotation = upPosition.rotation;
                break;
        }
    }

    private void Start()
    {
        StartCoroutine(KeyLoop());
    }

    private IEnumerator KeyLoop()
    {
        while (true)
        {
            GenerateKey();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}