﻿using System;
using DlibDotNet;
using DlibDotNet.Extensions;
using Dlib = DlibDotNet.Dlib;

namespace NetDetectFace
{
    class Program{
        private const string inputFilePath = "./TestImage/Michael-Jordan-Team-USA.png";

        static void Main(string[] args)
        {
            // set up Dlib facedetector
            using (var fd = Dlib.GetFrontalFaceDetector())
            {
                var img = Dlib.LoadImage<RgbPixel>(inputFilePath);

// find all faces in the image
                var faces = fd.Operator(img);
                foreach (var face in faces)
                {
                    // draw a rectangle for each face
                    Dlib.DrawRectangle(img, face, color: new RgbPixel(0, 255, 255), thickness: 4);
                    Dlib.SaveJpeg(img, "output.jpg");
                }
            }
        }
    }
    
}
