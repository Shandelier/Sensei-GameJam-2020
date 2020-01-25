using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WorldPuzzle : IInitializable
{
    [Inject] WorldPuzzleLocationBuilder locationBuilder = null;
    [Inject] Rigidbody playerRigidbody = null;

    public List<WorldPuzzleLocation> puzzleLocations;
    Animator animator = Camera.main.GetComponent<Animator>();

    public void Initialize() {
        this.setWorldPuzzleLocations();
    }

    public void checkForMatchingWithPuzzles() {
        for (int index = 0; index < this.puzzleLocations.Count; index++) {
            bool isMatching = this.isOnPosition(puzzleLocations[index]);

            if (isMatching) {
                puzzleLocations[index].activated = true;
            }
        }
    }

    private bool isOnPosition(WorldPuzzleLocation location) {
        bool isOnPosition = this.isWithinSmallDistance(location.position, this.playerRigidbody.transform.position);
        return isOnPosition;
    }

    private bool isWithinSmallDistance(Vector3 locationPosition, Vector3 playerPosition) {
        bool XWithinDistance = Mathf.Abs(playerPosition.x - locationPosition.x) < 1f;
        bool YWithinDistance = Mathf.Abs(playerPosition.y - locationPosition.y) < 1f;
        bool ZWithinDistance = Mathf.Abs(playerPosition.z - locationPosition.z) < 1f;
        return XWithinDistance && YWithinDistance && ZWithinDistance;
    }

    private void setWorldPuzzleLocations() {
        List<WorldPuzzleLocation> puzzles = new List<WorldPuzzleLocation>();

        puzzles.Add(locationBuilder.builder()
                    .position(WorldPuzzleLocationConfig.PUZZLE_1_LOCATION)
                    .rotation(WorldPuzzleLocationConfig.PUZZLE_1_ROTATION)
                    .build()); 

        this.puzzleLocations = puzzles;
    }
}
