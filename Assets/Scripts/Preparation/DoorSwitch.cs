using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Preparation
{
    public class DoorSwitch : MonoBehaviour
    {
        public GameObject _door;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                _door.gameObject.SetActive(false);
            }
        }
    }
}
