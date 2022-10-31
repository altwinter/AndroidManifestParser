#!/bin/bash
url1=https://android.googlesource.com/platform/frameworks/base/+/refs/heads/master/core/res/res/values/public-final.xml
url2=https://android.googlesource.com/platform/frameworks/base/+/refs/heads/master/core/res/res/values/attrs.xml
url3=https://android.googlesource.com/platform/frameworks/base/+/refs/heads/master/core/res/res/values/attrs_manifest.xml
curl "$url1?format=TEXT"| base64 --decode > public-final.xml
curl "$url2?format=TEXT"| base64 --decode > attrs.xml
curl "$url3?format=TEXT"| base64 --decode > attrs-manifest.xml