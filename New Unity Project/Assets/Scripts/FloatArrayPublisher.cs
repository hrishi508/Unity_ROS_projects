using UnityEngine;


namespace RosSharp.RosBridgeClient
{
    public  class FloatArrayPublisher :Publisher<Messages.Float32MultiArray>
    {
        public  float[] messageData;

        private Messages.Float32MultiArray message;

        protected  override  void Start()
        {
            base .Start();
            InitializeMessage();
        }

        private  void InitializeMessage()
        {
            message = new Messages.Float32MultiArray
            {
                data = messageData
            };
        }

        private  void Update()
        {
            message.data = messageData;
            Publish(message);
        }
    }
}
