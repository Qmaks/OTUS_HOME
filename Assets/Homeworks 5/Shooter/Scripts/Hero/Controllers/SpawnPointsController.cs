using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnPointsController : MonoBehaviour
{
   [ShowInInspector,ReadOnly]
   private Transform[] spawns;

   private void Awake()
   {
      spawns = transform.Cast<Transform>().ToArray();
   }

   public Transform GetRandomSpawnPoint()
   {
      return spawns[Random.Range(0, spawns.Length)];
   }
}
