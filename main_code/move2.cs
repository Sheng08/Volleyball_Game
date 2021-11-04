using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
namespace source
{
    
    public class move2 : NetworkBehaviour
    {
        
        static public MoveType moveType2;

        public Joystick joystick;
        public joybutton joybutton;
        public bool jump;


        void Start()
        {
            joystick = FindObjectOfType<Joystick>();
            joybutton = FindObjectOfType<joybutton>();

        }


        void Update()
        {
            if (isLocalPlayer)
            {
                if (Input.GetKey("d"))
                {
                    transform.Translate(0, 0, 0.2f);
                    moveType2 = MoveType.Right;
                    Debug.Log(moveType2);
                }

                if (Input.GetKey("a"))
                {
                    transform.Translate(0, 0, -0.2f);
                    moveType2 = MoveType.Left;
                    Debug.Log(moveType2);
                }

                if (Input.GetKey("w"))
                {
                    transform.Translate(0, 0.2f, 0);
                }

                var rd = GetComponent<Rigidbody>();
                rd.velocity = new Vector3(joystick.Vertical * 10f, rd.velocity.y, joystick.Horizontal * 10f);
                if (!jump && joybutton.Pressed)
                {
                    jump = true;
                    rd.velocity += Vector3.up * 0.5f;

                }
                if (jump && joybutton.Pressed)
                {
                    jump = false;


                }

                Rigidbody player = gameObject.GetComponent<Rigidbody>();
                Vector3 move = new Vector3(Mathf.Abs(player.velocity.x), Mathf.Abs(player.velocity.y), Mathf.Abs(player.velocity.z));
            }

        }

  
    }
}