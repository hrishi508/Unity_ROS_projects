using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class FloatArrayPublisherLidar : Publisher<Messages.Float32MultiArray>
    {
        //public float[] messageData;

        private Messages.Float32MultiArray message;

        protected override void Start()
        {
            base .Start();
            //messageData = new float[lidar1.size];
            //messageData = lidar1.distances;
            InitializeMessage();
        }

        private void InitializeMessage()
        {
            message = new Messages.Float32MultiArray
            {
                data = lidar.distances
            };
        }

        private void Update()
        {
            message.data = lidar.distances;
            Publish(message);
        }
    }
}
