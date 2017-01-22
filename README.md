# JustaCam
Just a Camera App to spice up your everyday life

Completed this hack at UofT Hacks IV Jan 20-22 2017
By Thomas, Pratt, and Jacob

## Summary, Goals, and Future
The goal of our hack was to bring augmented reality to the everyday user. 60 hours worth of content is uploaded to YouTube every minute. Notyoutube every one of those creators is apt at editing, or could afford to hire an editor for special effects. Thats where JustACam comes in. Every wanted to support your favourite sports team, but have no jersey, we can take coordinates associated with your body and map a graphic on top of them.

We complete this through Caffee, an open source deep-learning framework developed by UC Berkley, and Unity 3d. We take a video file and run it through Caffee to get JSON files of all the coordinates. Then in Unity 3d we use c# to parse the files, map the coordinates, and place graphics on top.

In the future we'd love to take this to a mobile application along with setting up a server on AWS to complete the Caffee processing, and Unity mapping to send videos fairly quickly back to the phone.

## Setup and How to get Started
1. Download Caffee [here](://github.com/CMU-Perceptual-Computing-Lab/caffe_rtpose)
2. Download Unity3d [here](://unity3d.com)
3. Select a video with you or anyone else and upload it to Caffee to get JSON coordinates
'''
..*./build/examples/rtpose/rtpose.bin --video video_file.mp4
'''
4. Take these coordinates, save them to a directory and remember where you saved them
...* dont forget to change the curFile to where you saved your JSON files
