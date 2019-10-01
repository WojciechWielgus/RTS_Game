using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : UnitButton
{
    public void SpawnBuilding()
    {
        CameraControl.SpawnBulding(spawnPrefab);
    }


    public override void SpawnUnit()
    {
        //base.SpawnUnit();
    }
}
