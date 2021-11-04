using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
namespace source
{
    public enum MoveType
    {
        Idle = 0,
        Left = 1,
        Right = 2

    }
    public class move : NetworkBehaviour
    {

        static public MoveType moveType;
      
        public Joystick joystick;
        public joybutton joybutton;
        public bool jump;


        void Start()
        {
            joystick = FindObjectOfType<Joystick>();
            joybutton = FindObjectOfType<joybutton>();

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                if (Input.GetKey("d"))
                {
                    transform.Translate(0, 0, 0.2f);
                    moveType = MoveType.Right;
                }

                if (Input.GetKey("a"))
                {
                    transform.Translate(0, 0, -0.2f);
                    moveType = MoveType.Left;
                }
                //&& gameObject.GetComponent<Rigidbody>().velocity.y!=0
                if (Input.GetKey("w"))
                {
                    transform.Translate(0, 0.2f, 0);
                }

                var rd = GetComponent<Rigidbody>();
                rd.velocity = new Vector3(joystick.Vertical * 10f, rd.velocity.y, joystick.Horizontal * 10f);
                if(!jump && joybutton.Pressed)
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


            //if (Input.GetKey("right")) { transform.Rotate(0, 3, 0); }


        }
        
        /*private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "ball")
            {
                //rd = MyNetworkManager.ball.GetComponent<Rigidbody>();
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                Rigidbody player = gameObject.GetComponent<Rigidbody>();
                Vector3 move = new Vector3(Mathf.Abs(player.velocity.x), Mathf.Abs(player.velocity.y), Mathf.Abs(player.velocity.z));
                if (MoveType.HasFlag(MoveType.Left))
                {
                    GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().AddForce(left_Ball_Force * ratio);
                }
                else if (MoveType.HasFlag(MoveType.Right))
                {
                    GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().AddForce(right_Ball_Force * ratio);
                }
                //rd.AddForce(move * 150);
                Debug.Log(move);
            }

        }*/
    }
}