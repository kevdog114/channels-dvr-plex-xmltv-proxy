# Channels DVR XMLTV Proxy for Plex

## Overview
Channels DVR Server can be set up to connect to various TV Everywhere sources
using your regular streaming account credentials. Those TV Everywhere channels
can then be exposed as an M3U stream.

If you are a Plex user, you can use Channels DVR as its TV Guide source by using
xTeve. Channels DVR also exposes the TV Guide information via a JSON and XMLTV
endpoint. However, Plex does not interpret the "<new />" tags to identify which
episodes are new, which causes an inaccurate TV Guide in Plex.

## Purpose of this project
This docker image handles some of the format differences between how Channels
DVR generates its XMLTV file and Plex expects. Namely, it fixes the issue of
Plex seeing nearly all episodes as "New" when they are not new episodes.

## Sample data
Channels DVR endpoints:
```
  http://ip:8089/devices/ANY/channels.m3u
  http://ip:8089/devices/ANY/guide
  http://ip:8089/devices/ANY/guide/xmltv
  http://ip:8089/devices/ANY/guide/xmltv?duration=86000
```

## Using
This can be run as a docker image:
```
  docker run -d -p 8080:80 \
    -e "XMLTV_SOURCE=http://ip:8089/devices/ANY/guide/xmltv?duration=1209600" \
    -e "M3U_SOURCE=http://ip:8089/devices/ANY/channels.m3u" \
    channels-dvr-plex-xmltv-proxy
```

You can then use these endpoints for your XMLTV and M3U, to be imported into Plex and xTeve:
```
  http://ip-of-this-docker:8080/api/m3u
  http://ip-of-this-docker:8080/api/xmltv
```
