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
