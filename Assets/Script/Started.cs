using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

namespace StarterAssets
{
    public class Started : MonoBehaviour
    {
        private Animator camAnim;
        public float StartedTimeout = 3f;
        public float minFallSpeed = 2f;
        public float maxFallSpeed = 5f;
        private float _fallspeedDelta; 
        private float _startedTimeoutDelta = 0f;
        private bool _started = true;
        public GameObject centerGate;
        public GameObject[] Players;
        private ThirdPersonController _player;
        
        private float _index = 0f;
        

        // Start is called before the first frame update
        void Start()
        {
            Players = GameObject.FindGameObjectsWithTag("Player");
            Players[0].SetActive(false);
            _player = Players[0].GetComponent<ThirdPersonController>();
            camAnim = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            StartCutscene();
            Spawn();
            StartFalling();
        }

        public void StartFalling()
        {
            if(!_started)
            {
                Players[0].SetActive(true);
                if(_index <= 1f)
                {
                    _player._startedFall = true;
                    _index += Time.deltaTime;
                }
                if(_player.Grounded && _index >= 1f)
                {
                    _player._startedFall = false;
                    camAnim.SetBool("Started2", true);
                }
            }
            if(_player._startedFall)
            {
                _player._verticalVelocity -= _fallspeedDelta * Time.deltaTime;
                if(Input.GetButtonUp("Jump"))
                {
                    _fallspeedDelta = maxFallSpeed;
                }
                else
                {
                    _fallspeedDelta = minFallSpeed;
                }
            }
            
        }

        // Update is called once per frame
        public void Spawn()
        {   
            if(_startedTimeoutDelta > StartedTimeout)
            {
                if(_startedTimeoutDelta > StartedTimeout + 1f)
                {
                    StopCutscene();
                }
                if(_started)
                {
                    Players[0].transform.position = new Vector3 (centerGate.transform.position.x, centerGate.transform.position.y + 0.5f, centerGate.transform.position.z);
                    _started = false;
                }

            }
        }

        public void StartCutscene()
        {
            if(_startedTimeoutDelta <= StartedTimeout + 1f)
            {
                _startedTimeoutDelta += Time.deltaTime;
            }
        }

        public void StopCutscene()
        {
            camAnim.SetBool("Started", true);
        }
    }   
}
