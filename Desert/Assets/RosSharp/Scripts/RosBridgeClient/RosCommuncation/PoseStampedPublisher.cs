/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

/*using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class PoseStampedPublisher : Publisher<Messages.Geometry.Pose>
    {
        public Transform PublishedTransform;
        //public string FrameId = "Unity";

        private Messages.Geometry.Pose message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            message = new Messages.Geometry.Pose
            {
               /* header = new Messages.Header()
                {
                    frame_id = FrameId
                }*/
            /*};
        }

        /*private void UpdateMessage()
        {
            //message.header.Update();
            message.position = GetGeometryPoint(PublishedTransform.position.Unity2Ros());
            message.orientation = GetGeometryQuaternion(PublishedTransform.rotation.Unity2Ros());

            Publish(message);
        }

        private Messages.Geometry.Point GetGeometryPoint(Vector3 position)
        {
            Messages.Geometry.Point geometryPoint = new Messages.Geometry.Point();
            /*geometryPoint.x = position.x;
            geometryPoint.y = position.y;
            geometryPoint.z = position.z;*/
            /*geometryPoint.x = PublishedTransform.position.x;
            geometryPoint.y = PublishedTransform.position.y;
            geometryPoint.z = PublishedTransform.position.z;
            return geometryPoint;
        }

        private Messages.Geometry.Quaternion GetGeometryQuaternion(Quaternion quaternion)
        {
            Messages.Geometry.Quaternion geometryQuaternion = new Messages.Geometry.Quaternion();
            /*geometryQuaternion.x = quaternion.x;
            geometryQuaternion.y = quaternion.y;
            geometryQuaternion.z = quaternion.z;
            geometryQuaternion.w = quaternion.w;*/
           /* geometryQuaternion.x = 0;
            geometryQuaternion.y = updown.pass;
            geometryQuaternion.z = 0;
            geometryQuaternion.w = 0;
            return geometryQuaternion;
        }

    }
} */
