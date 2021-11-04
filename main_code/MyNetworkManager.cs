using UnityEngine;
using Mirror;
using UnityEngine.UI;
namespace source
{
    // Custom NetworkManager that simply assigns the correct racket positions when
    // spawning players. The built in RoundRobin spawn method wouldn't work after
    // someone reconnects (both players would be on the same side).

    [AddComponentMenu("")]
    public class MyNetworkManager : NetworkManager
    {
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;
        public Transform ballRacketSpawn;
        //public GameObject playerPrefab1;
        //public GameObject playerPrefab2;
        //public GameObject[] playerArr;
        static public GameObject ball;
        Transform ballstart;
        Transform start;
        GameObject player;
        static protected int i = 0;
        //static public GameObject ball;
        //int numPlayers = 0;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            
            //Transform start;
            if (numPlayers == 1)
            {
                //GameObject.Find("PLAYER").GetComponent<Text>().text = "0";
                //GameObject.Find("PLAYER2").GetComponent<Text>().text = "0";
                
                start = rightRacketSpawn;
                player = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "player2"), start.position, start.rotation);

            }
            else if (numPlayers == 0)
            {
                //GameObject.Find("PLAYER").GetComponent<Text>().text = "0";
                //GameObject.Find("PLAYER2").GetComponent<Text>().text = "0";
                
                start = leftRacketSpawn;
                player = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "player1"), start.position, start.rotation);

            }

            NetworkServer.AddPlayerForConnection(conn, player);
            // add player at correct spawn position
            //Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
            //Vector3 rot = start.rotation.eulerAngles;
            //rot = new Vector3(rot.x, rot.y + 180, rot.z );
            //GameObject player = Instantiate(playerPrefab, start.position, Quaternion.Euler(rot));


            Debug.Log("connect");
            /*if (i == 1)
            {
                //GameObject.Find("PLAYER").GetComponent<Text>().text = "0";
                //GameObject.Find("PLAYER2").GetComponent<Text>().text = "0";
                Transform start = rightRacketSpawn;
                GameObject player2 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "player2"), start.position, start.rotation);
                NetworkServer.AddPlayerForConnection(conn, player2);
                
            }
            i++;*/
            if (numPlayers == 2)
            {
                ballstart = ballRacketSpawn;
                ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Beachball"), ballstart.position, ballstart.rotation);
                NetworkServer.Spawn(ball);
                Debug.Log("2plaer");
            }
          

            /*ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Beachball"));
            move.rdd = ball.GetComponent<Rigidbody>();
            spawn ball if two players
            if (numPlayers == 2)
            {
                
                NetworkServer.Spawn(ball);
                
                //move_ball.rrd = ball.GetComponent<Rigidbody>();
                Debug.Log("2plaer");
            }*/
            //numPlayers++;
        }

        /*public override void OnServerDisconnect(NetworkConnection conn)
        {
            // destroy ball
            if (ball != null)
                NetworkServer.Destroy(ball);

            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }*/
    }

}