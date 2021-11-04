using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
namespace source
{
    public class move_ball : NetworkBehaviour
    {
        public Rigidbody rd;
        public Vector3 left_Ball_Force;
        public Vector3 right_Ball_Force;
        public float ratio;
        public AudioClip ballcollision;
      
        [SyncVar] int scoreLeft = 0;
        [SyncVar] int scoreRight = 0;

        [ClientRpc]
        void rightRpcScore(int score)
        {
            //right.text = score.ToString();
            GameObject.Find("PLAYER2").GetComponent<Text>().text = score.ToString();

        }

        [ClientRpc]
        void leftRpcScore(int score)
        {
            //left.text = score.ToString();
            GameObject.Find("PLAYER").GetComponent<Text>().text = score.ToString();
        }

        [ServerCallback]
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                if (move.moveType.HasFlag(MoveType.Left))
                {
                    Debug.Log("left");
                    GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().AddForce(left_Ball_Force * ratio);
                }
                else if (move.moveType.HasFlag(MoveType.Right))
                {
                    GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().AddForce(right_Ball_Force * ratio);
                }
                if(ballcollision)
                {
                    AudioSource.PlayClipAtPoint(ballcollision,other.transform.position);
                }
            }
            if (other.gameObject.tag == "Player2")
            {
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().AddForce(left_Ball_Force * ratio);
                /*if (move2.moveType2.HasFlag(MoveType.Left))
                {
                    Debug.Log("left");
                    GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().AddForce(right_Ball_Force * ratio);
                }
                else if (move2.moveType2.HasFlag(MoveType.Right))
                {
                    GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().AddForce(left_Ball_Force * ratio); 
                }*/
                if (ballcollision)
                {
                    AudioSource.PlayClipAtPoint(ballcollision, other.transform.position);
                }
            }
            if (other.gameObject.tag == "leftground")
            {
                //gameObject.transform.position = GameObject.Find("right_target_point").transform.position;
                //GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GameObject.Find("Beachball(Clone)").transform.position = GameObject.Find("right_target_point").transform.position;
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                scoreRight++;
                //CmdScoreRight();
                rightRpcScore(scoreRight);
                //right.text = scoreRight.ToString();
            }
            if (other.gameObject.tag == "rightground")
            {
                //move = new Vector3(move.x, move.y, move.z +0.1f );
                //gameObject.transform.position = GameObject.Find("left_target_point").transform.position;
                //GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                GameObject.Find("Beachball(Clone)").transform.position = GameObject.Find("left_target_point").transform.position;
                GameObject.Find("Beachball(Clone)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                scoreLeft++;
                //CmdScoreLeft();
                leftRpcScore(scoreLeft);
                //left.text = scoreLeft.ToString();
            }

        }
    }
}