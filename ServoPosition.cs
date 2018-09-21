using System;
using System.Windows;
using Microsoft.Kinect;
using System.Windows.Media.Media3D;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    class ServoPosition
    {
        public Double ZRotation(Joint A, Joint Origin, Joint C)
        {  
            Vector a = new Vector(A.Position.X - Origin.Position.X, A.Position.Y - Origin.Position.Y);
            Vector c = new Vector(C.Position.X - Origin.Position.X, C.Position.Y - Origin.Position.Y);
            return Vector.AngleBetween(a, c);
        }

        public Double YRotation(Joint A, Joint Origin, Joint C)
        {
            Vector3D a = new Vector3D(A.Position.X - Origin.Position.X,
                                      A.Position.Y - Origin.Position.Y,
                                      A.Position.Z - Origin.Position.Z);
            Vector3D c = a;
            c.X = 0;
            return Vector3D.AngleBetween(a, c);
        }

        public Double XRotation(Joint A, Joint Origin, Joint C)
        {
            Vector a = new Vector(A.Position.Y - Origin.Position.Y, A.Position.Z - Origin.Position.Z);
            Vector c = new Vector(C.Position.Y - Origin.Position.Y, C.Position.Z - Origin.Position.Z);
            return Vector.AngleBetween(a, c);
        }

        public Double Angle3D(Joint A, Joint Origin, Joint C)
        {
            Vector3D a = new Vector3D(A.Position.X - Origin.Position.X,
                                      A.Position.Y - Origin.Position.Y,
                                      A.Position.Z - Origin.Position.Z);
            Vector3D c = new Vector3D(C.Position.X - Origin.Position.X,
                                      C.Position.Y - Origin.Position.Y,
                                      C.Position.Z - Origin.Position.Z);
            return Vector3D.AngleBetween(a, c);
        }
    }
}