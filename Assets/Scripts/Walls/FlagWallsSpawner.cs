using System.Collections.Generic;
using Model.Definitions;
using UnityEngine;
using Utils;

namespace Walls
{
    public class FlagWallsSpawner : MonoBehaviour
    {
        public static List<GameObject> BrickWallsList = new List<GameObject>();
        public static List<GameObject> IronWallsList = new List<GameObject>();

        private void Start()
        {
            BrickWallsList.Clear();
            IronWallsList.Clear();

            var flagWalls = DefsFacade.I.FlagWalls;

            foreach (var brickWall in flagWalls.BrickWalls)
            {
                var wall = SpawnUtils.Spawn(brickWall, brickWall.transform.position, Quaternion.identity);
                BrickWallsList.Add(wall);
            }

            foreach (var ironWall in flagWalls.IronWalls)
            {
                var wall = SpawnUtils.Spawn(ironWall, ironWall.transform.position, Quaternion.identity);
                IronWallsList.Add(wall);
            }
        }

        public static void SetActiveObject(bool value)
        {
            foreach (var wall in BrickWallsList)
            {
                if (wall.TryGetComponent<MeshRenderer>(out MeshRenderer renderer))
                {
                    renderer.enabled = value;
                }

                if (wall.TryGetComponent<BoxCollider>(out BoxCollider coll))
                {
                    coll.enabled = value;
                }
            }
        }
    }
}