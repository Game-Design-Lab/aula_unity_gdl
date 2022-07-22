using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Preparation
{
    public class BlockSwitch : MonoBehaviour
    {
        public GameObject _block;

        private void Start()
        {
            _block.gameObject.SetActive(false);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _block.gameObject.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _block.gameObject.SetActive(false);
        }
    }
}
