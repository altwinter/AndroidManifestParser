# Android Manifest Parser

## Overview
A C# parser of AndroidManifest.xml binaries with an output in XML or Json

The Json output contain some implicit datas like export etc. that can be found in the Manifest

## Exemple

To Xml
```C#
var pathManifest = @"resource/AndroidManifest.xml";
var result = AndroidParser.Manifest(pathManifest);
```

To Json
```C#
var pathManifest = @"resource/AndroidManifest.xml";
var result = AndroidParser.ManifestToJson(pathManifest);
```


To Xml with resources
```C#
var pathManifest = @"resource/AndroidManifest.xml";
var pathApk = @"resource/Application.apk");
var result = AndroidParser.Manifest(pathManifest, pathApk);
```

To Json with resources
```C#
var pathManifest = @"resource/AndroidManifest.xml";
var pathApk = @"resource/Application.apk");
var result = AndroidParser.ManifestToJson(pathManifest, pathApk);
```


## Third party
[androidxmldotnet](https://github.com/quamotion/androidxmldotnet) for Android manifest binary parsing [LICENSE](lib/AndroidXml/LICENSE.txt)

[aapt2](https://developer.android.com/studio/command-line/aapt2) for getting Arsc resources datas [REPOSITORY](https://android.googlesource.com/platform/frameworks/base/+/master/tools/aapt2)


## Result

You can compare the result of the decompilation beetween Apktool and our parser on the [instagram](test/resource/Instagram_v230.0.0.20.108_apkpure.com.apk) [Manifest](test/resource/AndroidManifest-instagram-bin.xml)

[Apktool](https://ibotpeaches.github.io/Apktool/) is a reverse engineering Android apk file tool (written in Java), that can decompile AndroidManifest.xml

### Apktool

[AndroidManifest.xml](test/result/AndroidManifest-apktool.xml)

### Ours
[AndroidManifest without resources](test/result/AndroidManifest-withoutResources.xml)

[AndroidManifest with resources](test/result/AndroidManifest-withResources.xml)

## Developpement
Developed on Linux