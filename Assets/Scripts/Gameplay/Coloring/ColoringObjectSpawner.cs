using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dash.Draw.Gameplay
{
    public class ColoringObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToSpawn;

        private void Start()
        {
            if (null == _objectToSpawn)
            {
                Debug.LogError("[ColoringObjectSpawner::Start] Didn't find an object to spawn. " +
                               "Please make sure the variable has been properly assigned in the inspector");
                return;
            }
            GameObject spawnedColoringObject = Instantiate(_objectToSpawn);
            if (!spawnedColoringObject.TryGetComponent(out ColoringObject _))
            {
                spawnedColoringObject.AddComponent<ColoringObject>();
            }

            if (!spawnedColoringObject.TryGetComponent(out Inspectable _))
            {
                spawnedColoringObject.AddComponent<Inspectable>();
            }
        }
    }
}