# GenRhubarb
A wav to mp4 lip sync converter gui tool for rhubarb and ffmpeg Windows

by Arda Erdikmen (c)2023
 

#### This work is licensed under a Creative Commons Attribution-NonCommercial 4.0 International License.

## Installation:
1. download the binary release from releases (see right hand side of this window). unpack archive to any directory that you have full access
2. Place rhubarb.exe (and any other dependencies, if available) in the same directory as GenRhubarb.exe. https://github.com/DanielSWolf/rhubarb-lip-sync
3. Place ffmpeg.exe binary and other dependencies in ffmpeg/ folder. genRhubarb looks for "ffmpeg/ffmpeg.exe" relative to itself.  https://github.com/GyanD/codexffmpeg/releases/

![Image](https://github.com/ref-xx/GenRhubarb/blob/master/ReadmeFolderStructure.jpg)

Hope it works. that's it. 

## Usage
1. Run the GenRhubarb
2. put 9 mouth shape png images A through X, in a folder, click "pick image folder" and pick the first image, generally "something_A.png". see example LISA image folder. https://github.com/DanielSWolf/rhubarb-lip-sync/tree/master/img
3. put your wav file at the same folder as GenRhubarb.exe and click "pick wav" select your audio file.
4. set resolution.
5. click "start encoding",  you will see some text output in the status bar, give some time, those are intensive conversions, after a while conversions will finish and you will see the mp4 file in the same folder.

![Image](https://github.com/ref-xx/GenRhubarb/blob/master/ReadmeScreeenshot.jpg)
    
