using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Szczesniak {
    public class SpringBlock : MonoBehaviour {

        AABB aabb;

        void Start() {
            aabb = GetComponent<AABB>();
            Zone.main.powerups.Add(aabb);
        }


        void Update() {

        }

        private void OnDestroy() {
            if (Zone.main == null) return; // do nothing.
            Zone.main.powerups.Remove(aabb);
        }

        public void PlayerHit(PlayerMovement pm) {
            pm.LaunchPlayer(new Vector3(50, 25, 0));
        }
    }
}