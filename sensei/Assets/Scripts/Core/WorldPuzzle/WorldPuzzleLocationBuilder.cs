using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WorldPuzzleLocationBuilder {

    WorldPuzzleLocation worldLocation = null;

    public WorldPuzzleLocationBuilder builder() {
        this.worldLocation = new WorldPuzzleLocation();
        return this;
    }

    public WorldPuzzleLocationBuilder position(Vector3 position) {
        worldLocation.position = position;
        return this;
    }

    public WorldPuzzleLocationBuilder rotation(Quaternion rotation) {
        worldLocation.rotation = rotation;
        return this;
    }

    public WorldPuzzleLocation build() {
        if (this.worldLocation.position == null) {
            Debug.LogError(ErrorMessages.ERROR_1);
        }

        if (this.worldLocation.rotation == null) {
            Debug.LogError(ErrorMessages.ERROR_2);
        }

        return this.worldLocation;
        
    }
}
