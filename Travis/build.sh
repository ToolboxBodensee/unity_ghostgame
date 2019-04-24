#! /bin/sh

# Example build script for Unity3D project. See the entire example: https://github.com/JonathanPorta/ci-build

# Change this the name of your project. This will be the name of the final executables as well.
project="Travis-Unity"
# DATE=`date +%y.%m.%d`
# versionName="a.${DATE}"


echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
 -batchmode \
 -nographics \
 -silent-crashes \
 -logFile \
 -projectPath $(pwd)/ \
 -executeMethod BuildScript.Windows \
 -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
 -batchmode \
 -nographics \
 -silent-crashes \
 -logFile \
 -projectPath $(pwd)/ \
 -executeMethod BuildScript.OSX \
 -quit

echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
 -batchmode \
 -nographics \
 -silent-crashes \
 -logFile \
 -projectPath $(pwd)/ \
 -executeMethod BuildScript.Linux \
 -quit

echo "Attempting to build $project for WebGL"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
 -batchmode \
 -nographics \
 -silent-crashes \
 -logFile \
 -projectPath $(pwd)/ \
 -quit \
 -executeMethod BuildScript.WebGL

# export ANDROID_SDK_ROOT="/usr/local/share/android-sdk"
# export ANDROID_NDK_HOME="/usr/local/share/android-ndk"
# export JAVA_HOME=$(/usr/libexec/java_home)

# echo "Attempting to build $project for Android"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
#   -batchmode \
#   -nographics \
#   -silent-crashes \
#   -logFile \
#   -projectPath $(pwd)/ \
#   -quit \
#   -executeMethod BuildScript.Android

# echo "Attempting to build $project for iOS"
# /Applications/Unity/Unity.app/Contents/MacOS/Unity \
#   -batchmode \
#   -nographics \
#   -silent-crashes \
#   -logFile \
#   -projectPath $(pwd)/ \
#   -quit \
#   -executeMethod BuildScript.iOS

echo 'Attempting to zip builds'
cd $(pwd)/Build
tar -czvf linux.tar.gz linux/
hdiutil create osx.dmg -srcfolder osx/ -ov
zip -r windows.zip windows/
# zip -r ios.zip ios/
